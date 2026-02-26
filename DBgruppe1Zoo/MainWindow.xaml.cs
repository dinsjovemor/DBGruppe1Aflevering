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
        DyrRepository dyrRepo = new DyrRepository();
        FoderplanRepository foderplanRepo = new FoderplanRepository();

        public MainWindow()
        {
            InitializeComponent();

            dgDyr.ItemsSource = dyrRepo.GetAll();

            dgFoderplan.ItemsSource = foderplanRepo.GetAll();
        }

        private void btnNy_Click(object sender, RoutedEventArgs e)
        {
            txtAlder.Clear();
            txtArt.Clear();
            txtFoderplanID.Clear();
            txtSikkerhedskrav.Clear();
            txtType.Clear();

            btnSlet.IsHitTestVisible = false;
            btnSlet.Opacity = 0.5;
        }

        /// <summary>
        /// Gem metode der opretter et nyt Dyr objekt med brugerens input og tilføjer det i vores Datagrid. 
        /// </summary>
        private void btnGem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dyr d = new Dyr { Art = txtArt.Text, Type = txtType.Text, Alder = Convert.ToInt32(txtAlder.Text), Sikkerhedskrav = Convert.ToInt32(txtSikkerhedskrav.Text), FoderplanId = Convert.ToInt32(txtFoderplanID.Text) };
                dyrRepo.Add(d);
                dgDyr.ItemsSource = dyrRepo.GetAll(); //Genindlæser fra databasen
            }
            catch
            {
                MessageBox.Show("Indtast venligst et gyldigt dyr");
            }
            
        }

        private void btnSlet_Click(object sender, RoutedEventArgs e)
        {
            if (dgDyr.SelectedItem is Dyr picked)
            {
                if (MessageBox.Show($"Er du sikker på at du vil slette {picked.Art}?", "Slet Dyr", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    dyrRepo.Delete(picked);
                    dgDyr.ItemsSource = dyrRepo.GetAll();
                }
            }
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

        private void txtFoderplanID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dgDyr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnSlet.IsHitTestVisible = true;
            btnSlet.Opacity = 1;
        }
    }
}