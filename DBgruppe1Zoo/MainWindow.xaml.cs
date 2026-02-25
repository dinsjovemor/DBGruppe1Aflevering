using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DBgruppe1Zoo.Repositories;

namespace DBgruppe1Zoo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DyrRepository dyrRepo = new DyrRepository();

            dgDyr.ItemsSource = dyrRepo.GetAll();

        }

        private void btnNy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSlet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtArt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtType_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtAlder_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtSikkerhedskrav_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}