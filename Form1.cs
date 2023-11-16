using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CozyClicker.Properties;

namespace CozyClicker
{
    public partial class Form1 : Form
    {
        int ClicksDoneInt = 0;

        bool IsUpgrade1 = false;
        bool IsUpgrade2 = false;
        bool IsUpgrade3 = false;
        bool IsUpgrade4 = false;
        bool IsUpgrade5 = false;
        bool IsUpgrade6 = false;

        public Form1()
        {
            InitializeComponent();

            this.Closed += Form1_Closed;
        }

        private void Form1_Closed(object sender, EventArgs e)
        {
            Save();
        }

        private void ClickFunction()
        {
            ClicksDoneInt++;
        }

        private void ClickMoon_Click(object sender, EventArgs e)
        {
            ClickFunction();
            AnimateClick();
            RandomBonusManager();
            label1.Text = "Your Clicks: " + ClicksDoneInt;
        }

        private async Task AnimateClick()
        {
            labelStar.Visible = true;

            await Task.Delay(150);

            labelStar.Visible = false;
        }

        private void Save()
        {
            Settings.Default.ClicksDone = ClicksDoneInt;
            Settings.Default.Upgrade1 = IsUpgrade1;
            Settings.Default.Upgrade2 = IsUpgrade2;
            Settings.Default.Upgrade3 = IsUpgrade3;
            Settings.Default.Upgrade4 = IsUpgrade4;
            Settings.Default.Upgrade5 = IsUpgrade5;
            Settings.Default.Upgrade6 = IsUpgrade6;
            Settings.Default.Save();
        }

        private void ClickerBuy1_Click(object sender, EventArgs e)
        {
            if (ClicksDoneInt >= 250 && IsUpgrade1 == false)
            {
                IsUpgrade1 = true;
                ClicksDoneInt -= 250;
                ClickerBuy1.Visible = false;
            }
        }

        private void ClickerBuy2_Click(object sender, EventArgs e)
        {
            if (ClicksDoneInt >= 1000 && IsUpgrade2 == false)
            {
                IsUpgrade2 = true;
                ClicksDoneInt -= 1000;
                ClickerBuy2.Visible = false;
            }
        }

        private void ClickerBuy3_Click(object sender, EventArgs e)
        {
            if (ClicksDoneInt >= 5000 && IsUpgrade3 == false)
            {
                IsUpgrade3 = true;
                ClicksDoneInt -= 5000;
                ClickerBuy3.Visible = false;
            }
        }

        private void ClickerBuy4_Click(object sender, EventArgs e)
        {
            if (ClicksDoneInt >= 10000 && IsUpgrade4 == false)
            {
                IsUpgrade4 = true;
                ClicksDoneInt -= 10000;
                ClickerBuy4.Visible = false;
            }
        }

        private void ClickerBuy5_Click(object sender, EventArgs e)
        {
            if (ClicksDoneInt >= 25000 && IsUpgrade5 == false)
            {
                IsUpgrade5 = true;
                ClicksDoneInt -= 25000;
                ClickerBuy5.Visible = false;
            }
        }

        private void ClickerBuy6_Click(object sender, EventArgs e)
        {
            if (ClicksDoneInt >= 99999 && IsUpgrade6 == false)
            {
                IsUpgrade6 = true;
                ClicksDoneInt -= 99999;
                ClickerBuy6.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsUpgrade1 == true)
            {
                ClicksDoneInt += 2;
            }

            if (IsUpgrade2 == true)
            {
                ClicksDoneInt += 5;
            }

            if (IsUpgrade3 == true)
            {
                ClicksDoneInt += 25;
            }

            if (IsUpgrade4 == true)
            {
                ClicksDoneInt += 99;
            }

            if (IsUpgrade5 == true)
            {
                ClicksDoneInt += 444;
            }

            if (IsUpgrade6 == true)
            {
                ClicksDoneInt += 999;
            }

            label1.Text = "Your Clicks: " + ClicksDoneInt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClicksDoneInt = Settings.Default.ClicksDone;

            if (Settings.Default.Upgrade1 == true)
            {
                IsUpgrade1 = true;
                ClickerBuy1.Visible = false;
            }

            if (Settings.Default.Upgrade2 == true)
            {
                IsUpgrade2 = true;
                ClickerBuy2.Visible = false;
            }

            if (Settings.Default.Upgrade3 == true)
            {
                IsUpgrade3 = true;
                ClickerBuy3.Visible = false;
            }

            if (Settings.Default.Upgrade4 == true)
            { 
                IsUpgrade4 = true;
                ClickerBuy4.Visible = false;
            }

            if (Settings.Default.Upgrade5 == true)
            {
                IsUpgrade5 = true;
                ClickerBuy5.Visible = false;
            }

            if (Settings.Default.Upgrade6 == true)
            {
                IsUpgrade6 = true;
                ClickerBuy6.Visible = false;
            }

            timer1.Start();
        }

