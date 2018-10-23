using Killer_Sudoku.TetrisFigures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    public class SerializedBoard
    {
        public int size;
        public List<SerializableFigure> listOfFigures = new List<SerializableFigure>();
        public SerializedBoard()
        {

        }
        public SerializedBoard(List<TetrisFigure> tetrisFigures, int size)
        {
            this.size = size;
            foreach (var figure in tetrisFigures)
            {
                SerializableFigure newFigure = new SerializableFigure();

                newFigure.Positions = figure.Positions;
                newFigure.Result = figure.Result;
                newFigure.MaxRotation = figure.MaxRotation;
                newFigure.Operation = figure.Operation;
                newFigure.Type = figure.Type;
                newFigure.FigurePermutations = figure.FigurePermutations;
                newFigure.FigurePermutations = figure.FigurePermutations;
                listOfFigures.Add(newFigure);
            }
        }
    }
}
