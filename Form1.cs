using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormDataGridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bancoDadosDataSetTabelas.aluno'.
            // Você pode movê-la ou removê-la conforme necessário.
            this.alunoTableAdapter.Fill(this.bancoDadosDataSetTabelas.aluno);

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            String nome;
            String curso;
            nome = txtNome.Text;
            curso = txtCurso.Text;
           
            if(nome.Equals("") || curso.Equals(""))
            {
                MessageBox.Show("Preencher os campos", "Preenchimento");
            }
            else
            {
                alunoTableAdapter.InsertAlunos(txtNome.Text, txtCurso.Text);
                this.alunoTableAdapter.Fill(this.bancoDadosDataSetTabelas.aluno);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            alunoTableAdapter.DeleteAlunos(id);
            this.alunoTableAdapter.Fill(this.bancoDadosDataSetTabelas.aluno);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            alunoTableAdapter.UpdateAluno(txtNome.Text, txtCurso.Text, Convert.ToInt32(txtId.Text));
            this.alunoTableAdapter.Fill(this.bancoDadosDataSetTabelas.aluno);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dgAlunos_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dgAlunos.CurrentCell.Value.ToString());

            if(Convert.ToInt32(dgAlunos.CurrentCell.Value) > 0)
            {
                int registro = Convert.ToInt32(dgAlunos.CurrentCell.Value) - 1;
                txtId.Text = dgAlunos.Rows[registro].Cells[0].Value.ToString();
                txtNome.Text = dgAlunos.Rows[registro].Cells[1].Value.ToString();
                txtCurso.Text = dgAlunos.Rows[registro].Cells[2].Value.ToString();
            }
            
        }

        private void dgAlunos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
