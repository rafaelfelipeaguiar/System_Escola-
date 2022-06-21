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
    /// Lógica interna para EscolaList.xaml
    /// </summary>
    public partial class EscolaList : Window
    {
        public EscolaList()
        {
            InitializeComponent();
            Loaded += EscolaList_Loaded;
        }
        private void EscolaList_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }
        private void LoadDataGrid()
        {
            try
            {
                var dao = new EscolaDAO();
                List<Escola> listaEscolas = dao.List();

                dataGridEscola.ItemsSource = listaEscolas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            var escolaSelected = dataGridEscola.SelectedItem as Escola;
            var view = new Cadastro(escolaSelected);
            view.ShowDialog();
            LoadDataGrid();

        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            var escolaSelected = dataGridEscola.SelectedItem as Escola;

            var result = MessageBox.Show($"Deseja excluir a Escola '{escolaSelected.Nome}'?", "Confirmação de Exclusão",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new EscolaDAO();
                    dao.Delete(escolaSelected);
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
