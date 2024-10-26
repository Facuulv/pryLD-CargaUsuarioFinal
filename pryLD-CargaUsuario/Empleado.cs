using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryLD_CargaUsuario
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Puesto { get; set; }
        public string Salario { get; set; }
        public string Vacaciones { get; set; }
        public DateTime Fecha { get; set; }

        public Empleado (string nombre, string apellido, string documento, string puesto, string salario, string vacaciones, DateTime fecha)
        {
            Nombre = nombre;
            Apellido = apellido;
            Documento = documento;
            Puesto = puesto;
            Salario = salario;
            Vacaciones = vacaciones;
            Fecha = fecha;
        }

        public Dictionary<string, object> EmpleadoDicc()
        {
            Dictionary<string, object> nuevoEmp = new Dictionary<string, object>();
            nuevoEmp["nombre"] = Nombre;
            nuevoEmp["apellido"] = Apellido;
            nuevoEmp["documento"] = Documento;
            nuevoEmp["puesto"] = Puesto;
            nuevoEmp["salario"] = Salario;
            nuevoEmp["vacaciones"] = Vacaciones;
            nuevoEmp["fecha"] = Fecha;

            return nuevoEmp;
        }
    }
}
