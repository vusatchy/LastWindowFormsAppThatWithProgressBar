using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LastConsoleAppThatWithProgressBar
{
    public partial class MainForm : Form
    {

        private AppController controller;
      
        public MainForm()
        {
            InitializeComponent();
        }


        public int getStratValue()
        {
            return Int32.Parse(textBoxStart.Text);
        }

        public int getFinishValue()
        {
            return Int32.Parse(textBoxFinish.Text);
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            controller = new AppController();
            backgroundWorker.RunWorkerAsync();
      
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
  
            controller.setStart(getStratValue());
            controller.setFinish(getFinishValue());
            int diff = Math.Abs(getFinishValue() - getStratValue());
            for (int i = 0; i <= diff; i++)
            {
                controller.executeAdd(i);
                System.Threading.Thread.Sleep(100);
                backgroundWorker.ReportProgress(100 * i / diff);
                
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            progressLabel.Text = e.ProgressPercentage.ToString() + "%";
            richTextBox.Text = controller.getStringRepresantationOfList();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
   
    }
}
