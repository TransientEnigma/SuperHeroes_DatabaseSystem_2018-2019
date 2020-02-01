using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for City
/// </summary>
public class clsCity
{
    //private member variable for primary key
    private Int32 pmCityNo;

    //public property function for the CityNo
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

    //private member string variable for the City name
    private string pmCityName;

    //public property function to hold the name of the City
    public string CityName
    {
        get
        {
            return pmCityName;

        }
        set
        {
            pmCityName = value;
        }
    }


}