using AppModelo.Controller.External;
using AppModelo.Model.Domain.Validators;
using AppModelo.View.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppModelo.View.Windows.Cadastro
{
    public partial class frmCadastroFuncionario : Form
    {
        public frmCadastroFuncionario()
        {
            InitializeComponent();
            Componentes.FormatarCamposObrigatorios(this);
        }

        private void btnPesquisarCep_Click(object sender, EventArgs e)
        {
            //Crio a instancia do Controllador
            var cepController = new ViaCepController();
            //Recebo os dados do metodo para obter endereco
            var endereco = cepController.Obter(txtEnderecoCep.Text);

            txtEnderecoBairro.Text = endereco.Bairro;
            txtEnderecoComplemento.Text = endereco.Complemento;
            txtEnderecoMunicipio.Text = endereco.Localidade;
            txtEnderecoLogradouro.Text = endereco.Logradouro;
            txtEnderecoUF.Text = endereco.Uf;
        }

        private void txtNome_Validating(object sender, CancelEventArgs e)
           {
            //primeira regra nome
            if(txtNome.Text.Length<6)
            {
                errorProvider.SetError(txtNome,"Digite seu nome Completo");
                return;
            }
            
            //executa letra por letra procurando numero até não tiver erro
            foreach(var letra in    txtNome.Text)
            {
                if(char.IsNumber(letra))
                {
                    errorProvider.SetError(txtNome, "Seu Nome parece estar Errado");
                    return;

                }
            }
            errorProvider.Clear();
        }

        private void txtCpf_Validating(object sender, CancelEventArgs e)
        {
            var cpf = txtCpf.Text;
            var cpfEhValido = Validadores.ValidarCPF(cpf);
            if(cpfEhValido is false)
            {
                errorProvider.SetError(txtCpf, "CPF Inválido");
                return;
            }
            errorProvider.Clear();
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            var email = txtEmail.Text;
            var emailEhValido = Validadores.EmailEValido(email);
            if(emailEhValido is false)
            {
                errorProvider.SetError(txtEmail, "E-mail Inválido");
                return ;
            }
            errorProvider.Clear();
        }

        private void txtDataNascimento_Validating(object sender, CancelEventArgs e)
        {
            
            var dataNascimento = parsetxtDataNascimento.Text;
            
            if(dataNascimento <= DateTime.Now.AddDays(1))
            {

            }
            
        }
    }
}
