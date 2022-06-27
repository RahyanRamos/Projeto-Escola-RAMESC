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
using ProjetoEscola.Models;
using ProjetoEscola.Views;
using ProjetoEscola.Properties;
using ProjetoEscola.Helpers;
using ProjetoEscola.Database;

namespace ProjetoEscola.Views
{
    /// <summary>
    /// Lógica interna para CursoFormWindow.xaml
    /// </summary>
    public partial class CursoFormWindow : Window
    {
        private Curso _curso = new Curso();

        public CursoFormWindow()
        {
            InitializeComponent();
            Loaded += CursoFormWindow_Loaded;
        }

        //public CursoFormWindow(Curso curso)
        //{
        //    InitializeComponent();
        //    Loaded += CursoFormWindow_Loaded;

        //    _curso = curso;
        //}

        private void CursoFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Text = _curso.Nome;
            txtCargaHoraria.Text = _curso.CargaHoraria;
            txtDescricao.Text = _curso.Descricao;

            if ((bool)rdTurnoMatutino.IsChecked)
            {
                _curso.Turno = "Matutino";
            }
            if ((bool)rdTurnoVespertino.IsChecked)
            {
                _curso.Turno = "Vespertino";
            }
            if ((bool)rdTurnoNoturno.IsChecked)
            {
                _curso.Turno = "Noturno";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _curso.Nome = txtNome.Text;
            _curso.CargaHoraria = txtCargaHoraria.Text;
            _curso.Descricao = txtDescricao.Text;

            if((bool)rdTurnoMatutino.IsChecked)
            {
                _curso.Turno = "Matutino";
            }
            if((bool)rdTurnoVespertino.IsChecked)
            {
                _curso.Turno = "Vespertino";
            }
            if ((bool)rdTurnoNoturno.IsChecked)
            {
                _curso.Turno = "Noturno";
            }

            try
            {
                var dao = new CursoDAO();

                if(_curso.Id > 0)
                {
                    dao.Update(_curso);
                }
                else
                {
                    dao.Insert(_curso);
                }

                MessageBox.Show("Registro de curso cadastrado com sucesso.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Voltar_Click(object sender, RoutedEventArgs e)
        {
            var form = new CursoListWindow();
            form.Show();
            this.Close();
        }
    }
}
