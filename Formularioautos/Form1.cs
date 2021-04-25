using Formularioautos.Cars;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularioautos
{
    public partial class Form1 : Form
    {
        public Carros pcarros;

        public Carros Carroactual { get;  set; }

       

        public Form1()

        {
            
        InitializeComponent();
            




    }
        public Carros Seleccionado { get; set; }

        public void RefrescarListado()
        {
            //refresca el listado que estan en las celdas
            MySqlDataAdapter _comando = new MySqlDataAdapter(String.Format(
               "SELECT id, marca, modelo, precio, estado FROM autos "), Conexion.ObtenerConexion());
            DataTable dt = new DataTable();
            _comando.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();


        }

        public void Limpiar()

        {
            //Limpia las cajas de Textos
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();

        }






        private void Form1_Load(object sender, EventArgs e)
        {
            //lista los datos en el data gridview
            dataGridView1.DataSource = Listar();
           

        }
        public static List<Carros> Listar()
        {
            //lista los datos que se ingresaron
            List<Carros> lista = new List<Carros>();

            MySqlCommand _comando = new MySqlCommand(String.Format(
                "SELECT id, marca, modelo, precio, estado FROM autos "), Conexion.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Carros pcarros = new Carros();

                pcarros.Id = _reader.GetString(0);
                pcarros.Marca = _reader.GetString(1);
                pcarros.Modelo = _reader.GetString(2);
                pcarros.Precio = _reader.GetString(3);
                pcarros.Estado = _reader.GetString(4);

                lista.Add(pcarros);

            }
            return lista;

        }
       
        

        private void button1_Click(object sender, EventArgs e)
        {
           
            //Boton agregar 
            Carros pcarros = new Carros();
            pcarros.Marca = textBox1.Text.Trim();
            pcarros.Modelo = textBox2.Text.Trim();
            pcarros.Precio = textBox3.Text.Trim();
            int res = pcarros.Agregar(pcarros);

            if (res > 0)
            {
                MessageBox.Show(" Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefrescarListado();
                Limpiar();
               
            }
            else
            {
                MessageBox.Show("No se pudo guardar", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Verifica si la conexion a la base de datos 
            Conexion.ObtenerConexion();
            MessageBox.Show(" Usted se ha conectado con éxito ");


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //permite que asigne las celdas para modicicar o eliminar
            textBox1.Text = dataGridView1.SelectedCells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedCells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedCells[3].Value.ToString();
            pcarros = new Carros();
            pcarros.Id = dataGridView1.SelectedCells[0].Value.ToString();
            pcarros.Marca = dataGridView1.SelectedCells[1].Value.ToString();
            pcarros.Modelo = dataGridView1.SelectedCells[2].Value.ToString();
            pcarros.Precio = dataGridView1.SelectedCells[3].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Refresca loslistado de las celdas
            //RefrescarListado();
            Refresh();
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            //funcio que modifica los datos
            pcarros.Marca = textBox1.Text;
            pcarros.Modelo = textBox2.Text;
            pcarros.Precio = textBox3.Text;


            if (pcarros.Modificar(pcarros) > 0)
            {
                MessageBox.Show("Los datos se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefrescarListado();
                Refresh();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            //elimina registros de la forma fisica
            if (MessageBox.Show("¿Está usted seguro que desea eliminar el registro de la tabla?", "Estás seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (pcarros.Eliminar(pcarros) > 0)
                {
                    MessageBox.Show("Eliminado correctamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarListado();

                }
                else
                {
                    MessageBox.Show("No se pudo eliminar", "no fue" +
                        "eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            else

                MessageBox.Show("se canceló la eliminación", "Eliminación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


        }

        private void button6_Click(object sender, EventArgs e)
        {

            //permite buscar 
            Carros buscar = new Carros();
           

            dataGridView1.DataSource = buscar.BuscarLista(textBox4.Text, textBox2.Text);

            if (dataGridView1.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
               

                this.Close();

            }
            else
                MessageBox.Show("Debe Seleccionar una Fila");



        }
    }




}
    

