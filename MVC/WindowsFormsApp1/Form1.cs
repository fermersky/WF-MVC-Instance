using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers;
using WindowsFormsApp1.Views;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form, IView
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Controller controller;

        public Controller Controller
        {
            get { return controller; }
            set
            {
                if (controller == value) return;
                if (controller != null)
                    UnBindFromModel(controller);
                controller = value;
                BindToModel(controller);
            }
        }

        public void BindToModel(Controller controller)
        {
            controller.Model.PropertyChanged += OnModelChanged;
        }

        public void UnBindFromModel(Controller controller)
        {
            controller.Model.PropertyChanged -= OnModelChanged;
        }

        private void OnModelChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateBnd();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controller.Load();
            UpdateBnd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller.Add(new Person { Name = textBox1.Text, Surname = textBox2.Text, Age = Convert.ToInt32(textBox3.Text) });
            UpdateBnd();
        }

        public void UpdateBnd()
        {
            comboBox1.DataSource = null;
            comboBox1.DataSource = Controller.Model.Persons;
            comboBox1.DisplayMember = "Surname";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                Person pers = (Person)comboBox1.SelectedItem;
                textBox1.Text = pers.Name;
                textBox2.Text = pers.Surname;
                textBox3.Text = pers.Age.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedPersonIndex = 0;
            if (comboBox1.SelectedIndex != -1)
            {
                selectedPersonIndex = comboBox1.SelectedIndex;
            }
        
            Person pers = new Person { Name = textBox1.Text, Surname = textBox2.Text, Age = Convert.ToInt32(textBox3.Text) };
            Controller.Edit(pers, selectedPersonIndex);
            UpdateBnd();
        }
    }
}
