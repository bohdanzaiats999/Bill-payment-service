using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;

namespace Bill_payment_service
{
    class CRUD
    {
        private SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.ConnectionString);
        int balance = 0;

        // Реєстрація
        public bool Registration(string login, string password)
        {
            if (login == "" | password == "")
            {
                MessageBox.Show("Введіть логін і пароль");
                return false;
            }
            else
            {
                SqlDataReader sqlDataReader;

                SqlCommand cmd = new SqlCommand("SELECT Login FROM Users WHERE Login = @Login", sqlConnection);
                cmd.Parameters.Add(new SqlParameter("Login", login));

                sqlConnection.Open();
                sqlDataReader = cmd.ExecuteReader();
                sqlDataReader.Read();

                if (!sqlDataReader.HasRows)
                {
                    sqlConnection.Close();
                    sqlDataReader.Close();

                    cmd.CommandText = "INSERT INTO Users VALUES (@Login,@Password,@Score,@Block,@AdminStatus,@AutoPay,@InternetDebt,@UtilitiesDebt,@СellphoneBillDebt)";

                    cmd.Parameters.Add(new SqlParameter("Password", password.GetHashCode()));
                    cmd.Parameters.Add(new SqlParameter("Score", 1));
                    cmd.Parameters.Add(new SqlParameter("Block", false)); // false - заборонені дії в системі , true - дозволені дії в системі
                    cmd.Parameters.Add(new SqlParameter("AdminStatus", false)); // false - простий користувач, true - адміністратор
                    cmd.Parameters.Add(new SqlParameter("AutoPay", false));
                    cmd.Parameters.Add(new SqlParameter("InternetDebt", 1));
                    cmd.Parameters.Add(new SqlParameter("UtilitiesDebt", 1));
                    cmd.Parameters.Add(new SqlParameter("СellphoneBillDebt", 1));

                    sqlConnection.Open();
                    sqlDataReader = cmd.ExecuteReader();
                    sqlConnection.Close();
                    sqlDataReader.Close();

                    cmd.CommandText = "SELECT Id FROM Users WHERE Login = @Login";

                    sqlConnection.Open();
                    sqlDataReader = cmd.ExecuteReader();
                    sqlDataReader.Read();

                    Properties.Settings.Default.IdUser = (int)sqlDataReader[0];
                    Properties.Settings.Default.Save();

                    sqlConnection.Close();
                    sqlDataReader.Close();

                    User user = new User();
                    user.Show();
                    return true;
                }
                MessageBox.Show("Цей Логін вже занятий");
                return false;
            }
        }

        // Логін
        public bool Login(string login, string password)
        {
            if (login == "" | password == "")
            {
                MessageBox.Show("Введіть логін і пароль");
                return false;
            }
            else
            {
                SqlDataReader sqlDataReader;
                SqlCommand cmd = new SqlCommand("SELECT Login,Password,AdminStatus,Id,Block FROM Users WHERE Login = @Login and Password = @Password ", sqlConnection);
                cmd.Parameters.Add(new SqlParameter("Login", login));
                cmd.Parameters.Add(new SqlParameter("Password", password.GetHashCode()));

                sqlConnection.Open();
                sqlDataReader = cmd.ExecuteReader();
                sqlDataReader.Read();

                if (!sqlDataReader.HasRows)
                {
                    sqlConnection.Close();
                    sqlDataReader.Close();
                    MessageBox.Show("Вибачте,ви не зареєстровані", "УПС");
                    return false;
                }
                else
                {
                    bool adminStatus = (bool)sqlDataReader[2];
                    bool blockStatus = (bool)sqlDataReader[4];

                    Properties.Settings.Default.IdUser = (int)sqlDataReader[3];
                    Properties.Settings.Default.Login = login;
                    Properties.Settings.Default.Save();
                    if (adminStatus == true)
                    {
                        Admin admin = new Admin();
                        admin.Show();
                    }
                    else
                    {
                        if (blockStatus)
                        {
                            MessageBox.Show("Ваш акаунт заблокований,очікуйте розблокування зі сторони Адміністратора");
                        }
                        else
                        {
                            User user = new User();
                            user.Show();
                        }
                    }
                }
                sqlConnection.Close();
                return true;
            }
        }

