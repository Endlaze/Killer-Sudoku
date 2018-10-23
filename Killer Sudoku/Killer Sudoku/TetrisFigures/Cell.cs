using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku.TetrisFigures
{
    public class Cell
    {
       public Cell() { }
       private  int[] position;
       private  int number;
       private bool partOfAFigure = false;

        //Position setter & getter
        public int [] Position
        {
            get { return this.position;}
            set { this.position = value;}
        }
        //Number setter & getter
        public int Number
        {
            get { return this.number;}
            set { this.number = value;}
        }

        //PartOfAFigure setter & getter
        public bool PartOfAFigure
        {
            get { return this.partOfAFigure; }
            set { this.partOfAFigure = value; }
        }

        public bool isPartOfAFigure()
        {
            if (this.partOfAFigure)
            {
                return true;
            }

            return false;
        }
    }
}
