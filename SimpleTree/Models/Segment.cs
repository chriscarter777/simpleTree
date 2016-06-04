using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace SimpleTree.Models
{
    public class Segment
    {

        public double Angle { get; set; }
        public double Length { get; set; }
        public int Weight { get; set; }
        public Color Chroma { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2
        {
            get
            {
                return X1 + (int)Math.Round((Length * Math.Sin(Angle)));
            }
        }
        public int Y2
        {
            get
            {
                return Y1 - (int)Math.Round((Length * Math.Cos(Angle)));
            }
        }

        public Segment(double ang, double len, int wt, Color colr, int x, int y)
        {
            Angle = ang;
            Length = len;
            Weight = wt;
            Chroma = colr;
            X1 = x;
            Y1 = y;
        }

        public override string ToString()
        {
            string descr = "Segment: Angle " + Angle + "Length " + Length + "Weight " + Weight + " Color " + Chroma + " from " + X1 + " , " + Y1 + " to " + X2 + " , " + Y2;
            return descr;
        }
    }  //end class Segment
}