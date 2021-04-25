using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularioautos.Cars
{
    public class Carros
    {
      

   
        public string Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Precio { get; set; }
        public string Estado { get; set; }

   
    public Carros()
    {

    }

    public Carros(string pId, string pMarca, string pModelo, string pPrecio, string pEstado)
        {
            this.Id = pId;
            this.Marca = pMarca;
            this.Modelo = pModelo;
            this.Precio = pPrecio;
            this.Estado = pEstado;
        }


        public int Agregar(Carros Pcarros)
        {
            //funcion agregar esta puede agregar datos en los textbox
            int retorno = 0;
            MySqlConnection add = Conexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into autos (marca, modelo, precio) values ('{0}','{1}','{2}')",
            Pcarros.Marca, Pcarros.Modelo, Pcarros.Precio), add);
            retorno = comando.ExecuteNonQuery();
            add.Close();
            return retorno;
        }

        public int Modificar(Carros pCarros)
        {
            //funcion modificar permite modificar los campos que asigne
            int retorno = 0;

           MySqlConnection add = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update autos set marca='{0}', modelo='{1}', precio='{2}' where id={3}",
                pCarros.Marca, pCarros.Modelo, pCarros.Precio, pCarros.Id),add);
        
            retorno = comando.ExecuteNonQuery();

           add.Close();

            return retorno;
        }

        public int Eliminar(Carros pCarros)
        {
            //esta funcion permite eliminacion fisica los campos que sea asignado
            int retorno = 0;
            MySqlConnection add = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Delete from autos where id={0}", pCarros.Id), add);

            retorno = comando.ExecuteNonQuery();

            add.Close();

            return retorno;

        }

        public int Eliminacionlogica(Carros pCarros)
        {
            //eliminacion logica
            int retorno = 0;
            MySqlConnection add = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update autos set estado='ACTIVO' where id={0}",pCarros.Id), add);


            retorno = comando.ExecuteNonQuery();

            add.Close();

            return retorno;
        }
        public List<Carros> BuscarLista(string Pid, string Pmarca)
        {

       //BUSCARLISTAS
            List<Carros> lista = new List<Carros>();

            MySqlCommand _comando = new MySqlCommand(String.Format(
                "SELECT id, marca, modelo, precio, estado FROM autos Where id ='{0}' or marca ='{1}'",Pid,Pmarca)
              , Conexion.ObtenerConexion());
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

       
    }

}

    
