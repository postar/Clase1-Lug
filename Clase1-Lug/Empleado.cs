using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Clase1_Lug
{
    public class Empleado
    {
        private Acceso acceso = new Acceso();

        private int legajo;

        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private float sueldo;

        public float Sueldo
        {
            get { return sueldo; }
            set { sueldo = value; }
        }

        public void Insertar()
        {
            acceso.Abrir();
            string sql = "Insert into Empleado (legajo,nombre,sueldo) ";
            sql += "values (" + legajo.ToString() + ",'" + nombre + "'," + sueldo.ToString() + ")";
            acceso.Escribir(sql);
            acceso.Cerrar();
        }
        public void Editar()
        {
            acceso.Abrir();
            string sql = "update empleado set ";
            sql += " nombre = '" + nombre + "', sueldo =" + sueldo.ToString();
            sql += " where legajo = " + legajo.ToString();
            acceso.Escribir(sql);
            acceso.Cerrar();

        }
        public void Borrar()
        {
            acceso.Abrir();
            string sql = "delete from empleado";
            sql += " where legajo = " + legajo.ToString();
            acceso.Escribir(sql);
            acceso.Cerrar();
        }

        public static List<Empleado> Listar()
        {
            List<Empleado> empleados = new List<Empleado>();
            Acceso acceso = new Acceso();
            acceso.Abrir();
            SqlDataReader lector = acceso.Leer("Select * from empleado");
            while (lector.Read())
            {
                Empleado emp = new Empleado();
                emp.legajo = lector.GetInt32(0);
                emp.nombre = lector["nombre"].ToString();
                emp.sueldo = float.Parse(lector["sueldo"].ToString());
                empleados.Add(emp);
            }
            lector.Close();
            acceso.Cerrar();
            return empleados;
        }
    }
}