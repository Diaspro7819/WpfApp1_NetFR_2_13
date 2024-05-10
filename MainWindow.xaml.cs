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
using CalcClassSS;

namespace WpfApp1_NetFR_2_13
{
    public partial class MainWindow : Window
    {
        private int memoryValue = 0; // Переменная для хранения значения памяти

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            textBoxExpression.Text = "";
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            string buttonText = ((Button)sender).Content.ToString();
            textBoxExpression.Text += buttonText;
        }
        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            string buttonText = ((Button)sender).Content.ToString();
            textBoxExpression.Text += " " + buttonText + " ";
        }
        private void Button_Equals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string expression = textBoxExpression.Text;
                int result = EvaluateExpression(expression);
                textBoxResult.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
        public int EvaluateExpression(string expression)
        {
            string[] tokens = expression.Split(' ');
            if (tokens.Length != 3)
            {
                throw new InvalidOperationException("Неверное выражение");
            }

            int operand1 = int.Parse(tokens[0]);
            int operand2 = int.Parse(tokens[2]);
            string operation = tokens[1];

            switch (operation)
            {
                case "+":
                    return CalcClassSS.Class1.Add(operand1, operand2);
                case "-":
                    return CalcClassSS.Class1.Subtract(operand1, operand2);
                case "*":
                    return CalcClassSS.Class1.Multiply(operand1, operand2);
                case "/":
                    return CalcClassSS.Class1.Divide(operand1, operand2);
                default:
                    throw new InvalidOperationException("Неверная операция");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // кнопка равно
            try
            {
                string expression = textBoxExpression.Text;
                int result = EvaluateExpression(expression);
                textBoxResult.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // кнопка mr - получить значение из памяти
            textBoxExpression.Text += memoryValue.ToString(); // Добавляем значение памяти в текстовое поле выражения

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // кнопка стереть
            if (textBoxExpression.Text.Length > 0)
            {
                textBoxExpression.Text = textBoxExpression.Text.Substring(0, textBoxExpression.Text.Length - 1);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // кнопка сброс
            textBoxExpression.Clear();
            textBoxResult.Clear();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            // m+
            int currentValue;
            if (int.TryParse(textBoxExpression.Text, out currentValue))
            {
                memoryValue += currentValue; // Добавляем текущее значение из текстового поля в память
            }
            else
            {
                MessageBox.Show("Неверное значение в текстовом поле");
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            // mc
            memoryValue = 0; // Обнуляем значение памяти

        }
    }
}
