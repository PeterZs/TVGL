﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MIConvexHull;

namespace TVGL.Miscellaneous_Functions.TraingulatePolygon
{
    #region Node Class
    /// <summary>
    /// Node class used in Triangulate Polygon
    /// Inherets position from point class
    /// </summary>
    internal class Node : Point
    {
        #region Properties
        /// <summary>
        /// Gets the loop ID that this node belongs to.
        /// </summary>
        internal int LoopID { get; private set; }

        /// <summary>
        /// Gets the line that starts at this node.
        /// </summary>
        internal Line StartLine { get; set; }

        /// <summary>
        /// Gets the line that ends at this node.
        /// </summary>
        internal Line EndLine { get;  set; }

        /// <summary>
        /// Gets the type of  node.
        /// </summary>
        internal int Type { get; private set; }

        /// <summary>
        /// Gets the base class, Point of this node.
        /// </summary>
        internal Point Point { get; private set; }
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new node from a given point
        /// /// </summary>
        /// <param name="point"></param>
        internal Node(Point currentPoint, int nodeType, int loopID)
            : base(new Point(currentPoint))
        {
            LoopID = loopID;
            Type = nodeType;
            Point = currentPoint;
        }
        #endregion
    }
    #endregion

    #region Trapezoid Class
    /// <summary>
    /// Trapezoid Class
    /// </summary>
    internal class Trapezoid
    {
        #region Properties
        /// <summary>
        /// Gets the TopNode. Set is through constructor.
        /// </summary>
        internal Node TopNode { get; private set; }

        /// <summary>
        /// Gets the BottomNode. Set is through constructor.
        /// </summary>
        internal Node BottomNode { get; private set; }

        /// <summary>
        /// Gets the left vertical line of the trapezoid. Set is through constructor.
        /// </summary>
        internal Line LeftLine { get; private set; }

        /// <summary>
        /// Gets the right vertical line of the trapezoid. Set is through constructor.
        /// </summary>
        internal Line RightLine { get; private set; }
        #endregion
        
        #region Constructor
        /// <summary>
        /// Constructs a new trapezoid based on two nodes and two vertical lines.
        /// </summary>
        /// <param name="topNode"></param>
        /// <param name="bottomNode"></param>
        /// <param name="leftLine"></param>
        /// <param name="rightLine"></param>
        internal Trapezoid(Node topNode, Node bottomNode, Line leftLine, Line rightLine)
        {
            TopNode = topNode;
            BottomNode = bottomNode;
            LeftLine = leftLine;
            RightLine = rightLine;
        }
        #endregion
    }
    #endregion

    #region Partial Trapezoid Class
    /// <summary>
    /// Partial Trapezoid Class. Used to hold information to create Trapezoids.
    /// </summary>
    internal class PartialTrapezoid
    {
        /// <summary>
        /// Gets the TopNode. Set is through constructor.
        /// </summary>
        internal Node TopNode { get; private set; }

        /// <summary>
        /// Gets the left vertical line of the trapezoid. Set is through constructor.
        /// </summary>
        internal Line LeftLine { get; private set; }

        /// <summary>
        /// Gets the right vertical line of the trapezoid. Set is through constructor.
        /// </summary>
        internal Line RightLine { get; private set; }

        /// <summary>
        /// Constructs a partial trapezoid
        /// </summary>
        /// <param name="topNode"></param>
        /// <param name="leftLine"></param>
        /// <param name="rightLine"></param>
        internal PartialTrapezoid(Node topNode, Line leftLine, Line rightLine)
        {
            TopNode = topNode;
            LeftLine = leftLine;
            RightLine = rightLine;
        }

        /// <summary>
        /// Checks whether the partial trapezoid contains the two lines.
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <returns></returns>
        internal bool Contains(Line line1, Line line2)
        {
            if (LeftLine != line1 && LeftLine != line2) return false;
            return RightLine == line1 || RightLine == line2;
        }
    }
    #endregion

    #region MonotonePolygon class

    /// <summary>
    /// Monotone Polygon, which consists of two ordered chains
    /// The chains start and end at the same nodes
    /// </summary>
    internal class MonotonePolygon
    {
        #region Properties
        /// <summary>
        /// Gets Monochain1. Set is through the constructor.
        /// </summary>
        internal List<Node> LeftChain { get; private set; }

        /// <summary>
        /// Gets Monochain2. Set is through the constructor.
        /// </summary>
        internal List<Node> RightChain { get; private set; }

        /// <summary>
        /// Gets Monochain2. Set is through the constructor.
        /// </summary>
        internal List<Node> SortedNodes { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructs a MonotonePolygon based on a list of nodes.
        /// </summary>
        /// <param name="leftChain"></param>
        /// <param name="rightChain"></param>
        /// <param name="sortedMonotonePolyNodesChain"></param>
        internal MonotonePolygon(List<Node> leftChain, List<Node> rightChain, List<Node> sortedNodes)
        {
            LeftChain = leftChain;
            RightChain = rightChain;
            SortedNodes = sortedNodes;
        }
        #endregion
    }
    #endregion

    #region Line Class
    /// <summary>
    /// Line
    /// </summary>
    internal class Line
    {

        /// <summary>
        /// Gets the Node which the line is pointing to. Set is through the constructor.
        /// </summary>
        internal Node ToNode { get; private set; }

        /// <summary>
        /// Gets the Node which the line is pointing away from. Set is through the constructor.
        /// </summary>
        internal Node FromNode { get; private set; }

        private readonly double m;
        private readonly double b;
        
        /// <summary>
        /// Sets to and from nodes as well as slope and intercept of line.
        /// </summary>
        /// <param name="fromNode"></param>
        /// <param name="toNode"></param>
        internal Line(Node fromNode, Node toNode)
        {
            FromNode = fromNode;
            ToNode = toNode;
                        
            //Solve for y = mx + b
            m = (ToNode.Y - FromNode.Y) / (ToNode.X - FromNode.X);
            b = ToNode.Y - m * ToNode.X;
        }

        /// <summary>
        /// Gets X intercept given Y
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        internal double Xintercept(double y)
        {
            return (y - b)/m;
        }

        /// <summary>
        ///   Gets Y intercept given X
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal double Yintercept(double x)
        {
            return (x - b)/m;
        }

    }
    #endregion
}