using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// [WEEK9]
/// This class is going to encapsulate and define a template 
/// for a Superhero with the attributes specified in the table (tblSuperHero).
/// Each attribute in this class will be specified as a private member.
/// Due to the private nature of the variables, they will not be visible
/// to other functions and classes. However access will be limited via a
/// public property, that will be used to change the private member (variable). 
/// These properties containing the getter (get) will
/// allow us to retrieve data from the property. Also, these properties 
/// containing setter (set) will allow data into the public property to change
/// the private data member.
/// </summary>
public class clsSuperHero

{
    //The private member pmSuperHeroID 
    //Note The 'pm' in pmSuperHeroID is for private member
    private Int32 pmSuperHeroID;
    //public property funtion SuperHeroID.
    public Int32 SuperHeroID
    {
        get
        {
            return pmSuperHeroID;
        }
        set
        {
            pmSuperHeroID = value;
        }
    }

    //Private member pmNickname
    private String pmNickname;
    //public property funtion Nickname
    public String Nickname
    {
        get
        {
            return pmNickname;
        }
        set
        {
            pmNickname = value;
        }
    }

    //Private member pmGender 
    private String pmGender;
    //public property funtion Gender
    public String Gender
    {
        get
        {
            return pmGender;
        }
        set
        {
            pmGender = value;
        }
    }

    //Private member pmHeight_m 
    private Decimal pmHeight_m;
    //public property function Height_m
    public Decimal Height_m
    {
        get
        {
            return pmHeight_m;
        }
        set
        {
            pmHeight_m = value;
        }
    }

