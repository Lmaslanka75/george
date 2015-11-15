﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP_Amazon_ClassLibrary;

namespace TermProject
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Register Button
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            Customer newCustomer = new Customer();
            newCustomer.FirstName = txtName.Text;
            newCustomer.Email = txtEmail.Text;
            newCustomer.Password = txtpassword.Text;
            
            //all fields are valid
            if (ValidFields())
            {
                //Add new Customer to TP_Customer DB
                register.AddNewCustomer(newCustomer);

                //if "Remember Me" is checked, store userName in cookie
                if (chkbxRemeberMe.Checked)
                {
                    HttpCookie myCookie = new HttpCookie("Login_Cookie");
                    myCookie.Values["email"] = txtEmail.Text;
                    myCookie.Values["LastVisited"] = DateTime.Now.ToString();
                    myCookie.Expires = new DateTime(2025, 1, 1);
                    Response.Cookies.Add(myCookie);
                }
                else
                {
                    //remove user's email from username textbox
                    Response.Cookies.Remove("mycookie");
                }

                Response.Redirect("~/Login.aspx");
            }

            //not all fields are valid
            else 
            {
                clearFields();
                lblGeneralError.Text = "Error. Try Again.";
            }


        }//end of Registerbutton click event


        public bool ValidFields()
        {
            bool validInput;
            bool passwordsEqual = String.Equals(txtpassword.ToString(), txtReenterPassword.ToString());

            if(txtName.Text == "")
            {
                lblInvalidName.Text = "Please enter your name.";
                validInput = false;
            }

            //check if email is valid
            if (txtEmail.Text.IndexOf("@") == -1 || txtEmail.Text.IndexOf(".") == -1)
            {
                validInput = false;
            }

            //passwords dont match
            if (!passwordsEqual)
            {
                lblPasswordsDontmatch.Text = "Passwords Must Match";
                txtpassword.Text = "";
                txtReenterPassword.Text = "";
                validInput = false;
            }
            else
            {
                validInput= true;
            }

            return validInput;
        }


        public void clearFields()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtpassword.Text = "";
            txtReenterPassword.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");

        }

    
    
    
    
    }//end of class




}//end of namespace

