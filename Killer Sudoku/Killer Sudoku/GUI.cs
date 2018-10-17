using Killer_Sudoku.KillerSudokuBoard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Killer_Sudoku
{
    public partial class GUI : Form
    {
        PictureBox[,] board1 = new PictureBox[19, 19];
        PictureBox[,] board2 = new PictureBox[19, 19];
        Board killer;

        public GUI()
        {
            InitializeComponent();

            
            

        }

        private void drawColors(PictureBox pictureBox, Color color)
        {
            pictureBox.BackColor = color;

        }

        private void drawOnPictureBox(string text, PictureBox pictureBox, int xCoordinate, int yCoordinate)
        {
            var image = pictureBox.Image;
            var font = new Font("Arial", 7);
            var graphics = Graphics.FromImage(image);
            graphics.DrawString(text,font, Brushes.Black, new Point(xCoordinate,yCoordinate));
            pictureBox.Image = image;

        }

     


        

        private PictureBox [,] CreateBoard(int positionX, int positionY, int size, int blockSize)
        {
            PictureBox[,] board = new PictureBox[size, size];
            for (int i=0; i<size; i++)
            {
                for (int j=0; j<size; j++)
                {
                    board[i,j] = new PictureBox();
                    board[i,j].Location = new Point(i * blockSize + positionX, j * blockSize + positionY);
                    board[i, j].Width = blockSize;
                    board[i, j].Height = blockSize;
                    board[i, j].Visible = true;
                    board[i, j].BorderStyle = BorderStyle.FixedSingle;
                    board[i, j].BringToFront();
                    board[i, j].Image = new Bitmap(size, size);
                    this.Controls.Add(board[i, j]);
                }
            }
            return board;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void load_killer_Click(object sender, EventArgs e)
        {

            //Function to load Killer Sudoku
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine( openFileDialog1.FileName);
            }


        }
        //Function to save Killer Sudoku
        private void save_killer_Click(object sender, EventArgs e)
        {

        }

        private void thread_input_TextChanged(object sender, EventArgs e)
        {

        }

        private void thread_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkKeyPress(sender, e);   
        }

        private void size_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkKeyPress(sender, e);
        }

        private void checkKeyPress (object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }

            

        }

        private void size_input_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void start_button_Click(object sender, EventArgs e)
        {
            int size = Int32.Parse(size_input.Text);
            this.killer = new Board(size, "sum");
            
            List<TetrisFigure> boardFigures = this.killer.boardFigures;
           
            board1 = CreateBoard(10, 70, size, 25);
            board2 = CreateBoard(570, 70, size, 25);

            foreach (var figure in boardFigures)
            {
                foreach (var cell in figure.Positions)
                {
                    Console.Write(cell.Position[0]+" "+ cell.Position[1]);
                    drawColors(board1[cell.Position[0], cell.Position[1]],figure.Color);
                    drawColors(board2[cell.Position[0], cell.Position[1]], figure.Color);
                }
            }
        }
    }
}