    //Private member pmWeight_kg 
    private Int32 pmWeight_kg;
    //public member Weight_kg
    public Int32 Weight_kg
    {
        get
        {
            return pmWeight_kg;
        }
        set
        {
            pmWeight_kg = value;
        }
    }
    //Private member pmBirthDate 
    private DateTime pmBirthDate;
    //public property function BirthDate
    public DateTime BirthDate
    {
        get
        {
            return pmBirthDate;
        }
        set
        {
            pmBirthDate = value;
        }
    }
    //Private member pmAge 
    private Int32 pmAge;
    //public property function Age
    public Int32 Age
    {
        get
        {
            return pmAge;
        }
        set
        {
            pmAge = value;
        }
    }
    //Private member pmCity 
    private Int32 pmCityNo;
    //public property funtion City
    public Int32 CityNo
    {
        get
        {
            return pmCityNo;
        }
        set
        {
            pmCityNo = value;
        }
    }
    //private member pmStrenth 
    private bool pmStrength;
    //public property function Strength
    public bool Strength
    {
        get
        {
            return pmStrength;
        }
        set
        {
            pmStrength = value;
        }
    }
    //Private member pmSpeed 
    private bool pmSpeed;
    //public property function Speed
    public bool Speed
    {
        get
        {
            return pmSpeed;
        }
        set
        {
            pmSpeed = value;
        }
    }
    // Private member pmFlight 
    private bool pmFlight;
    //public property function Flight
    public bool Flight
    {
        get
        {
            return pmFlight;
        }
        set
        {
            pmFlight = value;
        }
    }
    //Private member pmTeleportation 
    private bool pmTeleportation;
    //public property function Teleportation
    public bool Teleportation
    {
        get
        {
            return pmTeleportation;
        }
        set
        {
            pmTeleportation = value;
        }
    }
    //Private member pmInvisibility 
    private bool pmInvisibility;
    //public property function Invisibility
    public bool Invisibility
    {
        get
        {
            return pmInvisibility;
        }
        set
        {
            pmInvisibility = value;
        }
    }
    //Priavte member pmTelekenisis 
    private bool pmTelekenisis;
    //public member Telekenisis
    public bool Telekenisis
    {
        get
        {
            return pmTelekenisis;
        }
        set
        {
            pmTelekenisis = value;
        }
    }
    //Private member pmPsychokenisis 
    private bool pmPsychokenisis;
    //public property function Psychokenisis
    public bool Psychokenisis
    {
        get
        {
            return pmPsychokenisis;
        }
        set
        {
            pmPsychokenisis = value;
        }
    }
    /************************************************************ [29/01/2019] Code for Validation of form Data *******************************************************************************/
    public string ValidateSuperheroData(string SuperHeroID, string NicknameString, string HeightString, string WeightString, string BirthDateString ,string CityString)
    {
        //declare a string to store any validation errors
        string ValidationErrors = "";

        /********************** Validation of SuperHeroID ***************************************/
 
        //This section of code to check the SuperHeroID is redundant since the SuperHeroID is automatically generated in the database and cannot be manually inputed
        //There is no need to check this if its automatically generated. Nore is there a need to check it if the option to change
        //the SuperHeroID is not available when updating a profile.
        try
        {
            //declare a temporary variable for an integer
            Int32 tempSuperHeroID;
            //get the superheroID and store in the tempSuperHeroID variable
            tempSuperHeroID = Convert.ToInt32(SuperHeroID);
            //check the range: ID is less than 0
            if (tempSuperHeroID < 0)
            {
                //if ID is less than zero then concatenate error text on to Validation string
                ValidationErrors = ValidationErrors + "the superheroID is less than zero";
            }
            //check the range: ID is greater than 999999 (limit for 6 characters)
            if (tempSuperHeroID > 999999)
            {
                //if ID is greater than 999999 then concatenate error text on to Validation string
                ValidationErrors = ValidationErrors + "the superheroID is more than 6 digits";
            }
        }
        catch
        {
            //if the try statement fails then concatenate error text on to Validation string
            ValidationErrors = ValidationErrors + "the superheroID is not valid";
        }

        /**************************** Validation of Superhero text field input *********************************/
        //try this code to check the Superhero name field
        try
        {
            //check name only contains letters
            //if((NicknameString.Length >= 3) & (NicknameString.Length < 30))
            //{
            //convert to an array of characters
            char[] NicknameCharacters = NicknameString.ToArray<char>();

            //declare a variable to store the count for the while loop, when looping through character array
            Int32 CharacterCounter = 0;
            //loop through the character array
            while (CharacterCounter < NicknameString.Length)
            {
                //check that the value fo each character indexed in the character array by character count is a letter or a space
                //(i.e. any character not betwen 'A' to 'Z' or 'a' to 'z'  and ' ' (space) will give an error. 
                if ((NicknameCharacters[CharacterCounter] >= 'A') && (NicknameCharacters[CharacterCounter] <= 'z') || (NicknameCharacters[CharacterCounter] == ' '))
                {
                    //do nothing
                }
                else
                {
                    //cancatenate  an error on to validation string if any character is not a letter (not including spaces)
                    ValidationErrors = ValidationErrors + "Superhero name field' should only contain letters.";
                    //then break out the look
                    break;
                }
                CharacterCounter++;
            }

            //check that the first 3 characters are not 3 spaces in a row
            //Check the first 3 characters in the string are not spaces
            if ((NicknameCharacters[0] == ' ') && (NicknameCharacters[1] == ' ') && (NicknameCharacters[2] == ' '))
            {
                //if so cancatenate  an error on to validation string
                 ValidationErrors = ValidationErrors + "The first 3 characters of the Superhero name field' can not be spaces.";
            }

            //}
            //Check nickname is not less than 2 characters or blank
            if (NicknameString.Length < 3)
            {
                //cancatenate  an error on to validation string
                ValidationErrors = ValidationErrors + "'Superhero name field' is too short (min 3 characters). ";
            }
            //Check nickname is not longer than 30 characters
            if (NicknameString.Length > 30) 
            {
                //cancatenate  an error on to validation string
                ValidationErrors = ValidationErrors + "'Superhero name field' is too long (max 30 characters). ";
            }
        }
        catch
        {
            //Encase the field is blank and the try statement fails
            ValidationErrors = ValidationErrors + "'Superhero name field' is not a valid type. ";

        }

        
        /************************************ Validation of Date of Birth *******************************************/

        try
        {
            //create a temporary date time variable 
            DateTime tempBirthDate;
            //and  to pass in the birth date to check its the correct format.
            tempBirthDate = Convert.ToDateTime(BirthDateString);
            //[25/01/2019] I want to compare a range for the date of birth, so i will create some upper and lower limits of type DateTime
            //so I can compare the input against
            //get the minimum acceptable date and store in the DateTime variable
            DateTime LowerDate = Convert.ToDateTime("1800/01/01");
            //this gets the current date and stores in the datetime variable CurrentDate
            DateTime CurrentDate = DateTime.Today; 
            //
            if (tempBirthDate < LowerDate)
            {
                //cancatenate  an error to validation string
                ValidationErrors = ValidationErrors + "'BirthDate' year cannot be less than 1800. ";
            }
            if (tempBirthDate > CurrentDate)
            {
                ValidationErrors = ValidationErrors + "'BirthDate' year is in the future. ";
            }
        }
        catch
        {
            ValidationErrors = ValidationErrors + "'BirthDate' must be a valid date and format DD/MM/YYYY. ";
        }

        /****************************************** Validation of Height *******************************************/

        //Validate input for Height_m is decimal
        try
        {
            //declare a temporary height variable of single float type to store the decimal 
            //convert the height to a single and test if its the correct format by
            //assigning it to tempHeight variable to check its format
            Single tempHeight_m = Convert.ToSingle(HeightString);
            //minimum height can be 0.5m, check if minimum height less than 0.5
            if(tempHeight_m < 0.5)
            {
                //cancatenate  an error on to validation string
                ValidationErrors = ValidationErrors + "'Height' is below mimimum acceptable value of 0.5m. ";
            }
            //check if minimum height greater than 5.0
            if (tempHeight_m > 5.0)
            {
                //cancatenate  an error on to validation string
                ValidationErrors = ValidationErrors + "'Height' is above maximum acceptable value of 5.0m. ";
            }

        }
        catch 
        {
            //provide an error message if try statement fails
            ValidationErrors = ValidationErrors + "'Height' is not entered correctly. ";
        }

        /****************************************** Validation of Weight ********************************************/
 
        //validate weight input to confirm its an integer
        try
        {
            //declare a temporary integer value 
            //convert to integer and test that the value passed in is the correct format
            Int32 tempWeight_kg = Convert.ToInt32(WeightString);
            //check if weight is less than 20
            if (tempWeight_kg < 20)
            {
                //cancatenate  an error on to validation string
                ValidationErrors = ValidationErrors + "'Weight' can not be less than 20kg. ";
            }
            //check if weight is greater than 500
            if(tempWeight_kg > 500)
            {
                //cancatenate  an error on to validation string
                ValidationErrors = ValidationErrors + "'Weight' can not be more than 500kg. ";
            }
        }
        catch
        {
            //if try statement fails cancatenate  an error on to validation string
            ValidationErrors = ValidationErrors + "'Weight' is not entered correctly. ";
        }
        //This code checks the maximum and minimum length of the City name provided
        if (CityString.Length <= 3)
        {
            //cancatenate  an error on to validation string
            ValidationErrors = ValidationErrors + "'City' name is too short (min 2 characters). ";
        }
        if (CityString.Length >= 30) //Check city is not longer than 19 characters
        {
            //cancatenate  an error on to validation string
            ValidationErrors = ValidationErrors + "'City' name is too long (max 20 characters). ";
        }
        //return the concatenated string
        return ValidationErrors;
    }
/****************************** [27/02/2019] Code added to return the age of a person based on the birthdate and current date *********************************/

