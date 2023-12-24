using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
        public readonly IEnumerable<Dictionary<string, bool>> データ配列_Keys
        {
            get
            {
                for (int i = 0; i < データ配列.Max(データ => データ.Count); i++)
                {
                    Dictionary<string, bool> Keys = new();
                    foreach (var Key in データ配列.Where(データ => i < データ.Count).Select(データ => データ.ElementAt(i).Key))
                    {
                        Keys[Key] = true;
                    }
                    yield return Keys;
                }
            }
        }
    }
}