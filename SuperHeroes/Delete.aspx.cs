using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Default2 : System.Web.UI.Page
{   //Initiales SuperHeroIDPassed to 0. This allows the below if statement to check if the value is 0 or valid integer (i.e. greater than 0)
    Int32 SuperHeroIDPassed = 0;
    //declare a string variable and initiallise it to ""
    string SuperHeroDetails = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        //Get the SuperHeroID value from the query string and convert to integer and then assign to SUperHeroIDPassed
        SuperHeroIDPassed = Convert.ToInt32(Request.QueryString["DeleteSuperHeroID"]);
        //get the dtring containing superhero details from the query string
        SuperHeroDetails = Request.QueryString["SuperHeroDetails"];
        //show the record details in the message for confirmation request
        lblDeleteSuperHeroID.Text = SuperHeroDetails;
    }

    protected void btnDeleteYes_Click(object sender, EventArgs e)
    {   //This function handles the click event of the Yes button
        //check if SuperHeroID passed in is a valid integer value for the SuperHeroID
        if (SuperHeroIDPassed > 0)
        {
            ///create an instance of the clsSuperHeroCollection class and call it oneSuperHero
            ///The oneSuperHero object will be used to access the delete method
            clsSuperHeroCollection oneSuperHeroCollection = new clsSuperHeroCollection();
            //[03-02-2019] declare a boolean variable, for if the record exists/not. Initialise it to false
            Boolean Exists = false;
            //try and find the record. Sets Exists to true if found
            Exists = oneSuperHeroCollection.ThisSuperHero.LocateRecord(SuperHeroIDPassed);
            if (Exists)
            {
                //assign the SuperHeroID to the SuperHeroID variable of ThisSuperHero
                oneSuperHeroCollection.ThisSuperHero.SuperHeroID = SuperHeroIDPassed;
                //if the record exists then delete it using the Delete function
                oneSuperHeroCollection.Delete();

                ////show a message that its been deleted
                //lblDeleteError.Text = "Deletion of " + SuperHeroIDPassed + " Successful";

                //redirect (go back to the Default.aspx page) sends the result of deletion (true = successful).
                //This is so record can be deleted from the listbox
                Response.Redirect("Default.aspx?SuperHeroID=" + true);
            }
            else
            {
                //if the above try statement fails then display an error
                lblDeleteError.Text = "Error:~ Delete Failed";
            }
        }
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