        private void RandomBonusManager()
        {
            labelBonus1.Visible = false;
            labelBonus2.Visible = false;
            labelBonus3.Visible = false;
            labelBonus4.Visible = false;
            labelBonus5.Visible = false;
            labelBonus6.Visible = false;
            labelBonus7.Visible = false;
            labelBonus8.Visible = false;

            Random random = new Random();
            int randomNum = random.Next(1, 10); //10% chance

            Random randomStar = new Random();
            int randomStarNum = randomStar.Next(1, 8); //From 1 to 8

            if (randomNum == 1)
            {
                if (randomStarNum == 8)
                {
                    labelBonus8.Visible = true;
                }

                if (randomStarNum == 7)
                {
                    labelBonus7.Visible = true;
                }

                if (randomStarNum == 6)
                {
                    labelBonus6.Visible = true;
                }

                if (randomStarNum == 5)
                {
                    labelBonus5.Visible = true;
                }

                if (randomStarNum == 4)
                {
                    labelBonus4.Visible = true;
                }

                if (randomStarNum == 3)
                {
                    labelBonus3.Visible = true;
                }

                if (randomStarNum == 2)
                {
                    labelBonus2.Visible = true;
                }

                if (randomStarNum == 1)
                {
                    labelBonus1.Visible = true;
                }
            }
        }

        private void labelBonus1_Click(object sender, EventArgs e)
        {
            ClicksDoneInt += 50;
            label1.Text = "Your Clicks: " + ClicksDoneInt;
            labelBonus1.Visible = false;
        }

        private void labelBonus2_Click(object sender, EventArgs e)
        {
            ClicksDoneInt += 50;
            label1.Text = "Your Clicks: " + ClicksDoneInt;
            labelBonus2.Visible = false;
        }

        private void labelBonus3_Click(object sender, EventArgs e)
        {
            ClicksDoneInt += 50;
            label1.Text = "Your Clicks: " + ClicksDoneInt;
            labelBonus3.Visible = false;
        }

        private void labelBonus4_Click(object sender, EventArgs e)
        {
            ClicksDoneInt += 50;
            label1.Text = "Your Clicks: " + ClicksDoneInt;
            labelBonus4.Visible = false;
        }

        private void labelBonus5_Click(object sender, EventArgs e)
        {
            ClicksDoneInt += 50;
            label1.Text = "Your Clicks: " + ClicksDoneInt;
            labelBonus5.Visible = false;
        }

        private void labelBonus6_Click(object sender, EventArgs e)
        {
            ClicksDoneInt += 50;
            label1.Text = "Your Clicks: " + ClicksDoneInt;
            labelBonus6.Visible = false;
        }

        private void labelBonus7_Click(object sender, EventArgs e)
        {
            ClicksDoneInt += 50;
            label1.Text = "Your Clicks: " + ClicksDoneInt;
            labelBonus7.Visible = false;
        }

        private void labelBonus8_Click(object sender, EventArgs e)
        {
            ClicksDoneInt += 50;
            label1.Text = "Your Clicks: " + ClicksDoneInt;
            labelBonus8.Visible = false;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Settings.Default.ClicksDone = 0;
            Settings.Default.Upgrade1 = false;
            Settings.Default.Upgrade2 = false;
            Settings.Default.Upgrade3 = false;
            Settings.Default.Upgrade4 = false;
            Settings.Default.Upgrade5 = false;
            Settings.Default.Upgrade6 = false;
            Settings.Default.Save();

            label1.Text = "Your Clicks: " + ClicksDoneInt;

            ClicksDoneInt = Settings.Default.ClicksDone;
            IsUpgrade1 = Settings.Default.Upgrade1;
            IsUpgrade2 = Settings.Default.Upgrade2;
            IsUpgrade3 = Settings.Default.Upgrade3;
            IsUpgrade4 = Settings.Default.Upgrade4;
            IsUpgrade5 = Settings.Default.Upgrade5;
            IsUpgrade6 = Settings.Default.Upgrade6;

            ClickerBuy1.Visible = true;
            ClickerBuy2.Visible = true;
            ClickerBuy3.Visible = true;
            ClickerBuy4.Visible = true;
            ClickerBuy5.Visible = true;
            ClickerBuy6.Visible = true;
        }
    }
}
