using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADONetCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Pessoa p = new Pessoa();
            p.nome = txbNome.Text;
            p.cidade = txbCidade.Text;

            bool retorno = p.gravar();
            if (retorno)
            {
                MessageBox.Show("Gravado com Sucesso!");    
            }
            else
            {
                MessageBox.Show("Erro ao gravar."); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();

            string sql = "select * from pessoas";
            DataTable dt = new DataTable();

            dt = bd.executarConsultaGenerica(sql);

            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pessoa p = new Pessoa();
            int id = int.Parse(txbId.Text);
            p.consultar(id);
            MessageBox.Show(p.nome);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pessoa p = new Pessoa();
            p.id = int.Parse(txbId.Text);

            bool retorno = p.excluir();

            if (retorno)
            {
                MessageBox.Show("Pessoa foi excluído!");
            }
            else
            {
                MessageBox.Show("Erro ao excluir ou pessoa não encontrada.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pessoa p = new Pessoa();
            int id = int.Parse(txbConsultaEdicao.Text);
            p.consultar(id);

            txbNomeEdicao.Text = p.nome;
            txbCidadeEdicao.Text = p.cidade;
            txbConsultaEdicao.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Pessoa p = new Pessoa();
            p.id = int.Parse(txbConsultaEdicao.Text);
            p.nome = txbNomeEdicao.Text;
            p.cidade = txbCidadeEdicao.Text;

            bool retorno = p.atualizar();
            if (retorno)
            {
                MessageBox.Show("Pessoa atualizada com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao atualizar pessoa.");
            }

            txbConsultaEdicao.Enabled = true;
            txbCidadeEdicao.Text = "";
            txbNomeEdicao.Text = "";
        }
    }
}
