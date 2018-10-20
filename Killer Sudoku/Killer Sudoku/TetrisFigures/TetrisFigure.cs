using Killer_Sudoku.TetrisFigures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    abstract class TetrisFigure
    {
        private Cell[] cells;
        private Color color;
        private int result;
        private bool solving;
        private int maxRotation;
        private string operation;
        List<List<int>> figurePermutations;
        List<int> usedPermutations;

        //MaxRotation setter & getter
        public List<List<int>> FigurePermutations
        {
            get { return this.figurePermutations; }
            set { this.figurePermutations = value; }
        }

        //MaxRotation setter & getter
        public string Operation
        {
            get { return this.operation; }
            set { this.operation = value; }
        }

        //MaxRotation setter & getter
        public int MaxRotation
        {
            get { return this.maxRotation; }
            set { this.maxRotation = value; }
        }

        //Solving setter & getter
        public bool Solving
        {
            get { return this.solving; }
            set { this.solving = value; }
        }

        //Cells setter & getter
        public Cell[] Positions
        {
            get { return this.cells; }
            set { this.cells = value; }
        }

        //Color setter & getter
        public Color Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        //Operation value setter & getter
        public int Result
        {
            get { return this.result; }
            set { this.result = value; }
        }

        //Function to init array
        public void InitCells(int [,] coordinates)
        {
            this.cells = new Cell[coordinates.GetLength(0)];
            for (int i=0; i< coordinates.GetLength(0); i++)
            {
                cells[i] = new Cell();
                cells[i].Position = ArrayExt.GetRow(coordinates, i);
            }
        }

        //Rotate function
        public void Rotate()
        {
            int[,] rotationMatrix = { {0,1 }, {-1,0} };

            for (int i=1; i<this.cells.GetLength(0); i++)
            {
                this.cells[i].Position = ArrayOperations.SubtractArray(this.cells[i].Position,this.cells[0].Position);
                this.cells[i].Position = ArrayOperations.MultArrayByMatrix(this.cells[i].Position,rotationMatrix);
                this.cells[i].Position = ArrayOperations.SumArray(this.cells[i].Position, this.cells[0].Position);
            }
        }

        public void SetFigurePermutations(int boardSize)
        {
            switch (this.operation)
            {
                case "sum":
                    this.figurePermutations = Permutations.GetFigureSumPermutations(this.result, this.Positions.Length);
                    break;
                case "mult":
                    this.figurePermutations = Permutations.GetFigureMulPermutations(this.result, this.Positions.Length, boardSize);
                    break;
                default:
                    break;
            }
        }

        public abstract void InitFigureCoordinates(int[] pivot);
       
    }
}
