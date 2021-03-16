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
        SelectedOperator selectedOperator;

        public MainWindow() {
            InitializeComponent();

            btnAC.Click += BtnAC_Click;
            btnNegative.Click += BtnNegative_Click;
            btnPercent.Click += BtnPercent_Click;
            btnEquals.Click += BtnEquals_Click;
        }

        private void BtnEquals_Click(object sender, RoutedEventArgs e) {
            
            double newNumber;

            if (double.TryParse(lblResult.Content.ToString(), out newNumber)) {
                switch (selectedOperator) {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Minus(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Times(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }
            }

            lblResult.Content = result.ToString();
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

            if(sender == btnTimes) {
                selectedOperator = SelectedOperator.Multiplication;
            }
            else if (sender == btnDivide) {
                selectedOperator = SelectedOperator.Division;
            }
            else if (sender == btnPlus) {
                selectedOperator = SelectedOperator.Addition;
            }
            else if (sender == btnMinus) {
                selectedOperator = SelectedOperator.Subtraction;
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

        private void btnDot_Click(object sender, RoutedEventArgs e) {

            if (lblResult.Content.ToString().Contains(".")) {
                //do nothing
            }
            else {
                lblResult.Content = $"{lblResult.Content}.";
            }
        }
    }

    public enum SelectedOperator {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class SimpleMath {
        public static double Add(double n1, double n2) {
            return n1 + n2;
        }

        public static double Minus(double n1, double n2) {
            return n1 - n2;
        }

        public static double Times(double n1, double n2) {
            return n1 * n2;
        }

        public static double Divide(double n1, double n2) {

            if(n2 == 0) {
                MessageBox.Show("Division by 0 is not Supported", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            return n1 / n2;
        }
    }
}
