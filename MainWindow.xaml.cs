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

namespace Calculator {

    public partial class MainWindow : Window {

        double lastNumber;
        double result;

        public MainWindow() {
            InitializeComponent();

            btnAC.Click += BtnAC_Click;
            btnNegative.Click += BtnNegative_Click;
            btnPercent.Click += BtnPercent_Click;
            btnEquals.Click += BtnEquals_Click;
        }

        private void BtnEquals_Click(object sender, RoutedEventArgs e) {
            
        }

        private void BtnPercent_Click(object sender, RoutedEventArgs e) {
            if (double.TryParse(lblResult.Content.ToString(), out lastNumber)) {
                lastNumber = lastNumber / 100;
                lblResult.Content = lastNumber.ToString();
            }
        }

        private void BtnNegative_Click(object sender, RoutedEventArgs e) {
            if(double.TryParse(lblResult.Content.ToString(), out lastNumber)) {
                lastNumber = lastNumber * -1;
                lblResult.Content = lastNumber.ToString();
            }
        }

        private void BtnAC_Click(object sender, RoutedEventArgs e) {
            lblResult.Content = "0";
        }

        private void btnOperation_Click(object sender, RoutedEventArgs e) {
            if (double.TryParse(lblResult.Content.ToString(), out lastNumber)) {
                lblResult.Content = "0";
            }
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e) {

            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if (lblResult.Content.ToString() == "0") {
                lblResult.Content = $"{selectedValue}";
            }
            else {
                lblResult.Content = $"{lblResult.Content}{selectedValue}";
            }
        }
    }
}
