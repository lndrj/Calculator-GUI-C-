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

namespace Kalkulacka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Operace operace = new Operace();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            double firstNumber, secondNumber;
            if (!double.TryParse(firstNumberTextBox.Text, out firstNumber) || !double.TryParse(secondNumberTextBox.Text, out secondNumber))
            {
                resultTextBlock.Text = "Neplatný vstup.";
                return;
            }
            string operatorSymbol = operatorTextBox.Text;
            double result = 0;
            switch (operatorSymbol)
            {
                case "+":
                    result = operace.Add(firstNumber, secondNumber);
                    break;
                case "-":
                    result = operace.Minus(firstNumber, secondNumber);
                    break;
                case "*":
                    result = operace.Multiply(firstNumber, secondNumber);
                    break;
                case "/":
                    try
                    {
                        result = operace.Divide(firstNumber, secondNumber);
                    }
                    catch (ArgumentException ex)
                    {
                        resultTextBlock.Text = ex.Message;
                        return;
                    }
                    break;
                default:
                    resultTextBlock.Text = "Neplatný operátor.";
                    return;
            }

            resultTextBlock.Text = $"Výsledek: {result}";
        }
        }
    }
