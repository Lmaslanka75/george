﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.SqlClient;
using System.Data;

namespace TermProject
{
    public partial class AuntFreida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                DBConnect db = new DBConnect();
                string merchEmail = Session["emailSession"].ToString();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetMerchAccount";
                command.Parameters.AddWithValue("@email", merchEmail);
                DataSet ds = db.GetDataSetUsingCmdObj(command);
                gvMerchAccount.DataSource = ds;
                gvMerchAccount.DataBind();
            

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void btnEditAccount_Click(object sender, EventArgs e)
        {
            ucMerch.Visible = true;
        }

        protected void btnAPI_Click(object sender, EventArgs e)
        {
            Label lblAPI = new Label();
            DBConnect db = new DBConnect();
            string merchEmail = Session["emailSession"].ToString();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetAPI";
            command.Parameters.AddWithValue("@email", merchEmail);
            DataSet ds = db.GetDataSetUsingCmdObj(command);
            string api = ds.Tables[0].Rows[0]["APIKey"].ToString();
            lblAPI.Text = api;

            
        }
    }
}