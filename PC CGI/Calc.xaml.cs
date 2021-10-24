using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace PC_CGI
{
    public partial class Calc : Window
    {
        int TotalCost = 0;
        DataDownload DD;
        Order Ord;
        internal Calc(Order order, DataDownload dD)
        {
            DD = dD;
            Ord = order;
            InitializeComponent();
            AddToCheck(dD.FindRow("Анкер", order.Anker), dD.GetCost("1", order.Anker));
            AddToCheck(dD.FindRow("Бридж", order.Bridge), dD.GetCost("2", order.Bridge));
            AddToCheck(dD.FindRow("Вид_сборки", order.TypeBuild), dD.GetCost("3", order.TypeBuild));
            AddToCheck(dD.FindRow("Материал_корпуса", order.DecaMaterial), dD.GetCost("4", order.DecaMaterial));
            AddToCheck(dD.FindRow("Струны", order.Strings), dD.GetCost("5", order.Strings));
            AddToCheck(dD.FindRow("Материал_грифа", order.TypeGrif), dD.GetCost("6", order.TypeGrif));
            AddToCheck(dD.FindRow("Покраска", order.Colouring), dD.GetCost("7", order.Colouring));
            AddToCheck(dD.FindRow("Электронная_начинка", order.Electric), dD.GetCost("8", order.Electric));
            AddToCheck(dD.FindRow("Колки", order.Kolk), dD.GetCost("9", order.Kolk));
            AddToCheck(dD.FindRow("Звукосниматель", order.SoundGet), dD.GetCost("10", order.SoundGet));
            CheckTB.Text += "Итого : " + TotalCost.ToString() + " Российских Рублей";
        }
        void AddToCheck(string Description, int cost)
        {
            if (cost == 0 || Description == "") return;
            TotalCost += cost;
            CheckTB.Text += Description + cost.ToString() + " Российских Руб.\n";
        }
        private void Close_Click(object sender, RoutedEventArgs e) => Close();
        private void SendOrder_Click(object sender, RoutedEventArgs e)
        {
            DD.Send("ENDCALC");
            DD.Send("1");
            DD.Send(FIO.Text);
            DD.Send("2");
            DD.Send(Phone.Text);
            DD.Send("3");
            DD.Send(ColorLink.Text);
            DD.Send("4");
            DD.Send(Model3dLink.Text);
            DD.Send("5");
            DD.Send(Descriptions.Text);
            DD.Send("6");
            DD.Send(Ord.Kolk + "|" +
                Ord.SoundGet + "|" +
                Ord.Bridge + "|" +
                Ord.Anker + "|" +
                Ord.TypeBuild + "|" +
                Ord.TypeGrif + "|" +
                Ord.DecaMaterial + "|" +
                Ord.Strings + "|" +
                Ord.Colouring + "|" +
                Ord.Electric);
            DD.Send("ENDCLIENTINFO");
            //TODO Добавить окно информаирования
            MessageBox.Show("Ваш заказ успешно зарегистрирован под номером : " + DD.Receive() + ". С вами скоро свяжется наш оператор для уточнения заказа. Информацию об оплате вам сообщат дополнительно.");
            Close();
        }
        private void FIO_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) { if (FIO.Text == "ФИО") FIO.Text = ""; }
        private void Phone_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) { if (Phone.Text == "Телефон") Phone.Text = ""; }
        private void ColorLink_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) { if (ColorLink.Text == "Ссылка на пример окраски(если нужно)") ColorLink.Text = ""; }
        private void Model3dLink_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) { if (Model3dLink.Text == "Ссылка на 3D - модель желаемой гитары(не обязательно)") Model3dLink.Text = ""; }
        private void Model3dLink_Copy_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) { if (Descriptions.Text == "Дополнительные пожелания") Descriptions.Text = ""; }
    }
}
