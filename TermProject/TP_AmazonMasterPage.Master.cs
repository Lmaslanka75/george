﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class TP_AmazonMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // lblWelcomeUser.Text = "Welcome " + email +"!";
        }

        protected void lnkbtnViewCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void lnkbtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product.aspx");
        }

        protected void lnkbtnCheckOut_Click(object sender, EventArgs e)
        {
            
        }
    }
}