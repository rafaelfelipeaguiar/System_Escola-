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
using System_Escola.Models;
using System_Escola.Helpers;

namespace System_Escola.Views
{
    /// <summary>
    /// Lógica interna para CursoList.xaml
    /// </summary>
    public partial class CursoList : Window
    {
        public CursoList()
        {
            InitializeComponent();
            Loaded += ListaCurso_Loaded;

            
        }
        private void ListaCurso_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }
        private void LoadDataGrid()
        {
            try
            {
                var dao = new CursoDAO();

                dataGrid.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void MenuItem_Novo_Click(object sender, RoutedEventArgs e)
        {
            var window = new CursoList();
            window.ShowDialog();
            LoadDataGrid();
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            var cursoSelected = dataGrid.SelectedItem as Curso;

            var result = MessageBox.Show($"Deseja realmente remover o curso `{cursoSelected.Nome}`?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new CursoDAO();
                    dao.Delete(cursoSelected);
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            var cursoSelected = dataGrid.SelectedItem as Curso;

            var window = new CadastroCurso(cursoSelected);
            window.ShowDialog();
            LoadDataGrid();
        }
    }
}
