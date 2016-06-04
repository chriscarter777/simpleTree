using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleTree.Models;

namespace SimpleTree
{
    public partial class Index : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void render_Click(Object sender, EventArgs e)
        {
            //parse the tree parameters from the form
            Rendering.numGenerations = int.Parse(txtGenerations.Text);
            Rendering.lengthChange = double.Parse(txtLength.Text) / 100;
            Rendering.branchAngle = double.Parse(txtAngle.Text);
            Rendering.randomness = double.Parse(txtRandomness.Text) / 100;
            Rendering.wind = double.Parse(txtWind.Text) / 100;
        }

    }
}