    // This is better than storing age because it will give the upto date age of a person every time its needed.
    // I placed the code here because everytime the collection class is used the to retrieve information,
    // the Age is then required at the same time.
public Int32 CalculateAge(DateTime BirthDate, DateTime CurrentDate)
{
        //declare integer to store the age and initialise =0
        Int32 Age = 0;
        //check if the year is current year
        if (BirthDate.Year == CurrentDate.Year)
        {
            //age is zero
            Age = 0;
            //return age
            return Age;
        }
        else
        {
            //if the current month is before the birth month then birthday has not passed, so a year less in age
            if (CurrentDate.Month < BirthDate.Month) 
            {
                Age = Convert.ToInt32(CurrentDate.Year - BirthDate.Year) - 1;
               
            }
            //if the current month is after the birth month then birthday has passed, so a year more in age
            if (CurrentDate.Month > BirthDate.Month) 
            {
                Age = Convert.ToInt32(CurrentDate.Year - BirthDate.Year);

            }
            //if current month is equal to birthday month then check if the day (actual birthday has passed or not):
            if (CurrentDate.Month == BirthDate.Month) 
            {
                // This section of code checks that the birthday has passed or not so Age years can be calculated
                //if birthday's day in the month is less than current day in current month, then birthday has passed
                if (CurrentDate.Day >= BirthDate.Day) 
                {
                    // on or after the birthday we calculate the complete difference in years
                    Age = Convert.ToInt32(CurrentDate.Year - BirthDate.Year);
                }
                //if the birthday has not passed
                if (CurrentDate.Day < BirthDate.Day) 
                {
                 //the age is not the full years difference yet (one year less)
                 Age = Convert.ToInt32(CurrentDate.Year - BirthDate.Year) - 1;
                }
            }
            return Age;
        }
}

/**************************************** [27/02/2019] Code added to format the displayed date ********************************************************/
    /*[27/01/2019] didn't like the date format displayed when the display all or profile DOB is retrieved from the
     * database. For consistency in the displayed date format I have created the following code
     */

