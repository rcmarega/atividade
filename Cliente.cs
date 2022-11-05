using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AtividadeSala1
{
    class Cliente
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string cidade { get; set; }
        public string endereco { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string dataNascimento { get; set; }


        // método construtor p/ minha tabala.

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aluno\source\repos\AtividadeSala1\BdCliente.mdf;Integrated Security=True;Connect Timeout=30");
        // cria objeto de conexao 'con'.

        public List<Cliente> listacliente() // metodo do tipo lista
        {
            List<Cliente> li = new List<Cliente>();
            string sql = "SELECT * FROM Cliente";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cliente c = new Cliente();
                c.Id = (int)dr["Id"];
                c.nome = dr["nome"].ToString();
                c.cidade = dr["cidade"].ToString();
                c.endereco = dr["endereco"].ToString();
                c.celular = dr["celular"].ToString(); ;
                c.email = dr["email"].ToString();
                c.dataNascimento = dr["dataNascimento"].ToString();
                li.Add(c);
            }
            dr.Close();
            con.Close();
            return li;
        }

        public void Inserir(string nome, string cidade, string endereco, string celular, string email, string dataNascimento)
        {
            string sql = "INSERT INTO Cliente(nome,cidade,endereco,celular,email,dataNascimento) VALUES ('" + nome + "','" + cidade + "' ,'" + endereco+ "' ,'" + celular + "','" + email + "' ,'" + dataNascimento + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Atualizar(int Id, string nome, string cidade, string endereco, string celular, string email, string dataNascimento)
        {
            string sql = "UPDATE Cliente SET nome = '"+ nome +"',cidade='"+ cidade+ "', endereco ='"+endereco+"', celular='"+celular+"', email='"+email+"', dataNascimento='"+dataNascimento+"'  WHERE Id='"+Id+"' ";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void Excluir(int Id)
        {
            string sql = "DELETE FROM Cliente WHERE Id='" + Id + "' ";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Localizar(int Id)
        {
            string sql = "SELECT * FROM Cliente WHERE Id='" + Id + "' ";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                cidade = dr["cidade"].ToString();
                endereco = dr["endereco"].ToString();
                celular = dr["celular"].ToString(); ;
                email = dr["email"].ToString();
                dataNascimento = dr["dataNascimento"].ToString();
            }
            dr.Close();
            con.Close();
        }


    }
}
