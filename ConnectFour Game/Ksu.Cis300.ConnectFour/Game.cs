using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ksu.Cis300.ConnectFour
{
    class Game
    {
        public const int ColumnSize = 6;

        /// <summary>
        /// Declares an enum
        /// </summary>
        public enum PlayersTurn
        {
            Red,
            Black
        }   //END OF enum Declaration

        public readonly Color[] PlayerColors = { Color.Red, Color.Black };  //READONLY ARRAY

        private PlayersTurn _turn = PlayersTurn.Red;    //Presets the Turn to red
        /// <summary>
        /// Getter and Setter for turn
        /// </summary>
        public PlayersTurn Turn
        {
            get { return _turn; }
            set { _turn = value; }
        }   //END OF Turn
        
        //Keeps track of the currect column of the doubly linked list
        private DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>> _columns = null;

        /// <summary>
        /// Getter and Setter for column
        /// </summary>
        public DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>> Column
        {
            get { return _columns; }
            set { _columns= value; }
        }   //END OF Column

        /// <summary>
        /// Finds the column the user is working in
        /// </summary>
        /// <param name="columId"></param>
        public void FindColumn(string columId)
        {
            while(columId != _columns.Id)
            {
                if(_columns.Next != null)
                {
                    _columns = _columns.Next;
                }   //END OF IF STATEMENT
                else
                {
                    break;
                }
            }   //END OF WHILE LOOP
            while(columId != _columns.Id)
            {
                if(_columns.Prev != null)
                {
                    _columns = _columns.Prev;
                }   //END OF IF STATEMENT
                else
                {
                    break;
                }
            }   //END OF WHILE LOOP
        }   //END OF FindColum

        /// <summary>
        /// Finds the cell using the string id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A cell containing Data within the ID</returns>
        private DoubleLinkedListCell<GamePiece> FindCell(string id)
        {
            FindColumn(id[0].ToString());
            DoubleLinkedListCell<GamePiece> temp = _columns.Data;   //temp cell to manipulate
            while (temp != null)
            {
                if (temp.Id == id)
                {
                    return temp;
                }   //END OF IF
                else
                {
                    temp = temp.Prev;
                }   //END OF ELSE
            }   //END OF WHILE LOOP
            return null; 
        }   //END OF FindCell

        /// <summary>
        /// This function checks to see if the given cell was placed in a spot that connected four 
        /// game pieces of the same color in a row
        /// </summary>
        /// <param name="cell">Holds the cell ID of the piece just placed</param>
        /// <returns>A boolean holding whether the player won or not</returns>
        public bool CheckWin(DoubleLinkedListCell<GamePiece> cell)
        {
            if (Check(cell.Data.Row, cell.Data.Column, 0, 1, cell.Data.PieceColor))
            {
                return true;
            }   //END OF IF STATEMENT
            else if (Check(cell.Data.Row, cell.Data.Column, 1, 0, cell.Data.PieceColor))
            {
                return true;
            }   //END OF IF STATEMENT
            else if (Check(cell.Data.Row, cell.Data.Column, -1, 1, cell.Data.PieceColor))
            {
                return true;
            }   //END OF IF STATEMENT
            else if (Check(cell.Data.Row, cell.Data.Column, 1, 1, cell.Data.PieceColor))
            {
                return true;
            }   //END OF IF STATEMENT
            else
            {
                return false;
            }   //END OF ELSE
        }   //END OF CheckWin

        /// <summary>
        /// This is a helper function to the CheckWin function
        /// </summary>
        /// <param name="row">Start row</param>
        /// <param name="col">Start col</param>
        /// <param name="RowDirection">Used to traverse the game board</param>
        /// <param name="colDirection">Used to traverse the game board</param>
        /// <param name="color">Color of the "Winner"</param>
        /// <returns>A boolean stating if the Color has won</returns>
        private bool Check(int row, char col, int RowDirection, int colDirection, Color color)
        {
            bool Conditionals = false, ReverseLookUp = true;
            for(int i = 0; i <= 4; i++)
            {
                if (0 < row && row <= ColumnSize && col >= 'A' && col <= 'G')
                {
                    DoubleLinkedListCell<GamePiece> temp = FindCell((col.ToString() + row).ToString());
                    if(temp == null)
                    {
                        if(Conditionals)
                        {
                            ReverseLookUp = false;
                            break;
                        }   //END OF IF STATEMENT
                        else
                        {
                            RowDirection = RowDirection * -1;
                            colDirection = colDirection * -1;
                            Conditionals = true;
                            i = 0;
                        }   //END OF ELSE
                    }   //END OF IF STATEMENT
                    else if(temp.Data.PieceColor != color)
                    {
                        if(Conditionals)
                        {
                            ReverseLookUp = false;
                            break;
                        }   //END OF IF STATEMENT
                        else
                        {
                            RowDirection = RowDirection * -1;
                            colDirection = colDirection * -1;
                            Conditionals = true;
                            i = 0;
                        }   //END OF ELSE
                    }   //END OF ELSE IF
                }   //END OF IF STATEMENT
                else
                {
                    if(Conditionals)
                    {
                        ReverseLookUp = false;
                        break;
                    }   //END OF IF STATEMENT
                    else
                    {
                        RowDirection = RowDirection * -1;
                        colDirection = colDirection * -1;
                        Conditionals = true;
                        i = 0;
                    }   //END OF ELSE STATEMENT
                }   //END OF ELSE STATEMENT
                row += RowDirection;
                col = (char)(col + colDirection);
            }   //END OF FOR LOOP
            return ReverseLookUp;
        }   //END OF Check 
    }   //END OF CLASS
}   //END OF PROGRAM
