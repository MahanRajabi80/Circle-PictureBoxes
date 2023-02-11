using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Example_16_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------------------------------
        System.Collections.ArrayList pictureList = new System.Collections.ArrayList();
        //-----------------------------------------------------------------------------
        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Jpeg Files (*.jpg)|*.jpg|Bitmap Files (*.bmp)|*.bmp";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.SafeFileName != "")
            {
                PictureBox pic = new PictureBox();
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Size = new System.Drawing.Size(60, 60);
                pic.Image = Image.FromFile(openFileDialog1.FileName);
                pictureList.Add(pic);
                this.Controls.Add(pic);
            }
        }
        //-----------------------------------------------------------------------------
        int teta = 90;
        const int radius = 100;
        //-----------------------------------------------------------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureList.Count == 0)
                return;
            //----------------------------//
            int x = this.ClientSize.Width / 2; //center x
            int y = this.ClientSize.Height / 2; //center y
            for (int i = 0,t=teta; i < pictureList.Count; i++)
            {
                int dx = (int)(radius * Math.Cos(Radian(t)));
                int dy = (int)(radius * Math.Sin(Radian(t)));
                ((PictureBox)pictureList[i]).Location = new Point(x+dx,y-dy);
                t=(t+360/pictureList.Count)%360;//donbale aghab
            }
            teta--;
            if (teta == -1)
                teta = 359;
        }
        //-----------------------------------------------------------------------------
        private static double Radian(double d)
        {
            return d * Math.PI / 180;
        }
    }
}
