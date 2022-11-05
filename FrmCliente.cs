using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtividadeSala1
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            List<Cliente> clientes = cliente.listacliente();
            dgvCliente.DataSource = clientes; //Nome do gridview dvgCliente.
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Deseja realmente sair", "Sair do Aplicativo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (textNome.Text == "" && textCidade.Text == "" && textCelular.Text == "")
            {
                MessageBox.Show("Não exitsem dados para cadastrar, por favor preencha os campos", "sem dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textNome.Focus();
            }
            else
            {
                Cliente cliente = new Cliente();
                cliente.Inserir(textNome.Text, textCidade.Text, textEndereco.Text, textCelular.Text, textEmail.Text, textDataNascimento.Text);
                MessageBox.Show("Cliente cadastrado com sucesso!");
                List<Cliente> clientes = cliente.listacliente();
                dgvCliente.DataSource = clientes;
                textNome.Text = "";
                textCidade.Text = "";
                textEndereco.Text = "";
                textCelular.Text = "";
                textEmail.Text = "";
                textDataNascimento.Text = "";
                this.textNome.Focus();

            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            if (textId.Text == "")
            {
                MessageBox.Show("Digite um Id válido!");
                this.textId.Focus();
            }
            else
            {
                int Id = Convert.ToInt32(textId.Text.Trim()); // converte o que foi digitado em string. .Trim retira os espaços em branco antes e depois.
                Cliente cliente = new Cliente();
                cliente.Localizar(Id);
                textNome.Text = cliente.nome;
                textCidade.Text = cliente.cidade;
                textEndereco.Text = cliente.endereco;
                textCelular.Text = cliente.celular;
                textEmail.Text = cliente.email;
                textDataNascimento.Text = cliente.dataNascimento;
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(textId.Text.Trim());
            Cliente cliente = new Cliente();
            cliente.Atualizar(Id, textNome.Text, textCidade.Text, textEndereco.Text, textCelular.Text, textEmail.Text, textDataNascimento.Text);
            MessageBox.Show("Pessoa atualizada com sucesso!");
            List<Cliente> clientes = cliente.listacliente();
            dgvCliente.DataSource = clientes;
            textId.Text = "";
            textNome.Text = "";
            textCidade.Text = "";
            textEndereco.Text = "";
            textCelular.Text = "";
            textEmail.Text = "";
            textDataNascimento.Text = "";
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            this.textNome.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(textId.Text.Trim());
            Cliente cliente = new Cliente();
            cliente.Excluir(Id);
            MessageBox.Show("Pessoa excluáda com sucesso!");
            List<Cliente> clientes = cliente.listacliente();
            dgvCliente.DataSource = clientes;
            textId.Text = "";
            textNome.Text = "";
            textCidade.Text = "";
            textEndereco.Text = "";
            textCelular.Text = "";
            textEmail.Text = "";
            textDataNascimento.Text = "";
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            this.textNome.Focus();
        }

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvCliente.Rows[e.RowIndex];
                row.Selected = true;
                textId.Text = row.Cells[0].Value.ToString();
                textNome.Text = row.Cells[1].Value.ToString();
                textCidade.Text = row.Cells[2].Value.ToString();
                textEndereco.Text = row.Cells[3].Value.ToString();
                textCelular.Text = row.Cells[4].Value.ToString();
                textEmail.Text = row.Cells[5].Value.ToString();
                textDataNascimento.Text = row.Cells[6].Value.ToString();
            }
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }
    }
}
