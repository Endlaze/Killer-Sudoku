using Killer_Sudoku.KillerSudokuSolver;
using Killer_Sudoku.TetrisFigures;
using Killer_Sudoku.TetrisFigures.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku.KillerSudokuBoard
{
    class Board
    {
        private int[] colors;
        private int size;
        private int[,] values;
        public Cell [,] board;
        public List<TetrisFigure> boardFigures = new List<TetrisFigure>();
        private string operation;

        public Board(int size, string operation)
        {
            this.size = size;
            this.values = ArrayExt.InitIntMatrix(size);
            this.board= new Cell[size, size];
            InitBoard(size);
            KillerSudokuSolver.SudokuSolver sudoku = new SudokuSolver();
            this.values = sudoku.GetSudokuBoard(size);
            this.operation = operation;
            fitTetrisFigures();

        }

        //Function to init the board
        public void InitBoard (int size)
        {
            for (int i=0; i<size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int[] position = { i, j };
                    this.board[i, j] = new Cell();
                    this.board[i, j].Position = position;
                }
            }
        }

        //Function to fit the tetris figures in the board
        public void fitTetrisFigures()
        {
            for (int i=0; i<board.GetLength(0); i++)
            {
                for (int j=0; j<board.GetLength(1); j++)
                {
                    if (!checkCell(board[i,j])) {
                        int[] pivot = { i, j };
                        TetrisFigure figure = figureThatFits(pivot);
                        updateIsPartOfAFigure(figure);
                        Random rnd = new Random();
                        figure.Color = Color.FromArgb(rnd.Next(100, 256), rnd.Next(100, 256), rnd.Next(100, 256));

                        this.boardFigures.Add(figure);
                    }
                }
            }
        }

        public TetrisFigure figureThatFits(int [] pivot)
        {   string[] figures = { "block", "gun", "skew", "straight", "straight", "straight" };
            int[] figuresSizes = { 0, 0, 0, 3, 2, 1 };
            int cont = 1;
            int rotated = 0;
            int figurePosition = new Random().Next(figures.Length);
            int[] testedFigures = new int[6];
            testedFigures[0] = figurePosition;
            TetrisFigure figure = FigureFactory.GetNewFigure(figures[figurePosition], figuresSizes[figurePosition]);
            figure.InitFigureCoordinates(pivot);
            while (!canBePlaced(figure))
            {
                if (rotated<figure.MaxRotation) {
                    figure.Rotate();
                    rotated++;
                }
                else
                {
                    figurePosition = Utils.Utils.GiveMeANumber(testedFigures, figures.Length);
                    testedFigures[cont] = figurePosition;
                    figure = FigureFactory.GetNewFigure(figures[figurePosition], figuresSizes[figurePosition]);
                    figure.InitFigureCoordinates(pivot);
                    cont++;
                    rotated = 0;
                }
                
            }
            
            return figure;
        }

        public bool canBePlaced(TetrisFigure figure)
        {
            foreach (Cell cell in figure.Positions)
            {
                if (!fits(cell)) { return false; }
                if (checkCell(cell)) { return false; }
            }
            return true;
        }

        public bool fits(Cell cell)
        {
            int row = cell.Position[0];
            int col = cell.Position[1];

            if ((row > (size - 1)) || (col >(size-1)) || (row <0) || (col<0))
            {
                return false;
            }
            return true;
        }

        public bool checkCell(Cell cell)
        {
            int row = cell.Position[0];
            int col = cell.Position[1];

            return this.board[row, col].isPartOfAFigure(); 
        }

        public void updateIsPartOfAFigure(TetrisFigure figure)
        {
            
            int result = 0;
           
            if (this.operation.Equals("mult"))
            {
                result = 1;
            }

            foreach (Cell cell in figure.Positions)
            {
                cell.PartOfAFigure = true;
                result = ApplyOperation(values[cell.Position[0], cell.Position[1]], result);
                board[cell.Position[0], cell.Position[1]] = cell;
            }
            figure.Result = result;
            
        }

        public int ApplyOperation(int num, int result)
        {
            switch (this.operation)
            {
                case "sum":
                    return result + num;
                    break;
                case "mult":
                    return result * num;
                default:
                    return result;
            }
        }
    }
}
