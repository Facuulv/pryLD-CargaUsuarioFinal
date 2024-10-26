using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryLD_CargaUsuario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Empleados ListaDeEmpleados = new Empleados();

        List<string> trabajos = new List<string>() { "Back-End", "Front-End", "Developer", "Project Manager" };
        List<string> col = new List<string>() { "Nombre", "Apellido", "DNI", "Profesion", "Salario", "Vacaciones", "Fecha" };
        List<Dictionary<string, object>> empleados = new List<Dictionary<string, object>>();
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvEmpleados.Rows.Clear();
            dgvEmpleados.Columns.Clear();
            numSal.Maximum = 15000;

            foreach (string c in col)
            {
                dgvEmpleados.Columns.Add($"col{col.IndexOf(c)}", c);
            }

            foreach (string t in trabajos)
            {
                cmbTrabajo.Items.Add(t);
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            string nom = txtNombre.Text;
            string ap = txtApellido.Text;
            string dni = txtDni.Text.ToString();
            string puesto = cmbTrabajo.SelectedItem.ToString();
            string sal = numSal.Value.ToString();
            string vac = numVac.Value.ToString();
            DateTime fecha = dtpFecha.Value;

            if (nom != "" && ap != "" && dni != "")
            {
                if (puesto != "" && sal != null && vac != null)
                {
                    if (ListaDeEmpleados.VerificarDni(dni))
                    {
                        Empleado nuevoEmpleado = new Empleado(nom, ap, dni, puesto, sal, vac, fecha);

                        /*Dictionary<string, object> usuario = new Dictionary<string, object>();                       
                        usuario.Add("nombre", nom);
                        usuario.Add("apellido", ap);
                        usuario.Add("dni", dni);
                        usuario.Add("puesto", puesto);
                        usuario.Add("sal", sal);
                        usuario.Add("vac", vac);
                        usuario.Add("fecha", fecha);
                        empleados.Add(usuario);*/

                        if (ListaDeEmpleados.empleados.Count >= 0)
                        {
                            //usuario = empleados[empleados.Count - 1];
                            //dgvEmpleados.Rows.Add(usuario["nombre"], usuario["apellido"], usuario["dni"], usuario["puesto"], usuario["sal"], usuario["vac"], usuario["fecha"]);
                            ListaDeEmpleados.AgregarEmpleado(nuevoEmpleado);
                            dgvEmpleados.Rows.Clear();
                            ListaDeEmpleados.Imprimir(dgvEmpleados);
                            Limpiar();
                        }
                    } else
                    {
                        MessageBox.Show("El dni ya se encuentra cargado", "Atencion");
                        Limpiar();
                    }
                } else
                {
                    MessageBox.Show("Debe cargar todos los datos", "Atencion");
                }
            } else {
                MessageBox.Show("Debe cargar todos los datos", "Atencion");
            }

        }

        /*public bool Verif(string dni)
        {
            foreach(Dictionary<string, object> emp in empleados)
            {
                if (emp["dni"].ToString() == dni)
                {
                    return false;
                }                
            }
            return true;
        }*/

        public void Limpiar()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            cmbTrabajo.SelectedIndex = 0;
            numSal.Value = 0;
            numVac.Value = 0;
        }

        //Controlar si ya existe el puesto o no
        public bool ControlPuesto(string nuevoP)
        {
            bool resultado = false;
            trabajos.ForEach(trabajo =>
            {
                if (trabajo.Contains(nuevoP))
                {
                    resultado = true;
                }
            });
            return resultado;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nuevoE = txtNuevo.Text;
            if (!ControlPuesto(nuevoE))
            {
                trabajos.Add(nuevoE);
                cmbTrabajo.Items.Add(nuevoE);
                MessageBox.Show("Se ha cargado el nuevo puesto de trabajo", "Atencion");
                txtNuevo.Text = "";
            } else
            {
                MessageBox.Show("El puesto ya se encuentra cargado", "Error");
                txtNuevo.Text = "";
            }
            /*if (!trabajos.Contains(nuevoE))
            {
                trabajos.Add(nuevoE);
                cmbTrabajo.Items.Add(nuevoE);
                MessageBox.Show("Se ha cargado el nuevo puesto de trabajo", "Atencion");
                txtNuevo.Text = "";
            } else
            {
                MessageBox.Show("El puesto ya se encuentra cargado", "Error");
                txtNuevo.Text = "";
            }*/
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string doc = txtEliminar.Text;
            if (!ListaDeEmpleados.VerificarDni(doc))
            {
                ListaDeEmpleados.EliminarEmp(doc);
                dgvEmpleados.Rows.Clear();
                ListaDeEmpleados.Imprimir(dgvEmpleados);
                txtEliminar.Text = "";
            } else
            {
                MessageBox.Show($"El documento {doc} no existe en los registros", "Error");
                txtEliminar.Text = "";
            }            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
