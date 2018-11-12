using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String moving;
        int Speed = 2;
        int score = 0;
        bool alive = true;
    
        private void tick_Tick(object sender, EventArgs e)
        {
            if (alive)
            {
                ScoreLbl.Text = "Score: " + score;
                switch (moving)
                {
                    case "up":
                        Pacman.Top -= Speed;
                        break;
                    case "down":
                        Pacman.Top += Speed;
                        break;
                    case "left":
                        Pacman.Left -= Speed;
                        break;
                    case "right":
                        Pacman.Left += Speed;
                        break;
                }
                foreach (Control c in game.Controls)
                {
                    if (c.Bounds.IntersectsWith(Pacman.Bounds))
                    {
                        if (c.Tag == "Coin")
                        {
                            if (c.Visible)
                            {
                                score++;
                                c.Visible = false;
                            }
                        }
                        if (c.Tag == "Ghost")
                        {
                            alive = false;
                        }
                    }
                }
            }
            else Pacman.BackColor = Color.Crimson;
        }

        private void Up_Click(object sender, EventArgs e)
        {
            moving = "up";
        }
        private void Left_Click(object sender, EventArgs e)
        {
            moving = "left";
        }
        private void Down_Click(object sender, EventArgs e)
        {
            moving = "down";
        }
        private void Right_Click(object sender, EventArgs e)
        {
            moving = "right";
        }

        private void game_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
