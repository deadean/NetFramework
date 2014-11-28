using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessFiles(true);
        }

        private void ProcessFiles(bool toggle)
        {
            try
            {
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                // Load up all *.jpg files, and make a new folder for the modified data.
                string[] files = Directory.GetFiles("InputPicture", "*.jpg",
                SearchOption.AllDirectories);
                string newDir = "OutputPicture";
                Directory.CreateDirectory(newDir);
                // Process the image data in a blocking manner.
                if (toggle)
                {
                    foreach (string currentFile in files)
                    {
                        string filename = Path.GetFileName(currentFile);
                        using (Bitmap bitmap = new Bitmap(currentFile))
                        {
                            bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            bitmap.Save(Path.Combine(newDir, filename));
                            // Print out the ID of the thread processing the current image.
                            this.Text = string.Format("Processing {0} on thread {1}", filename,
                            Thread.CurrentThread.ManagedThreadId);
                        }
                    }
                    sw.Stop();
                    this.Text = sw.ElapsedMilliseconds.ToString();
                }
                else
                {
                    try
                    {
                        //Parallel.ForEach(files, currentFile =>
                        //this.Invoke((Action)delegate()
                        Task.Factory.StartNew(()=>
                        //ParallelOptions po = new ParallelOptions() { CancellationToken = cancelToken.Token, MaxDegreeOfParallelism = System.Environment.ProcessorCount };
                        //Parallel.ForEach(files, po, currentFile =>
                        {
                            //po.CancellationToken.ThrowIfCancellationRequested();
                            foreach (string currentFile in files)
                            {
                                string filename = Path.GetFileName(currentFile);
                                using (Bitmap bitmap = new Bitmap(currentFile))
                                {
                                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                    bitmap.Save(Path.Combine(newDir, filename));
                                    // This code statement is now a problem! See next section.
                                    this.Invoke((Action)delegate
                                    {
                                        this.Text = string.Format("Processing {0} on thread {1}", filename, Thread.CurrentThread.ManagedThreadId);
                                    });
                                }
                            }
                            sw.Stop();
                            this.Text = sw.ElapsedMilliseconds.ToString();
                        }
            );
                    }
                    catch (Exception ex)
                    {
                        this.Invoke((Action)delegate
                        {
                            this.Text = ex.Message;
                        });
                    }
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private CancellationTokenSource cancelToken = new CancellationTokenSource();

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessFiles(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }

    }
}
