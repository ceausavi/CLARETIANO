using System;
using System.Windows.Forms;

namespace banco_repository1
{
    public partial class Form1 : Form
    {
        private readonly ClienteRepository _clienteRepository;

        public Form1()
        {
            InitializeComponent();
            _clienteRepository = new ClienteRepository();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textID.Text) ||
                    string.IsNullOrWhiteSpace(textNome.Text) ||
                    string.IsNullOrWhiteSpace(textEndereco.Text) ||
                    string.IsNullOrWhiteSpace(textFone.Text))
                {
                    MessageBox.Show("Todos os campos são obrigatórios!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cliente = new Cliente
                {
                    IdClientes = int.Parse(textID.Text.Trim()),
                    Nome = textNome.Text.Trim(),
                    Endereco = textEndereco.Text.Trim(),
                    Telefone = textFone.Text.Trim()
                };

                bool sucesso = _clienteRepository.Inserir(cliente);

                if (!sucesso)
                    MessageBox.Show("Erro ao inserir o cliente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Cliente inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textID.Text))
                {
                    MessageBox.Show("Informe um ID para buscar!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idClientes = int.Parse(textID.Text.Trim());
                Cliente cliente = _clienteRepository.Buscar(idClientes);

                if (cliente != null)
                {
                    textNome.Text = cliente.Nome;
                    textEndereco.Text = cliente.Endereco;
                    textFone.Text = cliente.Telefone;
                    MessageBox.Show("Cliente encontrado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textID.Text) ||
                    string.IsNullOrWhiteSpace(textNome.Text) ||
                    string.IsNullOrWhiteSpace(textEndereco.Text) ||
                    string.IsNullOrWhiteSpace(textFone.Text))
                {
                    MessageBox.Show("Todos os campos são obrigatórios!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cliente = new Cliente
                {
                    IdClientes = int.Parse(textID.Text.Trim()),
                    Nome = textNome.Text.Trim(),
                    Endereco = textEndereco.Text.Trim(),
                    Telefone = textFone.Text.Trim()
                };

                bool sucesso = _clienteRepository.Atualizar(cliente);

                if (!sucesso)
                    MessageBox.Show("Erro ao atualizar o cliente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Cliente atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textID.Text))
                {
                    MessageBox.Show("Informe um ID para deletar!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult resultado = MessageBox.Show("Tem certeza que deseja deletar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    int idClientes = int.Parse(textID.Text.Trim());
                    bool sucesso = _clienteRepository.Deletar(idClientes);

                    if (!sucesso)
                        MessageBox.Show("Erro ao deletar o cliente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("Cliente deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            textID.Clear();
            textNome.Clear();
            textEndereco.Clear();
            textFone.Clear();
            textID.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
