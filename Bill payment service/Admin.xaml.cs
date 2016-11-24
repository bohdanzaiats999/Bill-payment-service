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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        CRUD crud = new CRUD();
        public Admin()
        {
            InitializeComponent();
            crud.DataGridAddAndBlockRefresh(ref dataGridAddAndBlock);
            crud.DataGridSettingTheFeesRefresh(ref dataGridSettingTheFees);
        }

        private void buttonAuthorizationRefresh_Click(object sender, RoutedEventArgs e)
        {
            crud.DataGridAddAndBlockRefresh(ref dataGridAddAndBlock);
        }

        private void buttonSettingTheFeesRefresh_Click(object sender, RoutedEventArgs e)
        {
            crud.DataGridSettingTheFeesRefresh(ref dataGridSettingTheFees);
        }

        private void buttonAddAndBlockBlockUnblock_Click(object sender, RoutedEventArgs e)
        {
            crud.BlockUnblockUser(textBoxAddAndBlockBlockUnblock.Text);
            crud.DataGridAddAndBlockRefresh(ref dataGridAddAndBlock);

        }

        private void buttonSettingTheFeesAddChangeInternet_Click(object sender, RoutedEventArgs e)
        {
            crud.SettingTheFeesInternet(textBoxSettingTheFeesId.Text, textBoxSettingTheFeesInternet.Text);
            crud.DataGridSettingTheFeesRefresh(ref dataGridSettingTheFees);

        }

        private void buttonSettingTheFeesAddChangeUtilities_Click(object sender, RoutedEventArgs e)
        {
            crud.SettingTheFeesUtilities(textBoxSettingTheFeesId.Text, textBoxSettingTheFeesUtilities.Text);
            crud.DataGridSettingTheFeesRefresh(ref dataGridSettingTheFees);
        }

        private void buttonSettingTheFeesAddChangeCellphoneBill_Click(object sender, RoutedEventArgs e)
        {
            crud.SettingTheFeesCellphoneBill(textBoxSettingTheFeesId.Text, textBoxSettingTheFeesCellphoneBill.Text);
            crud.DataGridSettingTheFeesRefresh(ref dataGridSettingTheFees);
        }
    }
}
