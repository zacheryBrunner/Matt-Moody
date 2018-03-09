using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ksu.Cis300.ConnectFour;

namespace Ksu.Cis300.ConnectFour
{
    public partial class ConnectFour : Form
    {
        private Game _game = new Game();    //Creates a new Game object
        private int _counter = 0;

        /// <summary>
        /// Initalizes the FlowDirections and puts buttons and labels in 
        /// them
        /// </summary>
        public ConnectFour()
        {
            InitializeComponent();
            for (int i = 0; i < 7; i++)
            {
                Button uxbutton = new Button();
                uxbutton.Text = ((char)('A' + i)).ToString();
                uxbutton.Name = ((char)('A' + i)).ToString();
                uxbutton.Width = 45;
                uxbutton.Height = 20;
                uxbutton.Margin = new System.Windows.Forms.Padding(5);
                uxbutton.Click += Button_Click;
                uxPlaceButtonContainer.Controls.Add(uxbutton);
                if(_game.Column == null)
                {
                    _game.Column = new DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>>(uxbutton.Name);
                }
                else
                {
                    while(_game.Column.Next != null)
                    {
                        _game.Column = _game.Column.Next;
                    }
                    DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>> temp = new DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>>(uxbutton.Name);
                    temp.Next = null;
                    temp.Prev = _game.Column;
                    _game.Column.Next = temp;
                }
                for(int j = Game.ColumnSize; j > 0; j--)
                {
                    Label uxlabel = new Label();
                    uxlabel.Width = 45;
                    uxlabel.Height = 45;
                    uxlabel.Margin = new System.Windows.Forms.Padding(5);
                    uxlabel.BackColor = Color.White;
                    uxlabel.Name = (((char)('A' + i)).ToString() + j.ToString());
                    uxBoardContainer.Controls.Add(uxlabel);
                }   //END OF INNER FOR LOOP
            }   //END OF OUTTER FOR LOOP
            uxTurnLabel.BackColor = Color.Red;
            uxTurnLabel.ForeColor = Color.Black;
            uxTurnLabel.Text = "Red";
        }   //END OF ConnectFour METHOD

        /// <summary>
        /// This event handler takes care of placing a new 
        /// game piece on the board in the corresponding column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonHit = button.Text;
            _game.FindColumn(buttonHit);
            Color color = new Color();
            if (uxTurnLabel.BackColor == Color.Red)
            {
                color = Color.Red;
                uxTurnLabel.BackColor = Color.Black;
                uxTurnLabel.ForeColor = Color.White;
                uxTurnLabel.Text = "Black";

            }   //END OF IF
            else
            {
                color = Color.Black;
                uxTurnLabel.BackColor = Color.Red;
                uxTurnLabel.ForeColor = Color.Black;
                uxTurnLabel.Text = "Red";
            }   //END OF ELSE

            if(_game.Column.Data == null)
            {
                _game.Column.Data = new DoubleLinkedListCell<GamePiece>(buttonHit + 1);
                _game.Column.Data.Data = new GamePiece(color, 1, Convert.ToChar(buttonHit));
                SetColor(buttonHit + "1", color);
            }else
            {
                GamePiece add = new GamePiece(color, _game.Column.Data.Data.Row + 1, Convert.ToChar(buttonHit));
                DoubleLinkedListCell<GamePiece> newPiece = new DoubleLinkedListCell<GamePiece>((buttonHit + (_game.Column.Data.Data.Row + 1)).ToString());
                newPiece.Data = add;
                newPiece.Next = null;
                newPiece.Prev = _game.Column.Data;
                _game.Column.Data = newPiece;
                SetColor(buttonHit + add.Row.ToString(), color);
                if (_game.Column.Data.Data.Row == 6)
                {
                    button.Enabled = false;
                    _counter++;
                }   //END OF IF
            }   //END OF ELSE

            if ((_game.CheckWin(_game.Column.Data)))
            {
                MessageBox.Show(color.ToString() + " is the winner");
                try
                {
                    Environment.Exit(0);
                }   //END OF TRY
                catch
                { } //END OF CATCH
            }   //END OF IF
            if (_counter == 7)
            {
                MessageBox.Show("It is a Draw");
                try
                {
                    Environment.Exit(0);
                }   //END OF TRY
                catch
                { } //END OF CATCH
            }   //END OF IF
        }   //END OF uxButton_Click
        
        /// <summary>
        /// This method searches for the slot Label and changes the color
        /// </summary>
        /// <param name="id">Holds the corresponding Name to the label color needing changed</param>
        /// <param name="color">Holds the color that needs to be put in the label</param>
        private void SetColor(string id, Color color)
        {
            Control[] arr = uxBoardContainer.Controls.Find(id, true);
            ((Label)arr[0]).BackColor = color;
        }   //END OF SetColor METHOD
    }   //END OF CLASS
}   //END OF PROGRAM
