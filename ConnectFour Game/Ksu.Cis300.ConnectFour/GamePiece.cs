using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ksu.Cis300.ConnectFour
{
    class GamePiece
    {
        private Color _pieceColor;
        private char _column;
        private int _row;
        /// <summary>
        /// Gets or Sets a color for a chip within the game of Connect Four
        /// </summary>
        public Color PieceColor
        {
            get { return _pieceColor; }
            set { _pieceColor = value; }
        }   //END OF PieceColor
      
        /// <summary>
        /// Gets or Sets the row for a chip within the game of Connect Four
        /// </summary>
        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }   //END OF Row
        
        /// <summary>
        /// Gets or Sets the Column within the game of Connect Four
        /// </summary>
        public char Column
        {
            get { return _column; }
            set { _column = value; }
        }

        /// <summary>
        /// Creates a new GamePiece object named gamePiece
        /// </summary>
        /// <param name="color">Color of the piece</param>
        /// <param name="row">Row location of the piece</param>
        /// <param name="column">Column of the piece</param>
        public GamePiece(Color color, int row, char column)
        {
            PieceColor = color;
            Row = row;
            Column = column;
        }   //END OF gamePiece method
    }   //END OF class
}   //END OF PROGRAM
