using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ksu.Cis300.MapViewer
{
    class QuadTree
    {
        //Private QuadTree variables used to store the children
        private QuadTree _northEastChild;                
        private QuadTree _northWestChild;                
        private QuadTree _southEastChild;
        private QuadTree _southWestChild;

        private RectangleF _rectangle;              //Private variables used to store the location in the map where this node is used
        private List<StreetSegment> _streets;       //Contains information on where the streets are assosiated with the node

        /// <summary>
        /// Method is used to iterate through the street segments to split between invisible and visible
        /// </summary>
        /// <param name="split">Holds all street segments to split between invisible and visible</param>
        /// <param name="height">Holds the height of the current tree</param>
        /// <param name="place">Holds a list of all streets that are visible at the current level</param>
        /// <param name="invisible">Holds a list of all streets that are invisible at the current level</param>
        private static void visibility(List<StreetSegment> split, int height, List<StreetSegment> place, List<StreetSegment> invisible)
        {
            foreach(StreetSegment street in split)
            {
                if(street.visibleLevels > height)
                {
                    place.Add(street);
                }   //END OF IF STATEMENT
                else
                {
                    invisible.Add(street);
                }   //END OF ELSE STATEMENT
            }   //END OF foreach LOOP
        }   //END OF visibility

        /// <summary>
        /// Iterates through the street segments to split east or west
        /// </summary>
        /// <param name="split">List of streetSegments to split</param>
        /// <param name="vertical">giving the value of a verticle line</param>
        /// <param name="west">street segments west of the given vertical line will be placed here</param>
        /// <param name="east">street segments east of the given vertical line will be placed here</param>
        private static void eastOrWest(List<StreetSegment> split, float vertical, List<StreetSegment> west, List<StreetSegment> east)
        {
            foreach(StreetSegment street in split)
            {
                if (street.start.X <= vertical && street.end.X <= vertical)
                {
                    west.Add(street);
                }   //END OF IF STATEMENT
                else if (street.start.X >= vertical && street.end.X >= vertical)
                {
                    east.Add(street);
                }   //END OF ELSE-IF STATEMENT
                else
                {
                    if (street.start.X != street.end.X)
                    {
                        StreetSegment tempEast = street;
                        StreetSegment tempWest = street;
                        float YCord = (((street.end.Y - street.start.Y) / (street.end.X - street.start.X)) * (vertical - street.start.X)) + street.start.Y;
                        PointF tempE = new PointF(vertical, YCord);
                        tempWest.end = tempE;
                        tempEast.start = tempE;
                        if (tempWest.start.X <= vertical)
                        {
                            west.Add(tempWest);
                            east.Add(tempEast);
                        }   //END OF IF STATEMENT
                        else
                        {
                            west.Add(tempEast);
                            east.Add(tempWest);
                        }   //END OF ELSE STATEMENT
                    }   //END OF IF STATEMENT
                }   //END OF ELSE-IF STATEMENT
            }   //END OF foreach LOOP
        }   //END OF eastORWest METHOD

        /// <summary>
        /// Method used to split the streets into north or south lists
        /// </summary>
        /// <param name="split">Full list of streets</param>
        /// <param name="horizontal">The horizontal point we are splitting upon</param>
        /// <param name="north">The list that will be modified to hold the north streets</param>
        /// <param name="south">The list that will be modified to hold the south streets</param>
        private static void northOrSouth(List<StreetSegment> split, float horizontal, List<StreetSegment> north, List<StreetSegment> south)
        {
            foreach(StreetSegment street in split)
            {
                if(street.start.Y <= horizontal && street.end.Y <= horizontal)
                {
                    south.Add(street);
                }   //END OF IF STATEMENT
                else if (street.start.Y >= horizontal && street.end.Y >= horizontal)
                {
                    north.Add(street);
                }   //END OF ELSE-IF STATEMENT
                else
                {
                    if (street.end.X != street.start.X)
                    {
                        StreetSegment tempNorth = street;
                        StreetSegment tempSouth = street;
                        float xCord = (((street.end.X - street.start.X) / (street.end.Y - street.start.Y)) * (horizontal - street.start.Y)) + street.start.X;
                        PointF tempE = new PointF(xCord, horizontal);
                        tempNorth.end = tempE;
                        tempSouth.start = tempE;
                        if (street.start.Y > horizontal)
                        {
                            north.Add(tempNorth);
                            south.Add(tempSouth);
                        }   //END OF IF STATEMENT
                        else
                        {
                            south.Add(tempNorth);
                            north.Add(tempSouth);
                        }   //END OF ELSE STATEMENT
                    }   //END OF IF STATEMENT
                }   //END OF ELSE STATEMENT
            }   //END OF FOREACH LOOP
        }   //END OF northOrSouth METHOD

        /// <summary>
        /// Constuctor used to fill each child with the correct streets and visibility levels
        /// </summary>
        /// <param name="list">The complete list of streets gotten from the program</param>
        /// <param name="area">The area that the rectangle is suppose to cover</param>
        /// <param name="height">The height of the current child of the tree</param>
        public QuadTree(List<StreetSegment> list, RectangleF area, int height)
        {
            _rectangle = area;
            if(height == 0)
            {
                _streets = list;
            }   //END OF IF STATEMENT
            else
            {
                float xCord = ((area.Width) / 2) + area.Left;
                float yCord = ((area.Height) / 2) + area.Top;
                List<StreetSegment> temp = new List<StreetSegment>();
                List<StreetSegment> northList = new List<StreetSegment>();
                List<StreetSegment> southList = new List<StreetSegment>();
                List<StreetSegment> northEastList = new List<StreetSegment>();
                List<StreetSegment> northWestList = new List<StreetSegment>();
                List<StreetSegment> southEastList = new List<StreetSegment>();
                List<StreetSegment> southWestList = new List<StreetSegment>();
                _streets = new List<StreetSegment>();

                visibility(list, height, _streets, temp);
                northOrSouth(temp, yCord, northList, southList);
                eastOrWest(northList, xCord, northWestList, northEastList);
                eastOrWest(southList, xCord, southWestList, southEastList);


                _northEastChild = new QuadTree(northEastList, area, height - 1);
                _northWestChild = new QuadTree(northWestList, area, height - 1);
                _southEastChild = new QuadTree(southEastList, area, height - 1);
                _southWestChild = new QuadTree(southWestList, area, height - 1);
            }   //END OF ELSE
        }   //END OF THE QuadTree CONSTRUCTOR

        /// <summary>
        /// Method used to actually draw the graph
        /// </summary>
        /// <param name="draw">Decides what to draw</param>
        /// <param name="scaleFactor">Gives the scale factor for translating map coordinates</param>
        /// <param name="maximum">maximum depth of tree nodes to be drawn</param>
        public void Draw(Graphics draw, int scaleFactor, int maximum)
        {
            RectangleF converted = new RectangleF(draw.ClipBounds.X / scaleFactor, draw.ClipBounds.Y / scaleFactor, draw.ClipBounds.Width / scaleFactor, draw.ClipBounds.Height / scaleFactor);
            if (converted.IntersectsWith(_rectangle))
            {
                foreach (StreetSegment street in _streets)
                {
                    street.Draw(draw, scaleFactor);
                }   //END OF foreach LOOP
                if (maximum > 0)
                {
                    _northWestChild.Draw(draw, scaleFactor, maximum - 1);
                    _northEastChild.Draw(draw, scaleFactor, maximum - 1);
                    _southWestChild.Draw(draw, scaleFactor, maximum - 1);
                    _southEastChild.Draw(draw, scaleFactor, maximum - 1);
                }   //END OF IF STATEMENT
            }   //END OF IF STATEMENT
        }   //END OF Draw METHOD
    }   //END OF CLASS
}   //END OF PROGRAM
