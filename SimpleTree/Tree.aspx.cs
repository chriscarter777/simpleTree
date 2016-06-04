using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using SimpleTree.Models;
using static SimpleTree.Models.Rendering;


namespace SimpleTree
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bitmap treeCanvas = new Bitmap(1400, 800);
            Graphics treeGraphic = Graphics.FromImage(treeCanvas);
            treeGraphic.Clear(Color.AliceBlue);

            //set colors for the tree
            Color branchColor = Color.SaddleBrown;
            Color leafColor = Color.Green;

            //set the main trunk properties
            double generationLength = startLength;
            int generationWeight = numGenerations * 1;
            Color generationColor = branchColor;

            //calculate tree dimensions, instantiate the array of line segments, and initialize the generation 0/segment 0 (the main trunk)
            int numLeaves = (int)(Math.Pow(2, numGenerations));
            Segment[,] segments = new Segment[numGenerations + 1, numLeaves];
            segments[0, 0] = new Segment(startAngle, generationLength, generationWeight, generationColor, x0, y0);

            //seed the random number generator
            Random rnd = new Random();

            //loop through each generation
            for (int thisGeneration = 0; thisGeneration <= numGenerations; thisGeneration++)
            {
                //set attributes for the child generation
                int childGeneration = thisGeneration + 1;
                generationLength *= lengthChange;
                generationWeight = (numGenerations - thisGeneration) * 1;
                if (childGeneration == numGenerations)
                {
                    generationColor = leafColor;
                }
                else
                {
                    generationColor = branchColor;
                }


                //loop through each segment in this generation... 
                int i = 0;
                int childGenerationcounter = 0;
                while (i <= (numLeaves - 1) && segments[thisGeneration, i] != null)
                {
                    Segment thisSegment = segments[thisGeneration, i];
                    //...draw it 
                    Pen segmentPen = new Pen(thisSegment.Chroma, thisSegment.Weight);
                    treeGraphic.DrawLine(segmentPen, thisSegment.X1, thisSegment.Y1, thisSegment.X2, thisSegment.Y2);

                    //...and if this is not the last generation, initialize its two child segments
                    if (thisGeneration < numGenerations)
                    {
                        //introduce randomness in segment length and angle here
                        double leftSegLength = generationLength * (1 + (((rnd.NextDouble() * 2) - 1) * randomness));
                        double rightSegLength = generationLength * (1 + (((rnd.NextDouble() * 2) - 1) * randomness));

                        double ltAngleRandomComponent = branchAngle * (((rnd.NextDouble() * 2) - 1) * randomness);
                        double rtAngleRandomComponent = branchAngle * (((rnd.NextDouble() * 2) - 1) * randomness);

                        double ltWindlessAngle = thisSegment.Angle - (branchAngle / 2) + ltAngleRandomComponent;
                        double rtWindlessAngle = thisSegment.Angle + (branchAngle / 2) + rtAngleRandomComponent;

                        double ltAngleWindComponent = ((Math.PI / 2) - ltWindlessAngle) * (wind / generationWeight);
                        double rtAngleWindComponent = ((Math.PI / 2) - rtWindlessAngle) * (wind / generationWeight);

                        double leftAngle = ltWindlessAngle + ltAngleWindComponent;
                        double rightAngle = rtWindlessAngle + rtAngleWindComponent;

                        segments[childGeneration, childGenerationcounter] = new Segment(leftAngle, leftSegLength, generationWeight, generationColor, thisSegment.X2, thisSegment.Y2);
                        childGenerationcounter++;
                        segments[childGeneration, childGenerationcounter] = new Segment(rightAngle, rightSegLength, generationWeight, generationColor, thisSegment.X2, thisSegment.Y2);
                        childGenerationcounter++;
                    }
                    i++;
                }
            }
            Response.ContentType = "image/jpeg";
            treeCanvas.Save(Response.OutputStream, ImageFormat.Jpeg);
            Response.End();
            treeGraphic.Dispose();
            treeCanvas.Dispose();
        }  //end Page_Load
    }  //end class -Default
}  //end namespace
