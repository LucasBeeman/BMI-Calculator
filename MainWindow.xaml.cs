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

namespace BMI_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public class Customer
        {
            public string lastName { get; set; }
            public string firstName { get; set; }
            public string phoneNumber { get; set; }
            public int heightInches { get; set; }
            public int weightLbs { get; set; }
            public int custBMI { get; set; }
            public string statusTitle { get; set; }

            public int CustomBMI(int weight, int height)
            {
                return weight * 703 / (height * height);
            }
            public Customer(string LastName, string FirstName, string PhoneNumber, int HeightInches, int WeightLbs )
            {
                this.lastName = LastName;
                this.firstName = FirstName;
                this.phoneNumber = PhoneNumber;
                this.heightInches = HeightInches;
                this.weightLbs = WeightLbs;
                this.custBMI = CustomBMI(weightLbs, heightInches);
                statusTitle = "Unknown Error";
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void xClearBtn_Click(object sender, RoutedEventArgs e)
        {
            xPhoneNumberBox.Text = "";
            xFirstNameBox.Text = "";
            xLastNameBox.Text = "";
            xHeightBox.Text = "";
            xWeightBox.Text = "";
        }

        private void xExitBtn_Click(object sender, RoutedEventArgs e)
        {
           Close();
        }
        private void xSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer customerOne = new Customer(xLastNameBox.Text, xFirstNameBox.Text, xPhoneNumberBox.Text, Int32.Parse(xHeightBox.Text), Int32.Parse(xWeightBox.Text));
                //MessageBox.Show($"The customer's name is {customerOne.firstName} {customerOne.lastName} and they can be reached at {customerOne.phoneNumber}. They are {customerOne.heightInches} inches tall. Their weight is {customerOne.weightLbs} lbs.");
                xYourBMIResults.Text = customerOne.custBMI.ToString();
                //MessageBox.Show($"{customerOne.weightLbs} {customerOne.heightInches} {customerOne.custBMI}");
                if (customerOne.custBMI < 18.5)
                {
                    xBMIMessage.Text = "According to CDC.gov BMI Calculator you are" +
                        " underweight";
                    customerOne.statusTitle = "Underweight";
                }
                else if (customerOne.custBMI < 24.9)
                {
                    xBMIMessage.Text = "According to CDC.gov BMI Calculator you are of" +
                        " healthy weight";
                    customerOne.statusTitle = "Healthy";
                }
                else if (customerOne.custBMI < 29.9)
                {
                    xBMIMessage.Text = "According to CDC.gov BMI Calculator you are" +
                        " overweight";
                    customerOne.statusTitle = "Overweight";
                }
                else
                {
                    xBMIMessage.Text = "According to CDC.gov BMI Calculator you are" +
                        "       Obese";
                    customerOne.statusTitle = "Obese";
                }
                xBMIHeader.Text = customerOne.statusTitle;
            }
            catch
            {
                MessageBox.Show("Invalid information... Try again.");
            }
                
        }
    }
}
