//Each Vehicle in the database will have one unique owner(profile member). All data will be fully validated and 
//include the following data types, string, number(integer or decimal), date and Boolean along with a full 
//test plan for data inputs.The proposed table for the extension will be called HeroVehicles and contain the 
//following attributes: A primary key identifier called VehicleID and associated foreign key HeroID 
//(to identify the unique owner), followed by some basic information for each Vehicle such as: 
//Make, Model, Colour, LitreEngine, Sunroof and RegistrationDate.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsSuperVehicles
/// </summary>
public class clsSuperVehicle
{
    //private member variable pmVehicleID
    private Int32 pmVehicleID;
    //public property function VehicleID
    public Int32 VehicleID
    {
        get
        {
            return pmVehicleID;
        }
        set
        {
            pmVehicleID = value;
        }
    }
    //private member variable pmSuperHeroID_FK
    private Int32 pmSuperHeroID_FK;
    //public property function SuperHeroID_FK
    public Int32 SuperHeroID_FK
    {
        get
        {
            return pmSuperHeroID_FK;
        }
        set
        {
            pmSuperHeroID_FK = value;
        }
    }
    //private member variable pmVehicleMake
    private string pmVehicleMake;
    //public property function VehicleMake
    public string VehicleMake
    {
        get
        {
            return pmVehicleMake;
        }
        set
        {
            pmVehicleMake = value;
        }
    }
    //private member variable pmVehicleModel
    private string pmVehicleModel;
    //public property function VehicleModel
    public string VehicleModel
    {
        get
        {
            return pmVehicleModel;
        }
        set
        {
            pmVehicleModel = value;
        }
    }
    //private member variable pmVehicleColor
    private string pmVehicleColor;
    //public property function VehicleColor
    public string VehicleColor
    {
        get
        {
            return pmVehicleColor;
        }
        set
        {
            pmVehicleColor = value;
        }
    }
    //private member variable pmVehicleLitreEngine
    private decimal pmVehicleLitreEngine;
    //public property function VehicleLitreEngine
    public decimal VehicleLitreEngine
    {
        get
        {
            return pmVehicleLitreEngine;
        }
        set
        {
            pmVehicleLitreEngine = value;
        }
    }
    //private member variable pmVehicleSunroof
    private Boolean pmVehicleSunroof;
    //public property function VehicleSunroof
    public Boolean VehicleSunroof
    {
        get
        {
            return pmVehicleSunroof;
        }
        set
        {
            pmVehicleSunroof = value;
        }
    }
    //private member variable pmVehicleRegistrationDate
    private DateTime pmVehicleRegistrationDate;
    //public property function VehicleRegistrationDate
    public DateTime VehicleRegistrationDate
    {
        get
        {
            return pmVehicleRegistrationDate;
        }
        set
        {
            pmVehicleRegistrationDate = value;
        }
    }

    /************************************************************ [27/02/2019] Code added to format the displayed date ********************************************************/
    /*[27/01/2019] didn't like the date format displayed when the display all or profile DOB is retrieved from the
     * database. For consistency in the displayed date format I have created the following code
     */

  }