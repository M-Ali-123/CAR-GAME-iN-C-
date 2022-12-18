using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppAli_paf
{
    public partial class Form1 : Form
    {

        int trafficSpeed = 15;
        int roadSpeed = 15;
        int playerSpeed = 12;
        int score;
        int carImage;

        Random rand = new Random();
        Random carPosition = new Random();
        bool goleft, goright;
        bool goUp, goDown;
        public Form1()
        {
            InitializeComponent();
        }

        private void resetGame(object sender, EventArgs e)
        {

            ResetGame();

        }
        private void ResetGame()
        {
            btnStart.Enabled = false;
            explosion.Visible = false;
            award.Visible = false;
            goleft = false;
            goright = false;
            goUp = false;
            goDown = false;
            score = 0;
            award.Image = Properties.Resources.bronze;
            roadSpeed = 12;
            trafficSpeed = 15;
            A1.Top = carPosition.Next(200, 500) * -1;
            A1.Left = carPosition.Next(5, 200);
            A2.Top = carPosition.Next(200, 500) * -1;
            A2.Left = carPosition.Next(245, 422);
            gameTimer.Start();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {

            textScore.Text = "Score : " + score;
            score++;

            if (goleft == true && player.Left > 10)
            {
                player.Left -= playerSpeed;
            }
            if (goright == true && player.Left < 415)
            {
                player.Left += playerSpeed;
            }
            if (goUp == true)
            {
                trafficSpeed += 10;
                roadSpeed += 10;
                //player.Up += playerSpeed;
            }
            if (goDown == true)
            {
                trafficSpeed -= 5;
                roadSpeed -= 5;
                //player.Up += playerSpeed;
            }




            roadtrack1.Top += roadSpeed;
            roadtrack2.Top += roadSpeed;

            if (roadtrack2.Top > 519)
            {
                roadtrack2.Top = -519;
            }
            if (roadtrack1.Top > 519)
            {
                roadtrack1.Top = -519;
            }

            A1.Top += trafficSpeed;
            A2.Top += trafficSpeed;

            if (A1.Top > 530)
            {
                ChangeACars(A1);
            }
            if (A2.Top > 530)
            {
                ChangeACars(A2);
            }

            if (player.Bounds.IntersectsWith(A1.Bounds)||
                player.Bounds.IntersectsWith(A2.Bounds))
            {
                gameOver();
            }
            if (score > 40 && score < 500)
            {
                award.Image = Properties.Resources.bronze;
                roadSpeed = 10;
                trafficSpeed = 15;
            }
            if (score > 500 && score < 1000)
            {
                award.Image = Properties.Resources.silver;
                roadSpeed = 15;
                trafficSpeed = 17;
            }
            if (score > 1000)
            {
                award.Image = Properties.Resources.gold;
                roadSpeed = 20;
                trafficSpeed = 20;
            }
          

        }
        
        private void gameOver()
        {
            gameTimer.Stop();
            explosion.Visible = true;
            player.Controls.Add(explosion);
            explosion.Location = new Point(-8, 5);
            explosion.BackColor = Color.Transparent;
            award.Visible = true;
            award.BringToFront();
            btnStart.Enabled = true;
        }

        private void ChangeACars(PictureBox tempCar)
        {
            carImage = rand.Next(1, 7);
            switch (carImage)
            {
                case 1:
            tempCar.Image = Properties.Resources.ambulance;
            break;
        case 2:
            tempCar.Image = Properties.Resources.carGreen;
            break;
                case 3:
                    tempCar.Image = Properties.Resources.carGrey;
                    break;
                case 4:
                    tempCar.Image = Properties.Resources.carOrange;
                    break;
                case 5:
                    tempCar.Image = Properties.Resources.carPink;
                    break;
                case 6:
                    tempCar.Image = Properties.Resources.CarRed;
                    break;
                case 7:
                    tempCar.Image = Properties.Resources.TruckBlue;
                    break;
                case 8:
                    tempCar.Image = Properties.Resources.TruckWhite;
                    break;
            }
            tempCar.Top = carPosition.Next(100, 400) * -1;
            if ((string)tempCar.Tag == "carLeft")
            {
                tempCar.Left = carPosition.Next(5, 200);
            }
            if ((string)tempCar.Tag == "carRight")
            {
                tempCar.Left = carPosition.Next(245, 422);
            }
        }

        private void roadtrack2_Click(object sender, EventArgs e)
        {

        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
            

        }

        private void keyisup(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

        }
    }
}
