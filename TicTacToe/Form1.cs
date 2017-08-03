using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        game myGame = new game();
        

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = myGame.p1.name;
            textBox2.Text = myGame.p2.name;
        }
        
        private void pictureBox0_Click(object sender, EventArgs e)
        {
            myGame.makeMove(pictureBox0, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            myGame.makeMove(pictureBox1, 1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            myGame.makeMove(pictureBox2, 2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            myGame.makeMove(pictureBox3, 3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            myGame.makeMove(pictureBox4, 4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            myGame.makeMove(pictureBox5, 5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            myGame.makeMove(pictureBox6, 6);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            myGame.makeMove(pictureBox7, 7);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            myGame.makeMove(pictureBox8, 8);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myGame.clear();
        }
       
        
    }

    public partial class player 
    {
        public int score { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string symbol { get; set; }
        public player()
        {
            score = 0;
            name = "Asif";
            path = symbol = string.Empty;
        }
        public player(string name, string pth, string symbol)
        {
            this.name = name;
            this.score = 0;
            path = pth;
            this.symbol = symbol;
        }
    }

    public partial class game 
    {
        private string[] board = new string[9];
        private int moves;
        private List<PictureBox> pbList = new List<PictureBox>();

        public player p1 = new player("Asif", "C: \\Users\\theas\\Desktop\\TicTacToe\\TicTacToe\\Stuff\\cross.png", "X");
        public player p2 = new player("John Doe", "C: \\Users\\theas\\Desktop\\TicTacToe\\TicTacToe\\Stuff\\circle.png", "O");
        //public int turn { get; set; }
        public game()
        {
            moves = 0;
            
            for (int i = 0; i < 9; i++)
            {
                board[i] = "blank"; 
            }
        }
        private void clear(List<PictureBox> allPBs)
        {
            moves = 0;

            for (int i = 0; i < 9; i++)
            {
                board[i] = "blank";
            }
            foreach(PictureBox item in allPBs)
            {
                item.Enabled = true;
                item.ImageLocation = string.Empty;
            }
            allPBs.Clear();         //clearing List to free up the memory
            
            
            
        }
        public void clear() 
        {
            clear(pbList);
        }
        //public int flipTurn()
        //{
        //    if (turn == 1)
        //        return 2;
        //    else
        //        return 1;
        //}
        public bool isWinning(string x)
        {
            if (board[0] == x && board[1] == x && board[2] == x)
            {
                return true;
            }
            else if(board[3] == x && board[4] == x && board[5] == x)
            {
                return true;
            }
            else if (board[6] == x && board[7] == x && board[8] == x)
            {
                return true;
            }
            else if (board[0] == x && board[3] == x && board[6] == x)
            {
                return true;
            }
            else if (board[1] == x && board[4] == x && board[7] == x)
            {
                return true;
            }
            else if (board[2] == x && board[5] == x && board[8] == x)
            {
                return true;
            }
            else if (board[2] == x && board[4] == x && board[6] == x)
            {
                return true;
            }
            else if (board[0] == x && board[4] == x && board[8] == x)
            {
                return true;
            }
            return false;
        }
        private void setBoard(int index, string who)
        {
            board[index] = who;
        }
        private bool isValidMove(int index)
        {
            if (board[index] == "blank")
                return true;
            else
                return false;
        }
        public void  makeMove(PictureBox PB, int boxNum) 
        {
            if (isValidMove(boxNum))
            {
                if (moves % 2 == 0)
                {
                    PB.ImageLocation = p1.path;
                    setBoard(boxNum, p1.symbol);
                    if (isWinning(p1.symbol))
                    {
                        MessageBox.Show($"{p1.name} won the match");
                        p1.score += 10;
                        
                        pbList.Add(PB);
                        PB.Enabled = false;
                        clear();
                    }
                }
                else
                {
                    PB.ImageLocation = p2.path;
                    setBoard(boxNum, p2.symbol);
                    if (isWinning(p2.symbol))
                    {
                        MessageBox.Show($"{p2.name} won the match");
                        p2.score += 10;
                        
                        pbList.Add(PB);
                        PB.Enabled = false;
                        clear();
                    }
                }
                pbList.Add(PB);
                PB.Enabled = false;
                
                moves++;
                if(moves == 9)
                {
                    MessageBox.Show("Match Draw");
                    clear(pbList);
                }
            }
            else
            {
                MessageBox.Show("Invalid Move");
            }
        }
    }
}
