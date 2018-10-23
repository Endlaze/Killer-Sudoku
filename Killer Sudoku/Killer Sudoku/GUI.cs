﻿using Killer_Sudoku.KillerSudokuBoard;
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
        PictureBox[,] board1;
        
        

        KillerSudokuSolver.KillerSudokuSolver killerSudokuSolver;
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
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            graphics.DrawString(text, font, Brushes.Black, new Point(xCoordinate, yCoordinate));
            pictureBox.Image = image;

        }

        private PictureBox[,] CreateBoard(int positionX, int positionY, int size, int blockSize)
        {
            PictureBox [,]board = new PictureBox[size, size];
            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = new PictureBox();
                    board[i, j].Location = new Point(i * blockSize + positionX, j * blockSize + positionY);
                    board[i, j].Width = blockSize;
                    board[i, j].Height = blockSize;
                    board[i, j].Visible = true;
                    board[i, j].BorderStyle = BorderStyle.FixedSingle;
                    board[i, j].BringToFront();
                    board[i, j].Image = new Bitmap(blockSize, blockSize);
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
                Console.WriteLine(openFileDialog1.FileName);
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

        private void checkKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void generate_button_Click(object sender, EventArgs e)
        {
            
            int size = Int32.Parse(size_input.Text);
            int threads = Int32.Parse(thread_input.Text);
            board1 = new PictureBox[size, size];

            this.killer = new Board(size, threads);
            List<TetrisFigure> boardFigures = this.killer.boardFigures;
            board1 = CreateBoard(10, 70, size, 33);
            

            foreach (var figure in boardFigures)
            {
                foreach (var cell in figure.Positions)
                {
                    drawColors(board1[cell.Position[0], cell.Position[1]], figure.Color);
                    
                }
            }

            foreach (var figure in boardFigures)
            {
                drawOnPictureBox(figure.Result.ToString(), board1[figure.Positions[0].Position[0], figure.Positions[0].Position[1]], 0, 0);
                if (figure.Operation.Equals("sum"))
                {
                    drawOnPictureBox("+", board1[figure.Positions[0].Position[0], figure.Positions[0].Position[1]], 24,0);
                }
                else
                {
                    drawOnPictureBox("x", board1[figure.Positions[0].Position[0], figure.Positions[0].Position[1]], 24, 0);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int size = Int32.Parse(size_input.Text);
            int threads = Int32.Parse(thread_input.Text);

            this.killerSudokuSolver = new KillerSudokuSolver.KillerSudokuSolver(size, threads, this.killer);
            //this.killerSudokuSolver.start();
            int[,] matrix = this.killerSudokuSolver.GetSudokuBoard();

            ArrayExt.Print2DArray(matrix);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    drawOnPictureBox(matrix[i,j].ToString(), board1[i, j], 14, 14);

                }

            }
           // board1 = CreateBoard(10, 70, size, 33);

            
        }
    }
}
