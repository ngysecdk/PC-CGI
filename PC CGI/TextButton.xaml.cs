using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PC_CGI
{
    /// <summary>
    /// Логика взаимодействия для TextButton.xaml
    /// </summary>
    public partial class TextButton : UserControl
    {
        string tableName = "";
        public string TableName { set => tableName = value; get => tableName; }
        public event EventHandler Click;
        public ImageSource NormalState { set => Normal.Source = value; get => Normal.Source; }
        public ImageSource MovedState { set => Moved.Source = value; get => Moved.Source; }
        public ImageSource PressedState { set => Pressed.Source = value; get => Pressed.Source; }
        public TextButton() => InitializeComponent();
        private void Border_MouseEnter(object sender, MouseEventArgs e) => setVisibles(Visibility.Visible);
        private void Border_MouseLeave(object sender, MouseEventArgs e) => setVisibles(normal: Visibility.Visible);
        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) => setVisibles(pressed: Visibility.Visible);
        private void Border_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Click != null) Click(this, null);
            setVisibles(Visibility.Visible);
        }
        void setVisibles(Visibility moved = Visibility.Hidden, Visibility pressed = Visibility.Hidden, Visibility normal = Visibility.Hidden)
        {
            Moved.Visibility = moved; Pressed.Visibility = pressed; Normal.Visibility = normal;
        }
    }
}
