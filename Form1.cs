using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bouncing_Ball
{
    public partial class Form1 : Form
    {
        private int ballWidth = 70;
        private int ballHeight = 70;
        private int ballPosX = 0;
        private int ballposY = 0;
        private int moveStepX = 4;
        private int moveStepY = 4;
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        private void paintcircle(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(this.BackColor);

            e.Graphics.FillEllipse(Brushes.Blue,
                ballPosX,ballposY,
                ballWidth, ballHeight);
            e.Graphics.DrawEllipse(Pens.Black,
                ballPosX, ballposY,
                ballWidth,ballHeight);
        }

        private void moveball(object sender, EventArgs e)
        {
            //update coordinates
            ballPosX += moveStepX;
            if(ballPosX<0||
                ballPosX+ballWidth
                >this.ClientSize.Width)
            { 
                moveStepX = -moveStepY; 
            }
            ballposY  += moveStepY;
            if (
                ballposY  < 0 ||
                ballposY+ ballHeight > this.ClientSize.Height)
            {
                moveStepY = -moveStepY;
            }
            //update painting 
            this.Refresh();
        }
    }
}
