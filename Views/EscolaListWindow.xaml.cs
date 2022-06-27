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
using ProjetoEscola.Models;

namespace ProjetoEscola.Views
{
    /// <summary>
    /// Lógica interna para EscolaListWindow.xaml
    /// </summary>
    public partial class EscolaListWindow : Window
    {
        public EscolaListWindow()
        {
            InitializeComponent();
            Loaded += EscolaListWindow_Loaded;
        }

        private void EscolaListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var dao = new EscolaDAO();
                List<Escola> listaEscolas = dao.List();

                dataGridEscola.ItemsSource = listaEscolas;

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Atualizar_Click(object sender, RoutedEventArgs e)
        {
            var escolaSelecionada = dataGridEscola.SelectedItem as Escola;

        //    var form = new EscolaFormWindow(escolaSelecionada);
        //    form.ShowDialog();
        }

        private void Button_Novo_Click(object sender, RoutedEventArgs e)
        {
            var form = new EscolaFormWindow();
            form.Show();
            this.Close();
        }

        private void Button_Voltar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Login();
            form.Show();
            this.Close();
        }
    }
}
