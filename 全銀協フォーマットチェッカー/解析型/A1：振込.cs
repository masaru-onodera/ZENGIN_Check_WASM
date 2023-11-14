using System;
using System.Collections.Generic;
using System.Linq;

namespace 全銀協フォーマット
{
    partial class 解析_11 : 解析_A1 { public 解析_11() : base("11", "会社", "振込指定日", "企業等", new[] { "1", "2" }, "預金者名", "社員番号、所属コード", false) { } }
    partial class 解析_12 : 解析_A1 { public 解析_12() : base("12", "会社", "振込指定日", "企業等", new[] { "1", "2" }, "預金者名", "社員番号、所属コード", false) { } }
    partial class 解析_71 : 解析_A1 { public 解析_71() : base("71", "会社", "振込指定日", "企業等", new[] { "1", "2" }, "預金者名", "社員番号、所属コード", false) { } }
    partial class 解析_72 : 解析_A1 { public 解析_72() : base("72", "会社", "振込指定日", "企業等", new[] { "1", "2" }, "預金者名", "社員番号、所属コード", false) { } }
    partial class 解析_21 : 解析_A1 { public 解析_21() : base("21", "振込依頼人", "取組日", "企業等", new[] { "1", "2", "4", "9" }, "受取人名", "顧客コード", true) { } }
    partial class 解析_A1(
        string 種別コード_コード,
        string 委託者_呼称,
        string 振込日_呼称,
        string 依頼者_呼称,
        string[] 預金種目_コード,
        string 振込先名_呼称,
        string 利用者識別領域,
        bool 振込指定区分とEDI情報
        ) : 解析型
    {
        public レコード ヘッダー(List<char> Char配列, int レコード番号)
        {
            レコード レコード = new(レコード番号);

            レコード["データ区分"] = new string(Char配列.GetRange(0, 1).ToArray());
            //1：ヘッダー・レコード
            //データセット解析時にチェックしているので省略

            レコード["種別コード"] = new string(Char配列.GetRange(1, 2).ToArray());
            //変数：種別コード
            if (種別コード_コード != レコード["種別コード"]) { throw new Exception("種別コード(文字列[1-2])：1レコード目の種別コード(" + 種別コード_コード + ")とは異なります。"); }

            レコード["コード区分"] = new string(Char配列.GetRange(3, 1).ToArray());
            //0：JIS
            if ("0" != レコード["コード区分"]
            //1：EBCDIC
             && "1" != レコード["コード区分"]) { throw new Exception("コード区分(文字列[3])：1レコード目のコード区分とは異なります。"); }

            レコード[委託者_呼称 + "コード"] = new string(Char配列.GetRange(4, 10).ToArray());
            //右詰め残り前「0」
            try { 文字種別.数字.チェック(レコード[委託者_呼称 + "コード"]); } catch (Exception e) { throw new Exception(委託者_呼称 + "コード(文字列[4-13])：" + e.Message); }

            レコード[委託者_呼称 + "名"] = new string(Char配列.GetRange(14, 40).ToArray());
            if (' ' == レコード[委託者_呼称 + "名"][0]) { try { 文字種別.スペース.チェック(レコード[委託者_呼称 + "名"]); } catch { throw new Exception(委託者_呼称 + "名(文字列[14-53])：左詰めされていません。"); } }
            try { 文字種別.口座名等ヲあり.チェック(レコード[委託者_呼称 + "名"]); } catch (Exception e) { throw new Exception(委託者_呼称 + "名(文字列[14-53])：" + e.Message); }

            レコード[振込日_呼称] = new string(Char配列.GetRange(54, 4).ToArray());
            //MMDD(月-日)
            try
            {
                文字種別.数字.チェック(レコード[振込日_呼称]);

                DateTime Date = new(DateTime.Now.Year, int.Parse(レコード[振込日_呼称].Substring(0, 2)), int.Parse(レコード[振込日_呼称].Substring(2, 2)));
                if (("0229" != レコード[振込日_呼称]) &&
                    (int.Parse(レコード[振込日_呼称].Substring(0, 2)) != Date.Month
                  || int.Parse(レコード[振込日_呼称].Substring(2, 2)) != Date.Day)) { throw new Exception("不正な日付です。\"" + レコード[振込日_呼称] + "\""); }
            }
            catch (Exception e) { throw new Exception(振込日_呼称 + "(文字列[54-57])：" + e.Message); }

            レコード["仕向銀行番号"] = new string(Char配列.GetRange(58, 4).ToArray());
            //統一金融機関番号
            try { 文字種別.数字.チェック(レコード["仕向銀行番号"]); } catch (Exception e) { throw new Exception("仕向銀行番号(文字列[58-61])：" + e.Message); }

            レコード["仕向銀行名"] = new string(Char配列.GetRange(62, 15).ToArray());
            //※省略可
            //左詰め残りスペース
            if (' ' == レコード["仕向銀行名"][0]) { try { 文字種別.スペース.チェック(レコード["仕向銀行名"]); } catch { throw new Exception("仕向銀行名(文字列[62-76])：左詰めされていません。"); } }
            try { 文字種別.店舗名ヲあり.チェック(レコード["仕向銀行名"]); } catch (Exception e) { throw new Exception("仕向銀行名(文字列[62-76])：" + e.Message); }

            レコード["仕向支店番号"] = new string(Char配列.GetRange(77, 3).ToArray());
            //統一店番号
            try { 文字種別.数字.チェック(レコード["仕向支店番号"]); } catch (Exception e) { throw new Exception("仕向支店番号(文字列[77-79])：" + e.Message); }

            レコード["仕向支店名"] = new string(Char配列.GetRange(80, 15).ToArray());
            //※省略可
            //左詰め残りスペース
            if (' ' == レコード["仕向支店名"][0]) { try { 文字種別.スペース.チェック(レコード["仕向支店名"]); } catch { throw new Exception("仕向支店名(文字列[80-94])：左詰めされていません。"); } }
            try { 文字種別.店舗名ヲあり.チェック(レコード["仕向支店名"]); } catch (Exception e) { throw new Exception("仕向支店名(文字列[80-94])：" + e.Message); }

            レコード["預金種目(" + 依頼者_呼称 + ")"] = new string(Char配列.GetRange(95, 1).ToArray());
            //※省略可(スペース)
            if (" " != レコード["預金種目(" + 依頼者_呼称 + ")"]
            //1:普通預金
             && "1" != レコード["預金種目(" + 依頼者_呼称 + ")"]
            //2:当座預金
             && "2" != レコード["預金種目(" + 依頼者_呼称 + ")"]
            //9:その他
             && "9" != レコード["預金種目(" + 依頼者_呼称 + ")"]) { throw new Exception(依頼者_呼称 + "預金種目(文字列[95])：指定可能な文字は[ｽﾍﾟｰｽ：省略][1：普通預金][2：当座預金][9：その他]です。"); }

            レコード["口座番号(" + 依頼者_呼称 + ")"] = new string(Char配列.GetRange(96, 7).ToArray());
            //※省略可(スペース)
            //右詰め残り前「0」
            try { 文字種別.数字.チェック(レコード["口座番号(" + 依頼者_呼称 + ")"]); } catch (Exception e) { try { 文字種別.スペース.チェック(レコード["口座番号(" + 依頼者_呼称 + ")"]); } catch { throw new Exception(依頼者_呼称 + "口座番号(文字列[96-102])：" + e.Message); } }

            レコード["ダミー"] = new string(Char配列.GetRange(103, 17).ToArray());
            try { 文字種別.スペース.チェック(レコード["ダミー"]); } catch (Exception e) { throw new Exception("ダミー(文字列[103-119])：" + e.Message); }

            return レコード;
        }
        public レコード データ(List<char> Char配列, int レコード番号)
        {
            レコード レコード = new(レコード番号);

            レコード["デー夕区分"] = new string(Char配列.GetRange(0, 1).ToArray());
            //2：データ・レコード
            //データセット解析時にチェックしているので省略

            レコード["被仕向銀行番号"] = new string(Char配列.GetRange(1, 4).ToArray());
            //統一金融機関番号
            try { 文字種別.数字.チェック(レコード["被仕向銀行番号"]); } catch (Exception e) { throw new Exception("被仕向銀行番号(文字列[1-4])：" + e.Message); }

            レコード["被仕向銀行名"] = new string(Char配列.GetRange(5, 15).ToArray());
            //※省略可
            //左詰め残りスペース
            if (' ' == レコード["被仕向銀行名"][0]) { try { 文字種別.スペース.チェック(レコード["被仕向銀行名"]); } catch { throw new Exception("被仕向銀行名(文字列[5-19])：左詰めされていません。"); } }
            try { 文字種別.店舗名ヲあり.チェック(レコード["被仕向銀行名"]); } catch (Exception e) { throw new Exception("被仕向銀行名(文字列[5-19])：" + e.Message); }

            レコード["被仕向支店番号"] = new string(Char配列.GetRange(20, 3).ToArray());
            //統一店番号
            try { 文字種別.数字.チェック(レコード["被仕向支店番号"]); } catch (Exception e) { throw new Exception("被仕向支店番号(文字列[20-22])：" + e.Message); }

            レコード["被仕向支店名"] = new string(Char配列.GetRange(23, 15).ToArray());
            //※省略可
            //左詰め残りスペース
            if (' ' == レコード["被仕向支店名"][0]) { try { 文字種別.スペース.チェック(レコード["被仕向支店名"]); } catch { throw new Exception("被仕向支店名(文字列[23-37])：左詰めされていません。"); } }
            try { 文字種別.店舗名ヲあり.チェック(レコード["被仕向支店名"]); } catch (Exception e) { throw new Exception("被仕向支店名(文字列[23-37])：" + e.Message); }

            レコード["手形交換所番号"] = new string(Char配列.GetRange(38, 4).ToArray());
            //※省略可
            try { 文字種別.数字.チェック(レコード["手形交換所番号"]); } catch (Exception e) { try { 文字種別.スペース.チェック(レコード["手形交換所番号"]); } catch { throw new Exception("手形交換所番号(文字列[38-41])：" + e.Message); } }

            レコード["預金種目"] = new string(Char配列.GetRange(42, 1).ToArray());
            if (預金種目_コード.All(code => code != レコード["預金種目"]))
            {
                string message = "預金種目(文字列[42])：指定可能な数字は";
                foreach (var code in 預金種目_コード)
                {
                    message += code switch
                    {
                        "1" => "[1：普通預金]",
                        "2" => "[2：当座預金]",
                        "4" => "[4：貯蓄預金]",
                        "9" => "[9：その他]",
                        _ => "[" + code + "]",
                    };
                }
                message += "です。";
                throw new Exception(message);
            }

            レコード["口座番号"] = new string(Char配列.GetRange(43, 7).ToArray());
            //右詰め残り前「0」
            try { 文字種別.数字.チェック(レコード["口座番号"]); } catch (Exception e) { throw new Exception("口座番号(文字列[43-49])：" + e.Message); }

            レコード[振込先名_呼称] = new string(Char配列.GetRange(50, 30).ToArray());
            //左詰め残りスペース(付録2参照)
            try { 文字種別.口座名等ヲあり.チェック(レコード[振込先名_呼称]); } catch (Exception e) { throw new Exception(振込先名_呼称 + "(文字列[50-79])：" + e.Message); }

            レコード["振込金額"] = new string(Char配列.GetRange(80, 10).ToArray());
            //右詰め残り前「0」
            try { 文字種別.数字.チェック(レコード["振込金額"]); } catch (Exception e) { throw new Exception("振込金額(文字列[80-89])：" + e.Message); }

            レコード["新規コード"] = new string(Char配列.GetRange(90, 1).ToArray());
            //1:第1回振込分
            if ("1" != レコード["新規コード"]
            //2:変更分(被仕向銀行・支店、預金種目・口座番号)
             && "2" != レコード["新規コード"]
            //0:その他
             && "0" != レコード["新規コード"]) { throw new Exception("新規コード(文字列[90])：指定可能な数字は[1：第1回振込分][2：変更分][0：その他]です。"); }

            //・項番15の識別表示欄に「Y」表示を付した場合には、本欄の内容は「依頼人から受取人に対して通知するEDI情報」を表わす。
            switch (Char配列.GetRange(112, 1)[0])
            {
                case 'Y' when 振込指定区分とEDI情報:
                    レコード["EDI情報"] = new string(Char配列.GetRange(91, 20).ToArray());
                    //左詰め残りスペース
                    try { 文字種別.EDI情報.チェック(レコード["EDI情報"]); } catch (Exception e) { throw new Exception("EDI情報(文字列[91-110])：" + e.Message); }
                    break;
                case ' ':
                default:
                    レコード[利用者識別領域] = new string(Char配列.GetRange(91, 20).ToArray());
                    //※依頼人が定めた受取人識別のための顧客コードを表わす。
                    //右詰め残り前「0」
                    //（注）顧客番号以外のものを記載しない。
                    try { 文字種別.数字.チェック(レコード[利用者識別領域]); } catch (Exception e) { throw new Exception(利用者識別領域 + "(文字列[91-110])：" + e.Message); }
                    break;
            }
            if (振込指定区分とEDI情報)
            {
                レコード["振込指定区分"] = new string(Char配列.GetRange(111, 1).ToArray());
                //※省略可
                if (" " != レコード["振込指定区分"]
                 //7:テレ振込
                 && "7" != レコード["振込指定区分"]
                 //8:文書振込
                 && "8" != レコード["振込指定区分"]) { throw new Exception("振込指定区分(文字列[111])：指定可能な数字は[ｽﾍﾟｰｽ：省略][7：テレ振込][8：文書振込]です。"); }

                レコード["識別表示"] = new string(Char配列.GetRange(112, 1).ToArray());
                //※省略可
                if (" " != レコード["識別表示"]
                 //本欄に「Y」表示を付した場合は、項番12・13の項目内容は「EDI情報」を表わす。
                 && "Y" != レコード["識別表示"]) { throw new Exception("識別表示(文字列[112])：指定可能な数字は[ｽﾍﾟｰｽ：顧客コード][Y：EDI情報]です。"); }

                レコード["ダミー"] = new string(Char配列.GetRange(113, 7).ToArray());
                try { 文字種別.スペース.チェック(レコード["ダミー"]); } catch (Exception e) { throw new Exception("ダミー(文字列[113-119])：" + e.Message); }
            }
            else
            {
                レコード["ダミー"] = new string(Char配列.GetRange(111, 9).ToArray());
                try { 文字種別.スペース.チェック(レコード["ダミー"]); } catch (Exception e) { throw new Exception("ダミー(文字列[111-119])：" + e.Message); }
            }
            return レコード;
        }
        public レコード トレーラ(List<char> Char配列, int レコード番号)
        {
            レコード レコード = new(レコード番号);

            レコード["デー夕区分"] = new string(Char配列.GetRange(0, 1).ToArray());
            //8：トレーラ・レコード
            //データセット解析時にチェックしているので省略

            レコード["合計件数"] = new string(Char配列.GetRange(1, 6).ToArray());
            //右詰め残り前「0」
            try { 文字種別.数字.チェック(レコード["合計件数"]); } catch (Exception e) { throw new Exception("合計件数(文字列[1-6])：" + e.Message); }

            レコード["合計金額"] = new string(Char配列.GetRange(7, 12).ToArray());
            //右詰め残り前「0」
            try { 文字種別.数字.チェック(レコード["合計金額"]); } catch (Exception e) { throw new Exception("合計金額(文字列[7-18])：" + e.Message); }

            レコード["ダミー"] = new string(Char配列.GetRange(19, 101).ToArray());
            try { 文字種別.スペース.チェック(レコード["ダミー"]); } catch (Exception e) { throw new Exception("ダミー(文字列[19-119])：" + e.Message); }

            return レコード;
        }
        public レコード エンド(List<char> Char配列, int レコード番号)
        {
            レコード レコード = new(レコード番号);

            レコード["データ区分"] = new string(Char配列.GetRange(0, 1).ToArray());
            //9:エンド・レコード
            //データセット解析時にチェックしているので省略

            レコード["ダミー"] = new string(Char配列.GetRange(1, 119).ToArray());
            try { 文字種別.スペース.チェック(レコード["ダミー"]); } catch (Exception e) { throw new Exception("ダミー(文字列[1-119])：" + e.Message); }

            return レコード;
        }
        public void 論理チェック(データセット データセット)
        {
            //①
            //データ：件数と金額
            //トレーラ：合計件数と合計金額、と一致していること。
            if (データセット.データ配列.Count != int.Parse(データセット.トレーラ["合計件数"])) { throw new Exception("合計件数(文字列[1-6])：データ件数と一致しません。"); }
            if (データセット.データ配列.Sum(データ => decimal.Parse(データ["振込金額"])) != decimal.Parse(データセット.トレーラ["合計金額"])) { throw new Exception("合計金額(文字列[1-6])：データ[振込金額]の合計と一致しません。"); }
        }
        public void 論理チェック(List<データセット> データセット配列, レコード エンド) { }
    }
}