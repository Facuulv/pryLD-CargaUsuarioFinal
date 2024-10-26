using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryLD_CargaUsuario
{
    public class Empleados
    {
        public List<Dictionary<string, object>> empleados = new List<Dictionary<string, object>>();

        public void AgregarEmpleado(Empleado emp)
        {
            //Agregar a la lista empleados un empleado convirtiendolo a diccionario
            empleados.Add(emp.EmpleadoDicc());
        }

        public void Imprimir(DataGridView grilla)
        {
            empleados.ForEach(emp =>
            {
                grilla.Rows.Add(emp["nombre"], emp["apellido"], emp["documento"], emp["puesto"], emp["salario"], emp["vacaciones"], emp["fecha"]);
            });
        }

        public bool VerificarDni(string dni)
        {
            bool res = true;
            empleados.ForEach(emp =>
            {
                if (emp["documento"].ToString() == dni)
                {
                    res = false;
                }
            });
            return res;
        }

        public void EliminarEmp(string dni)
        {
            //Itera del fin al principio para no alterar los indices de la lista de dicc empleados
            for (int i = empleados.Count - 1; i >= 0; i--)
            {
                if (empleados[i]["documento"].ToString() == dni)
                {
                    empleados.RemoveAt(i);
                }
            }
        }
    }
}
