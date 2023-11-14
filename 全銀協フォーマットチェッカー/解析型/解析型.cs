using System.Collections.Generic;

namespace 全銀協フォーマット
{
    interface 解析型
    {
        public abstract レコード ヘッダー(List<char> Char配列, int レコード番号);
        public abstract レコード データ(List<char> Char配列, int レコード番号);
        public abstract レコード トレーラ(List<char> Char配列, int レコード番号);
        public abstract レコード エンド(List<char> Char配列, int レコード番号);
        /// <summary>データの集計とトレーラの整合性</summary>
        public abstract void 論理チェック(データセット データセット);
        /// <summary>レコード件数とエンドレコードの整合性</summary>
        public abstract void 論理チェック(List<データセット> データセット配列, レコード エンド);
    }
}