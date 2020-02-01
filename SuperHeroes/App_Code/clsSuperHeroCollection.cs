using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsSuperHeroCollection
/// </summary>
public class clsSuperHeroCollection
{
    //Create an instance of the clsSuperHero class and call it pmThisSuperHero to store the data for a Superhero
    clsSuperHero pmThisSuperHero = new clsSuperHero();

    //Declaring the dBconnection here gives the connection more scope so its available to all the class
    //functions and subfunctions
    string SearchParameter;
    clsDataConnection dBConnection = new clsDataConnection();


    //ThisSuperHero public property can be used as a container of variables so values for SuperHero attributes can be 
    //passed into this funtion and then used in Add() or Update().
    public clsSuperHero ThisSuperHero
    {
        get
        {
            return pmThisSuperHero;
        }
        set
        {
            pmThisSuperHero = value;
        }
    }

    public Int32 Count //[Week10] - public property that will return the Count value of entries in the DataTable object
    {
        get
        { 
            ///This commented out code is now obscelete:
            ////send a filter to the query with blank search criteria: ""
            ////this results in a "" + '%' in the query that matches all nicknames that are then 
            ////put into the DataTable object, so that the items can be counted and a count value 
            ////returned i.e. return dataTable.Rows.Count; in the clsDataConnection line 209

            ////as described above, will add blank Nickname parameter as ""
            //dBConnection.AddParameter("@Nickname", "");

            ////Execute the query sproc_tblSuperHero_FilterByNickname
            //dBConnection.Execute("sproc_tblSuperHero_FilterByNickname");

            return dBConnection.Count;

        }
    }

    // [WEEK7] :
    // 1. We create an instance of clsDataConnection called MyDatabase
    // 2. We use the AddParameter method to add the data contained in AddressNo 
    // to the parameter in the stored procedure called @AddressNO
    // 3. We invoke the Execute method to run the stored procedure

    public Boolean Delete()
    {   try
        {//try to delete the record
            ///this public function provides the functionality for the delete method

            ///Create an instance of the data connection
            clsDataConnection myDatabaseConnection = new clsDataConnection();

            
            ///Pass both SuperHeroID parameter and parameter value to myDatabase to be used by stored procedure in database 
            myDatabaseConnection.AddParameter("@SuperHeroID", pmThisSuperHero.SuperHeroID);

            ///Execute the stored procedure in the database
            myDatabaseConnection.Execute("sproc_tblSuperHero_delete");
            
            //set the return value for the function
            return true;
        }
        catch //do this if the code above failed for some reason
        {
            //report back that there was an error
            return false;
        }
    }

///[--week10--] This funtion will be used to add a new superhero to the database
    public Boolean Add()
    {   try
        {
            clsDataConnection myDatabase = new clsDataConnection();
            ///Pass both parameter and parameter value to myDatabase list object 
            ///The following lines add a new entry into the database with attribute/variable values passed in the stored procedure
            //pass the parameter name and value for Nickname to the AddParameter method
            myDatabase.AddParameter("@Nickname", ThisSuperHero.Nickname);
            //pass the parameter name and value for Gender to the AddParameter method
            myDatabase.AddParameter("@Gender", ThisSuperHero.Gender);
            //pass the parameter name and value for Weight_kg to the AddParameter method
            myDatabase.AddParameter("@Weight_kg", ThisSuperHero.Weight_kg);
            //pass the parameter name and value for Height_m to the AddParameter method
            myDatabase.AddParameter("@Height_m", ThisSuperHero.Height_m);
            //pass the parameter name and value for BirthDate to the AddParameter method
            myDatabase.AddParameter("@BirthDate", ThisSuperHero.BirthDate);
            //pass the parameter name and value for Age to the AddParameter method
            myDatabase.AddParameter("@Age", ThisSuperHero.Age);
            //pass the parameter name and value for CityNo to the AddParameter method
            myDatabase.AddParameter("@CityNo", ThisSuperHero.CityNo);
            //pass the parameter name and value for Speed to the AddParameter method
            myDatabase.AddParameter("@Speed", ThisSuperHero.Speed);
            //pass the parameter name and value for Strength to the AddParameter method
            myDatabase.AddParameter("@Strength", ThisSuperHero.Strength);
            //pass the parameter name and value for Flight to the AddParameter method
            myDatabase.AddParameter("@Flight", ThisSuperHero.Flight);
            //pass the parameter name and value for Teleportation to the AddParameter method
            myDatabase.AddParameter("@Teleportation", ThisSuperHero.Teleportation);
            //pass the parameter name and value for Invisibility to the AddParameter method
            myDatabase.AddParameter("@Invisibility", ThisSuperHero.Invisibility);
            //pass the parameter name and value for Telekenisis to the AddParameter method
            myDatabase.AddParameter("@Telekenisis", ThisSuperHero.Telekenisis);
            //pass the parameter name and value for Psychokenisis to the AddParameter method
            myDatabase.AddParameter("@Psychokenisis", ThisSuperHero.Psychokenisis);
            ///Execute the stored procedure in the database for adding the details to the database
            myDatabase.Execute("sproc_tblSuperHero_AddSuperHero");
            //set the return value for the function
            return true;
        }
        catch 
        {
            //do this if the try code above failed for some reason
            //report back that there was an error
            return false;
        }
    }

