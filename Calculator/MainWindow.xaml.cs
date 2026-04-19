using System;
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

namespace CalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _firstNumber = 0;
        private string _operator = "";
        private bool _isNewEntry = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            string digit = ((Button)sender).Content.ToString();

            if (_isNewEntry || Display.Text == "0")
            {
                Display.Text = digit;
                _isNewEntry = false;
            }
            else
            {
                Display.Text += digit;
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            _firstNumber = double.Parse(Display.Text);
            _operator = ((Button)sender).Content.ToString();
            _isNewEntry = true;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (_operator == "") return;

            double secondNumber = double.Parse(Display.Text);
            double result = _operator switch
            {
                "+" => _firstNumber + secondNumber,
                "-" => _firstNumber - secondNumber,
                "*" => _firstNumber * secondNumber,
                "/" => secondNumber != 0 ? _firstNumber / secondNumber : double.NaN,
                _ => 0
            };

            Display.Text = double.IsNaN(result) ? "Error" : result.ToString();
            _operator = "";
            _isNewEntry = true;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            _firstNumber = 0;
            _operator = "";
            _isNewEntry = true;
        }
    }
}