    public String FormatDate(DateTime DateIn)
    {
        //declare a string variable to store the date in the correct format
        string DateOut;
        //Declare a string to store the day part of the Date
        String DD = Convert.ToString(DateIn.Day);
        //declare a string to store the month part of the Date
        String MM = Convert.ToString(DateIn.Month);
        //declare a string to store the year part of the Date
        string YYYY = Convert.ToString(DateIn.Year);
        //if the length of day part is less than 2 digits
        if (DD.Length < 2)
        {
            //make the tay part in to 2 digits by concatenating with 0
            DD = "0" + DD;
        }
        //if the month part is less than 2 digits
        if (MM.Length < 2)
        {
            //make the month part 2 digits long by concatenating with 0
            MM = "0" + MM;
        }
        //return the date in the concatenated format
        return DateOut = DD + "/" + MM + "/" + YYYY;
    }



/**********************************  [27/01/2019] Function that locates a superhero in database  *****************************************************/
    /// [27/01/2019] Function that locates a superhero in database using primary key and loads the private member values with the data relating to the superhero
    /// 
    public Boolean SelectSuperHero(Int32 SuperHeroIDPassedIn)
    {
        ///In this function an @SuperHeroID parameter is passed to the the FilterBySuperHeroID query. This will select the row 
        ///of matching information in the database table relating to the SuperHeroID. It then loads the DataTable with the single
        ///entry of SuperHeroID. The form is then loaded with the data for the row in the data table.

        //create a connection to the database
        clsDataConnection dBConnection = new clsDataConnection();
        //pass in the pararmeter name and value to the AddParameter list object
        dBConnection.AddParameter("@SuperHeroID", SuperHeroIDPassedIn);
        //execute the stored procedure
        dBConnection.Execute("sproc_tblSuperHero_FilterBySuperHeroID");
        //gets the count of records the DataTable is populated with
        Int32 RecordCount = dBConnection.Count; 
        //if there is an entry in the data table it will ==1
        if (dBConnection.Count == 1)
        {
            /// Get the data in the row, data is at index value 0 because the DataTable is a zero bound array
            /// Each row is individually selected using the attribute name (in the table) as the identifier.
            pmSuperHeroID = Convert.ToInt32(dBConnection.DataTable.Rows[0]["SuperHeroID"]);
            //get the value of nickname in the datatable and assign to private member variable
            pmNickname = Convert.ToString(dBConnection.DataTable.Rows[0]["Nickname"]);
            //get the value of gender in the datatable and assign to private member variable
            pmGender = Convert.ToString(dBConnection.DataTable.Rows[0]["Gender"]);
            //get the value of weight in the datatable and assign to private member variable
            pmWeight_kg = Convert.ToInt32(dBConnection.DataTable.Rows[0]["Weight_kg"]);
            //get the value of height in the datatable and assign to private member variable
            pmHeight_m = Convert.ToDecimal(dBConnection.DataTable.Rows[0]["Height_m"]);
            //get the value of birthdate in the datatable and assign to private member variable
            pmBirthDate = Convert.ToDateTime(dBConnection.DataTable.Rows[0]["BirthDate"]);
            //The following line is not required anymore as the age is calculated on the fly from BirthDate and CurrentDate
            //pmAge = Convert.ToInt32(dBConnection.DataTable.Rows[0]["Age"]);
            pmAge = Convert.ToInt32(CalculateAge(pmBirthDate, DateTime.Today));
            //get the value of cityNo in the datatable and assign to private member variable
            pmCityNo = Convert.ToInt32(dBConnection.DataTable.Rows[0]["CityNo"]);
            //get the value of speed in the datatable and assign to private member variable
            pmSpeed = Convert.ToBoolean(dBConnection.DataTable.Rows[0]["Speed"]);
            //get the value of strength in the datatable and assign to private member variable
            pmStrength = Convert.ToBoolean(dBConnection.DataTable.Rows[0]["Strength"]);
            //get the value of flight in the datatable and assign to private member variable
            pmFlight = Convert.ToBoolean(dBConnection.DataTable.Rows[0]["Flight"]);
            //get the value of teleportation in the datatable and assign to private member variable
            pmTeleportation = Convert.ToBoolean(dBConnection.DataTable.Rows[0]["Teleportation"]);
            //get the value of invisibility in the datatable and assign to private member variable
            pmInvisibility = Convert.ToBoolean(dBConnection.DataTable.Rows[0]["Invisibility"]);
            //get the value of telekenisis in the datatable and assign to private member variable
            pmTelekenisis = Convert.ToBoolean(dBConnection.DataTable.Rows[0]["Telekenisis"]);
            //get the value of psychokenisis in the datatable and assign to private member variable
            pmPsychokenisis = Convert.ToBoolean(dBConnection.DataTable.Rows[0]["Psychokenisis"]);
            //return true if there is a single entry in data table
            return true;
        }
        else
        {
            //if there is not a single entry in data table then return false
            return false;
        }
    }

/********************************** The FindRecord function ******************************************/
    //[03/02/2019] this section of code will find the SuperHeroID and if it does it returns true
    //if not then it returns false
    public Boolean LocateRecord(Int32 aSuperHeroID)
    {
        try
        {
            //Create an instance of the data connection
            clsDataConnection myDatabaseConnection = new clsDataConnection();
            //Pass both SuperHeroID parameter and parameter value to myDatabase to be used by stored procedure in database 
            myDatabaseConnection.AddParameter("@SuperHeroID", aSuperHeroID);
            //Execute the stored procedure in the database
            myDatabaseConnection.Execute("sproc_tblSuperHero_FilterBySuperHeroID");
            //set the return value for the function
            return true;
        }
        catch 
        {
            //do this if the try statement failed for some reason
            //report back that there was an error
            return false;
        }

    }

}