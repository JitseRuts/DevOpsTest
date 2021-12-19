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
using DevOpsTest.DAL;
using DevOpsTest.Models;

namespace DevOpsTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private QuoteRepository quoteRepository;
        private SortedSet<Quote> quotes;
        public MainWindow()
        {
            InitializeComponent();
            quoteRepository = new QuoteRepository();
            quotes = new SortedSet<Quote>(quoteRepository.GetQuotes());
            foreach (Quote quote in quotes)
            {
                string name = quote.Name;
                lstNames.Items.Add(name);
            }
        }

        private void ButtonAddQuote_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtQuote.Text) && !lstNames.Items.Contains(txtQuote.Text))
            {
                string name = txtQuote.Text;
                lstNames.Items.Add(name);
                Quote quote = new Quote { Name = name };
                quoteRepository.InsertQuote(quote);
                txtQuote.Clear();
            }
        }

        private void ButtonDeleteQuote_Click(object sender, RoutedEventArgs e)
        {
            lstNames.Items.RemoveAt
                (lstNames.Items.IndexOf(lstNames.SelectedItem));

        }

        private void lstNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
