using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ksu.Cis300.MapViewer
{
    public partial class uxMapViewer : Form
    {
        public uxMapViewer()
        {
            InitializeComponent();
        }   //END OF Initialization METHOD

        private int _initalScale = 10;  //Sets the initial map scale to 10
        private Map _currentMap;        //Creates a variable to hold the Map in

        /// <summary>
        /// Event handler for the OpenMap button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpenMap_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    RectangleF bounds;
                    List<StreetSegment> streets = ReadFile(uxOpenDialog.FileName, out bounds);
                    uxMapContainer.Controls.Clear();
                    _currentMap = new Map(streets, bounds, _initalScale);
                    uxMapContainer.Controls.Add(_currentMap);
                    uxZoomIn.Enabled = true;
                    uxZoomOut.Enabled = false;
                }   //END OF TRY
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }   //END OF CATCH
            }   //END OF IF STATEMENT
        }   //END OF uxOpenMap_Click METHOD

        /// <summary>
        /// Reads the file from the excel CSV doc
        /// </summary>
        /// <param name="fileName">Holds the string name to the file</param>
        /// <param name="mapBounds">Holds the map bounds for the QuadTree class</param>
        /// <returns></returns>
        private static List<StreetSegment> ReadFile(string fileName, out RectangleF mapBounds)
        {
            List<StreetSegment> listOfStreets = new List<StreetSegment>();
            using (StreamReader input = new StreamReader(fileName))
            {
                string[] lines = input.ReadLine().Split(',');
                float width = Convert.ToSingle(lines[0]);
                float length = Convert.ToSingle(lines[1]);
                mapBounds = new RectangleF(0, 0, width, length);
                while (!input.EndOfStream)
                {
                    lines = input.ReadLine().Split(',');
                    PointF xCord = new PointF(Convert.ToSingle(lines[0]), Convert.ToSingle(lines[1]));
                    PointF yCord = new PointF(Convert.ToSingle(lines[2]), Convert.ToSingle(lines[3]));
                    Color color = Color.FromArgb(Convert.ToInt32(lines[4]));
                    StreetSegment newStreet = new StreetSegment(xCord, yCord, color, Convert.ToSingle(lines[5]), Convert.ToInt32(lines[6]));
                    listOfStreets.Add(newStreet);
                }   //END OF WHILE LOOP
            }   //END OF USING STATEMENT
            return listOfStreets;
        }   //END OF ReadFile method

        /// <summary>
        /// Zooms in on the map and resets resolution when available.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxZoomIn_Click(object sender, EventArgs e)
        {
            Point position = uxMapContainer.AutoScrollPosition;
            position.X *= -1;
            position.Y *= -1;
            _currentMap.ZoomIn();
            uxZoomOut.Enabled = true;
            if (_currentMap.possibleZoomIn())
            {
                uxZoomIn.Enabled = true;
            }   //END OF IF STATEMENT
            else
            {
                uxZoomIn.Enabled = false;
            }   //END OF ELSE STATEMENT
            position.X = (position.X * 2) + (uxMapContainer.ClientSize.Width / 2);
            position.Y = (position.Y * 2) + (uxMapContainer.ClientSize.Height / 2);
            uxMapContainer.AutoScrollPosition = new Point(position.X, position.Y);
        }   //END OF uxZoomIn_Click

        /// <summary>
        /// Zooms out on the map and resets resolution when available.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxZoomOut_Click(object sender, EventArgs e)
        {
            Point position = uxMapContainer.AutoScrollPosition;
            position.X *= -1;
            position.Y *= -1;
            _currentMap.ZoomOut();
            uxZoomIn.Enabled = true;
            if (_currentMap.possibleZoomOut())
            {
                uxZoomOut.Enabled = true;
            }   //END OF IF STATEMENT
            else
            {
                uxZoomOut.Enabled = false;
            }   //END OF ELSE STATEMENT
            position.X = (position.X / 2) - (uxMapContainer.ClientSize.Width / 4);
            position.Y = (position.Y / 2) - (uxMapContainer.ClientSize.Height / 4);
            uxMapContainer.AutoScrollPosition = new Point(position.X, position.Y);
        }   //END OF uxZoomOut_Click
    }   //END OF CLASS
}   //END OF PROGRAM
