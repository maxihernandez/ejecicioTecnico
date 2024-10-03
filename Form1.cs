using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace EvaluacionTecnica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Cambia la cadena de conexión según tu base de datos
        private string connectionString = "Server=MAXPC\\MAXISQL;Database=EvaluacionTecnica;Integrated Security=True;";


        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("AsignarSaldos", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Crear un DataAdapter para llenar el DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);



                    // Mostrar resultados en DataGridView
                    ResultadoSP.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void ResultadoSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
