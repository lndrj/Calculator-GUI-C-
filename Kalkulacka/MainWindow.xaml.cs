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


        private string firstNumber = "";
        private string operatorSymbol = "";
        private string secondNumber = "";

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string input = button.Content.ToString();

            if (input == "." && (operatorSymbol == "" || secondNumber != ""))
            {
                // Pokud se pokusíme přidat desetinnou tečku bez operátoru nebo v druhém čísle, ignorujeme ji.
                return;
            }

            if (!string.IsNullOrEmpty(operatorSymbol))
            {
                secondNumber += input;
            }
            else
            {
                firstNumber += input;
            }

            UpdateInputTextBox();
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;
            operatorSymbol = button.Content.ToString();
            UpdateInputTextBox();
        }
        
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (secondNumber != "")
            {
                secondNumber = secondNumber.Substring(0, secondNumber.Length - 1);
            }
            else if (operatorSymbol != "")
            {
                operatorSymbol = "";
            }
            else if (firstNumber != "")
            {
                firstNumber = firstNumber.Substring(0, firstNumber.Length - 1);
            }

            UpdateInputTextBox();
        }


        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            double num1, num2;
            if (double.TryParse(firstNumber, out num1) && double.TryParse(secondNumber, out num2))
            {
                double result = PerformOperation(num1, num2, operatorSymbol);
                inputTextBox.Text = result.ToString();
                firstNumber = result.ToString();
                operatorSymbol = "";
                secondNumber = "";
            }
            else
            {
                inputTextBox.Text = "Neplatný vstup.";
            }
        }

        private double PerformOperation(double num1, double num2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return operace.Add(num1,num2);
                case "-":
                    return operace.Minus(num1,num2);
                case "*":
                    return operace.Multiply(num1,num2);
                case "/":
                    if (num2 != 0)
                    {
                        return operace.Divide(num1,num2);
                    }
                    else
                    {
                        return double.NaN; // Chyba dělení nulou
                    }
                default:
                    return double.NaN; // Neplatný operátor
            }
        }

        private void UpdateInputTextBox()
        {
            inputTextBox.Text = firstNumber + "" + operatorSymbol + "" + secondNumber;
        }
    }
}