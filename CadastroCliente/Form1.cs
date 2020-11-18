using System;
using System.Windows.Forms;

namespace CadastroCliente
{
    public partial class FrmCadastroCliente : Form
    {
        private bool novo = false;

        public FrmCadastroCliente()
        {
            InitializeComponent();
        }

        private void FrmCadastroCliente_Load(object sender, EventArgs e)
        {
            this.ActiveControl = tstCodigo.Control;

            configuraEstadoInicial();
        }

        private void tsbNovo_Click(object sender, EventArgs e)
        {
            novo = true;

            tsbNovo.Enabled = false;
            tsbSalvar.Enabled = true;
            tsbCancelar.Enabled = true;
            tstCodigo.Enabled = false;
            tsbBuscar.Enabled = false;
            tstCodigo.Text = String.Empty;

            abilitaCampos();

            txtNome.Focus();
        }

        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidaDados())
            {
                MessageBox.Show("Por favor, preencha todos os campos corretamente.", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DML.Cliente cliente = new DML.Cliente();

            cliente.Nome = txtNome.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.Bairro = txtBairro.Text;
            cliente.Cidade = txtCidade.Text;
            cliente.Uf = txtUf.Text;
            cliente.Cep = mtbCep.Text;
            cliente.Telefone = mtbTelefone.Text;

            if (novo)
            {
                BLL.Cliente bllCliente = new BLL.Cliente();

                try
                {
                    int affectedRow = bllCliente.Salvar(cliente);

                    if (affectedRow > 0)
                        MessageBox.Show("Registro incluido com sucesso!", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                BLL.Cliente bllCliente = new BLL.Cliente();

                try
                {
                    cliente.Id = int.Parse(txtCodigo.Text);

                    int affectedRow = bllCliente.Atualizar(cliente);

                    if (affectedRow > 0)
                        MessageBox.Show("Registro atualizado com sucesso!", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            limpaCampos();
            configuraEstadoInicial();
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            configuraEstadoInicial();
        }

        private void tsbExcluir_Click(object sender, EventArgs e)
        {
            BLL.Cliente bllCliente = new BLL.Cliente();

            try
            {
                int affectedRow = bllCliente.Excluir(int.Parse(txtCodigo.Text));

                if (affectedRow > 0)
                    MessageBox.Show("Registro excluido com sucesso!", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            limpaCampos();
            configuraEstadoInicial();
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            BLL.Cliente bllCliente = new BLL.Cliente();

            if (tstCodigo.TextLength == 0) return;

            try
            {
                int codigo = int.Parse(tstCodigo.Text);

                DML.Cliente cliente = bllCliente.Consultar(codigo);
                
                if (cliente != null)
                {
                    tsbNovo.Enabled = false;
                    tsbSalvar.Enabled = true;
                    tsbCancelar.Enabled = true;
                    tsbExcluir.Enabled = true;
                    tstCodigo.Text = String.Empty;

                    abilitaCampos();

                    txtCodigo.Enabled = true;
                    txtCodigo.ReadOnly = true;

                    txtCodigo.Text = cliente.Id.ToString();
                    txtNome.Text = cliente.Nome;
                    txtEndereco.Text = cliente.Endereco;
                    txtBairro.Text = cliente.Bairro;
                    txtCidade.Text = cliente.Cidade;
                    txtUf.Text = cliente.Uf;
                    mtbCep.Text = cliente.Cep;
                    mtbTelefone.Text = cliente.Telefone;

                    txtNome.Focus();

                    novo = false;
                }
                else
                {
                    limpaCampos();
                    configuraEstadoInicial();

                    MessageBox.Show("Nenhum registro encontrado para o Código \"" + codigo + "\"", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void configuraEstadoInicial()
        {
            tsbNovo.Enabled = true;
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tstCodigo.Enabled = true;
            tsbBuscar.Enabled = true;

            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUf.Enabled = false;
            mtbCep.Enabled = false;
            mtbTelefone.Enabled = false;

            tstCodigo.Focus();
        }

        private void limpaCampos()
        {
            tstCodigo.Text = String.Empty;

            txtCodigo.Text = String.Empty;
            txtNome.Text = String.Empty;
            txtEndereco.Text = String.Empty;
            txtBairro.Text = String.Empty;
            txtCidade.Text = String.Empty;
            txtUf.Text = String.Empty;
            mtbCep.Text = String.Empty;
            mtbTelefone.Text = String.Empty;
        }

        private void abilitaCampos()
        {
            txtNome.Enabled = true;
            txtEndereco.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtUf.Enabled = true;
            mtbCep.Enabled = true;
            mtbTelefone.Enabled = true;
        }

        private bool ValidaDados()
        {
            if (txtNome.TextLength == 0 | txtEndereco.TextLength == 0 | txtBairro.TextLength == 0
                 | txtCidade.TextLength == 0 | txtUf.TextLength < 2 | !mtbCep.MaskCompleted | !mtbTelefone.MaskCompleted)
            {
                return false;
            }

            return true;
        }
    }
}
