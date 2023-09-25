using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // Libreria para lectura y ecritura de archivos


namespace Formulario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnGuardar_Click_Click(object sender, EventArgs e)
        {
            // Obtener los datos de los TextBox
            string nombres = tbNombre.Text;
            string apellidos = tbApellidos.Text;
            string edad = tbEdad.Text;
            string estatura = tbEstatura.Text;
            string telefono = tbTelefono.Text;


            // Obtener el género seleccionado
            string genero = "";
            if (rbHombre.Checked)
            {
                genero = "Hombre";
            }
            else if (rbMujer.Checked)
            {
                genero = "Mujer";
            }

            // Crear una cadena con los datos
            string datos = $"Nombres: {nombres}\r\nApellidos: {apellidos}\r\nTelefono: {telefono} kg\r\nEstatura: {estatura} cm\r\nEdad: {edad} años\r\nGénero: {genero}";

            // Guardar los datos en un archivo de texto
            string rutaArchivo = "C:/Users/ygbal/Documents/datos.txt";
            //File.WriteAllText(rutaArchivo, datos);
            // Verificar si el archivo ya existe
            bool archivoExiste = File.Exists(rutaArchivo);

            using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
            {
                if (archivoExiste)
                {
                    // Si el archivo existe, añadir un separador antes del nuevo registro
                    writer.WriteLine();
                }

                writer.WriteLine(datos);
            }

            // Mostrar un mensaje con los datos capturados
            MessageBox.Show("Datos guardados con éxito:\n\n" + datos, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            // Limpiar los controles después de guardar
            tbNombre.Clear();
            tbApellidos.Clear();
            tbEstatura.Clear();
            tbTelefono.Clear();
            tbEdad.Clear();
            rbHombre.Checked = false;
            rbMujer.Checked = false;

        }
    }
}
