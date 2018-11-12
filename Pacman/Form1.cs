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
        int coinCount = 17;
        bool alive = true;
    
        private void tick_Tick(object sender, EventArgs e)
        {
            if (alive)
            {
                move();
                ScoreLbl.Text = "Score: " + score;
                foreach (Control c in game.Controls)
                {
                    if (c.Bounds.IntersectsWith(Pacman.Bounds))
                    {
                        switch (c.Tag)
                        {
                            case "Wall":
                                switch (moving)
                                {
                                    case "up":
                                        moving = "down";
                                        break;
                                    case "down":
                                        moving = "up";
                                        break;
                                    case "left":
                                        moving = "right";
                                        break;
                                    case "right":
                                        moving = "left";
                                        break;
                                }
                                move();
                                moving = "";
                                break;
                            case "Coin":
                                if (c.Visible)
                                {
                                    score++;
                                    c.Visible = false;
                                    if (score % 17 == 0 && score > 0) resetGame();
                                }
                                break;
                            case "Ghost":
                                alive = false;
                                break;
                        }
                    }
                }
            }
            else
            {
                Tick.Enabled = false;
                Pacman.BackColor = Color.Crimson;
                MessageBox.Show("You died!");
                score = 0;
                resetGame();
            }
        }

        private void move()
        {
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
        }

        private void resetGame()
        {
            Pacman.BackColor = Color.Gold;
            alive = true;
            moving = "";
            Tick.Enabled = true;
            Pacman.Location = new Point(439, 440);
            foreach (Control c in game.Controls)
            {
                if (c.Tag == "Coin") c.Visible = true;
            }
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case Keys.Left:
                    moving = "left";
                    break;
                case Keys.Right:
                    moving = "right";
                    break;
                case Keys.Up:
                    moving = "up";
                    break;
                case Keys.Down:
                    moving = "down";
                    break;
            }
        }
    }
}
