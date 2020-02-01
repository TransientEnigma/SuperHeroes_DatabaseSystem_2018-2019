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
        
        if (IsPostBack != true)
        {
            //clear labels and text
            ClearForm();
            ///[24/01/2019]This will be used to load form, so can therefore be used
            ///to load controls with preset values e.g. loading the drop down list:
            ///Just occured to me that since the ddl is a list, then items could be added to it in the same way
            ///tried it and it worked
            // this is because the list items below kept being added to the list when I clicked Save
            ddlProfileGender.Items.Clear();
            //add the list item
            ddlProfileGender.Items.Add("Unassigned");
            //add the list item
            ddlProfileGender.Items.Add("Male");
            //add the list item
            ddlProfileGender.Items.Add("Female");
            //add the list item
            ddlProfileGender.Items.Add("Neutral");
            //add the list item
            ddlProfileGender.Items.Add("Transgender");
            //add the list item
            ddlProfileGender.Items.Add("Non-binary");
            //make the SuperHeroID text = 0. This looks better and needed later in for the update method
            lblProfileSuperHeroID.Text = "0";
            //Populate the Cities list with the list of Cities
            DisplayCities();
            //[26/01/2018] Get the data (SuperHeroIndex) from the query string
            //Variable to store the index used to point to SuperHero data we want
            Int32 SuperHeroIDPassed = 0; // initialesed to 0 so only does if statement when the SuperHeroIndex Value is passed in
            ///Get the SuperHeroID value from the query string and convert to integer
            SuperHeroIDPassed = Convert.ToInt32(Request.QueryString["SuperHeroID"]);
            //check if SuperHeroID passed in is a valid integer (i.e. greater than 0)
            if(SuperHeroIDPassed > 0)
            {
                //get the Superhero based on the SuperHeroID passed to it
                DisplaySuperHero(SuperHeroIDPassed);
            }
        }
    }

    //This function is used to populate the City drop down list
    Int32 DisplayCities()
    {
        //create and instance of city collection class
        clsCityCollection ListofCities = new clsCityCollection();
        //[02/02/2019] initially tried a stored procedure tha used an integer primary key parameter in the clsCityCollection
        //class to search city, but this limited me to a single result for each search, so had to use a different type of stored procedure.
        //This other stored procedure was written to select either a number(primary key) or everything. The value was a comparison string
        //Thus the value passed was safe as long as there were no numbers in the cityname field of tblCity table.
        //Pass in the search parameter to select all the in the database
        ListofCities.CitySearchParameter(-1);
        //string variable to store the cities primary key value
        string CityNo;
        //string variable to store the name of the city
        string City;
        //integer variable to store the index of the loop, starts at 0
        Int32 CityPointer = 0;
        //starting from 0, then while the CityPointer is not more than the Count of
        //the number of rows of Cities
        while(CityPointer < ListofCities.Count)
        {
            //get the primary key number value of the city from the database
            CityNo = Convert.ToString(ListofCities.CityList[CityPointer].CityNo);
            //get the city name from the database
            City = Convert.ToString(ListofCities.CityList[CityPointer].CityName);
            //create a list item object with the information we just retrieved
            ListItem CityListItem = new ListItem(City,CityNo);
            //add the CityListItem object row to the list
            ddlProfileCity.Items.Add(CityListItem);
            //increment the CityPointer to point to the next record to get
            CityPointer++;
            
        }
        //return the count for the number of cities in the data table
        return ListofCities.Count;
    }
    //This function is used to populate the form using a SuperHeroID passed in as a parameter.
    //The parameter is then passed to the SelectSuperHero() function which resides in the clsSuperHero class.
    //The SelectSuperHero() function executes a Search and finds the superhero data and loads the properties
    // in the clsSuperHero class, these properties are then loaded in to the form by DisplaySuperHero
    void DisplaySuperHero(Int32 SuperHeroIDPassedIn)
    {
        clsSuperHero nSuperHero = new clsSuperHero();
        nSuperHero.SelectSuperHero(SuperHeroIDPassedIn);
        //gets the SuperHeroID from the Data table converts to string and assigns to textbox on form
        lblProfileSuperHeroID.Text = Convert.ToString(nSuperHero.SuperHeroID);
        //gets the Nickname from the Data table converts to string and assigns to textbox on form
        tbxProfileName.Text = Convert.ToString(nSuperHero.Nickname);
        //gets the Gender from the Data table converts to string and assigns to Gender string variabl
        string GenderCheck = Convert.ToString(nSuperHero.Gender);
        //gets the Height from the Data table converts to string and assigns to textbox on form
        tbxProfileHeight.Text = Convert.ToString(nSuperHero.Height_m);
        //gets the Weight from the Data table converts to string and assigns to textbox on form
        tbxProfileWeight.Text = Convert.ToString(nSuperHero.Weight_kg);
        //Formats the date (using FormatDate function) and converts it to string then assigns to the BirthDate textbox
        tbxProfileBirthDate.Text = Convert.ToString(nSuperHero.FormatDate(nSuperHero.BirthDate));
        //gets the City from the Data table converts to string and assigns to textbox on form
        ddlProfileCity.SelectedValue = Convert.ToString(nSuperHero.CityNo);  
        //calculates age and assigns it to the label for Age
        lblProfileCalculatedAge.Text = Convert.ToString(nSuperHero.CalculateAge(nSuperHero.BirthDate,DateTime.Today));
        //gets the boolean value of speed and assigns it (uses it to check or uncheck the checkbox)
        cbxProfileSpeed.Checked = Convert.ToBoolean(nSuperHero.Speed);
        //gets the boolean value of strength and assigns it (uses it to check or uncheck the checkbox)
        cbxProfileStrength.Checked = Convert.ToBoolean(nSuperHero.Strength);
        //gets the boolean value of flight and assigns it (uses it to check or uncheck the checkbox)
        cbxProfileFlight.Checked = Convert.ToBoolean(nSuperHero.Flight);
        //gets the boolean value of teleportation and assigns it (uses it to check or uncheck the checkbox)
        cbxProfileTeleportation.Checked = Convert.ToBoolean(nSuperHero.Teleportation);
        //gets the boolean value of invisibility and assigns it (uses it to check or uncheck the checkbox)
        cbxProfileInvisibility.Checked = Convert.ToBoolean(nSuperHero.Invisibility);
        //gets the boolean value of telekenisis and assigns it (uses it to check or uncheck the checkbox)
        cbxProfileTelekenisis.Checked = Convert.ToBoolean(nSuperHero.Telekenisis);
        //gets the boolean value of psychokenisis and assigns it (uses it to check or uncheck the checkbox)
        cbxProfilePsychokenesis.Checked = Convert.ToBoolean(nSuperHero.Psychokenisis); 
        //Use if statements to check the gender and use selected Index of the drop down list to select it (what will be displayed when page loads)
        //if gender value returned is unassigned then to select this in the ddl selected index value must =0
        if (GenderCheck == "Unassigned") { ddlProfileGender.SelectedIndex = 0; }
        //if gender value returned is Male then to select this in the ddl selected index value must =1
        if (GenderCheck == "Male") { ddlProfileGender.SelectedIndex = 1; }
        //if gender value returned is Female then to select this in the ddl selected index value must =2
        if (GenderCheck == "Female") { ddlProfileGender.SelectedIndex = 2; }
        //if gender value returned is Neutral then to select this in the ddl selected index value must =3
        if (GenderCheck == "Neutral") { ddlProfileGender.SelectedIndex = 3; }
        //if gender value returned is Transgender then to select this in the ddl selected index value must =4
        if (GenderCheck == "Transgender") { ddlProfileGender.SelectedIndex = 4; }
        //if gender value returned is Non-binary then to select this in the ddl selected index value must =5
        if (GenderCheck == "Non-binary") { ddlProfileGender.SelectedIndex = 5; }
    }
   

    protected void btnProfileSave_Click(object sender, EventArgs e)
    {
        ///[--week10--]this function handles the click event of the Save button
        ///it create instance of the clsSuperHeroCollection class and calls it SuperHero
        clsSuperHeroCollection theSuperHeroCollection = new clsSuperHeroCollection();
        //declares the variables to store the form data for new SuperHero
        string SuperHeroID = lblProfileSuperHeroID.Text;
        //get the nickname from forms textbox and store in associated string variable
        string Nickname = tbxProfileName.Text;
        //get the gender from forms dropdown list and store in associated string variable
        string Gender = ddlProfileGender.Text;
        //get the height from forms textbox and store it in the associated string variable
        string Height = tbxProfileHeight.Text;
        //get the weight from forms textbox and store it in the associated string variable
        string Weight = tbxProfileWeight.Text;
        //get the BirthDate from forms textbox and store it in associated string variable
        string BirthDate = tbxProfileBirthDate.Text;
        //get the City drop down list SelectedValue  and store it in associated string variable
        Int32 CityNo = Convert.ToInt32(ddlProfileCity.SelectedValue); 
        //get city name from ddl and assign it to the citName string variable
        string CityName = Convert.ToString(ddlProfileCity.SelectedItem);
        //string variable to store concatenated error messages
        string CheckNoValidationErrors = "";
        //DateTime type variable declaration and initialisation to be used to store The BirthDate in DateTime format
        DateTime TheBirthDate = Convert.ToDateTime("01/01/0001");
        //int type variable declaration and initialisation of variable to store calculated age (calculated using current age and date of birth)
        Int32 Age =0;
        // int type variable declaration and initialisation of variable to store integer value of weight
        Int32 Weight_kg = 0;
        //Decimal variable to store the heights decimal value
        decimal Height_m = 0;
        //declaration of variables to store boolean value for speed
        Boolean Speed = cbxProfileSpeed.Checked;
        //declaration of variables to store boolean value for strength
        Boolean Strength = cbxProfileStrength.Checked;
        //declaration of variables to store boolean value for flight
        Boolean Flight = cbxProfileFlight.Checked;
        //declaration of variables to store boolean value for teleportation
        Boolean Teleportation = cbxProfileTeleportation.Checked;
        //declaration of variables to store boolean value for invisibility
        Boolean Invisibility = cbxProfileInvisibility.Checked;
        //declaration of variables to store boolean value for telekenisis
        Boolean Telekenisis = cbxProfileTelekenisis.Checked;
        //declaration of variables to store boolean value for pychokenisis
        Boolean Psychokenisis = cbxProfilePsychokenesis.Checked; 
        //create and instance of the clsSuperHero
        clsSuperHero aSuperHero = new clsSuperHero();
        /// validate the data from the form using the ValidateSuperHeroData function
        /// and returned validation error messages and store in CheckNoValidationErrors string
        CheckNoValidationErrors = aSuperHero.ValidateSuperheroData(SuperHeroID, Nickname, Height, Weight, BirthDate, CityName );
        //If theres no validation errors then do this section of code:
        if (CheckNoValidationErrors == "") 
        {
            //If there are no validation errors then do some calculations or conversions that we need
            //find age using birthday and current date
            Age = aSuperHero.CalculateAge(Convert.ToDateTime(BirthDate), DateTime.Today);
            //Converts age from integer to string and displays the age as text
            lblProfileCalculatedAge.Text = Convert.ToString(Age); 
            //convert the weight into integer and store in the weight_kg integer variable
            Weight_kg = Convert.ToInt32(Weight);
            //convert the height in to integer and store in height_m decimal variable
            Height_m = Convert.ToDecimal(Height);
            //convert the birth date into a datatime variable and store in TheBirthDate DateTime variable
            TheBirthDate = Convert.ToDateTime(BirthDate);
            //convert SuperHeroID in to an integer and store in integer variable theSuperHeroID
            Int32 theSuperHeroID = Convert.ToInt32(SuperHeroID);
            //Check the label for SuperHeroID has no entered number (==0). 
            if (theSuperHeroID == 0) 
            {
                //[03/02/2019] assign the values to the variables of the ThisSuperHero property. 
                //No need to include the SuperHeroID as we are creating a new entry, the ID is automatically assigned in tblSuperHero
                //put the Nickname into the Nickname property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Nickname = Nickname;
                //put the Gender into the Gender property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Gender = Gender;
                //put the Height_m into the Height_m property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Height_m = Height_m;
                //put the Weight_kg into the Weight_kg property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Weight_kg = Weight_kg;
                //put the TheBirthDate into the TheBirthDate property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.BirthDate = TheBirthDate;
                //put the Age into the Age property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Age = Age;
                //put the CityNo into the CityNo property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.CityNo = CityNo;
                //put the Speed into the Speed property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Speed = Speed;
                //put the Strength into the Strength property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Strength = Strength;
                //put the Flight into the Flight property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Flight = Flight;
                //put the Teleportation into the Teleportation property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Teleportation = Teleportation;
                //put the Invisibility into the Invisibility property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Invisibility = Invisibility;
                //put the Telekenisis into the Telekenisis property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Telekenisis = Telekenisis;
                //put the Psychokenisis into the Psychokenisis property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Psychokenisis = Psychokenisis;
                try 
                {
                    //try this code to see if form fields have correct data type and no empty fields to cause errors
                    //Following code creates a new entry in the database if no value SuperHeroID is in the textbox txtProfileSuperHeroID
                    //Use onSuperHero ot invoke the Add() method of the object by passing it the data from the form, store return value in Sucess if the 
                    Boolean success = theSuperHeroCollection.Add();
                    //check if the above value is true
                    if (success == true)
                    {
                        //[23/01/2019] 
                        //int count = 0;
                        //while(count <= 10000000)      ///this code was suppose to provide a delay but did not work in that way.
                        //The idea was to display the message "saved successfully" for an instance so it could be seen by user before redirection.
                        //{
                        //lblProfileMessage.Text = "Saved Successfully";
                        //MessageBox.Show("Saved successfully"); //this messagebox code did not work
                        //}

                        //if the superhero was added successfully then send to confirmation page
                        Response.Redirect("SaveConfirmation.aspx");
                    }
                    else
                    {
                        //if the superhero was not added then display an error
                        lblProfileMessage.Text = "Error1:~ Save Failed.\n " + CheckNoValidationErrors;  //[25/01/1029] had to add the ValidationErrors on the end;
                    }
                }
                catch 
                {
                    //if the above try statement fails then sidplay an error
                    lblProfileMessage.Text = "Error2:~ Failed to execute Add(). ";
                }
            }
            //[22/01/2019] if theSuperHeroID is not 0 then do this
            if (theSuperHeroID > 0)
            {
                //[03/02/2019] assign the values to the variables of the ThisSuperHero property, this time include the SuperHeroID, 
                //this is used to select the row to update in the tblSuperHero table
                //put the SuperHeroID into the SuperHeroID property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.SuperHeroID = theSuperHeroID;
                //put the Nickname into the Nickname property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Nickname = Nickname;
                //put the Gender into the Gender property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Gender = Gender;
                //put the Height_m into the Height_m property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Height_m = Height_m;
                //put the Weight_kg into the Weight_kg property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Weight_kg = Weight_kg;
                //put the TheBirthDate into the TheBirthDate property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.BirthDate = TheBirthDate;
                //put the Age into the Age property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Age = Age;
                //put the CityNo into the CityNo property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.CityNo = CityNo;
                //put the Speed into the Speed property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Speed = Speed;
                //put the Strength into the Strength property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Strength = Strength;
                //put the Flight into the Flight property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Flight = Flight;
                //put the Teleportation into the Teleportation property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Teleportation = Teleportation;
                //put the Invisibility into the Invisibility property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Invisibility = Invisibility;
                //put the Telekenisis into the Telekenisis property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Telekenisis = Telekenisis;
                //put the Psychokenisis into the Psychokenisis property of the ThisSuperHero object
                theSuperHeroCollection.ThisSuperHero.Psychokenisis = Psychokenisis;
                try
                {
                    ///[24/01/2019] This code is similar to the Add function. It has been ammended to update an entry. 
                    ///This time it uses Update funtion instead of Add
                    Boolean success = theSuperHeroCollection.Update();
                    //check if the value of success is true
                    if (success == true)
                    {
                        //[23/01/2019] 
                        //int count = 0;
                        //while(count <= 10000000)      ///this code was suppose to provide a delay but did not work in that way.
                        //The idea was to display the message "saved successfully" for an instance so it could be seen by user before redirection.
                        //{
                        //lblProfileMessage.Text = "Saved Successfully";

                        //MessageBox.Show("Saved successfully"); //this messagebox code did not work
                        //}

                        //since above did not work decided to send to confirm page
                        Response.Redirect("SaveConfirmation.aspx");
                    }
                    else
                    {
                        //if sucess is false the superheor wasnt updated the display an error
                        lblProfileMessage.Text = "Error3:~ Save Failed.\n " + CheckNoValidationErrors;  //[25/01/1029] had to add the ValidationErrors on the end
                    }
                }
                catch 
                {
                    //if the try statement fails display an error
                    lblProfileMessage.Text = "Error4:~ Failed to execute Update().";
                }
            }
            else 
            {
                //if SuperHeroID is less than 0 then display an error
                lblProfileMessage.Text = "Error5:~ Invalid SuperHero ID.";
            }
        }
        else
        {
            //if there are validation errors then display the errror messages
            lblProfileMessage.Text = CheckNoValidationErrors;
        }

    }

    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {

    }

    //protected void ddlProfileGender_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    lblProfileGenderSelect.Text = ddlProfileGender.Text;


    //}

    protected void txtProfileSuperHeroID_TextChanged(object sender, EventArgs e)
    {

    }



    protected void btnProfileClear_Click(object sender, EventArgs e)
    {
        ClearForm();
    }

    void ClearForm()
    {
        //clear the form
        //Assigns the default value of 0 to the SuperHeroID textbox
        lblProfileSuperHeroID.Text = "0";
        //Clears the SuperHero textbox
        tbxProfileName.Text = "";
        //Clears the Age label with the assigned calculated age
        lblProfileCalculatedAge.Text = "";
        //clears the height textbox
        tbxProfileHeight.Text = "";
        //clears the weight textbox
        tbxProfileWeight.Text = "";
        //clears the BirthDate textbox
        tbxProfileBirthDate.Text = "";
        //clear the textbox for city
        //tbxProfileCity.Text = "";//no longer required
        //resets selected item of the drop down list to unassigned.
        ddlProfileGender.SelectedIndex = 0;
        //noted after clear button the selected text appears in label and needs clearing
        //lblProfileGenderSelect.Text = ""; //no longer required
        //clear the error message
        lblProfileMessage.Text = "";
        //unchecks the flight checkbox
        cbxProfileFlight.Checked = false;
        //unchecks the Invisibility checkbox
        cbxProfileInvisibility.Checked = false;
        //unchecks the Psychokenesis checkbox
        cbxProfilePsychokenesis.Checked = false;
        //unchecks the Speed checkbox
        cbxProfileSpeed.Checked = false;
        //unchecks the Strength checkbox
        cbxProfileStrength.Checked = false;
        //unchecks the Telekenisis checkbox
        cbxProfileTelekenisis.Checked = false;
        //unchecks the Teleportation checkbox
        cbxProfileTeleportation.Checked = false;
        //selects the first item in the list
        ddlProfileCity.SelectedIndex = 0; 
    }


    protected void txtProfileBirthDate_TextChanged(object sender, EventArgs e)
    {

    }

    protected void tbxProfileName_TextChanged(object sender, EventArgs e)
    {

    }

    protected void cbxProfilePsychokenesis_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void ddlProfileCity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    //This section of code was used for testing but is no longer required
    //protected void btnProfileSet_Click(object sender, EventArgs e)
    //{
    //    //testing how the ddlProfileCity drop down list works

    //        try
    //        {
    //            tbxSelectedIndex.Text = Convert.ToString(ddlProfileCity.SelectedIndex);
    //            tbxSelectedItem.Text = Convert.ToString(ddlProfileCity.SelectedItem);
    //            tbxSelectedValue.Text = ddlProfileCity.SelectedValue;
    //        }
    //        catch
    //        {
    //            lblProfileMessage.Text = "ddlCityError";
    //        }

    //}

    protected void btnProfileCancel_Click(object sender, EventArgs e)
    {
        //redirect to the default page
        Response.Redirect("Default.aspx");
    }

    protected void ddlProfileGender_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}