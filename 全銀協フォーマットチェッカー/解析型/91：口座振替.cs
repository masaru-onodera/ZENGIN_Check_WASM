using System;
using System.Collections.Generic;
using System.Linq;

namespace 全銀協フォーマット
{
    partial class 解析_91 : 解析型
    {
        public レコード ヘッダー(List<char> Char配列, int レコード番号)
        {
            レコード レコード = new(レコード番号);

            レコード["データ区分"] = new string(Char配列.GetRange(0, 1).ToArray());
            //1：ヘッダー・レコード
            //データセット解析時にチェックしているので省略

            レコード["種別コード"] = new string(Char配列.GetRange(1, 2).ToArray());
            //91：預金口座振替
            if ("91" != レコード["種別コード"]) { throw new Exception("種別コード(文字列[1-2])：1レコード目の種別コード(91)とは異なります。"); }

            レコード["コード区分"] = new string(Char配列.GetRange(3, 1).ToArray());
            //0：JIS
            if ("0" != レコード["コード区分"]
            //1：EBCDIC
             && "1" != レコード["コード区分"]) { throw new Exception("コード区分(文字列[3])：1レコード目のコード区分とは異なります。"); }

            レコード["委託者コード"] = new string(Char配列.GetRange(4, 10).ToArray());
            //右詰め残り前「0」
            try { 文字種別.数字.チェック(レコード["委託者コード"]); } catch (Exception e) { throw new Exception("委託者コード(文字列[4-13])：" + e.Message); }

            レコード["委託者名"] = new string(Char配列.GetRange(14, 40).ToArray());
            //左詰め残りスペース(付録2.参照)
            if (' ' == レコード["委託者名"][0]) { try { 文字種別.スペース.チェック(レコード["委託者名"]); } catch { throw new Exception("委託者名(文字列[14-53])：左詰めされていません。"); } }
            try { 文字種別.口座名等ヲあり.チェック(レコード["委託者名"]); } catch (Exception e) { throw new Exception("委託者名(文字列[14-53])：" + e.Message); }

            レコード["引落日"] = new string(Char配列.GetRange(54, 4).ToArray());
            //MMDD（月-日）
            try
            {
                文字種別.数字.チェック(レコード["引落日"]);

                DateTime Date = new(DateTime.Now.Year, int.Parse(レコード["引落日"].Substring(0, 2)), int.Parse(レコード["引落日"].Substring(2, 2)));
                if (("0229" != レコード["引落日"]) &&
                    (int.Parse(レコード["引落日"].Substring(0, 2)) != Date.Month
                  || int.Parse(レコード["引落日"].Substring(2, 2)) != Date.Day)) { throw new Exception("不正な日付です。\"" + レコード["引落日"] + "\""); }
            }
            catch (Exception e) { throw new Exception("引落日(文字列[54-57])：" + e.Message); }

            レコード["取引銀行番号"] = new string(Char配列.GetRange(58, 4).ToArray());
            //統一金融機関番号
            try { 文字種別.数字.チェック(レコード["取引銀行番号"]); } catch (Exception e) { throw new Exception("取引銀行番号(文字列[58-61])：" + e.Message); }

            レコード["取引銀行名"] = new string(Char配列.GetRange(62, 15).ToArray());
            //※省略可
            //左詰め残りスペース
            if (' ' == レコード["取引銀行名"][0]) { try { 文字種別.スペース.チェック(レコード["取引銀行名"]); } catch { throw new Exception("取引銀行名(文字列[62-76])：左詰めされていません。"); } }
            try { 文字種別.店舗名ヲあり.チェック(レコード["取引銀行名"]); } catch (Exception e) { throw new Exception("取引銀行名(文字列[62-76])：" + e.Message); }

            レコード["取引支店番号"] = new string(Char配列.GetRange(77, 3).ToArray());
            //統一店番号
            try { 文字種別.数字.チェック(レコード["取引支店番号"]); } catch (Exception e) { throw new Exception("取引支店番号(文字列[77-79])：" + e.Message); }

            レコード["取引支店名"] = new string(Char配列.GetRange(80, 15).ToArray());
            //※省略可
            //左詰め残りスペース
            if (' ' == レコード["取引支店名"][0]) { try { 文字種別.スペース.チェック(レコード["取引支店名"]); } catch { throw new Exception("取引支店名(文字列[80-94])：左詰めされていません。"); } }
            try { 文字種別.店舗名ヲあり.チェック(レコード["取引支店名"]); } catch (Exception e) { throw new Exception("取引支店名(文字列[80-94])：" + e.Message); }

            レコード["預金種目(委託者)"] = new string(Char配列.GetRange(95, 1).ToArray());
            //1：普通預金
            if ("1" != レコード["預金種目(委託者)"]
            //2：当座預金
             && "2" != レコード["預金種目(委託者)"]
            //9：その他
             && "9" != レコード["預金種目(委託者)"]) { throw new Exception("委託者預金種目(文字列[95])：指定可能な数字は[1：普通預金][2：当座預金][9：その他]です。"); }

            レコード["口座番号(委託者)"] = new string(Char配列.GetRange(96, 7).ToArray());
            //右詰め残り前「0」
            try { 文字種別.数字.チェック(レコード["口座番号(委託者)"]); } catch (Exception e) { throw new Exception("委託者口座番号(文字列[96-102])：" + e.Message); }

            レコード["ダミー"] = new string(Char配列.GetRange(103, 17).ToArray());
            try { 文字種別.スペース.チェック(レコード["ダミー"]); } catch (Exception e) { throw new Exception("ダミー(文字列[103-119])：" + e.Message); }

            return レコード;
        }
        public レコード データ(List<char> Char配列, int レコード番号)
        {
            レコード レコード = new(レコード番号);

            レコード["データ区分"] = new string(Char配列.GetRange(0, 1).ToArray());
            //2：データ・レコード
            //データセット解析時にチェックしているので省略

            レコード["引落銀行番号"] = new string(Char配列.GetRange(1, 4).ToArray());
            //統一金融機関番号
            try { 文字種別.数字.チェック(レコード["引落銀行番号"]); } catch (Exception e) { throw new Exception("引落銀行番号(文字列[1-4])：" + e.Message); }

            レコード["引落銀行名"] = new string(Char配列.GetRange(5, 15).ToArray());
            //※省略可
            //左詰め残りスペース
            if (' ' == レコード["引落銀行名"][0]) { try { 文字種別.スペース.チェック(レコード["引落銀行名"]); } catch { throw new Exception("引落銀行名(文字列[5-19])：左詰めされていません。"); } }
            try { 文字種別.店舗名ヲあり.チェック(レコード["引落銀行名"]); } catch (Exception e) { throw new Exception("引落銀行名(文字列[5-19])：" + e.Message); }

            レコード["引落支店番号"] = new string(Char配列.GetRange(20, 3).ToArray());
            //統一店番号
            try { 文字種別.数字.チェック(レコード["引落支店番号"]); } catch (Exception e) { throw new Exception("引落支店番号(文字列[20-22])：" + e.Message); }

            レコード["引落支店名"] = new string(Char配列.GetRange(23, 15).ToArray());
            //※省略可
            //左詰め残りスペース
            if (' ' == レコード["引落支店名"][0]) { try { 文字種別.スペース.チェック(レコード["引落支店名"]); } catch { throw new Exception("引落支店名(文字列[23-37])：左詰めされていません。"); } }
            try { 文字種別.店舗名ヲあり.チェック(レコード["引落支店名"]); } catch (Exception e) { throw new Exception("引落支店名(文字列[23-37])：" + e.Message); }

            レコード["ダミー１"] = new string(Char配列.GetRange(38, 4).ToArray());
            try { 文字種別.スペース.チェック(レコード["ダミー１"]); } catch (Exception e) { throw new Exception("ダミー１(文字列[38-41])：" + e.Message); }

            レコード["預金種目"] = new string(Char配列.GetRange(42, 1).ToArray());
            //1：普通預金
            if ("1" != レコード["預金種目"]
            //2：当座預金
             && "2" != レコード["預金種目"]
            //3：納税準備預金
             && "3" != レコード["預金種目"]
            //9：その他
             && "9" != レコード["預金種目"]) { throw new Exception("預金種目(文字列[42])：指定可能な数字は[1：普通預金][2：当座預金][3：納税準備預金][9：その他]です。"); }

            レコード["口座番号"] = new string(Char配列.GetRange(43, 7).ToArray());
            //右詰め残り前「0」
            try { 文字種別.数字.チェック(レコード["口座番号"]); } catch (Exception e) { throw new Exception("口座番号(文字列[43-49])：" + e.Message); }

            レコード["預金者名"] = new string(Char配列.GetRange(50, 30).ToArray());
            //左詰め残りスペース(付録2参照)
            try { 文字種別.口座名等ヲあり.チェック(レコード["預金者名"]); } catch (Exception e) { throw new Exception("預金者名(文字列[50-79])：" + e.Message); }

            レコード["引落金額"] = new string(Char配列.GetRange(80, 10).ToArray());
            //右詰め残り前「0」
            try { 文字種別.数字.チェック(レコード["引落金額"]); } catch (Exception e) { throw new Exception("引落金額(文字列[80-89])：" + e.Message); }

            レコード["新規コード"] = new string(Char配列.GetRange(90, 1).ToArray());
            //1：第1回引落分
            if ("1" != レコード["新規コード"]
            //2：変更分(引落銀行・支店、口座番号)
             && "2" != レコード["新規コード"]
            //0：その他
             && "0" != レコード["新規コード"]) { throw new Exception("新規コード(文字列[90])：指定可能な数字は[1：第1回引落分][2：変更分][0：その他]です。"); }

            レコード["顧客番号"] = new string(Char配列.GetRange(91, 20).ToArray());
            //右詰め残り前「0」
            //（注）顧客番号以外のものを記載しない。
            try { 文字種別.数字.チェック(レコード["顧客番号"]); } catch (Exception e) { throw new Exception("顧客番号(文字列[91-110])：" + e.Message); }

            レコード["振替結果コード"] = new string(Char配列.GetRange(111, 1).ToArray());
            //依頼明細では「0」とする。
            //0：振替済
            if ("0" != レコード["振替結果コード"]
            //1：資金不足
             && "1" != レコード["振替結果コード"]
            //2：取引なし
             && "2" != レコード["振替結果コード"]
            //3：預金者の都合による振替停止
             && "3" != レコード["振替結果コード"]
            //4：預金口座振替依頼書なし
             && "4" != レコード["振替結果コード"]
            //8：委託者の都合による振替停止
             && "8" != レコード["振替結果コード"]
            //9：その他
             && "9" != レコード["振替結果コード"]) { throw new Exception("振替結果コード(文字列[111])：指定可能な数字は[0：依頼/振替済][1：資金不足][2：取引なし][3：預金者の都合による振替停止][4：預金口座振替依頼書なし][8：委託者の都合による振替停止][9：その他]です。"); }

            レコード["ダミー２"] = new string(Char配列.GetRange(112, 8).ToArray());
            try { 文字種別.スペース.チェック(レコード["ダミー２"]); } catch (Exception e) { throw new Exception("ダミー２(文字列[112-119])：" + e.Message); }

            return レコード;
        }
        public レコード トレーラ(List<char> Char配列, int レコード番号)
        {
            レコード レコード = new(レコード番号);

            レコード["データ区分"] = new string(Char配列.GetRange(0, 1).ToArray());
            //8：トレーラ・レコード
            //データセット解析時にチェックしているので省略

            レコード["合計件数"] = new string(Char配列.GetRange(1, 6).ToArray());
            //右詰め残り前「0」
            try { 文字種別.数字.チェック(レコード["合計件数"]); } catch (Exception e) { throw new Exception("合計件数(文字列[1-6])：" + e.Message); }

            レコード["合計金額"] = new string(Char配列.GetRange(7, 12).ToArray());
            //右詰め残り前「0」
            try { 文字種別.数字.チェック(レコード["合計金額"]); } catch (Exception e) { throw new Exception("合計金額(文字列[7-18])：" + e.Message); }

            レコード["振替済件数"] = new string(Char配列.GetRange(19, 6).ToArray());
            //右詰め残り前「0」
            //依頼明細では全て「0」とする。
            try { 文字種別.数字.チェック(レコード["振替済件数"]); } catch (Exception e) { throw new Exception("振替済件数(文字列[19-24])：" + e.Message); }

            レコード["振替済金額"] = new string(Char配列.GetRange(25, 12).ToArray());
            //右詰め残り前「0」
            //依頼明細では全て「0」とする．
            try { 文字種別.数字.チェック(レコード["振替済金額"]); } catch (Exception e) { throw new Exception("振替済金額(文字列[25-36])：" + e.Message); }

            レコード["振替不能件数"] = new string(Char配列.GetRange(37, 6).ToArray());
            //右詰め残り前「0」
            //依頼明細では全て「0」とする．
            try { 文字種別.数字.チェック(レコード["振替不能件数"]); } catch (Exception e) { throw new Exception("振替不能件数(文字列[37-42])：" + e.Message); }

            レコード["振替不能金類"] = new string(Char配列.GetRange(43, 12).ToArray());
            //右詰め残り前「0」
            //依頼明細では全て「0」とする．
            try { 文字種別.数字.チェック(レコード["振替不能金類"]); } catch (Exception e) { throw new Exception("振替不能金類(文字列[43-54])：" + e.Message); }

            レコード["ダミー"] = new string(Char配列.GetRange(55, 65).ToArray());
            try { 文字種別.スペース.チェック(レコード["ダミー"]); } catch (Exception e) { throw new Exception("ダミー(文字列[55-119])：" + e.Message); }

            return レコード;
        }
        public レコード エンド(List<char> Char配列, int レコード番号)
        {
            レコード レコード = new(レコード番号);

            レコード["データ区分"] = new string(Char配列.GetRange(0, 1).ToArray());
            //9：エンド・レコード
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
            if (データセット.データ配列.Sum(データ => decimal.Parse(データ["引落金額"])) != decimal.Parse(データセット.トレーラ["合計金額"])) { throw new Exception("合計金額(文字列[1-6])：データ[引落金額]の合計と一致しません。"); }

            //以下チェック入れていく。

            if (!(
                (
                    //②-1、振替前として正常扱い
                    //データ：引落結果が全て0
                    データセット.データ配列.All(データ => "0" == データ["振替結果コード"])
                    //トレーラ：[振替済、振替不能]の[件数、金額]が0であること。
                    && (0 == int.Parse(データセット.トレーラ["振替済件数"]))
                    && (0 == decimal.Parse(データセット.トレーラ["振替済金額"]))
                    && (0 == int.Parse(データセット.トレーラ["振替不能件数"]))
                    && (0 == decimal.Parse(データセット.トレーラ["振替不能金類"]))
                ) || (
                        //②-2、振替後として正常扱い
                        //データ：引落結果[0:振替済]と[それ以外:振替不能]で分けた[件数、金額]
                        //トレーラ：[振替済、振替不能]の[件数、金額]と一致していること。
                        (データセット.データ配列.Count(データ => "0" == データ["振替結果コード"]) == int.Parse(データセット.トレーラ["振替済件数"]))
                     && (データセット.データ配列.Sum(データ => "0" == データ["振替結果コード"] ? decimal.Parse(データ["引落金額"]) : 0) == decimal.Parse(データセット.トレーラ["振替済金額"]))
                     && (データセット.データ配列.Count(データ => "0" != データ["振替結果コード"]) == int.Parse(データセット.トレーラ["振替不能件数"]))
                     && (データセット.データ配列.Sum(データ => "0" != データ["振替結果コード"] ? decimal.Parse(データ["引落金額"]) : 0) == decimal.Parse(データセット.トレーラ["振替不能金類"]))
                )
            )) { throw new Exception("振替済件数・振替済金額・振替不能件数・振替不能金類：データの[件数・金額]の集計と一致しません。"); }

        }
        public void 論理チェック(List<データセット> データセット配列, レコード エンド) { }
    }
}