        // Обновити dataGrid
        public void DataGridAddAndBlockRefresh(ref DataGrid dataGrid)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Id as ID,Login as Логін,Score as Рахунок ,AutoPay as Автооплата,Block as Заблоковані FROM Users ", sqlConnection);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGrid.ItemsSource = dataSet.Tables[0].DefaultView;
        }
        public void DataGridSettingTheFeesRefresh(ref DataGrid dataGrid)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Id as ID, Login as Логін, InternetDebt as Інтернет,UtilitiesDebt as Комунальні ,СellphoneBillDebt as МобільнийРахунок FROM Users ", sqlConnection);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGrid.ItemsSource = dataSet.Tables[0].DefaultView;
        }

        // Заблокувати/Розблокувати користувача
        public void BlockUnblockUser(string id)
        {
            int verification = 0;
            if (id == "")
            {
                MessageBox.Show("Введіть ID");
            }
            else if (!Int32.TryParse(id, out verification))
            {
                MessageBox.Show("Введіть число");
            }
            else
            {
                SqlDataReader sqlDataReader;
                SqlCommand sqlCommand = new SqlCommand("SELECT Block FROM Users WHERE Id = @Id ", sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("Id", id));

                sqlConnection.Open();
                sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();

                if (!sqlDataReader.HasRows)
                {
                    sqlDataReader.Close();
                    sqlConnection.Close();
                    MessageBox.Show("ID невірний");
                }
                else
                {
                    bool blockStatus = (bool)sqlDataReader[0];
                    sqlConnection.Close();
                    sqlDataReader.Close();

                    sqlCommand.CommandText = "UPDATE Users SET Block = @Status WHERE Id = @Id";
                    sqlCommand.Parameters.Add(new SqlParameter("Status", !blockStatus));

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (blockStatus == true)
                    {
                        MessageBox.Show("Користувач Розблокований");
                    }
                    else
                    {
                        MessageBox.Show("Користувач Заблокований");
                    }
                }
            }
        }

        // Поповнити рахунок
        public void AddFunds(string howMuch)
        {
            int verification = 0;
            if (howMuch == "")
            {
                MessageBox.Show("Введіть суму яку необхідно занести");
            }
            else if (!Int32.TryParse(howMuch, out verification))
            {
                MessageBox.Show("Введіть число");
            }
            else
            {
                SqlCommand sqlCommand = new SqlCommand("UPDATE Users SET Score = @Score WHERE Id = @Id ", sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("Score", balance + int.Parse(howMuch)));
                sqlCommand.Parameters.Add(new SqlParameter("Id", Properties.Settings.Default.IdUser));
                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                MessageBox.Show("Рахунок успішно поповнено");

            }
        }
        // Перевірити Баланс
        public int CheckTheBalance()
        {
            SqlDataReader sqlDataReader;

            SqlCommand sqlCommand = new SqlCommand("Select Score FROM Users WHERE Id = @Id ", sqlConnection);
            sqlCommand.Parameters.Add(new SqlParameter("Id", Properties.Settings.Default.IdUser));
            try
            {
                sqlConnection.Open();
                sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                balance = (int)sqlDataReader[0];
                sqlConnection.Close();
                sqlDataReader.Close();
                return balance;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        // Автоматична оплата
        public bool AutoPay(ref CheckBox status)
        {
            
            SqlCommand sqlCommand = new SqlCommand("UPDATE Users SET AutoPay = @Status WHERE Id = @Id",sqlConnection);
            sqlCommand.Parameters.Add(new SqlParameter("Status", status.IsChecked.Value));
            sqlCommand.Parameters.Add(new SqlParameter("Id", Properties.Settings.Default.IdUser));
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            if (status.IsChecked.Value)
            {
                MessageBox.Show("Автоматична оплата успішно включена");
                return true;
            }
            else
            {
                MessageBox.Show("Автоматична оплата успішно виключена");
                return false;
            }
        }
        // Оплатити інтернет
        public void InternetPay(ref TextBlock InternetPay)
        {
            int score = balance;
            int internetDebt = 0;
            SqlDataReader sqlDataReader;
            SqlCommand sqlCommand = new SqlCommand("SELECT InternetDebt FROM Users WHERE Id = @Id ", sqlConnection);
            sqlCommand.Parameters.Add(new SqlParameter("Id", Properties.Settings.Default.IdUser));
            try
            {
                sqlConnection.Open();
                sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                InternetPay.Text = sqlDataReader[0].ToString();
                internetDebt = (int)sqlDataReader[0];
                sqlConnection.Close();
                sqlDataReader.Close();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            if (internetDebt >= score)
            {
                internetDebt -= score;
                score = 0;
            }
            else
            {
                score -= internetDebt;
                internetDebt = 0;
            }
            sqlCommand.CommandText = "UPDATE Users SET InternetDebt = @InternetDebt,Score = @Score WHERE Id = @Id ";
            sqlCommand.Parameters.Add(new SqlParameter("InternetDebt", internetDebt));
            sqlCommand.Parameters.Add(new SqlParameter("Score", score));
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            InternetPay.Text = "Сума боргу за інтернет : "+ internetDebt.ToString();
            balance = score;
        }

        // Оплатити комунальні послуги
        public void UtilitiesPay(ref TextBlock UtilitiesPay)
        {
            int score = balance;
            int utilitiesDebt = 0;
            SqlDataReader sqlDataReader;
            SqlCommand sqlCommand = new SqlCommand("SELECT UtilitiesDebt FROM Users WHERE Id = @Id ", sqlConnection);
            sqlCommand.Parameters.Add(new SqlParameter("Id", Properties.Settings.Default.IdUser));
            try
            {
                sqlConnection.Open();
                sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                UtilitiesPay.Text = sqlDataReader[0].ToString();
                utilitiesDebt = (int)sqlDataReader[0];
                sqlConnection.Close();
                sqlDataReader.Close();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            if (utilitiesDebt >= score)
            {
                utilitiesDebt -= score;
                score = 0;
            }
            else
            {
                score -= utilitiesDebt;
                utilitiesDebt = 0;
            }
            sqlCommand.CommandText = "UPDATE Users SET UtilitiesDebt = @UtilitiesDebt,Score = @Score WHERE Id = @Id ";
            sqlCommand.Parameters.Add(new SqlParameter("UtilitiesDebt", utilitiesDebt));
            sqlCommand.Parameters.Add(new SqlParameter("Score", score));
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            UtilitiesPay.Text = "Сума боргу за комунальні послуги : " + utilitiesDebt.ToString();
            balance = score;

        }

        // Оплатити мобільний телефон
        public void CellphoneBillPay(ref TextBlock CellphoneBillPay)
        {
            int score = balance;
            int cellphoneBillDebt = 0;
            SqlDataReader sqlDataReader;
            SqlCommand sqlCommand = new SqlCommand("SELECT СellphoneBillDebt FROM Users WHERE Id = @Id ", sqlConnection);
            sqlCommand.Parameters.Add(new SqlParameter("Id", Properties.Settings.Default.IdUser));
            try
            {
                sqlConnection.Open();
                sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                CellphoneBillPay.Text = sqlDataReader[0].ToString();
                cellphoneBillDebt = (int)sqlDataReader[0];
                sqlConnection.Close();
                sqlDataReader.Close();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            if (cellphoneBillDebt >= score)
            {
                cellphoneBillDebt -= score;
                score = 0;
            }
            else
            {
                score -= cellphoneBillDebt;
                cellphoneBillDebt = 0;
            }
            sqlCommand.CommandText = "UPDATE Users SET СellphoneBillDebt = @СellphoneBillDebt,Score = @Score WHERE Id = @Id ";
            sqlCommand.Parameters.Add(new SqlParameter("СellphoneBillDebt", cellphoneBillDebt));
            sqlCommand.Parameters.Add(new SqlParameter("Score", score));
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            CellphoneBillPay.Text = "Сума боргу рахунку мобільного телефону : " + cellphoneBillDebt.ToString();
            balance = score;

        }

        // Відображення стану заборгованості
        public bool CheckTheDebt(ref TextBlock InternetPay, ref TextBlock UtilitiesPay, ref TextBlock CellphoneBillPay)
        {
            SqlDataReader sqlDataReader;
            SqlCommand sqlCommand = new SqlCommand("SELECT InternetDebt,UtilitiesDebt, СellphoneBillDebt,AutoPay FROM Users WHERE Id = @Id ", sqlConnection);
            sqlCommand.Parameters.Add(new SqlParameter("Id", Properties.Settings.Default.IdUser));
            bool autoPayStatus = false;
            try
            {
                sqlConnection.Open();
                sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                InternetPay.Text = "Сума боргу за інтернет : " + sqlDataReader[0].ToString();
                UtilitiesPay.Text = "Сума боргу за комунальні послуги : " + sqlDataReader[1].ToString();
                CellphoneBillPay.Text = "Сума боргу рахунку мобільного телефону : " + sqlDataReader[2].ToString();
                autoPayStatus = (bool)sqlDataReader[3];
                sqlConnection.Close();
                sqlDataReader.Close();
                return autoPayStatus;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // Добавити суму заборг користувачу за інтернет
        public void SettingTheFeesInternet(string id,string AddInternetDebt)
        {
            int verification = 0;
            if (id == "" | AddInternetDebt == "")
            {
                MessageBox.Show("Введіть ID і суму");
            }
            else if (!Int32.TryParse(id, out verification) | !Int32.TryParse(AddInternetDebt, out verification))
            {
                MessageBox.Show("Введіть цифри в поля ID і Інтернет ");
            }
            else
            {
                int internetDebt = 0;
                SqlDataReader sqlDataReader;
                SqlCommand sqlCommand = new SqlCommand("SELECT InternetDebt FROM Users WHERE Id = @Id ", sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("Id", id));

                try
                {
                    sqlConnection.Open();
                    sqlDataReader = sqlCommand.ExecuteReader();
                    sqlDataReader.Read();
                    internetDebt = (int)sqlDataReader[0];
                    sqlConnection.Close();
                    sqlDataReader.Close();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                
                sqlCommand.CommandText = "UPDATE Users SET InternetDebt = @InternetDebt  WHERE Id = @Id ";
                sqlCommand.Parameters.Add(new SqlParameter("InternetDebt", int.Parse(AddInternetDebt) + internetDebt));

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        // Добавити суму заборг користувачу за комунальні послуги

        public void SettingTheFeesUtilities(string id, string AddUtilitiesDebt)
        {
            int verification = 0;
            if (id == "" | AddUtilitiesDebt == "")
            {
                MessageBox.Show("Введіть ID і суму");
            }
            else if (!Int32.TryParse(id, out verification) | !Int32.TryParse(AddUtilitiesDebt, out verification))
            {
                MessageBox.Show("Введіть цифри в поля ID і Комунальні послуги ");
            }
            else
            {
                int utilitiesDebt = 0;
                SqlDataReader sqlDataReader;
                SqlCommand sqlCommand = new SqlCommand("SELECT UtilitiesDebt FROM Users WHERE Id = @Id ", sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("Id", id));
                try
                {
                    sqlConnection.Open();
                    sqlDataReader = sqlCommand.ExecuteReader();
                    sqlDataReader.Read();
                    utilitiesDebt = (int)sqlDataReader[0];
                    sqlConnection.Close();
                    sqlDataReader.Close();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                sqlCommand.CommandText = "UPDATE Users SET UtilitiesDebt = @UtilitiesDebt  WHERE Id = @Id ";
                sqlCommand.Parameters.Add(new SqlParameter("UtilitiesDebt", int.Parse(AddUtilitiesDebt) + utilitiesDebt));

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        // Добавити суму заборг користувачу на моб. тел.
        public void SettingTheFeesCellphoneBill(string id, string AddCellphoneBillDebt)
        {
            int verification = 0;
            if (id == "" | AddCellphoneBillDebt == "")
            {
                MessageBox.Show("Введіть ID і суму");
            }
            else if (!Int32.TryParse(id, out verification) | !Int32.TryParse(AddCellphoneBillDebt, out verification))
            {
                MessageBox.Show("Введіть цифри в поля ID і Мобільний рахунок ");
            }
            else
            {
                int СellphoneBillDebt = 0;
                SqlDataReader sqlDataReader;
                SqlCommand sqlCommand = new SqlCommand("SELECT СellphoneBillDebt FROM Users WHERE Id = @Id ", sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("Id", id));
                try
                {
                    sqlConnection.Open();
                    sqlDataReader = sqlCommand.ExecuteReader();
                    sqlDataReader.Read();
                    СellphoneBillDebt = (int)sqlDataReader[0];
                    sqlConnection.Close();
                    sqlDataReader.Close();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                sqlCommand.CommandText = "UPDATE Users SET СellphoneBillDebt = @СellphoneBillDebt  WHERE Id = @Id ";
                sqlCommand.Parameters.Add(new SqlParameter("СellphoneBillDebt", int.Parse(AddCellphoneBillDebt) + СellphoneBillDebt));

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

    }
}
