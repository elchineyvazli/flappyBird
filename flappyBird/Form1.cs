using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappyBird
{
    public partial class flappyBirdGame : Form
    {
        int antiGravity = -10;
        int gravity = 10;
        int score = 0;
        int pipeSpeed = 18;
        Random random = new Random();

        public flappyBirdGame()
        {
            InitializeComponent();
            gameStart();
        }
        public void gameStart()
        {
            gameTimer.Start();

            playButton.Enabled = false;

            flappyBird.Location = new Point(143, 176);

            pipeTop.Location = new Point(802, 1);

            pipeBottom.Location = new Point(802, 379);

            score = 0;

            labelScore.Text = score.ToString();
        }

        private void flappyBirdGame_Load(object sender, EventArgs e)
        {
            
        }

        private void flappyBirdGame_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void flappyBirdGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;

            score++;

            labelScore.Text = score.ToString();

            pipeBottom.Left -= pipeSpeed;

            pipeTop.Left -= pipeSpeed;

            if(pipeBottom.Left < -25)
            {
                pipeBottom.Left = 1095;
            }

            if(pipeTop.Left < -50)
            {
                pipeTop.Left = 1120;
            }

            if(flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) || flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds)
                || flappyBird.Bounds.IntersectsWith(place .Bounds) || flappyBird.Bounds.IntersectsWith(topPlace.Bounds))
            {
                gameOver();
            }
        }
        public void gameOver()
        {
            gameTimer.Stop();
            playButton.Enabled = true;
            MessageBox.Show("Game Over and your score : " + labelScore.Text);
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            gameStart();
        }
    }
}
