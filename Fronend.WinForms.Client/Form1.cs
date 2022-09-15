using Backend.Services.EF;
using Backend.Shared.Enums;
using BackEnd.DDD;
using BackEnd.DDD.Models;
using Microsoft.EntityFrameworkCore;

namespace Fronend.WinForms.Client
{
    public partial class Form1 : Form
    {
        private CustomerService _context;
        private Customers _customers;

        public Form1(CustomerService accessDbContext, Customers customers)
        {
            this._context = accessDbContext;
            _customers = customers;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetCustomers();
            Cities();
        }

        // Populate ComboBox
        public void Cities()
        {
            CityEnum cityEnum = new CityEnum();
            comboBox1.DataSource = Enum.GetValues(typeof(CityEnum));
        }

        //C
        public Customers NewCustomer()
        {
            try
            {
                _customers = new Customers();
                _customers.CustomerName = textBox2.Text;

                string city = comboBox1.Text;
                _customers.City = city;

                _context.NewCustomer(_customers);

                return _customers;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

            return _customers;
        }

        //R all Customers
        public List<Customers> GetCustomers()
        {
            return _context.GetCustomers();
        }

        //R Customer by Id
        public List<Customers> GetCustomerById(Guid Id)
        {
            return _context.GetCustomerId(Id);
        }

        //U
        public Customers UpdateCustomer()
        {
            Customers toBeUpdated = new Customers();
            toBeUpdated.CustomerName = textBox2.Text;
            toBeUpdated.City = comboBox1.Text;

            _context.UpdateCustomer(Guid.Parse(textBox1.Text), toBeUpdated);
            return _customers;
        }

        //D
        public void DeleteCustomer(Guid Id)
        {
            var customers = _context.GetCustomerById(Id);

            if (customers == null)
            {
                throw new NullReferenceException("Nothing to Delete.");
            }

            _context.DeleteCustomer(customers.Id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewCustomer();
            dataGridView1.DataSource = GetCustomers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateCustomer();
            dataGridView1.DataSource = GetCustomers();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id = Guid.Parse(textBox1.Text.ToString());
            DeleteCustomer(id);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                dataGridView1.DataSource = GetCustomers();
            } else
            {
                Guid? id = Guid.Parse(textBox1.Text);
                dataGridView1.DataSource = _context.GetCustomerId(id);
            }
            
        }
    }
}