using System.Collections.Generic;

namespace 全銀協フォーマット
{
    public struct データセット
    {
        public レコード ヘッダー;
        public List<レコード> データ配列;
        public レコード トレーラ;
        public データセット(レコード ヘッダー, List<レコード> データ配列, レコード トレーラ)
        {
            this.ヘッダー = ヘッダー;
            this.データ配列 = データ配列;
            this.トレーラ = トレーラ;
        }
    }
}