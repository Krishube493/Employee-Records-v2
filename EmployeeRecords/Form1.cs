using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace EmployeeRecords
{
    public partial class mainForm : Form
    {
        List<Employee> employeeDB = new List<Employee>();

        public mainForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee(idInput.Text, fnInput.Text, 
                lnInput.Text, dateInput.Text, salaryInput.Text);

            employeeDB.Add(emp);

            outputLabel.Text = "New Employee Added";
            ClearLabels();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
           
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            outputLabel.Text = "";
            foreach (Employee emp in employeeDB)
            {
                outputLabel.Text += emp.id + " " + emp.firstName + " " + emp.lastName + " "
                    + emp.date + " " + emp.salary + "\n";
            }
        }

        private void ClearLabels()
        {
            idInput.Text = "";
            fnInput.Text = "";
            lnInput.Text = "";
            dateInput.Text = "";
            salaryInput.Text = "";
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        public void loadDB()
        {
            
        }

        public void saveDB()
        {
            XmlWriter writer = XmlWriter.Create("Resources/EmployeeData.xml", null);

            writer.WriteStartElement("Employee");

            foreach (Employee emp in employeeDB)
            {
                writer.WriteElementString("id", emp.id);
                writer.WriteElementString("firstName", emp.firstName);
                writer.WriteElementString("lastName", emp.lastName);
                writer.WriteElementString("startDate", emp.date);
                writer.WriteElementString("salary", emp.salary);
            }
        }
    }
}
