using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TstCad.Models
{
    public class PessoaModel
    {
        // Campos ou atributos da classe (campos do banco de dados):
        [DisplayName("ID")]
        public int PessoaId { get; set; }
        [DisplayName("Nome")]
        public string NomePessoa { get; set; }
        [DisplayName("E-Mail")]
        public string EmailPessoa { get; set; }
        [DisplayName("Telefone")]
        public string TelefonePessoa { get; set; }

        // Criar CONSTANTE para conexão com banco:
        readonly string connectionString = @"Data Source=DESKTOP-U84PPK5\SQLEXPRESS;Initial Catalog=MeuBD;Integrated Security=True";

        public DataTable Listar()
        {
            DataTable tblPessoa = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter("SELECT * FROM tb_Pessoa", sqlCon);
                sqlDA.Fill(tblPessoa);
            }
            return tblPessoa;
        }
        public void Salvar()
        {
            // Cria a conexão com BD:
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                // Abre a conexão com BD:
                sqlCon.Open();
                // Instrução SQL para execução no BD:
                SqlCommand sqlCmd = new SqlCommand(
                    "INSERT INTO tb_Pessoa VALUES(@NomePessoa, @EmailPessoa, @TelefonePessoa)", sqlCon
                    );
                // Atribuir dados aos caampos (ou parâmetros da instrução SQL):
                sqlCmd.Parameters.AddWithValue("@NomePessoa", NomePessoa);
                sqlCmd.Parameters.AddWithValue("@EmailPessoa", EmailPessoa);
                sqlCmd.Parameters.AddWithValue("@TelefonePessoa", TelefonePessoa);
                // Executar o comando no SQL:
                sqlCmd.ExecuteNonQuery();
            }
        }
    }
}

