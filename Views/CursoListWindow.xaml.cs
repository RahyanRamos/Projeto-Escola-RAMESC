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
using ProjetoEscola.Views;

namespace ProjetoEscola.Views
{
    /// <summary>
    /// Lógica interna para CursoListWindow.xaml
    /// </summary>
    public partial class CursoListWindow : Window
    {
        public CursoListWindow()
        {
            InitializeComponent();
            Loaded += CursoListWindow_Loaded;
        }

        private void CursoListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var dao = new CursoDAO();
                List<Curso> listaCursos = dao.List();

                dataGridCurso.ItemsSource = listaCursos;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            var cursoSelecionado = dataGridCurso.SelectedItem as Curso;

            var resultado = MessageBox.Show($"Tem certeza que deseja deletar o curso {cursoSelecionado.Nome} ?", "Confirmação de Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if(resultado == MessageBoxResult.Yes)
                {
                    var dao = new CursoDAO();
                    dao.Delete(cursoSelecionado);

                    MessageBox.Show("Curso removido com sucesso!");
                    var form = new CursoListWindow();
                    form.Show();
                    this.Close();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Atualizar_Click(object sender, RoutedEventArgs e)
        {
            var cursoSelecionado = dataGridCurso.SelectedItem as Curso;

        //    var form = new CursoFormWindow(cursoSelecionado);
        //    form.ShowDialog();
        }

        private void Button_Novo_Click(object sender, RoutedEventArgs e)
        {
            var form = new CursoFormWindow();
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
