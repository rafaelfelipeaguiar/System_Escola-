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
using System_Escola.Helpers;
using System_Escola.Database;

namespace System_Escola.Views
{
    /// <summary>
    /// Lógica interna para CadastroCurso.xaml
    /// </summary>
    public partial class CadastroCurso : Window
    {
        private Curso _curso = new Curso();
        public CadastroCurso()
        {
            InitializeComponent();
            LoadDataGrid();
            Loaded += CadastroCurso_Loaded;
        }
        public CadastroCurso(Curso Curso)
        {
            InitializeComponent();
            _curso = Curso;
            LoadDataGrid();
            Loaded += CadastroCurso_Loaded;
        }

        private void CadastroCurso_Loaded(object sender, RoutedEventArgs e)
        {
            txt_NomeCurso.Text = _curso.Nome;
            txt_DescricaoCurso.Text = _curso.Descricao;
            txt_CargaHorariaCurso.Text = _curso.CargaHoraria;
            cb_TurnoCurso.Text = _curso.Turno;
        }

        private void bnt_Salvar_Click(object sender, RoutedEventArgs e)
        {
            _curso.Nome = txt_NomeCurso.Text;
            _curso.CargaHoraria = txt_CargaHorariaCurso.Text;
            _curso.Turno = cb_TurnoCurso.Text;
            _curso.Descricao = txt_DescricaoCurso.Text;

            try
            {
                var dao = new CursoDAO();

                if (_curso.Id > 0)
                {
                    dao.Update(_curso);
                    MessageBox.Show("Registro Atualizado!");
                }
                else
                {
                    dao.Insert(_curso);
                    MessageBox.Show("Registro Salvo!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadDataGrid()
        {
            try
            {
                var dao = new EscolaDAO();
                List<Escola> listaEscolas = dao.List();

                cb_ListEscolas.ItemsSource = listaEscolas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
