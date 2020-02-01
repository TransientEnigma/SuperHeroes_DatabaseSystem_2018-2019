using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsSuperVehicleCollection
/// </summary>
public class clsSuperVehicleCollection
{
    //create a connection to the database with class level scope
    clsDataConnection dBConnection = new clsDataConnection();
    //declare a class variable to store the SuperVehicleSuperHeroID
    Int32 SuperVehicleSuperHeroID;

    /*This stored procedure will select the car attributes belonging to a Superhero with @SuperHeroID as the parameter*/
    //    CREATE PROCEDURE[dbo].[sproc_tblSuperVehicle_SelectSuperHeroVehicle]
    //    
    //    @SuperHeroID int
    //AS
    //    SELECT*
    //    FROM tblSuperVehicle
    //    WHERE tblSuperVehicle.SuperHeroID = @SuperHeroID;
    //RETURN 0

    public void VehicleSearchByParameter(Int32 SuperVehicleSuperHeroIDIn )
    {
        //assigns the search parameter to the Search Parameter class scope
        SuperVehicleSuperHeroID = SuperVehicleSuperHeroIDIn;
        //re-instate the connection
        dBConnection = new clsDataConnection();
        //Pass the parameter and value to the list object for the query
        dBConnection.AddParameter("@SuperHeroID", SuperVehicleSuperHeroID);
        //execute the select all query
        dBConnection.Execute("sproc_tblSuperVehicle_SelectSuperHeroVehicle");
    }

    //constructor is the first function that loads when an instance of the clasee is created
    //It is used to initialise variables and execute any code that needs to be executed first.
    //It is used to initialise the class.

    //The execution of the stored procedure results in all rows in the SuperVehicle table
    //being selected. These values populate a Data Table object (an in memory representation
    //of the database. The count of the rows is stored in the Count property of the
    // dBConnection object.

    //Count property to return the count
    public Int32 Count
    {
        get
        {
            //return the count of the data from the database
            return dBConnection.Count;
        }
    }


    //Once the DataTable is loaded with the values, we can access them with the following
    //function. 
    //The function below header specifies a List array of type clsSuperVehicle. SO will return a clsSuperVehicle list array 
    //The values are read only by making the funtion in to a property and useing a
    //getter. This ensures data is not written to and available to other funtions
    //
    public List<clsSuperVehicle> SuperVehicleList
    {

        get
        {//this code in this function has its own scope so we need to repeat the code to get the connection
            //repeat the connection information, to create a shared connection:
            dBConnection = new clsDataConnection();
            //Pass the parameter and value to the list object for the query
            dBConnection.AddParameter("@SuperHeroID", SuperVehicleSuperHeroID);
            //execute the select all query
            dBConnection.Execute("sproc_tblSuperVehicle_SelectSuperHeroVehicle");


            //create an instance of clsSuperVehicle as a list array to store the SuperVehicle objects
            List<clsSuperVehicle> SuperVehicleList = new List<clsSuperVehicle>();

            //Integer variable to store the index values to point to the data
            // and used to travers the rows of data in the Data Table
            Int32 Pointer = 0;

            //Pointer variable is used to point to the row in the Data Table
            //The While loop repeats the code in the loop, and increments the Pointer variable
            //until all the rows have been traversed, which is when SuperVehiclePointy is greater than dbConnection.Count
            //(the count of the rows). 
            //This is given by the condition in loop where, the Pointer
            // is incremented until the count is no longer greater than the pointer
            while (Pointer < dBConnection.Count)
            {
                //create an instance of the clsSuperVehicle object, to access the properties and store data in them.
                clsSuperVehicle aSuperVehicle = new clsSuperVehicle();

                //This is the table for which the following code relates
                // CREATE TABLE[dbo].[tblSuperVehicle] (
                //[SuperVehicleID] INT IDENTITY(1, 1) NOT NULL,
                //[SuperHeroID] INT NOT NULL,
                //[Make] VARCHAR(20)    NOT NULL,
                //[Model] VARCHAR(20)    NOT NULL,
                //[Color] VARCHAR(20)    NOT NULL,
                //[LitreEngine] DECIMAL(18, 2) NOT NULL,
                //[Sunroof] BIT DEFAULT((0)) NULL,
                //[RegistrationDate] DATETIME DEFAULT(getdate()) NULL,
                //CONSTRAINT[PK_tblSuperVehicle] PRIMARY KEY CLUSTERED([SuperVehicleID] ASC),
                //CONSTRAINT[FK_tblSuperVehicle_tblSuperHero] FOREIGN KEY([SuperHeroID]) REFERENCES[dbo].[tblSuperHero] ([SuperHeroID])
                //);

                //get the primary key for the SuperVehicle from the database and assign to the SuperVehicleID property
                // of the object
                aSuperVehicle.VehicleID = Convert.ToInt32(dBConnection.DataTable.Rows[Pointer]["SuperVehicleID"]);
                //get the foreign key for the SuperHeroID for the vehicle from the database and assign to the SuperVehicleID property of the object
                aSuperVehicle.SuperHeroID_FK = Convert.ToInt32(dBConnection.DataTable.Rows[Pointer]["SuperHeroID"]);
                //get the  SuperVehicleMake from the table and assign to the  SuperVehicleMake property of the clsSuperVehicle.cs object
                aSuperVehicle.VehicleMake = Convert.ToString(dBConnection.DataTable.Rows[Pointer]["Make"]);
                //get the SuperVehicleModel from the database and assign to the SuperVehicleModel property of the clsSuperVehicle.cs object
                aSuperVehicle.VehicleModel = Convert.ToString(dBConnection.DataTable.Rows[Pointer]["Model"]);
                //get the SuperVehicleColor from the database and assign to the SuperVehicleColor property of the clsSuperVehicle.cs object
                aSuperVehicle.VehicleColor = Convert.ToString(dBConnection.DataTable.Rows[Pointer]["Color"]);
                //get the SuperVehicleLitreEngine from the database and assign to the SuperVehicleLitreEngine property of the clsSuperVehicle.cs object
                aSuperVehicle.VehicleLitreEngine = Convert.ToDecimal(dBConnection.DataTable.Rows[Pointer]["LitreEngine"]);
                //get the SuperVehicleSunroof from the database and assign to the SuperVehicleSunroof property of the clsSuperVehicle.cs object
                aSuperVehicle.VehicleSunroof = Convert.ToBoolean(dBConnection.DataTable.Rows[Pointer]["Sunroof"]);
                //get the SuperVehicleRegistrationDate from the database and assign to the SuperVehicleRegistrationDate property of the clsSuperVehicle.cs object
                aSuperVehicle.VehicleRegistrationDate = Convert.ToDateTime(dBConnection.DataTable.Rows[Pointer]["RegistrationDate"]);
                //add the list object to the list array 
                SuperVehicleList.Add(aSuperVehicle);

                //increment the Pointer to point to the next SuperVehicle
                Pointer++;
            }
            //return the list array of Cities taken from the database
            return SuperVehicleList;
        }
    }
}