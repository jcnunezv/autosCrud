using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formularioautos.Cars
{
    public class Conexion
    {
        
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection("Server=localhost; port=3306; Database=autosecotec; User id=root; Password=");

            conectar.Open();
            return conectar;


        }

      

    }
}
