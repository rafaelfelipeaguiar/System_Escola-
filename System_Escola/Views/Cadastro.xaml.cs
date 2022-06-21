using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System_Escola.Models;

namespace System_Escola.Views
{
    /// <summary>
    /// Lógica interna para Cadastro.xaml
    /// </summary>
    public partial class Cadastro : Window
    {
        public Cadastro()
        {
            InitializeComponent();
            Loaded += Cadastro_Loaded;
        }
        private Escola _escola = new Escola();

        public Cadastro(Escola escola)
        {
            InitializeComponent();
            Loaded += Cadastro_Loaded;
            _escola = escola;
        }
        private void Cadastro_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Text = _escola.Nome;
            txtRazao.Text = _escola.Razao;
            txtCNPJ.Text = _escola.Cnpj;
            txtInscrcao.Text = _escola.Inscricao;
            if (_escola.Tipo == "Público")
            {
                rdbPublica.IsChecked = true;
            }
            else
            {
                rdbPrivada.IsChecked = true;
            }
            txtNomeResponsavel.Text = _escola.Responsavel;
            txtTelefoneResponsavel.Text = _escola.TelefoneResponsavel;
            txttelefone.Text = _escola.Telefone;
            txtEmail.Text = _escola.Email;
            txtRua.Text = _escola.Rua;
            txtNumero.Text = _escola.Numero;
            txtBairro.Text = _escola.Bairro;
            txtComplemento.Text = _escola.Complemento;
            txtCep.Text = _escola.Cep;
            txtCidade.Text = _escola.Cidade;
            cbEstado.Text = _escola.Estado;
            dtpDataCricao.SelectedDate = _escola.Data;
        }

        private void bnt_Salvar_Click(object sender, RoutedEventArgs e)
        {
            _escola.Nome = txtNome.Text;
            _escola.Razao = txtRazao.Text;
            _escola.Cnpj = txtCNPJ.Text;
            _escola.Inscricao = txtInscrcao.Text;
            _escola.SetTipo((bool)rdbPublica.IsChecked);
            _escola.Responsavel = txtNomeResponsavel.Text;
            _escola.TelefoneResponsavel = txtTelefoneResponsavel.Text;
            _escola.Telefone = txttelefone.Text;
            _escola.Email = txtEmail.Text;
            _escola.Rua = txtRua.Text;
            _escola.Numero = txtNumero.Text;
            _escola.Bairro = txtBairro.Text;
            _escola.Complemento = txtComplemento.Text;
            _escola.Cep = txtCep.Text;
            _escola.Cidade = txtCidade.Text;
            _escola.Estado = cbEstado.Text;
            _escola.Data = dtpDataCricao.SelectedDate;

            try
            {
                var dao = new EscolaDAO();

                if (_escola.Id > 0)
                {
                    dao.Update(_escola);
                    MessageBox.Show("Registro Atualizado!");
                }
                else
                {
                    dao.Insert(_escola);
                    MessageBox.Show("Registro Salvo!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
