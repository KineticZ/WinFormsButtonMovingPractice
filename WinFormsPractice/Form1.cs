using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsPractice
{
    public partial class Form1 : Form
    {
        bool isWindowNormal { get; set; }

        private Point MousePoint { get; set; }
        public Form1()
        {
            InitializeComponent();
            isWindowNormal = false;
            //WindowState = FormWindowState.Maximized; 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(MousePosition.X, MousePosition.Y);

            pictureBox2.BackColor = Color.FromArgb(0, 100, 100);
            pictureBox3.BackColor = Color.FromArgb(100, 0, 10);

            pictureBox3.Width = 10;
            pictureBox3.Height = 10;
        }
               
        
        private void MoveButton()
        {
            int speed = 20;
            int offset = 100;
            Rectangle rect = button1.ClientRectangle;
            int x = button1.Location.X;
            int y = button1.Location.Y;
            int width = rect.Width;
            int height = rect.Height;
            
            bool isInsideTopBoundary = y - offset > 0;
            bool isInsideBottomBoundary = y + height + offset < ActiveForm.Size.Height;
            bool isInsideLeftBoundary = x - offset > 0;
            bool isInsideRightBoundary = x + width + offset < ActiveForm.Size.Width;

            
            bool isUnderTheTop = MousePoint.Y > y;
            bool isAboveBottom = MousePoint.Y < y + height;
            bool isLeftOfTheLeft = MousePoint.X > x - offset && MousePoint.X < x + width / 2f;
            bool isRightOfTheRight = MousePoint.X < (x + width) + offset && MousePoint.X > x + width / 2f;
            if (isLeftOfTheLeft && isUnderTheTop && isAboveBottom && isInsideRightBoundary)
            {
                button1.Location = new Point(button1.Location.X + speed, button1.Location.Y);
            }
            else if (isRightOfTheRight && isUnderTheTop && isAboveBottom && isInsideLeftBoundary)
            {
                button1.Location = new Point(button1.Location.X - speed, button1.Location.Y);
            }

            bool isRightOfLeft = MousePoint.X > x;
            bool isLeftOfRight = MousePoint.X < x + width;
            bool isTopOfTop = MousePoint.Y > y - offset && MousePoint.Y < y + height / 2f;
            bool isBottomOfBottom = MousePoint.Y < (y + height) + offset && MousePoint.Y > y + height / 2f;
            if (isTopOfTop && isRightOfLeft && isLeftOfRight && isInsideBottomBoundary)
            {
                button1.Location = new Point(button1.Location.X, button1.Location.Y + speed);
            }
            else if(isBottomOfBottom && isRightOfLeft && isLeftOfRight && isInsideTopBoundary)
            {
                button1.Location = new Point(button1.Location.X, button1.Location.Y - speed);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (isWindowNormal)
            {
                isWindowNormal = false;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                isWindowNormal = true;
                WindowState = FormWindowState.Normal;
            }
 
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            MousePoint = new Point(e.Location.X, e.Location.Y);

            pictureBox2.Visible = true;
            int offset = 40;
            Rectangle rect = button1.ClientRectangle;
            int x = button1.Location.X;
            int y = button1.Location.Y;
            int width = rect.Width;
            int height = rect.Height;

            pictureBox2.Height = height - (2*offset);
            pictureBox2.Width = width - (2*offset);
            pictureBox2.Location = new Point(x + offset, y + offset);

            pictureBox3.Location = new Point(e.Location.X, e.Location.Y);          
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {            
            
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Visible = false;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {            
            MoveButton();           
        }
        
        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            MoveButton();
        }
    }
}
