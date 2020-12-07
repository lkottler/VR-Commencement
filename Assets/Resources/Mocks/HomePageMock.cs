using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePageMock 
{
    public static bool CallRegister(string name, string pass)
    {
        if (name == "RegTestUser") // mock existing user
        {
            return false;
        }
        return true;
    }

    public static bool CallLogin(string name, string pass)
    {
        if (name == "RegTestUser" && pass == "RegTestPass") // mock valid combo
        {
            return true;
        }
        return false;
    }
}
