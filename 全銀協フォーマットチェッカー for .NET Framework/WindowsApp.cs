using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class WindowsApp : Form
{

    public WindowsApp()
    {
        InitializeComponent();
    }

    FileInfo IBrowserFile;
    string エラーメッセージ = "";
    全銀協フォーマット.データ データ;

    void Reset() { IBrowserFile = null; エラーメッセージ = ""; データ = null; }
    private void LoadFile(FileInfo e)
    {
        try
        {
            Reset();
            IBrowserFile = e;
            var buf = new byte[IBrowserFile.Length];
            var fileStream = IBrowserFile.OpenRead();
            try { for (long i = 0; i < IBrowserFile.Length; i++) { buf[i] = (byte)fileStream.ReadByte(); } } finally { fileStream.Close(); }
            データ = new(buf, 120);
        }
        catch (Exception ex) { エラーメッセージ = ex.Message; }
    }

    private void InputFile_Click(object sender, EventArgs e)
    {
        //toolStripTextBox1.Text = "ファイルが選択されていません";
        OpenFileDialog fd = new();
        switch (fd.ShowDialog())
        {
            case DialogResult.OK:
                Reset();
                FileInfo FileInfo = new(fd.FileName);
                //toolStripTextBox1.Text = FileInfo.Name;
                LoadFile(FileInfo);
                break;

            case DialogResult.Cancel: default: Reset(); break;
        }
        //this.OnPaint(null);}protected override void OnPaint(PaintEventArgs e){base.OnPaint(e);

        toolStripTextBox1.Text = (IBrowserFile != null) ? IBrowserFile.Name : "ファイルが選択されていません";
        toolStripTextBox2.Text = (IBrowserFile != null) ? "File Size:" + IBrowserFile.Length : "";

        Controls.Remove(Controls["tableLayoutPanel1"]);
        var TableLayoutPanel = new TableLayoutPanel { GrowStyle = TableLayoutPanelGrowStyle.AddRows, AutoSize = true, Name = "tableLayoutPanel1", Dock = DockStyle.Fill, AutoScroll = true };
        if (データ != null)
        {
            foreach (var データセット in データ.データセット配列)
            {
                TableLayoutPanel.Controls.Add(new Label { BackColor = Color.Aqua, Text = "・ヘッダー", AutoSize = true, Dock = DockStyle.Fill });
                var ヘッダー = new TableLayoutPanel { ColumnCount = 100, GrowStyle = TableLayoutPanelGrowStyle.AddRows, AutoSize = true, Dock = DockStyle.Fill, AutoScroll = true };
                foreach (var keyValuePair in データセット.ヘッダー)
                {
                    var Row = new TableLayoutPanel { AutoSize = true, Dock = DockStyle.Fill };
                    Row.Controls.Add(new Label { BackColor = Color.Aqua, Text = keyValuePair.Key, AutoSize = true, Dock = DockStyle.Fill });
                    Row.Controls.Add(new Label { BackColor = Color.Aqua, Text = keyValuePair.Value, AutoSize = true, Dock = DockStyle.Fill });
                    ヘッダー.Controls.Add(Row);
                }
                TableLayoutPanel.Controls.Add(ヘッダー);

                if (0 != データセット.データ配列.Count)
                {
                    TableLayoutPanel.Controls.Add(new Label { BackColor = Color.Lime, Text = "・データ", AutoSize = true, Dock = DockStyle.Fill });
                    foreach (var データレコード in データセット.データ配列)
                    {
                        var データ = new TableLayoutPanel { ColumnCount = 100, GrowStyle = TableLayoutPanelGrowStyle.AddRows, AutoSize = true, Dock = DockStyle.Fill, AutoScroll = true };
                        foreach (var keyValuePair in データレコード)
                        {
                            var Row = new TableLayoutPanel { AutoSize = true, Dock = DockStyle.Fill };
                            Row.Controls.Add(new Label { BackColor = Color.Lime, Text = keyValuePair.Key, AutoSize = true, Dock = DockStyle.Fill });
                            Row.Controls.Add(new Label { BackColor = Color.Lime, Text = keyValuePair.Value, AutoSize = true, Dock = DockStyle.Fill });
                            データ.Controls.Add(Row);
                        }
                        TableLayoutPanel.Controls.Add(データ);
                    }
                }

                TableLayoutPanel.Controls.Add(new Label { BackColor = Color.LightPink, Text = "・トレーラ", AutoSize = true, Dock = DockStyle.Fill });
                var トレーラ = new TableLayoutPanel { ColumnCount = 100, GrowStyle = TableLayoutPanelGrowStyle.AddRows, AutoSize = true, Dock = DockStyle.Fill, AutoScroll = true };
                foreach (var keyValuePair in データセット.トレーラ)
                {
                    var Row = new TableLayoutPanel { AutoSize = true, Dock = DockStyle.Fill };
                    Row.Controls.Add(new Label { BackColor = Color.LightPink, Text = keyValuePair.Key, AutoSize = true, Dock = DockStyle.Fill });
                    Row.Controls.Add(new Label { BackColor = Color.LightPink, Text = keyValuePair.Value, AutoSize = true, Dock = DockStyle.Fill });
                    トレーラ.Controls.Add(Row);
                }
                TableLayoutPanel.Controls.Add(トレーラ);
            }

            TableLayoutPanel.Controls.Add(new Label { BackColor = Color.WhiteSmoke, Text = "・エンド", AutoSize = true, Dock = DockStyle.Fill });
            var エンド = new TableLayoutPanel { ColumnCount = 100, GrowStyle = TableLayoutPanelGrowStyle.AddRows, AutoSize = true, Dock = DockStyle.Fill, AutoScroll = true };
            foreach (var keyValuePair in データ.エンド)
            {
                var Row = new TableLayoutPanel { AutoSize = true, Dock = DockStyle.Fill };
                Row.Controls.Add(new Label { BackColor = Color.WhiteSmoke, Text = keyValuePair.Key, AutoSize = true, Dock = DockStyle.Fill });
                Row.Controls.Add(new Label { BackColor = Color.WhiteSmoke, Text = keyValuePair.Value, AutoSize = true, Dock = DockStyle.Fill });
                エンド.Controls.Add(Row);
            }
            TableLayoutPanel.Controls.Add(エンド);
        }
        else
        {
            TableLayoutPanel.Controls.Add(new Label { BackColor = Color.WhiteSmoke, Text = エラーメッセージ, AutoSize = true, Dock = DockStyle.Fill });
        }
        TableLayoutPanel.Controls.Add(new Label());

        this.Controls.Add(TableLayoutPanel);
        this.Controls.Remove(this.menuStrip1);
        this.Controls.Add(this.menuStrip1);
    }

    private void 対応種別コード_Click(object sender, EventArgs e)
    {
        var msg = "現在のバージョンでは下記の種別コードに対応しています。\r\n";
        foreach (var 種別コード in 全銀協フォーマット.データ.対応種別コード) { msg += " [ "+種別コード+" ] "; }
        MessageBox.Show(msg);
    }
}