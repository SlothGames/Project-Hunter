using UnityEngine;


public class DataBase : MonoBehaviour
{
    private int language; //0 - español, 1 - inglés

    ///////////////////////////////////////////////////////////////////////
    public Language languageDictionary;

    private Sprite[] europeanFlags;
    private Sprite[] asianFlags;
    private Sprite[] africanFlags;
    private Sprite[] americanFlags;
    private Sprite[] oceanianFlags;

    //Equipos ////////////////////////////////////////////////////////////////////Old Etonians HC
    //Africanos
    private Club[] argelianClubs; // Se debe guardar-cargar ya que los jugadores y personal de los equipos variará
    private int[] argelianL1; //Almacenamos el indice del equipo en la posición y accedemos a la información a través del array de clubs // Se debe guardar-cargar
    private int[] argelianL2; // Se debe guardar-cargar
    private League argelianLeague;
    private League argelianLeague2;

    private Club[] nigerianClubs;
    private int[] nigerianL1; // Se debe guardar-cargar
    private int[] nigerianL2; // Se debe guardar-cargar
    private League nigerianLeague;
    private League nigerianLeague2;

    private Club[] southAfClubs;
    private int[] southAfL1; // Se debe guardar-cargar
    private int[] southAfL2; // Se debe guardar-cargar
    private League sAfricanLeague;
    private League sAfricanLeague2;

    //America
    private Club[] brasilianClubs;
    private int[] brasilianL1; // Se debe guardar-cargar
    private int[] brasilianL2; // Se debe guardar-cargar
    private League brasilianLeague;
    private League brasilianLeague2;

    private Club[] canadianClubs;
    private int[] canadianL1; // Se debe guardar-cargar
    private int[] canadianL2; // Se debe guardar-cargar
    private League canadianLeague;
    private League canadianLeague2;

    private Club[] americanClubs;
    private int[] americanL1; // Se debe guardar-cargar
    private int[] americanL2; // Se debe guardar-cargar
    private League americanLeague;
    private League americanLeague2;

    //Asian
    private Club[] chineseClubs;
    private int[] chineseL1; // Se debe guardar-cargar
    private int[] chineseL2; // Se debe guardar-cargar
    private League chineseLeague;
    private League chineseLeague2;

    private Club[] coreanClubs;
    private int[] coreanL1; // Se debe guardar-cargar
    private int[] coreanL2; // Se debe guardar-cargar
    private League coreanLeague;
    private League coreanLeague2;

    private Club[] japanClubs;
    private int[] japanL1; // Se debe guardar-cargar
    private int[] japanL2; // Se debe guardar-cargar
    private League japanLeague;
    private League japanLeague2;

    //Europa
    public Club[] spanishClubs;  // Se debe guardar-cargar 
    private int[] spanishL1; // Se debe guardar-cargar
    private int[] spanishL2; // Se debe guardar-cargar
    private League spanishLeague;
    private League spanishLeague2;

    private Club[] russianClubs;
    private int[] russianL1; // Se debe guardar-cargar
    private int[] russianL2; // Se debe guardar-cargar
    private League russianLeague;
    private League russianLeague2;

    private Club[] ukClubs;
    private int[] ukL1; // Se debe guardar-cargar
    private int[] ukL2; // Se debe guardar-cargar
    private League ukLeague;
    private League ukLeague2;

    //Oceania
    private Club[] australianClubs;
    private int[] australianL1; // Se debe guardar-cargar
    private int[] australianL2; // Se debe guardar-cargar
    private League australianLeague;
    private League australianLeague2;

    private Club[] nzClubs;
    private int[] nzL1; // Se debe guardar-cargar
    private int[] nzL2; // Se debe guardar-cargar
    private League nzLeague;
    private League nzLeague2;


    //Patrocinadores////////////////////////////////////////////////////////////////////
    //private Sponsor[] sponsors;

    //Perfil jugador/////////////////////////////////////////////////////////////////// Se debe guardar en cada partida
    private Profile profile;

    //Jugadores//////////////////////////////////////////////////////////////////////// Se debe guardar en cada partida
    public Player[] playerList;

    //Cartas///////////////////////////////////////////////////////////////////////////
    public Object[] cardArponer;
    public Object[] cardShield;
    public Object[] cardArcher;
    public Object[] cardMagician;
    public Object[] cardExecuter;
    public Object[] cardPaladin;


    private void Awake()
    {
        language = 0;

        languageDictionary = this.gameObject.GetComponent<Language>();

        europeanFlags = new Sprite [17];
        asianFlags = new Sprite[14];
        africanFlags = new Sprite[12];
        americanFlags = new Sprite[17];
        oceanianFlags = new Sprite[4];

        Restart();
    }


