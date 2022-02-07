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
using System.IO;

namespace Binding
{
    public partial class MainWindow : Window
    {
        const string path = "data.txt";
        const char sep = ';';
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Write_Button_Click(object sender, RoutedEventArgs e)
        {

            //foreach (var item in Data.Children)
            //{
                
            //}

            try
            {
                Employee employee = new Employee(TBName.Text, TBSurname.Text, InputDoB.DisplayDate, InputEdu.SelectedIndex, TBOccupation.Text, Convert.ToDouble(TBGrossSalary.Text));
                File.WriteAllText(path, employee.ToString());
                TBGrossSalary.Background = Brushes.White;
            }
            catch 
            {
                Debug.Content = "Incorrect format";
                TBGrossSalary.Background = Brushes.Red;
            }
        }

        private void Read_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] read = File.ReadAllText(path).Split(sep);
                TBName.Text = read[0];
                TBSurname.Text = read[1];
                InputDoB.SelectedDate = DateTime.Parse(read[2]);
                InputEdu.SelectedIndex = Convert.ToInt32(read[3]);
                TBOccupation.Text = read[4];
                TBGrossSalary.Text = read[5];
            }
            catch { Debug.Content = "Read failed"; }

        }
    }



    public class Person
    {
        public Person(string name, string surname, DateTime dateOfBirth)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class Employee : Person
    {
        public Employee(string name, string surname, DateTime dateOfBirth, int education, string occupation, double grossSalary) : base(name, surname, dateOfBirth)
        {
            Education = education;
            Occupation = occupation;
            GrossSalary = grossSalary;
        }

        public int Education { get; set; }
        public string Occupation { get; set; }
        public double GrossSalary { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name + ";");
            sb.Append(Surname + ";");
            sb.Append(DateOfBirth.ToString() + ";");
            sb.Append(Education.ToString() + ";");
            sb.Append(Occupation + ";");
            sb.Append(GrossSalary.ToString() + ";");

            return sb.ToString();
        }
    }


}
