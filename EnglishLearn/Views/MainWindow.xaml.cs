using System.Windows;
using System.Windows.Controls;

namespace EnglishLearn.Views
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBox1.Text = "Введите слово";
            TextBox2.Text = "Введите перевод";
            TextBox3.Text = "Введите транскрипцию";
        }

        private void TextBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}
