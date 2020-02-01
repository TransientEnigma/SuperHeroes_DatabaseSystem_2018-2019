using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnDeleteYes_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");

        /******* This code is obscelete [23-01-01] deleted the textbox diplaying ID number and changed form controls*******/

        ///this function handles the click event of the Yes button
        //create instance of the clsSuperHeroCollection class and call it SuperHero
        //clsSuperHeroCollection oneSuperHero = new clsSuperHeroCollection();

        //declares a variable to store the SuperHeroID to delete
        //Int32 xSuperHeroID;
        //Copy the data from the interface to the RAM first converting it to Int32
        //xSuperHeroID = Convert.ToInt32(txtSuperHeroID.Text);
        //Invoke the delete method of the object passing it the data entered by the user, store return value in Sucess
        //Boolean success = oneSuperHero.Delete(xSuperHeroID);
        //if(success == true)
        //{
        //    lblDeleteError.Text= "Deletion of " + xSuperHeroID + " Successful";
        //}
        //else
        //{
        //    lblDeleteError.Text = "Error:~ Delete Failed";
        //}

    }

    protected void btnDeleteNo_Click(object sender, EventArgs e)
    {
        //redirect back to default page
        Response.Redirect("Default.aspx");
    }

    protected void txtSuperHeroID_TextChanged(object sender, EventArgs e)
    {

    }
}