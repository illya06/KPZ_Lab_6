using KPZ_Lab_6.Models;
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

namespace KPZ_Lab_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Employee> userData;

        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void LoadTable_Click(object sender, RoutedEventArgs e)
        {
            using (PracticeContext db = new PracticeContext())
            {
                userData = db.Employees.ToList();
            }
            table.ItemsSource = userData;
        }

        private void table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void table_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new PracticeContext())
            {
                var employee = db.Employees.Select(x => x).OrderByDescending(x => x.EmpNo).First();

                var newEmpl = new Employee();

                newEmpl.DeptNo = dept.Text;
                newEmpl.EmpFname = fn.Text;
                newEmpl.EmpLname = ln.Text;
                newEmpl.EmpNo = employee.EmpNo + 1;

                db.Employees.Add(newEmpl);

                db.SaveChanges();
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new PracticeContext())
            {
                var employee = db.Employees.Where(x => x.EmpNo == Int32.Parse(numb.Text)).Select(x => x).First();

                if (employee != null)
                {
                    employee.EmpFname = fn.Text;
                    employee.EmpLname = ln.Text;
                    employee.DeptNo = dept.Text;
                }

                db.SaveChanges();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new PracticeContext())
            {
                var employee = db.Employees.Where(x => x.EmpNo == Int32.Parse(numb.Text)).Select(x => x).First();

                if (employee != null)
                {
                    db.Employees.Remove(employee);
                }

                db.SaveChanges();
            }
        }
    }
}