    public void Restart()
    {
        profile = new Profile();

        //Banderas
        StartFlags();

        //Equipos
        StartTeams();

        //Cartas
        StartCards();

        //Jugadores
        SetPlayersClub();
        SetHabilitys();

        //Sponsor
        //StartSponsor();
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Idioma ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void SetLanguage (int value)
    {
        language = value;
    }


    public int GetLanguage()
    {
        return language;
    }


    public string GetTranslatedWord(string keyWord)
    {
        string translatedWord = "";
        
        if (language == 0)
        {
            translatedWord = languageDictionary.spanish[keyWord];
        }
        else if (language == 1)
        {
            translatedWord = languageDictionary.english[keyWord];
        }

        return translatedWord;
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Naciones ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public Sprite GetFlag(int continent, int country) //Continent 0 Africa 1 America 2 Asia 3 Europa 4 Oceania
    {
        Sprite returnedFlag;

        if(continent == 0)
        {
            returnedFlag = africanFlags[country];
        }
        else if (continent == 1)
        {
            returnedFlag = americanFlags[country];
        }
        else if (continent == 2)
        {
            returnedFlag = asianFlags[country];
        }
        else if(continent == 3)
        {
            returnedFlag = europeanFlags[country];
        }
        else
        {
            returnedFlag = oceanianFlags[country];
        }

        return returnedFlag;
    }


    private void StartFlags()
    {
        // Banderas Europeas //////////////////////////////////////////////////////////////////////////
        europeanFlags[0] = Resources.Load<Sprite>("UI/Flags/Europe/Espana");
        europeanFlags[1] = Resources.Load<Sprite>("UI/Flags/Europe/Uk");
        europeanFlags[2] = Resources.Load<Sprite>("UI/Flags/Europe/Francia");
        europeanFlags[3] = Resources.Load<Sprite>("UI/Flags/Europe/Italia");
        europeanFlags[4] = Resources.Load<Sprite>("UI/Flags/Europe/Alemania");
        europeanFlags[5] = Resources.Load<Sprite>("UI/Flags/Europe/Croacia");
        europeanFlags[6] = Resources.Load<Sprite>("UI/Flags/Europe/Dinamarca");
        europeanFlags[7] = Resources.Load<Sprite>("UI/Flags/Europe/Finlandia");
        europeanFlags[8] = Resources.Load<Sprite>("UI/Flags/Europe/Grecia");
        europeanFlags[9] = Resources.Load<Sprite>("UI/Flags/Europe/Irlanda");
        europeanFlags[10] = Resources.Load<Sprite>("UI/Flags/Europe/Islandia");
        europeanFlags[11] = Resources.Load<Sprite>("UI/Flags/Europe/Polonia");
        europeanFlags[12] = Resources.Load<Sprite>("UI/Flags/Europe/Portugal");
        europeanFlags[13] = Resources.Load<Sprite>("UI/Flags/Europe/Rusia");
        europeanFlags[14] = Resources.Load<Sprite>("UI/Flags/Europe/Serbia");
        europeanFlags[15] = Resources.Load<Sprite>("UI/Flags/Europe/Suecia");
        europeanFlags[16] = Resources.Load<Sprite>("UI/Flags/Europe/Ucrania");

        // Banderas Africanas
        africanFlags[0] = Resources.Load<Sprite>("UI/Flags/Africa/Angola");
        africanFlags[1] = Resources.Load<Sprite>("UI/Flags/Africa/Argelia");
        africanFlags[2] = Resources.Load<Sprite>("UI/Flags/Africa/BurkinaFaso");
        africanFlags[3] = Resources.Load<Sprite>("UI/Flags/Africa/Camerun");
        africanFlags[4] = Resources.Load<Sprite>("UI/Flags/Africa/Egipto");
        africanFlags[5] = Resources.Load<Sprite>("UI/Flags/Africa/Ghana");
        africanFlags[6] = Resources.Load<Sprite>("UI/Flags/Africa/Guinea");
        africanFlags[7] = Resources.Load<Sprite>("UI/Flags/Africa/Marruecos");
        africanFlags[8] = Resources.Load<Sprite>("UI/Flags/Africa/Nigeria");
        africanFlags[9] = Resources.Load<Sprite>("UI/Flags/Africa/Senegal");
        africanFlags[10] = Resources.Load<Sprite>("UI/Flags/Africa/Sudafrica");
        africanFlags[11] = Resources.Load<Sprite>("UI/Flags/Africa/Togo");

        // Banderas Americanas
        americanFlags[0] = Resources.Load<Sprite>("UI/Flags/America/Argentina");
        americanFlags[1] = Resources.Load<Sprite>("UI/Flags/America/Brasil");
        americanFlags[2] = Resources.Load<Sprite>("UI/Flags/America/Canada");
        americanFlags[3] = Resources.Load<Sprite>("UI/Flags/America/Chile");
        americanFlags[4] = Resources.Load<Sprite>("UI/Flags/America/Colombia");
        americanFlags[5] = Resources.Load<Sprite>("UI/Flags/America/CostaRica");
        americanFlags[6] = Resources.Load<Sprite>("UI/Flags/America/Cuba");
        americanFlags[7] = Resources.Load<Sprite>("UI/Flags/America/Ecuador");
        americanFlags[8] = Resources.Load<Sprite>("UI/Flags/America/Honduras");
        americanFlags[9] = Resources.Load<Sprite>("UI/Flags/America/Jamaica");
        americanFlags[10] = Resources.Load<Sprite>("UI/Flags/America/Mexico");
        americanFlags[11] = Resources.Load<Sprite>("UI/Flags/America/Nicaragua");
        americanFlags[12] = Resources.Load<Sprite>("UI/Flags/America/Paraguay");
        americanFlags[13] = Resources.Load<Sprite>("UI/Flags/America/Peru");
        americanFlags[14] = Resources.Load<Sprite>("UI/Flags/America/Salvador");
        americanFlags[15] = Resources.Load<Sprite>("UI/Flags/America/Uruguay");
        americanFlags[16] = Resources.Load<Sprite>("UI/Flags/America/Usa");

        // Banderas Asiaticas
        asianFlags[0] = Resources.Load<Sprite>("UI/Flags/Asia/Arabia");
        asianFlags[1] = Resources.Load<Sprite>("UI/Flags/Asia/China");
        asianFlags[2] = Resources.Load<Sprite>("UI/Flags/Asia/EAU");
        asianFlags[3] = Resources.Load<Sprite>("UI/Flags/Asia/Filipinas");
        asianFlags[4] = Resources.Load<Sprite>("UI/Flags/Asia/India");
        asianFlags[5] = Resources.Load<Sprite>("UI/Flags/Asia/Iran");
        asianFlags[6] = Resources.Load<Sprite>("UI/Flags/Asia/Israel");
        asianFlags[7] = Resources.Load<Sprite>("UI/Flags/Asia/Japon");
        asianFlags[8] = Resources.Load<Sprite>("UI/Flags/Asia/Korea");
        asianFlags[9] = Resources.Load<Sprite>("UI/Flags/Asia/Malasia");
        asianFlags[10] = Resources.Load<Sprite>("UI/Flags/Asia/Pakistan");
        asianFlags[11] = Resources.Load<Sprite>("UI/Flags/Asia/Singapur");
        asianFlags[12] = Resources.Load<Sprite>("UI/Flags/Asia/Tailandia");
        asianFlags[13] = Resources.Load<Sprite>("UI/Flags/Asia/Vietnam");

        // Banderas Oceanicas
        oceanianFlags[0] = Resources.Load<Sprite>("UI/Flags/Oceania/Australia");
        oceanianFlags[1] = Resources.Load<Sprite>("UI/Flags/Oceania/NuevaZelanda");
        oceanianFlags[2] = Resources.Load<Sprite>("UI/Flags/Oceania/Samoa");
        oceanianFlags[3] = Resources.Load<Sprite>("UI/Flags/Oceania/Tonga");
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Info del entrenador ////////////////////////////////////////////////////////////////////////////////////////////////////
    public void SetBornManager(int monthVa, int dayVa, int yearVa)
    {
        profile.month = monthVa;
        profile.day = dayVa;
        profile.year = yearVa;
    }


    public Vector3 GetBornManager()
    {
        Vector3 date = new Vector3(profile.month, profile.day, profile.year);

        return date;
    }


    public void SetNationalityManager(int continentVa, int countryVa)
    {
        profile.continent = continentVa;
        profile.country = countryVa;
    }


    public Vector2 GetNationalityManager()
    {
        Vector2 nationality = new Vector2(profile.continent, profile.country);

        return nationality;
    }


    public void SetExperienceManager(int pExperience, int tExperience)
    {
        profile.playerExperience = pExperience;
        profile.trainerExperience = tExperience;

        profile.reputation = (pExperience + tExperience) / 2;
        profile.economyGestion = 5;
    }


    public Vector2 GetExperienceManager()
    {
        Vector2 experience = new Vector2(profile.playerExperience, profile.trainerExperience);

        return experience;
    }


    public void SetNameManager(string nameVa, string surnameVa)
    {
        profile.nameM = nameVa;
        profile.surname = surnameVa;
    }


    public string[] GetNameManagerName()
    {
        string[] nameMa = new string[2];

        nameMa[0] = profile.nameM;
        nameMa[1] = profile.surname; 

        return nameMa;
    }


    public void SetTrainingClub(int continentClub, int countryClub, int division, int club)
    {
        profile.continentClub = continentClub;
        profile.countryClub = countryClub;
        profile.divisionClub = division;
        profile.clubIndex = club;
    }


    public int[] GetTrainingClub()
    {
        int[] trainingClubAux = new int [3];
        trainingClubAux[0] = profile.continentClub;
        trainingClubAux[1] = profile.countryClub;
        trainingClubAux[2] = profile.clubIndex;

        return trainingClubAux;
    }


    public Profile GetProfile()
    {
        return profile;
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    ///Info de los equipos //////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    public League GetLeague(int contientValue, int countryValue, int divisionValue)
    {
        if(contientValue == 0)
        {
            if(countryValue == 0)
            {
                if(divisionValue == 0)
                {
                    return argelianLeague;
                }
                else
                {
                    return argelianLeague2;
                }
            }
            else if (countryValue == 1)
            {
                if (divisionValue == 0)
                {
                    return nigerianLeague;
                }
                else
                {
                    return nigerianLeague2;
                }
            }
            else
            {
                if (divisionValue == 0)
                {
                    return sAfricanLeague;
                }
                else
                {
                    return sAfricanLeague2;
                }
            }
        }
        else if (contientValue == 1)
        {
            if (countryValue == 0)
            {
                if (divisionValue == 0)
                {
                    return brasilianLeague;
                }
                else
                {
                    return brasilianLeague2;
                }
            }
            else if (countryValue == 1)
            {
                if (divisionValue == 0)
                {
                    return canadianLeague;
                }
                else
                {
                    return canadianLeague2;
                }
            }
            else
            {
                if (divisionValue == 0)
                {
                    return americanLeague;
                }
                else
                {
                    return americanLeague2;
                }
            }
        }
        else if (contientValue == 2)
        {
            if (countryValue == 0)
            {
                if (divisionValue == 0)
                {
                    return chineseLeague;
                }
                else
                {
                    return chineseLeague2;
                }
            }
            else if (countryValue == 1)
            {
                if (divisionValue == 0)
                {
                    return coreanLeague;
                }
                else
                {
                    return coreanLeague2;
                }
            }
            else
            {
                if (divisionValue == 0)
                {
                    return japanLeague;
                }
                else
                {
                    return japanLeague2;
                }
            }
        }
        else if (contientValue == 3)
        {
            if (countryValue == 0)
            {
                if (divisionValue == 0)
                {
                    return russianLeague;
                }
                else
                {
                    return russianLeague2;
                }
            }
            else if (countryValue == 1)
            {
                if (divisionValue == 0)
                {
                    return spanishLeague;
                }
                else
                {
                    return spanishLeague2;
                }
            }
            else
            {
                if (divisionValue == 0)
                {
                    return ukLeague;
                }
                else
                {
                    return ukLeague2;
                }
            }
        }
        else
        {
            if (countryValue == 0)
            {
                if (divisionValue == 0)
                {
                    return australianLeague;
                }
                else
                {
                    return australianLeague2;
                }
            }
            else
            {
                if (divisionValue == 0)
                {
                    return nzLeague;
                }
                else
                {
                    return nzLeague2;
                }
            }
        }
    }


    public int[] GetLeagueTeam(int continentValue, int countryValue, int divisionValue)
    {
        if (continentValue == 0)
        {
            if (countryValue == 0)
            {
                if(divisionValue == 0)
                {
                    return argelianL1;
                }
                else
                {
                    return argelianL2;
                }
            }
            else if (countryValue == 1)
            {
                if (divisionValue == 0)
                {
                    return nigerianL1;
                }
                else
                {
                    return nigerianL2;
                }
            }
            else
            {
                if (divisionValue == 0)
                {
                    return southAfL1;
                }
                else
                {
                    return southAfL2;
                }
            }
        }
        else if (continentValue == 1)
        {
            if (countryValue == 0)
            {
                if (divisionValue == 0)
                {
                    return brasilianL1;
                }
                else
                {
                    return brasilianL2;
                }
            }
            else if (countryValue == 1)
            {
                if (divisionValue == 0)
                {
                    return canadianL1;
                }
                else
                {
                    return canadianL2;
                }
            }
            else
            {
                if (divisionValue == 0)
                {
                    return americanL1;
                }
                else
                {
                    return americanL2;
                }
            }
        }
        else if (continentValue == 2)
        {
            if (countryValue == 0)
            {
                if (divisionValue == 0)
                {
                    return chineseL1;
                }
                else
                {
                    return chineseL2;
                }
            }
            else if (countryValue == 1)
            {
                if (divisionValue == 0)
                {
                    return coreanL1;
                }
                else
                {
                    return coreanL2;
                }
            }
            else
            {
                if (divisionValue == 0)
                {
                    return japanL1;
                }
                else
                {
                    return japanL2;
                }
            }
        }
        else if (continentValue == 3)
        {
            if (countryValue == 0)
            {
                if (divisionValue == 0)
                {
                    return russianL1;
                }
                else
                {
                    return russianL2;
                }
            }
            else if (countryValue == 1)
            {
                if (divisionValue == 0)
                {
                    return spanishL1;
                }
                else
                {
                    return spanishL2;
                }
            }
            else
            {
                if (divisionValue == 0)
                {
                    return ukL1;
                }
                else
                {
                    return ukL2;
                }
            }
        }
        else
        {
            if (countryValue == 0)
            {
                if (divisionValue == 0)
                {
                    return australianL1;
                }
                else
                {
                    return australianL2;
                }
            }
            else
            {
                if (divisionValue == 0)
                {
                    return nzL1;
                }
                else
                {
                    return nzL2;
                }
            }
        }
    }


    public Club GetTeam(int continentValue, int countryValue, int indexValue)
    {
        if(continentValue == 0)
        {
            if(countryValue == 0)
            {
                return argelianClubs[indexValue];
            }
            else if (countryValue == 1)
            {
                return nigerianClubs[indexValue];
            }
            else
            {
                return southAfClubs[indexValue];
            }
        }
        else if (continentValue == 1)
        {
            if (countryValue == 0)
            {
                return brasilianClubs[indexValue];
            }
            else if (countryValue == 1)
            {
                return canadianClubs[indexValue];
            }
            else
            {
                return americanClubs[indexValue];
            }
        }
        else if (continentValue == 2)
        {
            if (countryValue == 0)
            {
                return chineseClubs[indexValue];
            }
            else if (countryValue == 1)
            {
                return coreanClubs[indexValue];
            }
            else
            {
                return japanClubs[indexValue];
            }
        }
        else if (continentValue == 3)
        {
            if (countryValue == 0)
            {
                return russianClubs[indexValue];
            }
            else if (countryValue == 1)
            {
                return spanishClubs[indexValue];
            }
            else
            {
                return ukClubs[indexValue];
            }
        }
        else
        {
            if (countryValue == 0)
            {
                return australianClubs[indexValue];
            }
            else
            {
                return nzClubs[indexValue];
            }
        }
    }


    private void StartTeams()
    {
        //Africa
        argelianClubs = new Club[20];

        StartArgeliaL1();
        argelianLeague = new League();
        argelianLeague.StartLeague(0, 0, 0);

        StartArgeliaL2();
        argelianLeague2 = new League();
        argelianLeague2.StartLeague(0, 0, 1);


        nigerianClubs = new Club[20];

        StartNigeriaL1();
        nigerianLeague = new League();
        nigerianLeague.StartLeague(0, 1, 0);

        StartNigeriaL2();
        nigerianLeague2 = new League();
        nigerianLeague2.StartLeague(0, 1, 1);


        southAfClubs = new Club[20];

        StartSAfricaL1();
        sAfricanLeague = new League();
        sAfricanLeague.StartLeague(0, 2, 0);

        StartSAfricaL2();
        sAfricanLeague2 = new League();
        sAfricanLeague2.StartLeague(0, 2, 1);


        //America
        brasilianClubs = new Club[20];

        StartBrasilL1();
        brasilianLeague = new League();
        brasilianLeague.StartLeague(1, 0, 0);

        StartBrasilL2();
        brasilianLeague2 = new League();
        brasilianLeague2.StartLeague(1, 0, 1);


        canadianClubs = new Club[20];

        StartCanadaL1();
        canadianLeague = new League();
        canadianLeague.StartLeague(1, 1, 0);

        StartCanadaL2();
        canadianLeague2 = new League();
        canadianLeague2.StartLeague(1, 1, 1);


        americanClubs = new Club[20];
        
        StartUSAL1();
        americanLeague = new League();
        americanLeague.StartLeague(1, 2, 0);

        StartUSAL2();
        americanLeague2 = new League();
        americanLeague2.StartLeague(1, 2, 1);


        //Asia
        chineseClubs = new Club[20];

        StartChinaL1();
        chineseLeague = new League();
        chineseLeague.StartLeague(2, 0, 0);

        StartChinaL2();
        chineseLeague2 = new League();
        chineseLeague2.StartLeague(2, 0, 1);


        coreanClubs = new Club[20];

        StartKoreaL1();
        coreanLeague = new League();
        coreanLeague.StartLeague(2, 1, 0);

        StartKoreaL2();
        coreanLeague2 = new League();
        coreanLeague2.StartLeague(2, 1, 1);


        japanClubs = new Club[20];

        StartJapanL1();
        japanLeague = new League();
        japanLeague.StartLeague(2, 2, 0);

        StartJapanL2();
        japanLeague2 = new League();
        japanLeague2.StartLeague(2, 2, 1);


        //Europa
        spanishClubs = new Club[20];

        StartSpainL1();
        spanishLeague = new League();
        spanishLeague.StartLeague(3, 0, 0);

        StartSpainL2();
        spanishLeague2 = new League();
        spanishLeague2.StartLeague(3, 0, 1);


        russianClubs = new Club[20];

        StartRusiaL1();
        russianLeague = new League();
        russianLeague.StartLeague(3, 1, 0);

        StartRusiaL2();
        russianLeague2 = new League();
        russianLeague2.StartLeague(3, 1, 1);


        ukClubs = new Club[20];

        StartUkL1();
        ukLeague = new League();
        ukLeague.StartLeague(3, 2, 0);

        StartUkL2();
        ukLeague2 = new League();
        ukLeague2.StartLeague(3, 2, 1);


        //Oceania
        australianClubs = new Club[20];

        StartAustraliaL1();
        australianLeague = new League();
        australianLeague.StartLeague(4, 0, 0);

        StartAustraliaL2();
        australianLeague2 = new League();
        australianLeague2.StartLeague(4, 0, 1);


        nzClubs = new Club[20];

        StartNZL1();
        nzLeague = new League();
        nzLeague.StartLeague(4, 1, 0);

        StartNZL2();
        nzLeague2 = new League();
        nzLeague2.StartLeague(4, 1, 1);
    }

    //Africa
    private void StartArgeliaL1()
    {
        argelianL1 = new int[10];

        for (int i = 0; i < 10; i++)
        {
            argelianL1[i] = i;

            Club aux = new Club();
            argelianClubs[i] = aux.StartClub(0, 0, 0, i);

            argelianClubs[i].cupQua = true;
            argelianClubs[i].preCupQua = false;
            /*
            if(i < 2)
            {
                argelianClubs[i].worldQua = false;
                argelianClubs[i].continentQua = true;
            }
            else
            {
                argelianClubs[i].worldQua = false;
                argelianClubs[i].continentQua = false;
            }
            */
        }
    }


    public Club GetArgelianL1Club(int value)
    {
        return argelianClubs[argelianL1[value]];
    }


    private void StartArgeliaL2()
    {
        argelianL2 = new int[10];

        for (int i = 10; i < 20; i++)
        {
            argelianL2[i - 10] = i;

            Club aux = new Club();
            argelianClubs[i] = aux.StartClub(0, 0, 1, i);

            argelianClubs[i].cupQua = true;
            argelianClubs[i].preCupQua = true;
            /*
            argelianClubs[i].worldQua = false;
            argelianClubs[i].continentQua = false;
            */
        }
    }


    public Club GetArgelianL2Club(int value)
    {
        return argelianClubs[argelianL2[value]];
    }


    private void StartNigeriaL1()
    {
        nigerianL1 = new int[10];

        for (int i = 0; i < 10; i++)
        {
            Club aux = new Club();
            nigerianClubs[i] = aux.StartClub(0, 1, 0, i);

            nigerianClubs[i].cupQua = true;
            nigerianClubs[i].preCupQua = false;
            /*
            nigerianClubs[i].worldQua = false;
            nigerianClubs[i].continentQua = false;
            */
        }
    }


    public Club GetNigerianL1Club(int value)
    {
        return nigerianClubs[nigerianL1[value]];
    }


    private void StartNigeriaL2()
    {
        nigerianL2 = new int[10];

        for (int i = 10; i < 20; i++)
        {
            argelianL2[i - 10] = i;

            Club aux = new Club();
            nigerianClubs[i] = aux.StartClub(0, 1, 1, i);

            nigerianClubs[i].cupQua = true;
            nigerianClubs[i].preCupQua = true;
            /*
            nigerianClubs[i].worldQua = false;
            nigerianClubs[i].continentQua = false;
            */
        }
    }


    public Club GetNigerianL2Club(int value)
    {
        return nigerianClubs[nigerianL2[value]];
    }


    private void StartSAfricaL1()
    {
        southAfL1 = new int[10];

        for (int i = 0; i < 10; i++)
        {
            Club aux = new Club();
            southAfClubs[i] = aux.StartClub(0, 2, 0, i);

            southAfClubs[i].cupQua = true;
            southAfClubs[i].preCupQua = false;
            /*
            southAfClubs[i].worldQua = false;
            southAfClubs[i].continentQua = false;
            */
        }
    }


    public Club GetSAfricaL1Club(int value)
    {
        return southAfClubs[southAfL1[value]];
    }


    private void StartSAfricaL2()
    {
        southAfL2 = new int[10];

        for (int i = 10; i < 20; i++)
        {
            southAfL2[i - 10] = i;

            Club aux = new Club();
            southAfClubs[i] = aux.StartClub(0, 2, 1, i);

            southAfClubs[i].cupQua = true;
            southAfClubs[i].preCupQua = true;
            /*
            southAfClubs[i].worldQua = false;
            southAfClubs[i].continentQua = false;
            */
        }
    }


    public Club GetSAfricaL2Club(int value)
    {
        return southAfClubs[southAfL2[value]];
    }

    //América
    private void StartBrasilL1()
    {
        brasilianL1 = new int[10];

        for (int i = 0; i < 10; i++)
        {
            Club aux = new Club();
            brasilianClubs[i] = aux.StartClub(1, 0, 0, i);

            brasilianClubs[i].cupQua = true;
            brasilianClubs[i].preCupQua = false;
            /*
            brasilianClubs[i].worldQua = false;
            brasilianClubs[i].continentQua = false;
            */
        }
    }


    public Club GetBrasilianL1Club(int value)
    {
        return brasilianClubs[brasilianL1[value]];
    }


    private void StartBrasilL2()
    {
        brasilianL2 = new int[10];

        for (int i = 10; i < 20; i++)
        {
            brasilianL2[i - 10] = i;

            Club aux = new Club();
            brasilianClubs[i] = aux.StartClub(1, 0, 1, i);

            brasilianClubs[i].cupQua = true;
            brasilianClubs[i].preCupQua = true;
            /*
            brasilianClubs[i].worldQua = false;
            brasilianClubs[i].continentQua = false;
            */
        }
    }


    public Club GetBrasilianL2Club(int value)
    {
        return brasilianClubs[brasilianL2[value]];
    }


    private void StartCanadaL1()
    {
        canadianL1 = new int[10];

        for (int i = 0; i < 10; i++)
        {
            Club aux = new Club();
            canadianClubs[i] = aux.StartClub(1, 1, 0, i);

            canadianClubs[i].cupQua = true;
            canadianClubs[i].preCupQua = false;
            /*
            canadianClubs[i].worldQua = false;
            canadianClubs[i].continentQua = false;
            */
        }
    }


    public Club GetCanadianL1Club(int value)
    {
        return canadianClubs[canadianL1[value]];
    }


    private void StartCanadaL2()
    {
        canadianL2 = new int[10];

        for (int i = 10; i < 20; i++)
        {
            argelianL2[i - 10] = i;

            Club aux = new Club();
            canadianClubs[i] = aux.StartClub(1, 1, 1, i);

            canadianClubs[i].cupQua = true;
            canadianClubs[i].preCupQua = true;
            /*
            canadianClubs[i].worldQua = false;
            canadianClubs[i].continentQua = false;
            */
        }
    }


    public Club GetCanadianL2Club(int value)
    {
        return canadianClubs[canadianL2[value]];
    }


    private void StartUSAL1()
    {
        americanL1 = new int[10];

        for (int i = 0; i < 10; i++)
        {
            Club aux = new Club();
            americanClubs[i] = aux.StartClub(1, 2, 0, i);

            americanClubs[i].cupQua = true;
            americanClubs[i].preCupQua = false;
            /*
            americanClubs[i].worldQua = false;
            americanClubs[i].continentQua = false;
            */
        }
    }


    public Club GetAmericanL1Club(int value)
    {
        return americanClubs[americanL1[value]];
    }


    private void StartUSAL2()
    {
        americanL2 = new int[10];

        for (int i = 10; i < 20; i++)
        {
            argelianL2[i - 10] = i;

            Club aux = new Club();
            americanClubs[i] = aux.StartClub(1, 2, 1, i);

            americanClubs[i].cupQua = true;
            americanClubs[i].preCupQua = true;
            /*
            americanClubs[i].worldQua = false;
            americanClubs[i].continentQua = false;
            */
        }
    }


    public Club GetAmericanL2Club(int value)
    {
        return americanClubs[americanL2[value]];
    }

    //Asia
    private void StartChinaL1()
    {
        chineseL1 = new int[10];

        for (int i = 0; i < 10; i++)
        {
            Club aux = new Club();
            chineseClubs[i] = aux.StartClub(2, 0, 0, i);

            chineseClubs[i].cupQua = true;
            chineseClubs[i].preCupQua = false;
            /*
            chineseClubs[i].worldQua = false;
            chineseClubs[i].continentQua = false;
            */
        }
    }


    public Club GetChineseL1Club(int value)
    {
        return chineseClubs[chineseL1[value]];
    }


    private void StartChinaL2()
    {
        chineseL2 = new int[10];

        for (int i = 10; i < 20; i++)
        {
            argelianL2[i - 10] = i;

            Club aux = new Club();
            chineseClubs[i] = aux.StartClub(2, 0, 1, i);

            chineseClubs[i].cupQua = true;
            chineseClubs[i].preCupQua = true;
            /*
            chineseClubs[i].worldQua = false;
            chineseClubs[i].continentQua = false;
            */
        }
    }


    public Club GetChineseL2Club(int value)
    {
        return chineseClubs[chineseL2[value]];
    }


    private void StartKoreaL1()
    {
        coreanL1 = new int[10];

        for (int i = 0; i < 10; i++)
        {
            Club aux = new Club();
            coreanClubs[i] = aux.StartClub(2, 1, 0, i);

            coreanClubs[i].cupQua = true;
            coreanClubs[i].preCupQua = false;
            /*
            coreanClubs[i].worldQua = false;
            coreanClubs[i].continentQua = false;
            */
        }
    }


    public Club GetKoreanL1Club(int value)
    {
        return coreanClubs[coreanL1[value]];
    }


    private void StartKoreaL2()
    {
        coreanL2 = new int[10];

        for (int i = 10; i < 20; i++)
        {
            coreanL2[i - 10] = i;

            Club aux = new Club();
            coreanClubs[i] = aux.StartClub(2, 1, 1, i);

            coreanClubs[i].cupQua = true;
            coreanClubs[i].preCupQua = true;
            /*
            coreanClubs[i].worldQua = false;
            coreanClubs[i].continentQua = false;
            */
        }
    }


    public Club GetKoreanL2Club(int value)
    {
        return coreanClubs[coreanL2[value]];
    }


    private void StartJapanL1()
    {
        japanL1 = new int[10];

        for (int i = 0; i < 10; i++)
        {
            Club aux = new Club();
            japanClubs[i] = aux.StartClub(2, 2, 0, i);

            japanClubs[i].cupQua = true;
            japanClubs[i].preCupQua = false;
            /*
            japanClubs[i].worldQua = false;
            japanClubs[i].continentQua = false;
            */
        }
    }


    public Club GetJapanL1Club(int value)
    {
        return japanClubs[japanL1[value]];
    }


    private void StartJapanL2()
    {
        japanL2 = new int[10];

        for (int i = 10; i < 20; i++)
        {
            japanL2[i - 10] = i;

            Club aux = new Club();
            japanClubs[i] = aux.StartClub(2, 2, 1, i);

            japanClubs[i].cupQua = true;
            japanClubs[i].preCupQua = true;
            /*
            japanClubs[i].worldQua = false;
            japanClubs[i].continentQua = false;
            */
        }
    }


    public Club GetJapanL2Club(int value)
    {
        return japanClubs[japanL2[value]];
    }


    //Europa
    private void StartSpainL1()
    {
        spanishL1 = new int[10];

        for (int i = 0; i < 10; i++)
        {
            spanishL1[i] = i;

            Club aux = new Club();
            spanishClubs[i] = aux.StartClub(3, 0, 0, i);
            
            spanishClubs[i].cupQua = true;
            spanishClubs[i].preCupQua = false;
            /*
            spanishClubs[i].worldQua = false;
            spanishClubs[i].continentQua = false;
            */
        }
    }


    public Club GetSpanishL1Club(int value)
    {
        return spanishClubs[spanishL1[value]];
    }


    private void StartSpainL2()
    {
        spanishL2 = new int [10];

        for (int i = 10; i < 20; i++)
        {
            spanishL2[i - 10] = i;

            Club aux = new Club();
            spanishClubs[i] = aux.StartClub(3, 0, 1, i);

            spanishClubs[i].cupQua = true;
            spanishClubs[i].preCupQua = true;
            /*
            spanishClubs[i].worldQua = false;
            spanishClubs[i].continentQua = false;
            */
        }
    }


    public Club GetSpanishL2Club(int value)
    {
        return spanishClubs[spanishL2[value]];
    }


    private void StartRusiaL1()
    {
        russianL1 = new int[10];

        for (int i = 0; i < 10; i++)
        {
            Club aux = new Club();
            russianClubs[i] = aux.StartClub(3, 1, 0, i);

            russianClubs[i].cupQua = true;
            russianClubs[i].preCupQua = false;
            /*
            russianClubs[i].worldQua = false;
            russianClubs[i].continentQua = false;
            */
        }
    }


    public Club GetRussianL1Club(int value)
    {
        return russianClubs[russianL1[value]];
    }


    private void StartRusiaL2()
    {
        russianL2 = new int[10];

        for (int i = 10; i < 20; i++)
        {
            russianL2[i - 10] = i;

            Club aux = new Club();
            russianClubs[i] = aux.StartClub(3, 1, 1, i);

            russianClubs[i].cupQua = true;
            russianClubs[i].preCupQua = true;
            /*
            russianClubs[i].worldQua = false;
            russianClubs[i].continentQua = false;
            */
        }
    }


    public Club GetRussianL2Club(int value)
    {
        return russianClubs[russianL2[value]];
    }


    private void StartUkL1()
    {
        ukL1 = new int[10];

        for (int i = 0; i < 10; i++)
        {
            Club aux = new Club();
            ukClubs[i] = aux.StartClub(3, 2, 0, i);

            ukClubs[i].continent = 3;
            ukClubs[i].country = 0;
            ukClubs[i].division = 1;

            ukClubs[i].cupQua = true;
            ukClubs[i].preCupQua = false;
            /*
            ukClubs[i].worldQua = false;
            ukClubs[i].continentQua = false;
            */
        }
    }


    public Club GetUkL1Club(int value)
    {
        return ukClubs[ukL1[value]];
    }


    private void StartUkL2()
    {
        ukL2 = new int[10];

        for (int i = 10; i < 20; i++)
        {
            ukL2[i - 10] = i;

            Club aux = new Club();
            ukClubs[i] = aux.StartClub(3, 2, 1, i);

            ukClubs[i].cupQua = true;
            ukClubs[i].preCupQua = true;
            /*
            ukClubs[i].worldQua = false;
            ukClubs[i].continentQua = false;
            */
        }
    }


    public Club GetUkL2Club(int value)
    {
        return ukClubs[ukL2[value]];
    }

    //Oceanía
    private void StartAustraliaL1()
    {
        australianL1 = new int[10];

        for (int i = 0; i < 10; i++)
        {
            Club aux = new Club();
            australianClubs[i] = aux.StartClub(4, 0, 0, i);

            australianClubs[i].cupQua = true;
            australianClubs[i].preCupQua = false;
            /*
            australianClubs[i].worldQua = false;
            australianClubs[i].continentQua = false;
            */
        }
    }


    public Club GetAustralianL1Club(int value)
    {
        return australianClubs[australianL1[value]];
    }


    private void StartAustraliaL2()
    {
        australianL2 = new int[10];

        for (int i = 10; i < 20; i++)
        {
            australianL2[i - 10] = i;

            Club aux = new Club();
            australianClubs[i] = aux.StartClub(4, 0, 1, i);

            australianClubs[i].cupQua = true;
            australianClubs[i].preCupQua = true;
            /*
            australianClubs[i].worldQua = false;
            australianClubs[i].continentQua = false;
            */
        }
    }


    public Club GetAustralianL2Club(int value)
    {
        return australianClubs[australianL2[value]];
    }


    private void StartNZL1()
    {
        nzL1 = new int[10];

        for (int i = 0; i < 10; i++)
        {
            Club aux = new Club();
            nzClubs[i] = aux.StartClub(4, 1, 0, i);

            nzClubs[i].cupQua = true;
            nzClubs[i].preCupQua = false;
            /*
            nzClubs[i].worldQua = false;
            nzClubs[i].continentQua = false;
            */
        }
    }


    public Club GetNzL1Club(int value)
    {
        return nzClubs[nzL1[value]];
    }


    private void StartNZL2()
    {
        nzL2 = new int[10];

        for (int i = 10; i < 20; i++)
        {
            nzL2[i - 10] = i;

            Club aux = new Club();
            nzClubs[i] = aux.StartClub(4, 1, 1, i);

            nzClubs[i].cupQua = true;
            nzClubs[i].preCupQua = true;
            /*
            nzClubs[i].worldQua = false;
            nzClubs[i].continentQua = false;
            */
        }
    }


    public Club GetNzL2Club(int value)
    {
        return nzClubs[nzL2[value]];
    }


    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Info del patrocinador
    private void StartSponsor()
    {

    }


    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Info de las cartas
    private void StartCards()
    {
        cardArponer = Resources.LoadAll("Cards/Arponer", typeof(Card));
        cardShield = Resources.LoadAll("Cards/Shield", typeof(Card));
        cardArcher = Resources.LoadAll("Cards/Archer", typeof(Card));
        cardMagician = Resources.LoadAll("Cards/Magician", typeof(Card));
        cardExecuter = Resources.LoadAll("Cards/Executer", typeof(Card));
        cardPaladin = Resources.LoadAll("Cards/Paladin", typeof(Card));
    }


    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Info del jugador
    private void SetPlayersClub()
    {
        playerList = new Player[14];

        for (int i = 0; i < 14; i++)
        {
            Player player = new Player();
            playerList[i] = player.StartPlayer(i);

            switch (i)
            {
                case int n when (n < 7):
                    spanishClubs[0].players.Add(i);

                    break;

                case int n when (n < 14):
                    spanishClubs[1].players.Add(i);

                    break;
            }
        }
    }


    /// <summary>
    /// Roba el número de cartas indicado en la variable cardNumber
    /// </summary>
    private void SetHabilitys()
    {
        for (int i = 0; i < playerList.Length; i++)
        {
            switch (i)
            {
                case 0:
                    playerList[i].habilitys[0] = (Card)cardPaladin[0];
                    playerList[i].habilitys[1] = (Card)cardPaladin[1];
                    playerList[i].habilitys[2] = (Card)cardPaladin[2];
                    playerList[i].habilitys[3] = (Card)cardPaladin[3];
                    playerList[i].habilitys[4] = (Card)cardPaladin[4];

                    break;
                case 1:
                    playerList[i].habilitys[0] = (Card)cardMagician[24];
                    playerList[i].habilitys[1] = (Card)cardMagician[1];
                    playerList[i].habilitys[2] = (Card)cardMagician[2];
                    playerList[i].habilitys[3] = (Card)cardMagician[3];
                    playerList[i].habilitys[4] = (Card)cardMagician[4];

                    break;
                case 2:
                    playerList[i].habilitys[0] = (Card)cardArcher[13];
                    playerList[i].habilitys[1] = (Card)cardArcher[1];
                    playerList[i].habilitys[2] = (Card)cardArcher[2];
                    playerList[i].habilitys[3] = (Card)cardArcher[3];
                    playerList[i].habilitys[4] = (Card)cardArcher[4];

                    break;
                case 3:
                    playerList[i].habilitys[0] = (Card)cardArponer[0];
                    playerList[i].habilitys[1] = (Card)cardArponer[12];
                    playerList[i].habilitys[2] = (Card)cardArponer[2];
                    playerList[i].habilitys[3] = (Card)cardArponer[3];
                    playerList[i].habilitys[4] = (Card)cardArponer[4];

                    break;
                case 7:
                    playerList[i].habilitys[0] = (Card)cardShield[5];
                    playerList[i].habilitys[1] = (Card)cardShield[1];
                    playerList[i].habilitys[2] = (Card)cardShield[2];
                    playerList[i].habilitys[3] = (Card)cardShield[3];
                    playerList[i].habilitys[4] = (Card)cardShield[4];

                    break;
                case 8:
                    playerList[i].habilitys[0] = (Card)cardExecuter[0];
                    playerList[i].habilitys[1] = (Card)cardExecuter[1];
                    playerList[i].habilitys[2] = (Card)cardExecuter[2];
                    playerList[i].habilitys[3] = (Card)cardExecuter[3];
                    playerList[i].habilitys[4] = (Card)cardExecuter[4];

                    break;
                case 9:
                    playerList[i].habilitys[0] = (Card)cardPaladin[7];
                    playerList[i].habilitys[1] = (Card)cardPaladin[1];
                    playerList[i].habilitys[2] = (Card)cardPaladin[2];
                    playerList[i].habilitys[3] = (Card)cardPaladin[3];
                    playerList[i].habilitys[4] = (Card)cardPaladin[4];

                    break;
                case 10:
                    playerList[i].habilitys[0] = (Card)cardArponer[13];
                    playerList[i].habilitys[1] = (Card)cardArponer[12];
                    playerList[i].habilitys[2] = (Card)cardArponer[2];
                    playerList[i].habilitys[3] = (Card)cardArponer[3];
                    playerList[i].habilitys[4] = (Card)cardArponer[4];

                    break;
            }
        }
    }
}
