using System;
using System.Collections.Generic;
using System.Text;

namespace JImGui.Common
{
    //(0,0)
    //      p1 - p2
    //      |     |
    //      p4 - p3
    public class Rect
    {
        Point p1, p2, p3, p4;
        public Rect(Point topLeft,int width,int height)
        {
            p1 = topLeft;
            p2 = topLeft + new Point(width, 0);
            p3 = topLeft + new Point(width, height);
            p4 = topLeft + new Point(0, height);
        }
    }
}
