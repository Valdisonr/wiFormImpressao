using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Impressão
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        private Font bold = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
        private Font regular = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
        private Font regularItens = new Font(FontFamily.GenericSansSerif, 6, FontStyle.Regular);
        private Font printFont;




        private void button1_Click(object sender, EventArgs e)
        {
            printDoc();
        }

        void printDoc()

        {
            PrintDocument printDoc = new PrintDocument();

            printFont = new System.Drawing.Font("Arial", 8);
            printDoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDoc.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)


        {



            Graphics graphics = e.Graphics;
            int offset = 105;

            //print header
            graphics.DrawString("Properties.Settings.Default.Company", bold, Brushes.Black, 20, 0);
            graphics.DrawString("enderecoEMP", regularItens, Brushes.Black, 100, 15);


            graphics.DrawLine(Pens.Black, 20, 30, 310, 30);
            graphics.DrawString("CUPOM NÃO FISCAL", bold, Brushes.Black, 80, 35);
            graphics.DrawLine(Pens.Black, 20, 50, 310, 50);
            graphics.DrawString("PEDIDO: " /*+ FormatId.formatLong(venda.id)*/, regular, Brushes.Black, 20, 60);
            graphics.DrawLine(Pens.Black, 20, 75, 310, 75);

            //itens header
            graphics.DrawString("PRODUTO", regular, Brushes.Black, 20, 80);
            graphics.DrawString("UNIT.", regular, Brushes.Black, 150, 80);
            graphics.DrawString("QTD.", regular, Brushes.Black, 200, 80);
            graphics.DrawString("TOTAL", regular, Brushes.Black, 245, 80);
            // graphics.DrawLine(Pens.Black, 20, 95, 310, 95);


            foreach (DataGridViewRow row in gvprod.Rows)
            {
                string produto = (row.Cells["descricao"].Value.ToString());
                // string produto = (row.Cells["descricao"].Value.ToString());
                // string produto = (row.Cells["descricao"].Value.ToString());
                // string produto = (row.Cells["descricao"].Value.ToString());
                graphics.DrawString(produto.Length > 20 ? produto.Substring(0, 20) + "..." : produto, regularItens, Brushes.Black, 20, offset);
                graphics.DrawString(row.Cells["unid"].Value.ToString(), regularItens, Brushes.Black, 155, offset);
                graphics.DrawString(row.Cells["Qt"].Value.ToString(), regularItens, Brushes.Black, 215, offset);
                //   graphics.DrawString(row.Cells[""].Value.ToString(), regularItens, Brushes.Black,225, offset);
                graphics.DrawString(row.Cells["ValorUnit"].Value.ToString(), regularItens, Brushes.Black, 250, offset);
                //Cwriter.WriteLine(row.Cells["ValorTotal"].Value.ToString());

                offset += 20;
            }



            string qtd = gvprod.Rows.Count.ToString();
            //itens de venda

            //total
            offset += 20;
            graphics.DrawString("QTD ITENS: " + qtd, regularItens, Brushes.Black, 20, offset);
            offset += 20;

            graphics.DrawLine(Pens.Black, 20, offset, 310, offset);
            offset += 5;


            graphics.DrawString("TOTAL R$: ", bold, Brushes.Black, 20, offset);

            graphics.DrawString("txtTotal.Text", bold, Brushes.Black, 230, offset);
            offset += 20;
            graphics.DrawString("Formas de Pagamento:", regularItens, Brushes.Black, 20, offset);
            offset += 10;
            graphics.DrawString("lbitemPgto.Text", bold, Brushes.Black, 20, offset);
            offset += 20;




            graphics.DrawLine(Pens.Black, 20, offset, 310, offset);
            offset += 10;

            //bottom
            graphics.DrawString("Data: " + DateTime.Now.ToString("dd/MM/yyyy"), regularItens, Brushes.Black, 20, offset);
            graphics.DrawString("HORA: " + DateTime.Now.ToString("HH:mm:ss"), regularItens, Brushes.Black, 220, offset);

            e.HasMorePages = false;



        }
    }

}




