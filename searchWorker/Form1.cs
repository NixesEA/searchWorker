using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Collections;

namespace searchWorker
{
    public partial class Form1 : Form
    {
        public struct worker
        {
            public string fio;
            public string email;
            public int nomber;
            public int cval;

        };

        private const string V = "Стаж: ";
        public worker[] workers = new worker[100];
        public int j=0;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader objReader = new StreamReader("worker.txt", Encoding.GetEncoding(1251));
            string sLine = "";
            textBox1.Text = "";
            textBox2.Text = "";
            ArrayList arrText = new ArrayList();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    arrText.Add(sLine);
            }
            objReader.Close();

            foreach (string sOutput in arrText)
                textBox1.Text += sOutput + '\r' + '\n';

            textBox1.Text += "File is read!\r\n\r\n\r\n";




            string[] mas = textBox1.Text.Split('\n');



            for (int i = 0; i < mas.Length; i++)
            {
                string a = mas[i];
                if (a.IndexOf("ФИО") != -1)
                    workers[j].fio = a;
                if (a.IndexOf("@") != -1)
                    workers[j].email = a;
                if (a.IndexOf("Стаж") != -1)
                {                    
                    string[] df = mas[i].Split(' ');
                    
                    workers[j].cval = Convert.ToInt32(df[1]);
                }
                if (a.IndexOf("*") != -1)
                    j++;

            }
            /*
            for (int i = 0; i < j; i++)
            {
                
                textBox2.Text += "fio =" + workers[i].fio + "\r\n";
                textBox2.Text += "@" + workers[i].email + "\r\n";
                textBox2.Text += "cval =" + workers[i].cval + "\r\n";
            }
            */


            int max = 0, max_i = 0;
            for (int i = 0; i<=j; i++)
            {
                if (max < workers[i].cval)
                {
                    max = workers[i].cval;
                    max_i = i;
                }
            }

            textBox2.Text = "Лучший стаж:" + workers[max_i].cval + "\r\n";
            textBox2.Text += workers[max_i].fio + "\r\n" + workers[max_i].email;
        }
    }
}
