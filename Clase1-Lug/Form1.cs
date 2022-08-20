using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase1_Lug
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Empleado emp = new Empleado();
            emp.Legajo = int.Parse(textBox1.Text);
            emp.Borrar();
            Enlazar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Empleado emp = new Empleado();
            emp.Legajo = int.Parse(textBox1.Text);
            emp.Nombre = textBox2.Text;
            emp.Sueldo = float.Parse(textBox3.Text);
            emp.Insertar();
            Enlazar();
        }

        void Enlazar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Empleado.Listar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Empleado emp = new Empleado();
            emp.Legajo = int.Parse(textBox1.Text);
            emp.Nombre = textBox2.Text;
            emp.Sueldo = float.Parse(textBox3.Text);
            emp.Editar();
            Enlazar();
        }
    }
}
