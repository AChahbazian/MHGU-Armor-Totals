using System;
using System.Windows;
using HtmlAgilityPack;

namespace MHGU_Armor_Totals
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

        private void btnGetTotals_Click(object sender, RoutedEventArgs e)
        {
            // Clear listbox and declare function variables.
            lstMaterials.Items.Clear();
            HtmlWeb web;
            HtmlDocument doc;
            try
            {
                web = new HtmlWeb();
                doc = web.Load(txtURL.Text);
            }
            catch (Exception)
            {
                lstMaterials.Items.Add("Error loading information.");
                return;
            }

            // Get table with material cost.
            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//*[@id=\"app\"]/div[2]/div[1]/div[2]/div[2]/div/div[5]/table"))
            {
                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    foreach (HtmlNode cell in row.SelectNodes("th|td"))
                    {
                        lstMaterials.Items.Add(cell.InnerText);
                    }
                }
            }
        }
    }
}
