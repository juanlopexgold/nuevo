using System.Data;
using System.Data.SqlClient;
using Interface;
using Samuel_integrado.Models;

namespace Implementation
{
    
    public class ModeloServices:IModeloService
    {
         private readonly string _connectionString;
            public ModeloServices(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task InsertarModelo(string nombre, string descripcion, bool estado)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("insertar_modelo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@Estado", estado);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ModificarModelo(int idModelo, string nombre, string descripcion, bool estado)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("modificar_modelo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdModelo", idModelo);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@Estado", estado);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Modelo>> BuscarModeloPorId(int id)
        {
            List<Modelo> modelos = new List<Modelo>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("buscar_modelo_Id", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdModelo", id);

                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            modelos.Add(new Modelo
                            {
                                IdModelo = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Estado = reader.GetBoolean(3),
                                FechaRegistro = reader.GetDateTime(4)
                            });
                        }
                    }
                }
            }

            return modelos;
        }

       public async Task<List<Modelo>> ListarModelos()
{
    List<Modelo> modelos = new List<Modelo>();

    using (SqlConnection conn = new SqlConnection(_connectionString))
    {
        using (SqlCommand cmd = new SqlCommand("listar_modelos", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;

            await conn.OpenAsync();
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    modelos.Add(new Modelo
                    {
                        IdModelo = reader.GetInt32(0), // Asegúrate de que este índice coincida con el orden de las columnas en el SELECT
                        Nombre = reader.GetString(1),
                        Descripcion = reader.GetString(2),
                        Estado = reader.GetBoolean(3),
                        FechaRegistro = reader.GetDateTime(4)
                    });
                }
            }
        }
    }

    return modelos;
}

        public async Task EliminarModelo(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("eliminar_modelo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdModelo", id);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }




    }






}