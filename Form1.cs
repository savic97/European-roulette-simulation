using System;
using System.Drawing;
using System.Windows.Forms;

namespace Roulette
{
    public partial class Form1 : Form
    {
        
        private Random randomNumber = new Random();
        private int selectedNumber;
        private string selectedColor;
        private int money = 1000;
        private int bet = 5;
        private int option = 0;
        private int counter = 0;

       
        public Form1()
        {
            InitializeComponent();
        }

     
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
           
            bet = Convert.ToInt32(((RadioButton)sender).Text);
        }

      
        private void button_Click(object sender, EventArgs e)
        {
            
            if (((Button)sender).Tag != null && Convert.ToInt32(((Button)sender).Tag) >= 0 && Convert.ToInt32(((Button)sender).Tag) <= 36)
            {
               
                if (bet >= 10)
                {
                    option = 1;
                    selectedNumber = Convert.ToInt32(((Button)sender).Tag);
                    selectedColor = ((Button)sender).BackColor.ToKnownColor().ToString();
                }
                else
                {
                    MessageBox.Show("Lowest bet on number is 10.\nPlease increase your bet.", "Roulette");
                    return;
                }
            } 
           
            else if (((Button)sender).Text == "1st 12")
            {
                option = 2;
            }
            else if (((Button)sender).Text == "2nd 12")
            {
                option = 3;
            }
            else if (((Button)sender).Text == "3rd 12")
            {
                option = 4;
            }
            else if (((Button)sender).Text == "1-18")
            {
                option = 5;
            }
            else if (((Button)sender).Text == "19-36")
            {
                option = 6;
            }
            else if (((Button)sender).Text == "EVEN")
            {
                option = 7;
            }
            else if (((Button)sender).Text == "ODD")
            {
                option = 8;
            }
            else if (((Button)sender).Text == "RED")
            {
                
                if (bet >= 500)
                {
                    option = 9;
                    selectedColor = ((Button)sender).BackColor.ToKnownColor().ToString();
                }
                else
                {
                    MessageBox.Show("Lowest bet on color is 500.\nPlease increase your bet.", "Roulette");
                    return;
                }
            }
            else if (((Button)sender).Text == "BLACK")
            {
              
                if (bet >= 500)
                {
                    option = 10;
                    selectedColor = ((Button)sender).BackColor.ToKnownColor().ToString();
                }
                else
                {
                    MessageBox.Show("Lowest bet on color is 500.\nPlease increase your bet.", "Roulette");
                    return;
                }
            }
            else if (((Button)sender).Name == "row1")
            {
                option = 11;
            }
            else if (((Button)sender).Name == "row2")
            {
                option = 12;
            }
            else if (((Button)sender).Name == "row3")
            {
                option = 13;
            }
            else
            {
                option = 0;
            }

            ButtonStyle((Button)sender);
        }

        
        private void startWheel_Click(object sender, EventArgs e)
        {
            
            if (option == 0)
            {
                MessageBox.Show("Please, place a bet first.", "Roulette");
            }
            else if (money < bet)
            {
                MessageBox.Show("You don't have that money!", "Roulette");
            }
           
            else
            {
               
                startWheel.Visible = false;
                startWheel.Enabled = false;
                tableLayoutPanel1.Enabled = false;
                tableLayoutPanel1.Focus();

              
                timer1.Enabled = true;
                infoLabel.Text = "Roulette is rolling...";

                
                money -= bet;
                moneyLabel.Text = money.ToString();
            }
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (counter >= 30)
            {
              
                timer1.Enabled = false;
                counter = 0;
                RollWheel();
            }

          
            Image flipImage = pictureBox1.Image;
            flipImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pictureBox1.Image = flipImage;

            
            counter++;
        }

       
        private void RollWheel()
        {
           
            int number = randomNumber.Next(0, 36);
            string color = "None";
            bool even = number % 2 == 0; 
           
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is Button && c.Tag != null)
                {
                    if (Convert.ToInt32(c.Tag) == number)
                    {
                        color = c.BackColor.ToKnownColor().ToString();
                    }
                }
            }

           
            switch (option)
            {
                case 1:
                    if (number == selectedNumber)
                    {
                       
                        infoLabel.Text = color + " " + number + "\nWINNER PAID: +" + (bet * 36);
                        money += (bet * 36);
                        moneyLabel.Text = money.ToString();
                    }
                 
                    else
                    {
                        infoLabel.Text = color + " " + number + "\nLOST: -" + bet;
                    }
                    break;
                case int i when i >= 2 && i <= 4: 
                    if ((number >= 1) && (number <= 12) && option == 2) 
                     
                    {
                        infoLabel.Text = color + " " + number + "\nWINNER PAID: +" + (bet * 3);
                        money += (bet * 3);
                        moneyLabel.Text = money.ToString();
                    }
                    else if ((number >= 13) && (number <= 24) && option == 3) 
                       
                    {
                        infoLabel.Text = color + " " + number + "\nWINNER PAID: +" + (bet * 3);
                        money += (bet * 3);
                        moneyLabel.Text = money.ToString();
                    }
                    else if ((number >= 25) && (number <= 36) && option == 4) 
                      
                    {
                        infoLabel.Text = color + " " + number + "\nWINNER PAID: +" + (bet * 3);
                        money += (bet * 3);
                        moneyLabel.Text = money.ToString();
                    }
                  
                    else
                    {
                        infoLabel.Text = color + " " + number + "\nLOST: -" + bet;
                    }
                    break;
                case int i when i >= 5 && i <= 6: 
                   
                    if ((number >= 1) && (number <= 18) && option == 5) 
                       
                    {
                        infoLabel.Text = color + " " + number + "\nWINNER PAID: +" + (bet * 2);
                        money += (bet * 2);
                        moneyLabel.Text = money.ToString();
                    }
                    else if ((number >= 19) && (number <= 36) && option == 6) 
                       
                    {
                        infoLabel.Text = color + " " + number + "\nWINNER PAID: +" + (bet * 2);
                        money += (bet * 2);
                        moneyLabel.Text = money.ToString();
                    }
                   
                    else
                    {
                        infoLabel.Text = color + " " + number + "\nLOST: -" + bet;
                    }
                    break;
                case int i when i >= 7 && i <= 8: 
                    
                    if ((even == true) && number != 0 & option == 7) 
                       
                    {
                        infoLabel.Text = color + " " + number + "\nWINNER PAID: +" + (bet * 2);
                        money += (bet * 2);
                        moneyLabel.Text = money.ToString();
                    }
                    else if (even == false && number != 0 && option == 8)
                        
                    {
                        infoLabel.Text = color + " " + number + "\nWINNER PAID: +" + (bet * 2);
                        money += (bet * 2);
                        moneyLabel.Text = money.ToString();
                    }
                 
                    else
                    {
                        infoLabel.Text = color + " " + number + "\nLOST: -" + bet;
                    }
                    break;
                case int i when i >= 9 && i <= 10: 
                   
                    if (color == selectedColor)
                      
                    {
                        infoLabel.Text = color + " " + number + "\nWINNER PAID: +" + (bet * 2);
                        money += (bet * 2);
                        moneyLabel.Text = money.ToString();
                    }
                    
                    else
                    {
                        infoLabel.Text = color + " " + number + "\nLOST: -" + bet;
                    }
                    break;
                case int i when i >= 11 && i <= 13: 
                   
                    if ((number % 3 == 0) && option == 11)
                       
                    {
                        infoLabel.Text = color + " " + number + "\nWINNER PAID: +" + (bet * 3);
                        money += (bet * 3);
                        moneyLabel.Text = money.ToString();
                    }
                   
                    else if ((number % 3 == 2) && option == 12)
                    {
                        infoLabel.Text = color + " " + number + "\nWINNER PAID: +" + (bet * 3);
                        money += (bet * 3);
                        moneyLabel.Text = money.ToString();
                    }
                    
                    
                    else if (CheckRow(1, 3, 34, number) && option == 13)
                    {
                        infoLabel.Text = color + " " + number + "\nWINNER PAID: +" + (bet * 3);
                        money += (bet * 3);
                        moneyLabel.Text = money.ToString();
                    }
                   
                    else
                    {
                        infoLabel.Text = color + " " + number + "\nLOST: -" + bet;
                    }
                    break;
                default:
                    break;
            }

            
            startWheel.Enabled = true;
            startWheel.Visible = true;
            tableLayoutPanel1.Enabled = true;
        }

      
        
        private void ButtonStyle(Button button)
        {
            if (button.ForeColor == Color.Yellow)
            {
                tableLayoutPanel1.Focus();
                button.ForeColor = Color.White;
                option = 0;
            }
            else
            {
                foreach (Control c in tableLayoutPanel1.Controls)
                {
                    if (c is Button)
                    {
                        c.ForeColor = Color.White;
                    }
                }

                button.ForeColor = Color.Yellow;
            }
        }

        
       
        private void btnApply_Paint(object sender, PaintEventArgs e)
        {
            Button btnApply = ((Button)sender);

            Rectangle bounds = btnApply.ClientRectangle;
            bounds.Inflate(-3, -3);

            string text = btnApply.Text;
            Font font = btnApply.Font;

            using (SolidBrush backBrush = new SolidBrush(btnApply.BackColor))
            {
                e.Graphics.FillRectangle(backBrush, bounds);
            }

            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                if (btnApply.Enabled)
                {
                    using (Brush foreBrush = new SolidBrush(btnApply.ForeColor))
                    {
                        e.Graphics.DrawString(text, font, foreBrush, bounds, sf);
                    }
                }
                else
                {
                    ControlPaint.DrawStringDisabled(e.Graphics, text, font, btnApply.ForeColor, bounds, sf);
                }
            }
        }

      
        private bool CheckRow(int startingNumber, int add, int lastNumber, int numberToCompare)
        {
            
            for (int i = startingNumber; i <= lastNumber; i+=add)
            {
                
                if (numberToCompare == i)
                {
                    return true;
                }
            }

          
            return false;
        }

       
        private void resetBets_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is Button)
                {
                    c.ForeColor = Color.White;
                }
            }

            infoLabel.Text = "PLACE YOUR BET";
            tableLayoutPanel1.Focus();
            option = 0;
            money = 1000;
            moneyLabel.Text = "1000";
            bet = 5;
            radioButton5.Select();
        }

       
        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
