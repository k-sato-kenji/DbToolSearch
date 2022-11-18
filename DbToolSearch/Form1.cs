using System;
using System.Windows.Forms;

namespace DbToolSearch
{
    public partial class Form1 : Form
    {

        DbUtil lg;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DbUtil tool = new DbUtil();
            if (tool.DataBasLogin() != true)
            {
                try
                {
                    throw new MyException("エラーコード:001");
                }
                catch (MyException exc)
                {
                    MessageBox.Show("ＤＢオープンエラー検出:" + exc.Message, "異常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // アプリケーションを終了する
                    Application.Exit();
                }
            }

            // 初回データ処理
            tool.initialdisplay();

            //  画面にデータ設定
            n_TkcdTextBox.Text = definition.Comid.ToString();
            C_TknmTextBox.Text = definition.Comneme.ToString();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // 次データ処理
            DbUtil tool = new DbUtil();
            tool.nextdat();

            //  画面にデータ設定
            n_TkcdTextBox.Text = definition.Comid.ToString();
            C_TknmTextBox.Text = definition.Comneme.ToString();

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            // 前データ処理
            DbUtil tool = new DbUtil();
            tool.prewdat();

            //  画面にデータ設定
            n_TkcdTextBox.Text = definition.Comid.ToString();
            C_TknmTextBox.Text = definition.Comneme.ToString();

        }

        private void btnTop_Click(object sender, EventArgs e)
        {
            // 先頭データ処理
            DbUtil tool = new DbUtil();
            tool.topdat();

            //  画面にデータ設定
            n_TkcdTextBox.Text = definition.Comid.ToString();
            C_TknmTextBox.Text = definition.Comneme.ToString();

        }

        private void btnBottom_Click(object sender, EventArgs e)
        {
            // 先頭データ処理
            DbUtil tool = new DbUtil();
            tool.bottomdat();

            //  画面にデータ設定
            n_TkcdTextBox.Text = definition.Comid.ToString();
            C_TknmTextBox.Text = definition.Comneme.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            // メモリー解放
            DbUtil tool = new DbUtil();
            tool.Dispose();

            // 終了
            this.Close();

        }
    }
}
