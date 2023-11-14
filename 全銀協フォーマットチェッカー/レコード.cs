using System.Collections.Generic;

namespace 全銀協フォーマット
{
    public class レコード : Dictionary<string, string>
    {
        public int レコード番号;
        public レコード(int レコード番号)
        {
            this.レコード番号 = レコード番号;
        }
    }
}