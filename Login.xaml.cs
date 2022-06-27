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
using ProjetoEscola.Views;

namespace ProjetoEscola
{
    /// <summary>
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Escola_Click(object sender, RoutedEventArgs e)
        {
            var form = new EscolaListWindow();
            form.Show();
            this.Close();
        }

        private void Button_Curso_Click(object sender, RoutedEventArgs e)
        {
            var form = new CursoListWindow();
            form.Show();
            this.Close();
        }
    }
}
