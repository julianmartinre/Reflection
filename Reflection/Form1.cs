using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reflection
{
    public partial class Form1 : Form
    {
        List<Persona> personas = new List<Persona>();
        List<Producto> productos = new List<Producto>();
        List<Asignatura> asignaturas = new List<Asignatura>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            personas.Add(new Persona() { Id = Guid.NewGuid(), Nombre = "Pedro", Apellido = "Sanchez", Nacimiento = new DateTime(1990,1,20), Sueldo = 1000000, Activo = true });
            personas.Add(new Persona() { Id = Guid.NewGuid(), Nombre = "Carla", Apellido = "Perez", Nacimiento = new DateTime(1992, 4, 10), Sueldo = 2000000, Activo = false });
        
            dgvPersonas.DataSource = personas;

            productos.Add(new Producto() { Id = Guid.NewGuid(), Nombre = "Notebook", Descripcion = "8gb", Precio = 200000 });
            productos.Add(new Producto() { Id = Guid.NewGuid(), Nombre = "Celular", Descripcion = "Android 10", Precio = 300000 });

            dgvProductos.DataSource = productos;

            asignaturas.Add(new Asignatura() { Id = Guid.NewGuid(), Nombre = "Ingeniería de Software" });
            asignaturas.Add(new Asignatura() { Id = Guid.NewGuid(), Nombre = "Trabajo de Diploma" });

            dgvAsignaturas.DataSource = asignaturas;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            FileManager.ExportCsv(personas, "personas.csv");
            FileManager.ExportCsv(productos, "productos.csv");
            FileManager.ExportCsv(asignaturas, "asignaturas.csv");
        }
    }
}
