using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile : System.Object
{
    public string nameM, surname;
    public string nationality;

    public int year, month, day;
    public int continent, country;
    public int playerExperience, trainerExperience;
    public int continentClub, countryClub, divisionClub;
    public int clubIndex;

    public float reputation;
    public float economyGestion;

    public List<Title> titleWinned;
    


    public Profile() 
    {
        titleWinned = new List<Title>();
    }
}
