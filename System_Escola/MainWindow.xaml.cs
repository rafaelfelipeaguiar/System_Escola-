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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System_Escola.Views;

namespace System_Escola
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cadastro chamar = new Cadastro();
            chamar.ShowDialog();
        }

        private void bt_Curso_Click(object sender, RoutedEventArgs e)
        {
            CadastroCurso chamar = new CadastroCurso();
            chamar.ShowDialog();
        }

        private void bt_List_Click(object sender, RoutedEventArgs e)
        {
            CursoList chamar = new CursoList();
            chamar.ShowDialog();

        }

        private void bt_listEscola_Click(object sender, RoutedEventArgs e)
        {
            EscolaList chamar = new EscolaList();
            chamar.ShowDialog();
        }
    }
}
