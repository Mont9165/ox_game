using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace まるばつゲーム
{
    public partial class Form1 : Form
    {
        

        Button[] buttons = new Button[9];
        int[,] PlayerBorad = new int[,] {{ 0,0,0 }, { 0,0,0 }, { 0,0,0 }};
        int[,] ComputerBorad = new int[,] { { 0,0,0 }, { 0,0,0 }, { 0,0,0 } };

        public Form1()
        {
            InitializeComponent();

        }

        private void button_Click(object sender, EventArgs e)
        {
           
            //ここでプレイヤーのマーク記入とボタン無効化
            Debug.WriteLine("プレイヤー ボタン選択");

            Button PrayerButtton = (Button)sender;
            string namePB = PrayerButtton.Name;   //buttonのNameプロパティ
            PrayerButtton.Enabled = false;
            PrayerButtton.Text = "〇";

            string n = namePB.Replace("button", "");
            int num = int.Parse(n) - 1;

            if (num == 0) { PlayerBorad[0, 0] = 1; }
            if (num == 1) { PlayerBorad[0, 1] = 1; }
            if (num == 2) { PlayerBorad[0, 2] = 1; }
            if (num == 3) { PlayerBorad[1, 0] = 1; }
            if (num == 4) { PlayerBorad[1, 1] = 1; }
            if (num == 5) { PlayerBorad[1, 2] = 1; }
            if (num == 6) { PlayerBorad[2, 0] = 1; }
            if (num == 7) { PlayerBorad[2, 1] = 1; }
            if (num == 8) { PlayerBorad[2, 2] = 1; }

           
            if (isWin() == true & isLose() == false)
            {
                label1.Text = "You Win!!";
                label1.Enabled = false;

                for (int i = 0; i < 9; i++)
                {
                    buttons[i].Enabled = false;
                }
            }


            //ここでコンピュータのマーク記入とボタン無効化
            Debug.WriteLine("コンピュータ ボタン選択");
            

            for(int i= 0; i < 9; i++)
            {
                if(buttons[i].Enabled == true)
                {
                    buttons[i].Enabled = false;
                    buttons[i].Text = "×";
                    if (i == 0) { ComputerBorad[0, 0] = 1; }
                    if (i == 1) { ComputerBorad[0, 1] = 1; }
                    if (i == 2) { ComputerBorad[0, 2] = 1; }
                    if (i == 3) { ComputerBorad[1, 0] = 1; }
                    if (i == 4) { ComputerBorad[1, 1] = 1; }
                    if (i == 5) { ComputerBorad[1, 2] = 1; }
                    if (i == 6) { ComputerBorad[2, 0] = 1; }
                    if (i == 7) { ComputerBorad[2, 1] = 1; }
                    if (i == 8) { ComputerBorad[2, 2] = 1; }
                    break;
                }
            }


            if (isWin() == true && isLose() == false)
            {
                label1.Text = "You Win!!";
                label1.Enabled = false;

                for(int i = 0; i < 9; i++)
                {
                    buttons[i].Enabled = false;
                }
            }
            else if((isWin() == true && isLose() == true) || (isWin() == false && isLose() == false))
            {
                label1.Text = "Draw...";
                label1.Enabled = false;
                
            }
            else if (isWin() == false && isLose() == true)
            {
                label1.Text = "You Lose ^__^";
                label1.Enabled = false;

                for (int i = 0; i < 9; i++)
                {
                    buttons[i].Enabled = false;
                }
            }
            
            
        }

        private bool isWin()
        {
            Boolean win = false;
 
            //横
            if (PlayerBorad[0, 0] == 1 && PlayerBorad[0, 1] == 1 && PlayerBorad[0, 2] == 1) { win = true; }
            if (PlayerBorad[1, 0] == 1 && PlayerBorad[1, 1] == 1 && PlayerBorad[1, 2] == 1) { win = true; }
            if (PlayerBorad[2, 0] == 1 && PlayerBorad[2, 1] == 1 && PlayerBorad[2, 2] == 1) { win = true; }
            //縦
            if (PlayerBorad[0, 0] == 1 && PlayerBorad[1, 0] == 1 && PlayerBorad[2, 0] == 1) { win = true; }
            if (PlayerBorad[0, 1] == 1 && PlayerBorad[1, 1] == 1 && PlayerBorad[2, 1] == 1) { win = true; }
            if (PlayerBorad[0, 2] == 1 && PlayerBorad[1, 2] == 1 && PlayerBorad[2, 2] == 1) { win = true; }
            //斜め
            if (PlayerBorad[0, 0] == 1 && PlayerBorad[1, 1] == 1 && PlayerBorad[2, 2] == 1) { win = true; }
            if (PlayerBorad[0, 2] == 1 && PlayerBorad[1, 1] == 1 && PlayerBorad[2, 0] == 1) { win = true; }
 


            return win;
        }

        private bool isLose()
        {
            Boolean lose = false;

            //横
            if (ComputerBorad[0, 0] == 1 && ComputerBorad[0, 1] == 1 && ComputerBorad[0, 2] == 1) { lose = true; }
            if (ComputerBorad[1, 0] == 1 && ComputerBorad[1, 1] == 1 && ComputerBorad[1, 2] == 1) { lose = true; }
            if (ComputerBorad[2, 0] == 1 && ComputerBorad[2, 1] == 1 && ComputerBorad[2, 2] == 1) { lose = true; }
            //縦
            if (ComputerBorad[0, 0] == 1 && ComputerBorad[1, 0] == 1 && ComputerBorad[2, 0] == 1) { lose = true; }
            if (ComputerBorad[0, 1] == 1 && ComputerBorad[1, 1] == 1 && ComputerBorad[2, 1] == 1) { lose = true; }
            if (ComputerBorad[0, 2] == 1 && ComputerBorad[1, 2] == 1 && ComputerBorad[2, 2] == 1) { lose = true; }
            //斜め
            if (ComputerBorad[0, 0] == 1 && ComputerBorad[1, 1] == 1 && ComputerBorad[2, 2] == 1) { lose = true; }
            if (ComputerBorad[0, 2] == 1 && ComputerBorad[1, 1] == 1 && ComputerBorad[2, 0] == 1) { lose = true; }



            return lose;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //9 buttons input
            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;


        }

        

 
        
    }
}
