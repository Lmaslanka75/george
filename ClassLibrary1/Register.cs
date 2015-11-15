﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Utilities;
using System.Data.SqlClient;

namespace TP_Amazon_ClassLibrary
{
    //class to handle customer and merchant objects into DB using OOP design principles
    public class Register
    {
        public bool AddNewCustomer(Customer newCustomer)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "AddTPCustomer";
            objCommand.Parameters.AddWithValue("@Email", newCustomer.Email );
            objCommand.Parameters.AddWithValue("@password", newCustomer.Password);
            objCommand.Parameters.AddWithValue("@Name", newCustomer.Name);

            //integer to determine if value was added into DB or not
            int result= objDB.DoUpdateUsingCmdObj(objCommand);

            if (!(result <= 0)) //if a new row was successsfully added
            {
                return false;
            }
            else               //else the row was not added successfully
            {
                return true;

            }
        }

        public bool ValidLogin(string email, string password)
        {
            DataSet myDS = new DataSet();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_ValidLogin";
            objCommand.Parameters.AddWithValue("@Email", email);
            objCommand.Parameters.AddWithValue("@password", password);
            DBConnect objDB = new DBConnect();
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            bool returnvalue;

            //if the values are found in the DB return true
            if (myDS.Tables[0].Rows.Count == 1)
            {
                returnvalue = true;
            }

            //the user does not exist in the DB
            else
            {
                returnvalue = false;
            }
            return returnvalue;
            
 
        }


    }//end of Register class






}//end of namespace
