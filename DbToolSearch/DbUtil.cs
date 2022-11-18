using System;
using System.Windows.Forms;

// MySQLを使用する為。	
//｢NuGet｣は、｢.NET Framework｣に対応する、
//オープンソースのパッケージマネージャーです。
//ニューゲットやヌゲットなど、複数読み方があります。

using MySql.Data.MySqlClient;

namespace DbToolSearch
{
    public class DbUtil
    {
        // 定義を宣言
        //public MySqlConnection cn;
        public Boolean loginSta;
        public static string LoginErr;
        //DbUtil lg;

        private static MySqlConnection Connection { get; set; }

        // DataBasLogin  メソッド
        public bool DataBasLogin()
        {

            // MySQLへの接続情報
            //string server = "localhost";
            //string port = "3306";
            //string database = "mysql";
            //string user = "root";
            //string pass = "root";
            //string charset = "utf8";

            loginSta = true;
            //  接続のインスタンス
            Connection = new MySqlConnection();

            //Connection.ConnectionString = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};Charset={5}",
            //                                        server, port, database, user, pass, charset);

            //Console.WriteLine("");

            Connection.ConnectionString = System.IO.File.ReadAllText(@"C:\Data\ConnectionString.txt");

            try
            {
                Connection.Open();
                loginSta = true;
            }
            catch (Exception ex)
            {
                LoginErr = ex.ToString();
                loginSta = false;
            }
            // スタータスを返す。
            return loginSta;
        }

        public void initialdisplay()
        {
            // 初回表示処理
            //SQLコマンド定義
            string sql = "SELECT min(N_Tkcd) as tkcd, C_Tknm from t_tokuikubun";
            MySqlCommand command = new MySqlCommand(sql, Connection);
            MySqlDataReader reader = command.ExecuteReader();
            // 1件読み
            reader.Read();
            definition.Comcode = int.Parse(reader["tkcd"].ToString());
            Console.WriteLine("key(load): " + reader["tkcd"].ToString());
            //  画面に設定
            definition.Comid = int.Parse(reader["tkcd"].ToString());
            definition.Comneme = reader["C_Tknm"].ToString();
            // 読み込みクローズ
            reader.Close();
        }

        public void nextdat()
        {
            // 次データ表示処理
            //SQLコマンド定義
            string sql =
           "SELECT *, count(*) as cnt FROM t_tokuikubun where N_Tkcd=(select min(a.N_Tkcd) from t_tokuikubun as a where a.N_Tkcd > " + definition.Comcode + ")";
            MySqlCommand command = new MySqlCommand(sql, Connection);
            MySqlDataReader reader = command.ExecuteReader();
            // 1件読み
            reader.Read();
            definition.Comcnt = int.Parse(reader["cnt"].ToString());
            //  データ有無確認
            if ( definition.Comcnt == 0 )
            {
                MessageBox.Show("データが存在しません！", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Console.WriteLine("key(Prev): " + reader["N_Tkcd"].ToString());
                definition.Comcode = int.Parse(reader["N_Tkcd"].ToString());
                Console.WriteLine("key(load): " + reader["N_Tkcd"].ToString());
                //  画面に設定
                definition.Comid = int.Parse(reader["N_Tkcd"].ToString());
                definition.Comneme = reader["C_Tknm"].ToString();
            }
            // 読み込みクローズ
            reader.Close();
        }

        public void prewdat()
        {
            // 前データ表示処理
            //SQLコマンド定義
            string sql =
           "SELECT *, count(*) as cnt FROM t_tokuikubun where N_Tkcd=(select max(a.N_Tkcd) from t_tokuikubun as a where a.N_Tkcd < " + definition.Comcode + ")";
            MySqlCommand command = new MySqlCommand(sql, Connection);
            MySqlDataReader reader = command.ExecuteReader();
            // 1件読み
            reader.Read();
            definition.Comcnt = int.Parse(reader["cnt"].ToString());
            //  データ有無確認
            if (definition.Comcnt == 0)
            {
                MessageBox.Show("データが存在しません！", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Console.WriteLine("key(Prev): " + reader["N_Tkcd"].ToString());
                definition.Comcode = int.Parse(reader["N_Tkcd"].ToString());
                Console.WriteLine("key(load): " + reader["N_Tkcd"].ToString());
                //  画面に設定
                definition.Comid = int.Parse(reader["N_Tkcd"].ToString());
                definition.Comneme = reader["C_Tknm"].ToString();
            }
            // 読み込みクローズ
            reader.Close();
        }

        public void topdat()
        {
            // 先頭データ表示処理
            //SQLコマンド定義
            string sql =
           "SELECT *, count(*) as cnt FROM t_tokuikubun where N_Tkcd=(select min(a.N_Tkcd) from t_tokuikubun as a )";
            MySqlCommand command = new MySqlCommand(sql, Connection);
            MySqlDataReader reader = command.ExecuteReader();
            // 1件読み
            reader.Read();
            definition.Comcnt = int.Parse(reader["cnt"].ToString());
            //  データ有無確認
            if (definition.Comcnt == 0)
            {
                MessageBox.Show("データが存在しません！", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Console.WriteLine("key(Prev): " + reader["N_Tkcd"].ToString());
                definition.Comcode = int.Parse(reader["N_Tkcd"].ToString());
                Console.WriteLine("key(load): " + reader["N_Tkcd"].ToString());
                //  画面に設定
                definition.Comid = int.Parse(reader["N_Tkcd"].ToString());
                definition.Comneme = reader["C_Tknm"].ToString();
            }
            // 読み込みクローズ
            reader.Close();
        }

        public void bottomdat()
        {
            // 最終データ表示処理
            //SQLコマンド定義
            string sql =
           "SELECT *, count(*) as cnt FROM t_tokuikubun where N_Tkcd=(select max(a.N_Tkcd) from t_tokuikubun as a )";
            MySqlCommand command = new MySqlCommand(sql, Connection);
            MySqlDataReader reader = command.ExecuteReader();
            // 1件読み
            reader.Read();
            definition.Comcnt = int.Parse(reader["cnt"].ToString());
            //  データ有無確認
            if (definition.Comcnt == 0)
            {
                MessageBox.Show("データが存在しません！", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Console.WriteLine("key(Prev): " + reader["N_Tkcd"].ToString());
                definition.Comcode = int.Parse(reader["N_Tkcd"].ToString());
                Console.WriteLine("key(load): " + reader["N_Tkcd"].ToString());
                //  画面に設定
                definition.Comid = int.Parse(reader["N_Tkcd"].ToString());
                definition.Comneme = reader["C_Tknm"].ToString();
            }
            // 読み込みクローズ
            reader.Close();
        }

        //Disposeの実装です。
        public void Dispose()
        {
            Connection.Close();
            Connection.Dispose();
        }

    } //DbUtil
} //DbToolSearch
