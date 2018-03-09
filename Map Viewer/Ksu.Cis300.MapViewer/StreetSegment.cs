using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ksu.Cis300.MapViewer
{
    public struct StreetSegment
    {
        private PointF _start;              //Private vaiable for StreetSegment Class used to hold the information where the line should start
        private PointF _end;                //Private vaiable for StreetSegment Class used to hold the information where the line should end
        private Pen _pen;                   //Private vaiable for StreetSegment Class used to color lines that require specific colors
        private int _visibleLevels;         //Private vaiable for StreetSegment Class used to hold where the line becomes visible

        /// <summary>
        /// Construstor for the StreetSegment
        /// </summary>
        /// <param name="start">Holds the information for the _start variable</param>
        /// <param name="end">Holds the information for the _end variable</param>
        /// <param name="color">Holds the color that the line needs to be</param>
        /// <param name="width">Holds the width of the line</param>
        /// <param name="visible">Holds the zoom level that the line needs to be visible at</param>
        public StreetSegment(PointF start, PointF end, Color color, float width, int visible)
        {
            _start = start;
            _end = end;
            _pen = new Pen(color, width);
            _visibleLevels = visible;
        }   //END OF StreetSegment

        /// <summary>
        /// Getter and setter for the _start variable
        /// </summary>
        public PointF start
        {
            get { return _start; }
            set { _start = value; }
        }   //END OF start

        /// <summary>
        /// Getter and setter for the _end variable
        /// </summary>
        public PointF end
        {
            get { return _end; }
            set { _end = value; }
        }   //END OF end

        /// <summary>
        /// Getter for the visibleLevels variable
        /// </summary>
        public int visibleLevels
        {
            get { return _visibleLevels; }
        }   //END OF visibleLevels

        /// <summary>
        /// Draws the map using the DrawLine method
        /// </summary>
        /// <param name="x">Holds the information for the graphics</param>
        /// <param name="visible">Holds the zoom level each line is visible at</param>
        public void Draw(Graphics x, int scale)
        {
            x.DrawLine(_pen, (scale * _start.X), (scale * _start.Y), (scale * _end.X), (scale * _end.Y));
        }   //END OF DrawSegment
    }   //END OF CLASS
}   //END OF PROGRAM
