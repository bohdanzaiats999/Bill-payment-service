using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bill_payment_service
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Window
    {
        CRUD crud = new CRUD();
        public User()
        {
            InitializeComponent();

            textBlocScoreBalanceBalance.Text = "Доступна сума : " + crud.CheckTheBalance().ToString() + " грн";
           if(crud.CheckTheDebt(ref textBlockWatchServiceInternetPay, ref textBlockWatchServiceUtilitiesPay,ref textBlockWatchServiceCellphoneBillPay))
            {
                checkBoxScoreBalanceAutoPay.IsChecked = true;
                crud.InternetPay(ref textBlockWatchServiceInternetPay);
                crud.UtilitiesPay(ref textBlockWatchServiceUtilitiesPay);
                crud.CellphoneBillPay(ref textBlockWatchServiceCellphoneBillPay);
            }
            textBlocScoreBalanceBalance.Text = "Доступна сума : " + crud.CheckTheBalance().ToString() + " грн";


        }

        private void buttonScoreBalanceAddFunds_Click(object sender, RoutedEventArgs e)
        {
            crud.AddFunds(textBoxScoreBalanceAddFunds.Text);
            textBlocScoreBalanceBalance.Text = "Доступна сума : " + crud.CheckTheBalance().ToString() + " грн";

        }

        private void checkBoxScoreBalanceAutoPay_Click(object sender, RoutedEventArgs e)
        {
            if (crud.AutoPay(ref checkBoxScoreBalanceAutoPay))
            {
                crud.InternetPay(ref textBlockWatchServiceInternetPay);
                crud.UtilitiesPay(ref textBlockWatchServiceUtilitiesPay);
                crud.CellphoneBillPay(ref textBlockWatchServiceCellphoneBillPay);
                textBlocScoreBalanceBalance.Text = "Доступна сума : " + crud.CheckTheBalance().ToString() + " грн";
            }
        }

        private void buttonWatchServiceInternetPay_Click(object sender, RoutedEventArgs e)
        {
            crud.InternetPay(ref textBlockWatchServiceInternetPay);
            textBlocScoreBalanceBalance.Text = "Доступна сума : " + crud.CheckTheBalance().ToString() + " грн";

        }

        private void buttonWatchServiceUtilitiesPay_Click(object sender, RoutedEventArgs e)
        {
            crud.UtilitiesPay(ref textBlockWatchServiceUtilitiesPay);
            textBlocScoreBalanceBalance.Text = "Доступна сума : " + crud.CheckTheBalance().ToString() + " грн";


        }

        private void buttonWatchServiceСellphoneBillPay_Click(object sender, RoutedEventArgs e)
        {
            crud.CellphoneBillPay(ref textBlockWatchServiceCellphoneBillPay);
            textBlocScoreBalanceBalance.Text = "Доступна сума : " + crud.CheckTheBalance().ToString() + " грн";

        }
    }
}
