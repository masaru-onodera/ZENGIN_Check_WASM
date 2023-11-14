using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 全銀協フォーマット
{
    public class データ
    {
        #region プロパティ
        public List<データセット> データセット配列 = new();
        public レコード エンド;
        #endregion

        static readonly Dictionary<string, 解析型> 対応種別リスト = new Dictionary<string, 解析型>{
            {"11" , new 解析_11()},
            {"12" , new 解析_12()},
            {"71" , new 解析_71()},
            {"72" , new 解析_72()},
            {"21" , new 解析_21()},
            {"91" , new 解析_91()},
        };
        public static IEnumerable<string> 対応種別コード => 対応種別リスト.Keys;

        public データ(byte[] buf, int? レコードサイズ = null, bool? CR = null, bool? LF = null)
        {
            #region レコードサイズ自動判別
            if (null == レコードサイズ)
            {
                if (120 < buf.Length && 0x0d == buf[120]) { レコードサイズ = 120; }
                else if (200 < buf.Length && 0x0d == buf[200]) { レコードサイズ = 200; }
                else if (250 < buf.Length && 0x0d == buf[250]) { レコードサイズ = 250; }
                else if (300 < buf.Length && 0x0d == buf[300]) { レコードサイズ = 300; }
                else if (550 < buf.Length && 0x0d == buf[550]) { レコードサイズ = 550; }
                throw new Exception("レコードサイズを自動判断できませんでした。");
            }
            if (buf.Length < レコードサイズ.Value * 3) { throw new Exception("データセットに必要な最低ファイルサイズを満たしていません。"); }
            Encoding エンコーダ = (buf[レコードサイズ.Value switch
            {
                200 => 3,
                120 => 3,
                550 => 3,
                300 => 6,
                250 => 3,
                _ => throw new Exception("レコードサイズ[" + レコードサイズ.Value + "]には対応していません。")
            }])
            #endregion
            #region 文字コード自動判別
            switch
            {
                0x30 => Encoding.GetEncoding(932),//JIS
                0xF1 => Encoding.GetEncoding(20290),//EBCDIC
                _ => throw new Exception("文字コードが判別できません。"),
            };
            #endregion
            #region 改行有無自動判別
            if (null == CR) { CR = "\r" == エンコーダ.GetString(new[] { buf[レコードサイズ.Value] }); }
            if (null == LF) { LF = "\n" == エンコーダ.GetString(new[] { buf[レコードサイズ.Value + (CR.Value ? 1 : 0)] }); }
            #endregion
            var buffer = buf.Select(Byte => エンコーダ.GetString(new[] { Byte })[0]).ToList();

            if (0x1a == buf.Last()) { buffer.RemoveRange(buffer.Count - 1, 1); }// ファームバンキング依頼結果の場合の例外処理

            if ('1' != buffer[0]) { throw new Exception("ヘッダーがありません。"); }
            var 種別コード = new string(buffer.GetRange(1, レコードサイズ.Value switch { 300 => 1, _ => 2 }).ToArray());
            解析型 解析; if (!対応種別リスト.TryGetValue(種別コード, out 解析)) { throw new Exception("未対応の種別コードです。"); }

            int レコード番号 = 0;
            try
            {
                レコード番号++;
                while ('1' == buffer[0])
                {
                    if (new string(buffer.GetRange(1, レコードサイズ.Value switch { 300 => 1, _ => 2 }).ToArray()) != 種別コード) { throw new Exception("種別コードに一貫性がありません。"); }

                    if (buffer.Count < レコードサイズ.Value) { throw new Exception("レコードサイズが正しくありません。"); }
                    var ヘッダー = 解析.ヘッダー(buffer.GetRange(0, レコードサイズ.Value), レコード番号);
                    buffer.RemoveRange(0, レコードサイズ.Value);
                    if (CR.Value) { if ('\r' == buffer[0]) { buffer.RemoveRange(0, 1); } else { throw new Exception("改行コード'\\r'がありません。"); } }
                    if (LF.Value) { if ('\n' == buffer[0]) { buffer.RemoveRange(0, 1); } else { throw new Exception("改行コード'\\n'がありません。"); } }

                    レコード番号++;
                    if (buffer.Count < レコードサイズ.Value) { throw new Exception("レコードサイズが正しくありません。"); }
                    List<レコード> データ配列 = new();
                    while ('2' == buffer[0])
                    {
                        データ配列.Add(解析.データ(buffer.GetRange(0, レコードサイズ.Value), レコード番号));
                        buffer.RemoveRange(0, レコードサイズ.Value);
                        if (CR.Value) { if ('\r' == buffer[0]) { buffer.RemoveRange(0, 1); } else { throw new Exception("改行コード'\\r'がありません。"); } }
                        if (LF.Value) { if ('\n' == buffer[0]) { buffer.RemoveRange(0, 1); } else { throw new Exception("改行コード'\\n'がありません。"); } }

                        レコード番号++;
                        if (buffer.Count < レコードサイズ.Value) { throw new Exception("レコードサイズが正しくありません。"); }
                    }

                    if ('8' != buffer[0]) { throw new Exception("データまたはトレーラではありません。"); }
                    var トレーラ = 解析.トレーラ(buffer.GetRange(0, レコードサイズ.Value), レコード番号);
                    buffer.RemoveRange(0, レコードサイズ.Value);
                    if (CR.Value) { if ('\r' == buffer[0]) { buffer.RemoveRange(0, 1); } else { throw new Exception("改行コード'\\r'がありません。"); } }
                    if (LF.Value) { if ('\n' == buffer[0]) { buffer.RemoveRange(0, 1); } else { throw new Exception("改行コード'\\n'がありません。"); } }

                    データセット データセット = new(ヘッダー, データ配列, トレーラ);
                    解析.論理チェック(データセット);
                    データセット配列.Add(データセット);

                    レコード番号++;
                    if (buffer.Count < レコードサイズ.Value) { throw new Exception("レコードサイズが正しくありません。"); }
                }

                if ('9' != buffer[0]) { throw new Exception("エンドレコードがありません。"); }
                エンド = 解析.エンド(buffer.GetRange(0, レコードサイズ.Value), レコード番号);
                buffer.RemoveRange(0, レコードサイズ.Value);
                if (CR.Value) { if ('\r' == buffer[0]) { buffer.RemoveRange(0, 1); } else { throw new Exception("改行コード'\\r'がありません。"); } }
                if (LF.Value) { if ('\n' == buffer[0]) { buffer.RemoveRange(0, 1); } else { throw new Exception("改行コード'\\n'がありません。"); } }

                解析.論理チェック(データセット配列, エンド);
                if (0 < buffer.Count) { throw new Exception("エンドレコードの後ろにデータがあります。"); }
            }
            catch (Exception e) { throw new Exception("レコード番号[" + レコード番号 + "]：" + e.Message); }
        }
    }
}