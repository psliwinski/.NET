using System.Windows;
using System.Windows.Controls;

namespace WPFCalculatorCSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ResultText.Text = string.Empty;
            OperationText.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = string.Empty;

            var button = sender as Button;

            var currentNumber = button.Name[button.Name.Length - 1];

            OperationText.Text += currentNumber;
        }
        

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var operation = OperationText.Text;
            if (ContainsOperation(operation))
            {
               OperationText.Text = CalculateResult(operation).ToString();
            }

            OperationText.Text += "+";
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            var operation = OperationText.Text;
            if (ContainsOperation(operation))
            {
                OperationText.Text = CalculateResult(operation).ToString();
            }
            OperationText.Text += "-";
        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            var operation = OperationText.Text;
            if (ContainsOperation(operation))
            {
                OperationText.Text = CalculateResult(operation).ToString();
            }
            OperationText.Text += "*";
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            var operation = OperationText.Text;
            if (ContainsOperation(operation))
            {
                OperationText.Text = CalculateResult(operation).ToString();
            }
            OperationText.Text += "/";
        }

        private void ButtonResult_Click(object sender, RoutedEventArgs e)
        {
            var operation = OperationText.Text;

            ResultText.Text = CalculateResult(operation).ToString();

            OperationText.Text += string.Empty;
        }

        private bool ContainsOperation(string operation) => operation.Contains('+') || operation.Contains('-') || operation.Contains('*') || operation.Contains('/');
        


        private long CalculateResult(string operation) 
        {
            if (operation.Contains('+'))
            {

                var elements = operation.Split('+');
                return long.Parse(elements[0]) + long.Parse(elements[1]);

            }
            if (operation.Contains('-'))
            {

                var elements = operation.Split('-');
                return long.Parse(elements[0]) - long.Parse(elements[1]);

            }
            if (operation.Contains('*'))
            {

                var elements = operation.Split('*');
                return long.Parse(elements[0]) * long.Parse(elements[1]);

            }
            if (operation.Contains('/'))
            {

                var elements = operation.Split('/');
                return long.Parse(elements[0]) / long.Parse(elements[1]);

            }

            return default;
        }
    }
}
