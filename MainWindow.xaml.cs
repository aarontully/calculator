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

        private void btnNumber_Click(object sender, RoutedEventArgs e) {

            int selectedValue = 0;

            if(sender == btnZero) {
                selectedValue = 0;
            }
            else if (sender == btnOne) {
                selectedValue = 1;
            }
            else if (sender == btnTwo) {
                selectedValue = 2;
            }
            else if (sender == btnThree) {
                selectedValue = 3;
            }
            else if (sender == btnFour) {
                selectedValue = 4;
            }
            else if (sender == btnFive) {
                selectedValue = 5;
            }
            else if (sender == btnSix) {
                selectedValue = 6;
            }
            else if (sender == btnSeven) {
                selectedValue = 7;
            }
            else if (sender == btnEight) {
                selectedValue = 8;
            }
            else if (sender == btnNine) {
                selectedValue = 9;
            }

            if (lblResult.Content.ToString() == "0") {
                lblResult.Content = $"{selectedValue}";
            }
            else {
                lblResult.Content = $"{lblResult.Content}{selectedValue}";
            }
        }
    }
}
