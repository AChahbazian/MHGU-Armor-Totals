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

            // Get first row of the materials table contents.
            //var table = doc.DocumentNode.SelectSingleNode("//table[contains(@class, 'table table-sm\') and .//th//text()[contains(., \'Lv\')]]").InnerHtml;
            HtmlNode table = doc.DocumentNode.SelectSingleNode("//*[@id=\"app\"]/div[2]/div[1]/div[2]/div[2]/div/div[5]/table");
            HtmlNodeCollection rows = table.SelectNodes("tr");
            HtmlNode firstRow = rows[1];

            // Checking the raw data
            lstMaterials.Items.Add(firstRow.InnerHtml);

            /*
            // Load data from item table
            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table.table-sm"))
            {
                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    lstMaterials.Items.Add(row.InnerText.Trim('\n', ' '));
                }
            }
            */
        }
    }
}