    public Boolean Update()
    {
        try
        {
            //create an instance of clsDataConnection
            clsDataConnection myDatabase = new clsDataConnection();
            ///Pass both parameter and parameter value to myDatabase list object 
            ///The following lines add a new entry into the database with attribute/variable values passed in the stored procedure
            //pass the parameter name and value for SuperHeroID to the AddParameter method
            myDatabase.AddParameter("@SuperHeroID", ThisSuperHero.SuperHeroID);
            //pass the parameter name and value for Nickname to the AddParameter method
            myDatabase.AddParameter("@Nickname", ThisSuperHero.Nickname);
            //pass the parameter name and value for Gender to the AddParameter method
            myDatabase.AddParameter("@Gender", ThisSuperHero.Gender);
            //pass the parameter name and value for Weight_kg to the AddParameter method
            myDatabase.AddParameter("@Weight_kg", ThisSuperHero.Weight_kg);
            //pass the parameter name and value for Height_m to the AddParameter method
            myDatabase.AddParameter("@Height_m", ThisSuperHero.Height_m);
            //pass the parameter name and value for BirthDate to the AddParameter method
            myDatabase.AddParameter("@BirthDate", ThisSuperHero.BirthDate);
            //pass the parameter name and value for Age to the AddParameter method
            myDatabase.AddParameter("@Age", ThisSuperHero.Age);
            //pass the parameter name and value for CityNo to the AddParameter method
            myDatabase.AddParameter("@CityNo", ThisSuperHero.CityNo);
            //pass the parameter name and value for Speed to the AddParameter method
            myDatabase.AddParameter("@Speed", ThisSuperHero.Speed);
            //pass the parameter name and value for Strength to the AddParameter method
            myDatabase.AddParameter("@Strength", ThisSuperHero.Strength);
            //pass the parameter name and value for Flight to the AddParameter method
            myDatabase.AddParameter("@Flight", ThisSuperHero.Flight);
            //pass the parameter name and value for Teleportation to the AddParameter method
            myDatabase.AddParameter("@Teleportation", ThisSuperHero.Teleportation);
            //pass the parameter name and value for Teleportation to the AddParameter method
            myDatabase.AddParameter("@Invisibility", ThisSuperHero.Invisibility);
            //pass the parameter name and value for Invisibility to the AddParameter method
            myDatabase.AddParameter("@Telekenisis", ThisSuperHero.Telekenisis);
            //pass the parameter name and value for Telekenisis to the AddParameter method
            myDatabase.AddParameter("@Psychokenisis", ThisSuperHero.Psychokenisis);
            ///Execute the stored procedure to update the entry in the database
            myDatabase.Execute("sproc_tblSuperHero_UpdateSuperHero");
            //set the return value for the function
            return true;
        }
        catch 
        {
            //do this if the try code above failed for some reason
            //report back that there was an error
            return false;
        }
    }

   
    //This section of code allows you to do a search for a superhero. The stored procedure attempts to find a match with whatever parameter you enter
    //if you enter a decimal (for Age) it will try and find a match for that, or if you enter a name/gender or a partial name/gender
    public void SearchSuperHeros(string SearchParameterIn)
    {
        try
        {
            //[27/02/12019] try this first check if the search parameter is in a DateTime format
            //get the date in the search parameter and assign it to the DateTime variable
            DateTime DateIn = Convert.ToDateTime(SearchParameterIn);
            //declare a string to store the day part
            String DD = Convert.ToString(DateIn.Day);
            //declare a string to store the month part
            String MM = Convert.ToString(DateIn.Month);
            //declare a string to store the year part
            string YYYY = Convert.ToString(DateIn.Year);
            //if the day part is less than 2 digits
            if (DD.Length < 2)
            {
                //make the day part 2 digits long
                DD = "0" + DD;
            }
            //if the month part is less than 2 digits
            if (MM.Length < 2)
            {
                //make the month part 2 digits long
                MM = "0" + MM;
            }
            //the database search will not work unless the search parameter is in a particular format. 
            //This code converts the date in to the correct format so it can be used by the stored procedure to return results by date.
            SearchParameter =  YYYY + "-" + MM + "-" + DD;
            //use the same connection defined by the class variable at the top
            dBConnection = new clsDataConnection();
            //Add the parameter and value passed in to the Parameters list
            dBConnection.AddParameter("@Search", SearchParameter);
            //execute the stored procedure to load the  Data Table with the results
            dBConnection.Execute("sproc_tblSuperHero_tblCity_FilterBySearchCriteria");
        }
        catch
        {   //if the search parameter passed in is not a DateTime format then do this.
            //[31-01-2019] It appears that using the following 3 lines of code in Search Something provides a shared source of information
            //so enabling the SuperHeroList to populate the Object of parameters with commonly required data requested by the 
            //stored procedure using a shared parameter passed to the stored procedure. 
            //Various attempts to make it with one of the 3 elements missing resulted in failure
            //set the search parameter for the SuperHerosList, using a class variable with greater scope (at top)
            SearchParameter = SearchParameterIn;
            //use the same connection defined by the class variable at the top
            dBConnection = new clsDataConnection();
            //Add the parameter and value passed in to the Parameters list
            dBConnection.AddParameter("@Search", SearchParameter);
            //execute the stored procedure to load the  Data Table with the results
            dBConnection.Execute("sproc_tblSuperHero_tblCity_FilterBySearchCriteria");
        }
    }
    // [week10] public void SuperHeroList() converted to property will allow us to access 
    // data and not make changes to it, so will be read only (getter but no setter) dictated by clsSuperHero
    public List<clsSuperHero> SuperHeroList  // SuperHeroList is the return type here is of type List<clsSuperHero>
    {
    get
        {
            // [WEEK9] 1/3 - Creating an AddressList of type clsSuperHero to store the values from
            // the DataTable Object
            //create a array list object of type clsSuperHero (so it can store clsSuperHero objects)
            List<clsSuperHero> pmSuperHeroList = new List<clsSuperHero>();
            //This code became obscelete
            //[WEEK9] 2/3 - Makes these delcarations redundant because of the instance of 
            // new clsSuperHero class and use of properties to store values in private
            // in private member variabels.
            // Int32 SuperHeroID;
            // String Nickname;
            // String Gender;
            // Decimal Height_m;
            // Int32 Weight_kg;
            // DateTime BirthDate;
            // Int32 Age;
            // String City;
            // Boolean Strength;
            // Boolean Speed;
            // Boolean Flight;
            // Boolean Teleportation;
            // Boolean Invisibility;
            // Boolean Telekenisis;
            // Boolean Psychokenisis;

            //var to store the count for records
            Int32 RecordCount;

            //[WEEK7]   •	Open a connection to the database
            //          •	Send a parameter to the data layer specifying the filter
            //          •	Execute the stored procedure
            //          •	Give us access to the data table
            //
            //[31-01-2019] It appears that using the following 3 lines of code in Search Something provides a shared source of information
            //so enabling the SuperHeroList to populate the Object of parameters with commonly required data requested by the 
            //stored procedure using a shared parameter passed to the stored procedure. 
            //Various attempts to make it with one of the 3 elements missing resulted in failure
            //Use the shared connection (shared with the fucntion SearchSomething()
            dBConnection = new clsDataConnection();
            //need to pass in the parameter so that the information can be
            dBConnection.AddParameter("@Search", SearchParameter);
            //execute the query
            dBConnection.Execute("sproc_tblSuperHero_tblCity_FilterBySearchCriteria");
            //get the count of records
            RecordCount = dBConnection.Count;
            //declare an integer to store the index value
            Int32 Index=0;
            //In this while loop the data table rows are traversed and the column values are retrieved
            while (Index < RecordCount)
            // [WEEK7] [WEEK8] Data Tables and Loops - using an index (of type int) to 
            // traverse Rows, in the DataTable object.
            // Columns and rows are the building blocks of a data table. 
            // If there is a requiremnt to create data tables and add data to them, then
            // we need to work with the DataColumn and DataRow objects and ceate a data table 
            // schema and add rows to it. 
            // The DataTable object represents a data table. 
            // Useful link: https://www.youtube.com/watch?v=HgzqODTRC4I
            {
                //[WEEK9] 2/3 - Create an instance of clsSuperHero to copy data to (private member) pmVariables 
                //to store the DataTabe values and then add these to the pmSuperHeroList ArrayList
                //create a new object of type clsSuperHero
                clsSuperHero newCharacter = new clsSuperHero();
                //get the superHeroID and assign it to the property of the object
                newCharacter.SuperHeroID = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["SuperHeroID"]);
                //get the Nickname and assign it to the property of the object
                newCharacter.Nickname = Convert.ToString(dBConnection.DataTable.Rows[Index]["Nickname"]);
                //get the Gender and assign it to the property of the object
                newCharacter.Gender = Convert.ToString(dBConnection.DataTable.Rows[Index]["Gender"]);
                //get the Height_m and assign it to the property of the object
                newCharacter.Height_m = Convert.ToDecimal(dBConnection.DataTable.Rows[Index]["Height_m"]);
                //get the Weight_kg and assign it to the property of the object
                newCharacter.Weight_kg = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["Weight_kg"]);
                //get the BirthDate and assign it to the property of the object
                newCharacter.BirthDate = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["BirthDate"]);
                //get the Age and assign it to the property of the object
                newCharacter.Age = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["Age"]);
                //get the CityNo and assign it to the property of the object
                newCharacter.CityNo = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["CityNo"]);
                //get the Speed and assign it to the property of the object
                newCharacter.Speed = Convert.ToBoolean(dBConnection.DataTable.Rows[Index]["Speed"]);
                //get the Strength and assign it to the property of the object
                newCharacter.Strength = Convert.ToBoolean(dBConnection.DataTable.Rows[Index]["Strength"]);
                //get the Flight and assign it to the property of the object
                newCharacter.Flight = Convert.ToBoolean(dBConnection.DataTable.Rows[Index]["Flight"]);
                //get the Teleportation and assign it to the property of the object
                newCharacter.Teleportation = Convert.ToBoolean(dBConnection.DataTable.Rows[Index]["Teleportation"]);
                //get the Invisibility and assign it to the property of the object
                newCharacter.Invisibility = Convert.ToBoolean(dBConnection.DataTable.Rows[Index]["Invisibility"]);
                //get the Telekenisis and assign it to the property of the object
                newCharacter.Telekenisis = Convert.ToBoolean(dBConnection.DataTable.Rows[Index]["Telekenisis"]);
                //get the Psychokenisis and assign it to the property of the object
                newCharacter.Psychokenisis = Convert.ToBoolean(dBConnection.DataTable.Rows[Index]["Psychokenisis"]);
                //Add the new character to the SuperHiroList (ArrayList)
                pmSuperHeroList.Add(newCharacter);
                //Increment the index value (for next row in the DataTable object)
                Index++;
            }
            //return the list object
            return pmSuperHeroList;
        }
    }
}
 