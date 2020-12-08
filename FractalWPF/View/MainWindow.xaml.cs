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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FractalWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void create_project(object sender, RoutedEventArgs e)
        {
            ChoseProjectTypeWindow choseProjectTypeWindow = new ChoseProjectTypeWindow();
            this.Hide();

            choseProjectTypeWindow.Show();
        }

        private void open_project(object sender, RoutedEventArgs e)
        {

        }

        private void exit(object sender, RoutedEventArgs e)
        {

        }

        private void faq(object sender, RoutedEventArgs e)
        {

        }
    }
}
