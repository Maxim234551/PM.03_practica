using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sneak
{
    public partial class Form2 : Form
    {
        private int rI, rJ;
        private PictureBox fruit;
        private PictureBox[] snake = new PictureBox[400];
        private Label labelScore;
        private int dirX, dirY;
        private int width = 820;
        private int height = 720;
        private int sizeOfSides = 40;
        private int score = 0;
        public Form2()
        {
            InitializeComponent();
            this.Text = "Snake";
            this.Width = 900;
            this.Height = 800;
            dirX = 1;
            dirY = 0;
            labelScore = new Label();
            labelScore.Text = "Score: 0";
            labelScore.Font = new Font("Microsoft Sans Serif", 14);
            labelScore.Location = new Point(760, 20);
            this.Controls.Add(labelScore);
            snake[0] = new PictureBox();
            snake[0].Location = new Point(201, 201);
            snake[0].Size = new Size(sizeOfSides - 1, sizeOfSides - 1);
            snake[0].BackColor = Color.DarkGreen;
            this.Controls.Add(snake[0]);
            fruit = new PictureBox();
            fruit.BackColor = Color.Red;
            fruit.Size = new Size(sizeOfSides, sizeOfSides);
            generateMap();
            generateFruit();
            timer1.Tick += new EventHandler(update);
            timer1.Interval = 200;
            timer1.Start();
            this.KeyDown += new KeyEventHandler(OKP);
        }

        private void generateFruit()
        {
            Random r = new Random();
            rI = r.Next(0, height - sizeOfSides);
            int tempI = rI % sizeOfSides;
            rI -= tempI;
            rJ = r.Next(0, height - sizeOfSides);
            int tempJ = rJ % sizeOfSides;
            rJ -= tempJ;
            rI++;
            rJ++;
            fruit.Location = new Point(rI, rJ);
            this.Controls.Add(fruit);
        }

        private void checkBorders()
        {
            if (snake[0].Location.X < 0)
            {
                for (int _i = 1; _i <= score; _i++)
                {
                    this.Controls.Remove(snake[_i]);
                }
                Form4 newForm = new Form4(score);
                newForm.Show();
                this.Close();
            }
            if (snake[0].Location.X > height)
            {
                for (int _i = 1; _i <= score; _i++)
                {
                    this.Controls.Remove(snake[_i]);
                }
                Form4 newForm = new Form4(score);
                newForm.Show();
                this.Close();
            }
            if (snake[0].Location.Y < 0)
            {
                for (int _i = 1; _i <= score; _i++)
                {
                    this.Controls.Remove(snake[_i]);
                }
                Form4 newForm = new Form4(score);
                newForm.Show();
                this.Close();
            }
            if (snake[0].Location.Y > height)
            {
                for (int _i = 1; _i <= score; _i++)
                {
                    this.Controls.Remove(snake[_i]);
                }
                Form4 newForm = new Form4(score);
                newForm.Show();
                this.Close();
            }
        }

        private void eatItself()
        {
            for (int _i = 1; _i < score; _i++)
            {
                if (snake[0].Location == snake[_i].Location)
                {
                    for (int _j = _i; _j <= score; _j++)
                        this.Controls.Remove(snake[_j]);
                    Form4 newForm = new Form4(score);
                    newForm.Show();
                    this.Close();
                }
            }
        }

        private void eatFruit()
        {
            if (snake[0].Location.X == rI && snake[0].Location.Y == rJ)
            {
                labelScore.Text = "Score: " + ++score;
                snake[score] = new PictureBox();
                snake[score].Location = new Point(snake[score - 1].Location.X + 40 * dirX, snake[score - 1].Location.Y - 40 * dirY);
                snake[score].Size = new Size(sizeOfSides - 1, sizeOfSides - 1);
                snake[score].BackColor = Color.ForestGreen;
                this.Controls.Add(snake[score]);
                generateFruit();
            }

            if (score == 50)
            {
                Form3 newForm = new Form3(score);
                newForm.Show();
                this.Close();
            }
        }

        private void generateMap()
        {
            for (int i = 0; i < width / sizeOfSides; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(0, sizeOfSides * i);
                pic.Size = new Size(width - 100, 1);
                this.Controls.Add(pic);
            }
            for (int i = 0; i <= height / sizeOfSides; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(sizeOfSides * i, 0);
                pic.Size = new Size(1, width);
                this.Controls.Add(pic);
            }
        }

        private void moveSnake()
        {
            for (int i = score; i >= 1; i--)
            {
                snake[i].Location = snake[i - 1].Location;
            }
            snake[0].Location = new Point
             (snake[0].Location.X + dirX * (sizeOfSides), 
                snake[0].Location.Y + dirY * (sizeOfSides));
            eatItself();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void update(Object myObject, EventArgs eventsArgs)
        {
            checkBorders();
            eatFruit();
            moveSnake();
            
        }

        private void OKP(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    dirX = 1;
                    dirY = 0;
                    break;
                case "Left":
                    dirX = -1;
                    dirY = 0;
                    break;
                case "Up":
                    dirY = -1;
                    dirX = 0;
                    break;
                case "Down":
                    dirY = 1;
                    dirX = 0;
                    break;
            }
        }
    }
}
