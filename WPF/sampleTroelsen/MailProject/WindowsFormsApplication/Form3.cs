using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class Form3 : Form
    {
        private static int countClick = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Text = await DoWork();
        }

        private Task<string> DoWork()
        {
            countClick++;
            int d = countClick;
            return Task.Run
                (
                () =>
                {
                    Thread.Sleep(5000);
                    return "Count Click :"+d;
                }
                );
        }
    }
}
