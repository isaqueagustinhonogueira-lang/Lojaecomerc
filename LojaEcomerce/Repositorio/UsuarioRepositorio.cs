using LojaEcomerce.Interface;
using LojaEcomerce.Models;
using MySql.Data.MySqlClient;

namespace LojaEcomerce.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        //variavel privada e somente leitura para
        //receber a conexão do banco de dados
        private readonly string _connectionString;

        //consultar para inicializar a conaxão do banco
        public UsuarioRepositorio(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Conexao");
        }

        public LoginViewModel Validar(string email, string senha)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            var sql = "SELECT * FROM tb_Usuario WHERE Email AND senha = @email @senha";
            var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new LoginViewModel
                {
                    id = Convert.ToInt32(reader["id"]),
                    Nome = reader["Nome"].ToString(),
                    Email = reader["email"].ToString(),
                    Nivel = reader["Nivel"].ToString()
                };
            }
            return null;
    

        }

    }
}
