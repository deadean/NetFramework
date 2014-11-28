using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class Form2 : Form
    {
        private string theEBook;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //WebClient wc = new WebClient();
            //wc.DownloadStringCompleted += (s, eArgs) =>
            //{
            //    theEBook = eArgs.Result;
            //    textBox1.Text = theEBook;
            //};
            //// The Project Gutenberg EBook of A Tale of Two Cities, by Charles Dickens
            //wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/98/98-8.txt"));

            Parallel.Invoke
                (
                () =>
                {
                    int a = 0;
                    for (int i = 0; i < 10000000; i++)
                    {
                        a += 10;
                    }
                    MessageBox.Show("Thread 1 ended work");
                },
                () =>
                {
                    int a = 0;
                    for (int i = 0; i < 1000000000; i++)
                    {
                        a += 10;
                    }
                    MessageBox.Show("Thread 2 ended work");
                }
                );
        }
    }
}
