using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEasyCs101
{
    public partial class Form1 : Form
    {
        private Button bt;
        private Label[] lb = new Label[3];
        
        // [STAThread]
        
        public Form1()
        {
            InitializeComponent();
            this.Text = "Show File's Info";
            this.Width = 300;
            this.Height = 200;
            for (int i = 0; i < lb.Length; i++)
            {
                lb[i] = new Label();
                lb[i].Top = i * lb[0].Height;
                lb[i].Width = 300;
            }

            bt = new Button();
            bt.Text = "Show";
            bt.Dock = DockStyle.Bottom;
            bt.Parent = this;
            for (int i = 0; i < lb.Length; i++)
            {
                lb[i].Parent = this;
            }

            bt.Click += new EventHandler(BtClick);
        }

        public void BtClick(Object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            // v Whether press "Open" in DialogBox
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                lb[0].Text = "File name is " + ofd.FileName + ".";
                lb[1].Text = "Path is " + Path.GetFullPath(ofd.FileName) + ".";
                lb[2].Text = "Size is " + Convert.ToString(fi.Length) + ".";
            }
        }
    }
}