using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.MapViewer
{
    public partial class Map : UserControl
    {
        public Map()
        {
            InitializeComponent();
        }   //END OF Map Initialization

        /// <summary>
        /// Constant Variable to hold the map MaximumZoom
        /// </summary>
        private const int _maximumZoom = 6;

        private int _currentScale = 1;  //Private Variable to hold the current scale of the map
        private int _currentZoom = 0;   //Private Variable to hold the current zoom of the map
        private QuadTree _mapData;      //Private variable to hold the Map's data

        /// <summary>
        /// This method checks to see if it is possible to zoom in
        /// </summary>
        /// <returns></returns>
        public bool possibleZoomIn()
        {
            return (_currentZoom < _maximumZoom);
        }   //END OF possibleZoomIn

        /// <summary>
        /// This method checks to see if it is possible to zoom out
        /// </summary>
        /// <returns></returns>
        public bool possibleZoomOut()
        {
            return (_currentZoom > 0);
        }   //END OF possibleZoomOut

        /// <summary>
        /// This method checks to see if each street is within the bounds
        /// </summary>
        /// <param name="point"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        private static bool isWithinBounds(PointF point, RectangleF x)
        {
            return (point.X >= x.Left && point.X <= x.Right && point.Y >= x.Top && point.Y <= x.Bottom);
        }   //END OF isWithinBounds

        /// <summary>
        /// Map constuctor
        /// </summary>
        /// <param name="streets">List of streets to be error checked and placed</param>
        /// <param name="bounds">Holds the bounds of the map</param>
        /// <param name="scale">Holds the scale factor of the map</param>
        public Map(List<StreetSegment> streets, RectangleF bounds, int scale)
        {
            InitializeComponent();
            int streetError = 0;
            foreach (StreetSegment street in streets)
            {
                if(!isWithinBounds(street.start, bounds))
                {
                    throw new ArgumentException("Street " + streetError + " is not within the given bounds");
                }   //END OF IF STATEMENT
                if(!isWithinBounds(street.end, bounds))
                {
                    throw new ArgumentException("Street " + streetError + " is not within the given bounds");
                }   //END OF IF STATEMENT
                streetError++;
            }   //END OF foreach LOOP
            _mapData = new QuadTree(streets, bounds, _maximumZoom);
            _currentScale = scale;
            Size = new Size((int)(bounds.Width * scale), (int)(bounds.Height * scale));
        }   //END OF Map CONSTRUCTOR

        /// <summary>
        /// Paints the map
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics paintThis = e.Graphics;
            paintThis.Clip = new Region(ClientRectangle);
            _mapData.Draw(paintThis, _currentScale, _currentZoom);
        }   //END OF onPaint

        /// <summary>
        /// Used to zoom into the map
        /// </summary>
        public void ZoomIn()
        {
            if (possibleZoomIn())
            {
                _currentZoom++;
                _currentScale *= 2;
                Size = new Size(Size.Width * 2, Size.Height * 2);
                Invalidate();
            }   //END OF IF STATEMENT
        }   //END OF ZoomIn

        /// <summary>
        /// Used to zoom out of the map
        /// </summary>
        public void ZoomOut()
        {
            if(possibleZoomOut())
            {
                _currentZoom--;
                _currentScale /= 2;
                Size = new Size(Size.Width / 2, Size.Height / 2);
                Invalidate();
            }   //END OF IF STATEMENT
        }   //END OF ZoomOut
    }   //END OF CLASS
}   //END OF PROGRAM
