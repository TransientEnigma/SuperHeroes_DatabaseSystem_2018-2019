using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {//[04/02/2019] declares a boolean to store response or deleting the record
        Boolean DeleteSuccesful = false;
        //retrive the boolean value for the deletion result passed as a query string from delete page
        DeleteSuccesful = Convert.ToBoolean(Request.QueryString["DeletedResult"]);
        //if the boolean value retrieved is true then delete, if its not true the item will not be deleted and still appear in the list
        if (DeleteSuccesful)
        {
            try
            {
                //then try and delete entry from lstDefaultDetails listbox
                lstDefaultDetails.Items.RemoveAt(lstDefaultDetails.SelectedIndex);
            }
            catch 
            {
                //if it fails to delete the entry from listbox then display error
                lblDefaultError.Text = "Unable to clear deleted value from listbox";
            }
        }
    }

   
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //redirect to the profile page
        Response.Redirect("Profile.aspx");
    }

    protected void btnDefaultEdit_Click(object sender, EventArgs e)
    {
        //redirect to the profile page
        Response.Redirect("Profile.aspx");
    }

    protected void btnDefaultDisplayAll_Click(object sender, EventArgs e)
    {
        try 
        {

            //this code is now redundant due to the public void SuperHeroList() being converted to 
            //property [Week10] create an instance of the address book class clsSuperHeroCollection 
            //newSuperHero = new clsSuperHeroCollection();
            //Access the SuperHeroList()
            //newSuperHero.SuperHeroList();

            //try to display all the data from the data base in the list
            //clear all the contents in the lstDefaultDetails.Items listbox, before displaying items
            lstDefaultDetails.Items.Clear();
            //call the DisplaySuperHeros function below, 
            //send "" as a parameter for the search function to select all rows and columns of data to display
            DisplaySuperHeros("");
        }
        catch
        {
            //display an error if it fails
            lblDefaultError.Text = "Failed to list all requested entries.";
        }
    }

    Int32 DisplaySuperHeros(string SearchParameter)
    {
        //clear the listbox
        lstDefaultDetails.Items.Clear();
        //string variable to display "Super Speed"
        string SuperSpeed="";
        //string variable to display "Super Strength"
        string SuperStrength ="";
        //string variable to display "Super Flight"
        string SuperFlight ="";
        //string variable to display "Super Teleportation"
        string SuperTeleportation ="";
        //string variable to display "Super Invisibility"
        string SuperInvisibility ="";
        //string variable to display "Super Telekenisis"
        string SuperTelekenisis ="";
        //string variable to display "Super Psychokenisis"
        string SuperPsychokenisis ="";
        //variable to store the primary key
        Int32 SuperHeroID;
        //string variable for the Nickname
        String Nickname;
        //string variable for the Gender
        String Gender;
        //decimal variable to store Height_m
        Decimal Height;
        //integer variable to store Weight_kg
        Int32 Weight_kg;
        //DateTime variable to store birthdate
        DateTime BirthDate;
        //[27/02/2019] This line was added after the FormatDate function was created, so date can be displayed nicely in DD/MM/YYYY
        //string variable stores the formated date to be displayed
        String DisplayDate;
        //foreign key reference for City name in the SuperHeros Database (stored as a string value, thats why CityNo is a string)
        Int32 CityNo;
        //string variable to store the City name that will be retrieved from the City database using the CityNo
        string CityName;    
        //Int32 Age;          // variable for the Age is obscelete as the age is now calculated from the date
        //boolean value to store the boolean for speed in data base
        Boolean Speed;
        //boolean value to store the boolean for strength
        Boolean Strength;
        //boolean value to store the boolean for flight
        Boolean Flight;
        //boolean value to store the boolean for teleportation
        Boolean Teleportation;
        //boolean value to store the boolean for invisibility
        Boolean Invisibility;
        //boolean value to store the boolean for telekenisis
        Boolean Telekenisis;
        //boolean value to store the boolean for psychokenisis
        Boolean Psychokenisis;
        //integer variable to store age which will be calculated from the BirthDate and CurrentDate
        Int32 CurrentAge; 
        //create an instance of the clsSuperHeroCollection class to give us access to data we need. 
        ///The list is populated when we create an intsance of the class.
        ///create a SuperHeroCollection object, to get access to methods
        clsSuperHeroCollection newSuperHeroCollection = new clsSuperHeroCollection();
        //execute the search method in the object, passing the search parameter
        //returns the number of records in newSuperHeroCollection and assigned to recordCount variable
        newSuperHeroCollection.SearchSuperHeros(SearchParameter);
        //declare integet to store the record count
        Int32 recordCount;
        recordCount = newSuperHeroCollection.Count;
        //initialise the Variable to store the index of the loop (used to point to SuperHero data we want)
        Int32 Pointer = 0;
        //declare a new instance of the newSuperHero so that we can use it to access functions for calculate age and format date
        clsSuperHero newSuperHero = new clsSuperHero();
        //while loop that traverses the rows and gets the dat in each (named) column 
        while (Pointer < recordCount)
        {
            /// obtain the desired data from the populated superHeroList from the instance of clsSuperHeroCollection
            /// newSuperHeroCollection is the instance of clsSuperHeroCollection to will
            //Get primary key from the data table
            SuperHeroID = newSuperHeroCollection.SuperHeroList[Pointer].SuperHeroID;
            //get Nickname from the data table
            Nickname = newSuperHeroCollection.SuperHeroList[Pointer].Nickname;
            //get Gender from the data table
            Gender = newSuperHeroCollection.SuperHeroList[Pointer].Gender; 
            //get the weight from the data table
            Weight_kg = newSuperHeroCollection.SuperHeroList[Pointer].Weight_kg;
            //get the height from the datatable
            Height = newSuperHeroCollection.SuperHeroList[Pointer].Height_m;
            //get the birthdate from the data table
            BirthDate = newSuperHeroCollection.SuperHeroList[Pointer].BirthDate;
            //[27/01/2019] Formats and assigns date to the DisplayDate string.
            DisplayDate = newSuperHero.FormatDate(BirthDate);
            //[27/01/2019] Following code is obscelete as the age can be calculated directly
            //Age = newSuperHeroCollection.SuperHeroList[Pointer].Age; // get age
            //calculates the current age based on BirthDate and CurrentDate
            CurrentAge = newSuperHero.CalculateAge(BirthDate, DateTime.Today);
            //[02/02/2019] Adding the clsCityCollection and clsCity classes and having a seperate database for cities for the cities drop down list (in Profile.aspx)
            //meant SelectedValue for the Cities drop down list is passed to the database table for SuperHeros rather than the name.
            //the CityNo is being used as a foriegn key in the SuperHeros database and therefore when copied from the database a number appears in the listbox in Default.aspx. 
            //However this number can be converted back to the city name by creating an instance of the clsCityCollection, which can then be used to copy city from the datatable.
            //Get the foreign key CityNo (now stored in City) from the SuperHeros database and convert it to an integer
            CityNo = newSuperHeroCollection.SuperHeroList[Pointer].CityNo;
            //create an instance of the clsCityCollection to work with 
            clsCityCollection theCities = new clsCityCollection();
            //Pass in the search parameter (to populate the the list array object called CitiesList)
            theCities.CitySearchParameter(CityNo);
            //Get the CityName to be displayed based on the CityNo
            CityName = theCities.CityList[0].CityName;
            //get the boolean value of speed thats in the datatable
            Speed = newSuperHeroCollection.SuperHeroList[Pointer].Speed;
            //if the value is true, assign some text, else assign nothing
            if (Speed == true)
            {
                SuperSpeed = ", Super Speed";
            }
            else
            {
                SuperSpeed = "";
            }
            //get the boolean value of Strength thats in the datatable
            Strength = newSuperHeroCollection.SuperHeroList[Pointer].Strength;
            //if the value is true, assign some text, else assign nothing
            if (Strength == true)
            {
                SuperStrength = ", Super Strength";
            }
            else
            {
                SuperStrength = "";
            }
            //get the boolean value of Flight thats in the datatable
            Flight = newSuperHeroCollection.SuperHeroList[Pointer].Flight;
            //if the value is true, assign some text, else assign nothing
            if (Flight == true)
            {
                SuperFlight = ", Flight";
            }
            else
            {
                SuperFlight = "";
            }
            //get the boolean value of Teleportation thats in the datatable
            Teleportation = newSuperHeroCollection.SuperHeroList[Pointer].Teleportation;
            //if the value is true, assign some text, else assign nothing
            if (Teleportation == true)
            {
                SuperTeleportation = ", Teleportation";
            }
            else
            {
                SuperTeleportation = "";
            }
            //get the boolean value of Invisibility thats in the datatable
            Invisibility = newSuperHeroCollection.SuperHeroList[Pointer].Invisibility;
            //if the value is true, assign some text, else assign nothing
            if (Invisibility == true)
            {
                SuperInvisibility = ", Invisibility";
            }
            else
            {
                SuperInvisibility = "";
            }
            //get the boolean value of Telekenisis thats in the datatable
            Telekenisis = newSuperHeroCollection.SuperHeroList[Pointer].Telekenisis;
            //if the value is true, assign some text, else assign nothing
            if (Telekenisis == true)
            {
                SuperTelekenisis = ", Telekenisis";
            }
            else
            {
                SuperTelekenisis = "";
            }
            //get the boolean value of Psychokenisis thats in the datatable
            Psychokenisis = newSuperHeroCollection.SuperHeroList[Pointer].Psychokenisis;
            //if the value is true, assign some text, else assign nothing
            if (Psychokenisis == true)
            {
                SuperPsychokenisis = ", Psychokenisis";
            }
            else
            {
                SuperPsychokenisis = "";
            }

            ///List item is defined: public ListItem (string text, string value);
            ///https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.listitem.-ctor?view=netframework-4.7.2#System_Web_UI_WebControls_ListItem__ctor

            ///Initialise a new instance of list item with the concatenated string of data we want to display as the first parameter in ListItem instance
            ///The value of list item is the primary key, we convert to string and add as the second parameter to ListItem instance
            ///Each List item will be displayed in the format Nickname, gender, age.
            ListItem newListItem = new ListItem("Superhero ID [" + SuperHeroID.ToString() + "] " + Nickname + ": " + Gender + ", " +  Height.ToString() + "m tall" + ", " + Weight_kg + "kg" + ", "  + "born " + DisplayDate + ", " + CurrentAge.ToString() + " years old, " + " lives in " + CityName +  SuperFlight + SuperInvisibility + SuperSpeed + SuperStrength + SuperTelekenisis +  SuperTeleportation + SuperPsychokenisis, SuperHeroID.ToString());

            ///add the item to the list menu
            lstDefaultDetails.Items.Add(newListItem);

            /// increment pointer so it points to next superhero in the collection class
            Pointer++;
        }
        return recordCount;
    }


    protected void btnDefaultClear_Click(object sender, EventArgs e)
    {
        //clear the screen of the default page erros and text
        ClearDefaultScreen();

    }

    //This function is used to clear the default screan textboxes
    public void ClearDefaultScreen()
    {
        //clear the listbox
        lstDefaultDetails.Items.Clear();
        //clear the textbox
        tbxDefaultSearch.Text = "";
        //clear the labels
        lblDefaultError.Text = "";
        lblDefaultSuperCarDetails.Text = "";
        //clear the error message
        lblDefaultError.Text = "";
    }
    protected void lstDefaultDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void txtDefaultSelectedItem_TextChanged(object sender, EventArgs e)
    {

    }
    //This section of code was used for testing but is no longer required
    //protected void btnSet_Click(object sender, EventArgs e)
    //{ /// this is just to view the values the SelectedItem, SelectedValue and SelectedIndex of selected Items
    //    /// I was getting some error when the list wasn't populated to I wrote a try catch statement to display
    //    /// a message if there was not items in the list and I clicked the Set button on the form to display the values.
    //    try
    //    {
    //        txtDefaultSelectedItem.Text = lstDefaultDetails.SelectedItem.Text;
    //        txtDefaultSelectedValue.Text = Convert.ToString(lstDefaultDetails.SelectedValue);
    //        txtDefaultSelectedIndex.Text = Convert.ToString(lstDefaultDetails.SelectedIndex);
    //    }
    //    catch
    //    {
    //        lblDefaultError.Text = "Unpopulated List";
    //    }

    //}

    protected void btnDefaultDelete_Click(object sender, EventArgs e)
    {   //[13/01/19] Check to see if the user has made a selection from the list
        //If there is no selection then the value of SelectedIndex for the list will be -1

        //convert the selected indexvalue to an integer and store in the integer variable
        Int32 IndexValue = Convert.ToInt32(lstDefaultDetails.SelectedIndex);
        //check if the value is -1
        if (IndexValue != -1)
        {
            //no need to convert to a String lstDefaultDetails.SelectedValue is alread a String
            Response.Redirect("Delete.aspx?DeleteSuperHeroID=" + lstDefaultDetails.SelectedValue + "&SuperHeroDetails=" + lstDefaultDetails.SelectedItem);
        }
        else
        {
            //if no selection made show an error message
            lblDefaultError.Text = "Please make a selection";
        }

    }


    protected void btnDefaultUpdate_Click(object sender, EventArgs e)
    {
        //[13/01/19] this section is intended to work with Page_Load() of Profile.aspx
        ///to redirect to page for update
        ///code here will take the SelectedIndex
        ///of the selected item in the listbox and use this to populate the
        ///form on the profile page, so that information can be preloaded for the 
        ///user to make changes to and save. Since the SelectedIndex is the value that is incremented from '0' each time an item is added
        ///to the listbox, its integer value will correspond to the position of data in the DataTable, so we can use this as an index value
        ///The value is passed to the Profile page by means of query string method as follows:
        ///We take the lstDefaultDetails.SelectedIndex ('NOT' SelectedValue the primary Key/SuperHeroID) and pass it in to the response.redirect method.
        ///It is passed in as a 'key-value pair'. The name we are giving to the query string is 'SuperHeroIndex' and the value 
        ///we are sending it as 'lstDefaultDetails.SelectedIndex' The page it is being passed to has a seperate method called Page load 
        ///that pics out the Index and uses it to access the relevant information to load the form with.

        try
        {   //Need to check the SelectedValue is of the correct type, if item in the list is not selected then will crash
            //declare an integer variable to store the selected value
            Int32 CheckSelectedValue;
            //get the selected value from the list and convert to integer
            CheckSelectedValue = Convert.ToInt32(lstDefaultDetails.SelectedValue);
            //Convert the SelectedValue of the item selected in the list. 
            //Then if the selectedValue (primary key) of the item selected is greater than 0
            if (CheckSelectedValue != -1)
            {
                //no need to convert to a String lstDefaultDetails.SelectedValue is already a String
                Response.Redirect("Profile.aspx?SuperHeroID=" + lstDefaultDetails.SelectedValue);
            }
            else 
            {
                //if no selection made show an error message
                lblDefaultError.Text = "Please make a selection";
            }
        }
        catch
        {
            //in case there is a problem
            lblDefaultError.Text = "Please make a selection";
        }
        
    }

    protected void btnDefaultAdd_Click(object sender, EventArgs e)
    {
        ///This redirects to another page with form to add superhero entry to database.
        Response.Redirect("Profile.aspx");
    }

    protected void btnDefaultSearch_Click(object sender, EventArgs e)
    {
        //clear any text in the car details label
        lblDefaultSuperCarDetails.Text = "";
        try //try to display the data in the list based on search criteria.
        {
            //check that the search box is not empty
            if (tbxDefaultSearch.Text == "") 
            {
                //if the search textbox is empty
                lblDefaultError.Text = "Please enter search criteria";
            }
            else
            {
                //clear all the contents in the lstDefaultDetails.Items listbox, before displaying items
                lstDefaultDetails.Items.Clear();
                //clear the error text
                lblDefaultError.Text = "";

                //display any superheros based on the search text provided in the search textbox
                DisplaySuperHeros(tbxDefaultSearch.Text);
            }
        }
        catch
        {   //display error if it fails
            lblDefaultError.Text = "Failed to retrieve search results";
        }
    }


    protected void btnDefaultFindVehicle_Click(object sender, EventArgs e)
    {
        //Clear any the error
        lblDefaultError.Text = "";
        //clear the lable containing any information
        lblDefaultSuperCarDetails.Text = "";
        try
        {
            //declare an integer to store the foreign key for superheroID (in tblSuperVehicle
            Int32 ForeignSuperHeroIDKey;
            //declare a boolean to store the result of the function
            Boolean result;
            //get the selected value of the selected superhero (primary key/foreing key) and convert it to an interger
            ForeignSuperHeroIDKey = Convert.ToInt32(lstDefaultDetails.SelectedValue);
            //send the foreign key to  get the superHeroCar to display
            result = DisplaySuperHeroVehicle(ForeignSuperHeroIDKey);
            //displays an error if nothing if the search fails to execute
            if (!result)
            {
                //if there is no result
                lblDefaultSuperCarDetails.Text = "No Car found";
            }
        }
        catch
        {
            //if there is an error
            lblDefaultError.Text = "Please make a selection";
        }
        

    }

    //This function will find the superhero vehicle using the SuperHero primary key in the tblSuperHero, which is a foreign key in the tblSuperCars
     Boolean DisplaySuperHeroVehicle(Int32 ForeignSuperHeroIDKeyIn)
    {
        try
        {
            //declare a string to store the SuperVehicleID
            string SuperVehicleID = "";
            //declare a string to store the SuperVehicleMake
            string SuperVehicleMake = "";
            //declare a string to store the SuperVehicleModel
            string SuperVehicleModel = "";
            //declare a string to store the SuperVehicleColor
            string SuperVehicleColor = "";
            //declare a string to store the SuperVehicleLitreEngine
            string SuperVehicleLitreEngine = "";
            //declare a string to store the SuperVehicleSunroof
            string SuperVehicleSunroof = "";
            //declare a DateTime variable to store SuperVehicleRegistrationDateTime
            DateTime SuperVehicleRegistrationDateTime = Convert.ToDateTime("01 / 01 / 0001");
            //declare a string to store the SuperVehicleRegistrationDate
            string SuperVehicleRegistrationDate = "";
            //create the connection to access the database
            clsDataConnection mDatabase = new clsDataConnection();
            //create an instance of the clsSuperVehicleCollection class to work with
            clsSuperVehicleCollection aVehicleCollection = new clsSuperVehicleCollection();
            //invoke the function to get the vehicle data from the database and fill the SuperVehicleList object 
            aVehicleCollection.VehicleSearchByParameter(ForeignSuperHeroIDKeyIn);
            //check the count of vehicles found in the database that match for the SuperHeroID is  1
            //each superhero has only one vehicle so there should only be one SuperVehicle entry in the DataTable at index=0
            //get the SuperVehicleID and store this in the SuperVehicleID string variable
            SuperVehicleID = Convert.ToString(aVehicleCollection.SuperVehicleList[0].VehicleID);
            //get the SuperVehicleMake and store this in the SuperVehicleMake string variable
            SuperVehicleMake = Convert.ToString(aVehicleCollection.SuperVehicleList[0].VehicleMake);
            //get the SuperVehicleModel and store this in the SuperVehicleModel string variable
            SuperVehicleModel = Convert.ToString(aVehicleCollection.SuperVehicleList[0].VehicleModel);
            //get the SuperVehicleColor and store this in the SuperVehicleColor string variable
            SuperVehicleColor = Convert.ToString(aVehicleCollection.SuperVehicleList[0].VehicleColor);
            //get the SuperVehicleLitreEngine and store this in the SuperVehicleLitreEngine string variable
            SuperVehicleLitreEngine = Convert.ToString(aVehicleCollection.SuperVehicleList[0].VehicleLitreEngine);
            //if the SuperVehicleSunroof boolean value is true then it has a Sunroof else sunroof is blank
            if(aVehicleCollection.SuperVehicleList[0].VehicleSunroof)
            {
                SuperVehicleSunroof = " with sunroof, ";
            }
            else
            {
                SuperVehicleSunroof = ", ";
            }

            //get the DateTime of the VehicleRegistrationDate
            SuperVehicleRegistrationDateTime = aVehicleCollection.SuperVehicleList[0].VehicleRegistrationDate;
            //convert the registration date to a suitable format and stores it back in SuperVehicleRegistration
            //the clsSuperHero class contains a method to format the date
            clsSuperHero dateSuperHero = new clsSuperHero();
            //format the datetime variable and store it in the string variable
            SuperVehicleRegistrationDate = dateSuperHero.FormatDate(SuperVehicleRegistrationDateTime);
            //Concatenate the results and display the string in the lable
            lblDefaultSuperCarDetails.Text = "Vehicle ID [" + SuperVehicleID + "] " + "A " + SuperVehicleColor + ", "+ SuperVehicleLitreEngine + "Litre, " + SuperVehicleMake + " " + SuperVehicleModel +  SuperVehicleSunroof + "registered on " + SuperVehicleRegistrationDate;
            //return true the code works
            return true;
        }
        catch
        {
            //if the code doesnt work return false
            return false;
        }
    }

    protected void tbxDefaultSearch_TextChanged(object sender, EventArgs e)
    {

    }
}