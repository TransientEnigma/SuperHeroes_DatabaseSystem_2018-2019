using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsCityCollection
/// </summary>
public class clsCityCollection 
{

    //create a connection to the database with class level scope
    clsDataConnection dBCityConnection = new clsDataConnection();

    Int32 SearchParameterValue;

    public void CitySearchParameter(Int32 SearchParameterIn)
    {
        //[13-02-2019] Added the if else statement. Works in conjunction with city list
        //depending on the search paramerter will either search for
        //a single entry in tblCity or all entries
        //assigns the search parameter value passed in to the Search Parameter with class scope
        SearchParameterValue = SearchParameterIn;
        if (SearchParameterValue > 0)
        {

            //re-instate the connection
            dBCityConnection = new clsDataConnection();
            //Pass the parameter and value to the list object for the query
            dBCityConnection.AddParameter("@CityNo", SearchParameterValue);
            //execute the CityFind to find a city
            dBCityConnection.Execute("sproc_tblCity_CityFind");
        }
        if(SearchParameterValue == -1)
        {

            //re-instate the connection
            dBCityConnection = new clsDataConnection();
            //Pass the parameter and value to the list object for the query
            dBCityConnection.AddParameter("@SearchParameter", "");
            //execute the select all query
            dBCityConnection.Execute("sproc_tblCity_SellectAllByParameter");
        }
   
    }

    //constructor is the first function that loads when an instance of the clasee is created
    //It is used to initialise variables and execute any code that needs to be executed first.
    //It is used to initialise the class.

    public clsCityCollection()
        {

        }

    //The execution of the stored procedure results in all rows in the City table
    //being selected. These values populate a Data Table object (an in memory representation
    //of the database. The count of the rows is stored in the Count property of the
    // dbCityConnection object.

   //Count property to return the count
   public Int32 Count
    {
        get
        {
            //return the count of the data from the database
            return dBCityConnection.Count;
        }
    }


    //Once the DataTable is loaded with the values, we can access them with the following
    //function. 
    //The function below header specifies a List array of type clsCity. SO will return a clsCity list array 
    //The values are read only by making the funtion in to a property and useing a
    //getter. This ensures data is not written to and available to other funtions
    //
    public List<clsCity> CityList
    {
        
        get
        {
            //[13-02-2019] Added the if else statement, depending on the search paramerter will either search for
            //a single entry in tblCity or all entries
            if (SearchParameterValue > 0)
            {
                //re-instate the connection
                dBCityConnection = new clsDataConnection();
                //Pass the parameter and value to the list object for the query
                dBCityConnection.AddParameter("@CityNo", SearchParameterValue);
                //execute the CityFind to find a city
                dBCityConnection.Execute("sproc_tblCity_CityFind");

            }

            if (SearchParameterValue == -1)
            {
                //re-instate the connection
                dBCityConnection = new clsDataConnection();
                //Pass the parameter and value to the list object for the query
                dBCityConnection.AddParameter("@SearchParameter", "");
                //execute the select all query
                dBCityConnection.Execute("sproc_tblCity_SellectAllByParameter");
            }

            //create an instance of clsCity as a list array to store the City objects
            List<clsCity> CitiesList = new List<clsCity>();

            //Integer variable to store the index values to point to the data
            // and used to travers the rows of data in the Data Table
            Int32 CityPointer = 0;

            //CityPointer variable is used to point to the row in the Data Table
            //The While loop repeats the code in the loop, and increments the CityPointer variable
            //until all the rows have been traversed, which is when CityPointy is greater than dbConnection.Count
            //(the count of the rows). 
            //This is given by the condition in loop where, the CityPointer
            // is incremented until the count is no longer greater than the pointer
            while (CityPointer < dBCityConnection.Count)
            {
                //create an instance of the clsCity object, to access the properties
                // and store data in them.

                clsCity aCity = new clsCity();

                //get the primary key for the city from the database and assign to the CityNo property
                // of the object

                aCity.CityNo = Convert.ToInt32(dBCityConnection.DataTable.Rows[CityPointer]["CityNo"]);

                //also get the CityName from the table and assign to the CityName property of the object
                aCity.CityName = Convert.ToString(dBCityConnection.DataTable.Rows[CityPointer]["CityName"]);

                //add the list object to the list array 
                CitiesList.Add(aCity);

                //increment the CityPointer to point to the next City
                CityPointer++;
            }
            //return the list array of Cities taken from the database
            return CitiesList;
        }
    }
}