using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Club : object
{
    public string clubName;

    public int continent;
    public int country;
    public int division;
    public int economyStatus; //0 Rico 1 Potente 2 Estable 3 Aceptable 4 Deficiente
    public int reputation; //0 desconocido 1 local 2 regional 3 nacional 4 continental 5 mundial

    //Liga
    public int expectedLeaguePosition;
    public int actualLeaguePoints;
    public int leagueWins, leagueLoses, leagueDraws, leagueMatchs;
    public int actualLeagueScore;
   
    /*
    //Continental
    public int //expectedContinentPosition;
    public int //actualContinentPoints;
    public int//continentWins, //continentLoses, //continentDraws, //continentMatchs;
    public int //actualContinentScore;

    //Mundial
    public int //expectedWorldPosition;
    public int actualWorldPoints;
    public int worldWins, worldLoses, worldDraws, worldMatchs;
    public int actualWorldScore;
    */

    //Economía
    public int money;
    public int supporters;

    //Clasificaciones
    //public bool //worldQua;
    //public bool //continentQua;
    public bool cupQua;
    public bool preCupQua; //la juegan los equipos de 2ª que no han ascendido (8 equipos)
    public bool leagueChampion;
    //public bool//continentNextSeason;
    public bool ascent;
    public bool descent;

    //Escudo
    public Sprite logo;

    //Camiseta
    public Color homeColor;
    public Color visitorColor;

    //Rivales
    public List<string> localEnemies;
    public List<string> greatEnemies;

    //Equipo, se almacena el indice de los jugadores, estrategas y entrenadores
    public List<int> players; //Lista con el índice de los jugadores
    public List<Player> startTeamPlayers; //Jugadores titulares
    public List<Player> secondTeamPlayers; //Jugadores titulares
    public int[] playerPosition; //0 --> ln 0 centro, 1 --> ln 0 arriba, 2 --> ln 0 abajo, 3 --> ln 1 centro ...
    public List<Strategist> strategists; //Estategia del equipo
    public int numberOfStrategist; //Número de estrategias almacenadas
    public int trainer; //Índice del entrenador

    //Calidad de las instalaciones 1 -- Min 5 -- Max
    public int stadium;
    public int forge;
    public int hospital;
    public int training;


    public Club() { }


    public Club StartClub(int valueContinent, int valueCountry, int valueDivision, int clubValue)
    {
        leagueChampion = false;
       //continentNextSeason = false;
        ascent = false;
        descent = false;

        continent = valueContinent;
        country = valueCountry;
        division = valueDivision;

        leagueWins = 0;
        leagueLoses = 0;
        leagueDraws = 0;
        actualLeagueScore = 0;
        actualLeaguePoints = 0;
        leagueMatchs = 0;

       //continentWins = 0;
        //continentLoses = 0;
        //continentDraws = 0;
        //actualContinentPoints = 0;
        //actualContinentScore = 0;
        //continentMatchs = 0;

        /*
        worldWins = 0;
        worldLoses = 0;
        worldDraws = 0;
        actualWorldPoints = 0;
        actualWorldScore = 0;

        //expectedWorldPosition = 0;
        //expectedContinentPosition = 0;
        */
        expectedLeaguePosition = clubValue + 1;

        players = new List<int>();
        startTeamPlayers = new List<Player>();
        secondTeamPlayers = new List<Player>();
        playerPosition = new int[4];

        if (valueContinent == 0)
        {
            if (valueCountry == 0)
            {
                if (valueDivision == 0)
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Hamma Argel HC";

                            //foundationYear = 1990;
                            reputation = 4;

                            //expectedContinentPosition = 3;

                            money = 100570005;

                            //continentQua = true;

                            homeColor = Color.white;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            logo = Resources.Load<Sprite>("UI/TeamLogos/Africa/Argelia/1ª/Hamma");

                            break;
                        case 1:
                            clubName = "HC Oran Black Lion";

                            //foundationYear = 1995;
                            reputation = 4;

                            //expectedContinentPosition = 5;

                            money = 150070205;

                            //continentQua = true;

                            homeColor = Color.black;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            logo = Resources.Load<Sprite>("UI/TeamLogos/Africa/Argelia/1ª/OranBL");

                            break;
                        case 2:
                            clubName = "Épée Verte Chlef HC";

                            //foundationYear = 1994;
                            reputation = 3;

                            money = 65161405;

                            homeColor = Color.green;
                            visitorColor = Color.gray;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            logo = Resources.Load<Sprite>("UI/TeamLogos/Africa/Argelia/1ª/Epee");

                            break;
                        case 3:
                            clubName = "Setif Fouara HC";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 62061405;

                            visitorColor = new Color(163.0f / 255.0f, 93.0f / 255.0f, 31.0f / 255.0f, 255.0f / 255.0f); //Marron
                            homeColor = Color.blue;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            logo = Resources.Load<Sprite>("UI/TeamLogos/Africa/Argelia/1ª/Fouara");

                            break;
                        case 4:
                            clubName = "Constantina Grand Pont HC";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 62061405;

                            homeColor = Color.yellow;
                            visitorColor = Color.gray;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            logo = Resources.Load<Sprite>("UI/TeamLogos/Africa/Argelia/1ª/Pont");

                            break;
                        case 5:
                            clubName = "Tébessa Mur HC";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 56431405;

                            homeColor = new Color(119.0f / 255.0f, 0.0f / 255.0f, 31.0f / 255.0f, 255.0f / 255.0f); //Morado
                            visitorColor = new Color(163.0f / 255.0f, 93.0f / 255.0f, 31.0f / 255.0f, 255.0f / 255.0f); //Marron

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            logo = Resources.Load<Sprite>("UI/TeamLogos/Africa/Argelia/1ª/Mur");

                            break;
                        case 6:
                            clubName = "Chèvre Blanche Djelfa HC";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 48431405;

                            homeColor = Color.white;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            logo = Resources.Load<Sprite>("UI/TeamLogos/Africa/Argelia/1ª/Cabra");

                            break;
                        case 7:
                            clubName = "Batna Red Moon HC";

                            //foundationYear = 1991;
                            reputation = 2;

                            money = 43561405;

                            homeColor = Color.red;
                            visitorColor = new Color(128.0f / 255.0f, 255.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Verde amarillento

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            logo = Resources.Load<Sprite>("UI/TeamLogos/Africa/Argelia/1ª/RedMoon");

                            break;
                        case 8:
                            clubName = "HC Annaba Requin";

                            //foundationYear = 1993;
                            reputation = 2;

                            money = 36431405;

                            homeColor = Color.blue;
                            visitorColor = Color.gray;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            logo = Resources.Load<Sprite>("UI/TeamLogos/Africa/Argelia/1ª/Requin");

                            break;
                        case 9:
                            clubName = "Blida Neige Rouge";

                            //foundationYear = 1994;
                            reputation = 2;

                            money = 38431405;

                            homeColor = Color.red;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            logo = Resources.Load<Sprite>("UI/TeamLogos/Africa/Argelia/1ª/RedSnow");

                            break;
                    }
                }
                else
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Tremecén Bleu HC";

                            //foundationYear = 1999;
                            economyStatus = 3;
                            reputation = 2;

                            money = 30031405;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 1:
                            clubName = "El Eulma Hunters";

                            //foundationYear = 1995;
                            economyStatus = 3;
                            reputation = 2;

                            money = 28051505;

                            homeColor = Color.green;
                            visitorColor = Color.red;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 2:
                            clubName = "HC Biskra Oasis";

                            //foundationYear = 1989;
                            economyStatus = 3;
                            reputation = 3;

                            money = 25512505;

                            homeColor = Color.black;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 3:
                            clubName = "Djelfa HC";

                            //foundationYear = 1996;
                            economyStatus = 3;
                            reputation = 2;

                            money = 21512130;

                            homeColor = Color.black;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 4:
                            clubName = "HC Batna Flèches";

                            //foundationYear = 1992;
                            economyStatus = 3;
                            reputation = 2;

                            money = 19212130;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.gray;
                            visitorColor = new Color(255.0f / 255.0f, 100.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Naranja

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 5:
                            clubName = "Annaba Roche HC";

                            //foundationYear = 1995;
                            economyStatus = 3;
                            reputation = 1;

                            money = 16216638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.grey;
                            visitorColor = Color.black;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 6:
                            clubName = "Skikda HC";

                            //foundationYear = 1989;
                            economyStatus = 4;
                            reputation = 1;

                            money = 14244638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.white;
                            visitorColor = Color.yellow;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 7:
                            clubName = "HC Constantina";

                            //foundationYear = 1991;
                            economyStatus = 4;
                            reputation = 1;

                            money = 12554638;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 8:
                            clubName = "HC Argel Or";

                            //foundationYear = 1993;
                            economyStatus = 4;
                            reputation = 1;

                            money = 13714638;

                            homeColor = new Color(255.0f / 255.0f, 179.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Dorado
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 9:
                            clubName = "Orán HC";

                            //foundationYear = 2005;
                            economyStatus = 4;
                            reputation = 0;

                            money = 10428538;

                            homeColor = Color.blue;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                    }
                }
            }
            else if (valueCountry == 1)
            {
                if (valueDivision == 0)
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Granada Goshawk HC";

                            //foundationYear = 1990;
                            reputation = 5;

                            //expectedContinentPosition = 1;
                            //expectedWorldPosition = 1;

                            money = 198573205;

                            //continentQua = true;
                            //worldQua = true;

                            homeColor = Color.red;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 1:
                            clubName = "HC Madrid Bears";

                            //foundationYear = 1989;
                            reputation = 5;

                            //expectedContinentPosition = 3;

                            money = 186270205;

                            //continentQua = true;

                            homeColor = Color.white;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 2:
                            clubName = "Euskal Aizkora HC";

                            //foundationYear = 1992;
                            reputation = 4;

                            money = 165161405;

                            homeColor = Color.red;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 3:
                            clubName = "Barcelona Salamanders HC";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 124685251;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 4:
                            clubName = "Valencia Pirates";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 101574258;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 5:
                            clubName = "Zaragoza Lions HC";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 92645127;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 6:
                            clubName = "Vigo Kraken Hunters";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 85645127;

                            homeColor = new Color(88.0f / 255.0f, 230.0f / 255.0f, 230.0f / 255.0f, 255.0f / 255.0f); //Celeste
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 7:
                            clubName = "Tenerife Explorers HC";

                            //foundationYear = 1991;
                            reputation = 3;

                            money = 88645127;

                            homeColor = Color.blue;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 8:
                            clubName = "HC Osasuna Bulls";

                            //foundationYear = 1993;
                            reputation = 3;

                            money = 54155127;

                            homeColor = Color.red;
                            visitorColor = Color.gray;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 9:
                            clubName = "Cartagena Submarines";

                            //foundationYear = 1994;
                            reputation = 3;

                            money = 44155444;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                    }
                }
                else
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Tremecén Bleu HC";

                            //foundationYear = 1999;
                            reputation = 2;

                            money = 30031405;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 1:
                            clubName = "El Eulma Hunters";

                            //foundationYear = 1995;
                            reputation = 2;

                            money = 28051505;

                            homeColor = Color.green;
                            visitorColor = Color.red;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 2:
                            clubName = "HC Biskra Oasis";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 25512505;

                            homeColor = Color.black;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 3:
                            clubName = "Djelfa HC";

                            //foundationYear = 1996;
                            reputation = 2;

                            money = 21512130;

                            homeColor = Color.black;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 4:
                            clubName = "HC Batna Flèches";

                            //foundationYear = 1992;
                            reputation = 2;

                            money = 19212130;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.gray;
                            visitorColor = new Color(255.0f / 255.0f, 100.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Naranja

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 5:
                            clubName = "Annaba Roche HC";

                            //foundationYear = 1995;
                            reputation = 1;

                            money = 16216638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.grey;
                            visitorColor = Color.black;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 6:
                            clubName = "Skikda HC";

                            //foundationYear = 1989;
                            reputation = 1;

                            money = 14244638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.white;
                            visitorColor = Color.yellow;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 7:
                            clubName = "HC Constantina";

                            //foundationYear = 1991;
                            reputation = 1;

                            money = 12554638;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 8:
                            clubName = "HC Argel Or";

                            //foundationYear = 1993;
                            reputation = 1;

                            money = 13714638;

                            homeColor = new Color(255.0f / 255.0f, 179.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Dorado
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 9:
                            clubName = "Orán HC";

                            //foundationYear = 2005;
                            reputation = 0;

                            money = 10428538;

                            homeColor = Color.blue;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                    }
                }
            }
            else if (valueCountry == 2)
            {
                if (valueDivision == 0)
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Granada Goshawk HC";

                            //foundationYear = 1990;
                            reputation = 5;

                            //expectedContinentPosition = 1;
                            //expectedWorldPosition = 1;

                            money = 198573205;

                            //continentQua = true;
                            //worldQua = true;

                            homeColor = Color.red;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 1:
                            clubName = "HC Madrid Bears";

                            //foundationYear = 1989;
                            reputation = 5;

                            //expectedContinentPosition = 3;

                            money = 186270205;

                            //continentQua = true;

                            homeColor = Color.white;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 2:
                            clubName = "Euskal Aizkora HC";

                            //foundationYear = 1992;
                            reputation = 4;

                            money = 165161405;

                            homeColor = Color.red;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 3:
                            clubName = "Barcelona Salamanders HC";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 124685251;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 4:
                            clubName = "Valencia Pirates";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 101574258;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 5:
                            clubName = "Zaragoza Lions HC";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 92645127;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 6:
                            clubName = "Vigo Kraken Hunters";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 85645127;

                            homeColor = new Color(88.0f / 255.0f, 230.0f / 255.0f, 230.0f / 255.0f, 255.0f / 255.0f); //Celeste
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 7:
                            clubName = "Tenerife Explorers HC";

                            //foundationYear = 1991;
                            reputation = 3;

                            money = 88645127;

                            homeColor = Color.blue;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 8:
                            clubName = "HC Osasuna Bulls";

                            //foundationYear = 1993;
                            reputation = 3;

                            money = 54155127;

                            homeColor = Color.red;
                            visitorColor = Color.gray;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 9:
                            clubName = "Cartagena Submarines";

                            //foundationYear = 1994;
                            reputation = 3;

                            money = 44155444;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                    }
                }
                else
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Tremecén Bleu HC";

                            //foundationYear = 1999;
                            reputation = 2;

                            money = 30031405;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 1:
                            clubName = "El Eulma Hunters";

                            //foundationYear = 1995;
                            reputation = 2;

                            money = 28051505;

                            homeColor = Color.green;
                            visitorColor = Color.red;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 2:
                            clubName = "HC Biskra Oasis";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 25512505;

                            homeColor = Color.black;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 3:
                            clubName = "Djelfa HC";

                            //foundationYear = 1996;
                            reputation = 2;

                            money = 21512130;

                            homeColor = Color.black;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 4:
                            clubName = "HC Batna Flèches";

                            //foundationYear = 1992;
                            reputation = 2;

                            money = 19212130;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.gray;
                            visitorColor = new Color(255.0f / 255.0f, 100.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Naranja

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 5:
                            clubName = "Annaba Roche HC";

                            //foundationYear = 1995;
                            reputation = 1;

                            money = 16216638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.grey;
                            visitorColor = Color.black;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 6:
                            clubName = "Skikda HC";

                            //foundationYear = 1989;
                            reputation = 1;

                            money = 14244638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.white;
                            visitorColor = Color.yellow;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 7:
                            clubName = "HC Constantina";

                            //foundationYear = 1991;
                            reputation = 1;

                            money = 12554638;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 8:
                            clubName = "HC Argel Or";

                            //foundationYear = 1993;
                            reputation = 1;

                            money = 13714638;

                            homeColor = new Color(255.0f / 255.0f, 179.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Dorado
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 9:
                            clubName = "Orán HC";

                            //foundationYear = 2005;
                            reputation = 0;

                            money = 10428538;

                            homeColor = Color.blue;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                    }
                }
            }
        }      /////////////ÁFRICA/////////////////////////////////////
        else if (valueContinent == 1)
        {
            if (valueCountry == 0)
            {
                if (valueDivision == 0)
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Granada Goshawk HC";

                            //foundationYear = 1990;
                            reputation = 5;

                            //expectedContinentPosition = 1;
                            //expectedWorldPosition = 1;

                            money = 198573205;

                            //continentQua = true;
                            //worldQua = true;

                            homeColor = Color.red;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 1:
                            clubName = "HC Madrid Bears";

                            //foundationYear = 1989;
                            reputation = 5;

                            //expectedContinentPosition = 3;

                            money = 186270205;

                            //continentQua = true;

                            homeColor = Color.white;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 2:
                            clubName = "Euskal Aizkora HC";

                            //foundationYear = 1992;
                            reputation = 4;

                            money = 165161405;

                            homeColor = Color.red;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 3:
                            clubName = "Barcelona Salamanders HC";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 124685251;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 4:
                            clubName = "Valencia Pirates";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 101574258;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 5:
                            clubName = "Zaragoza Lions HC";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 92645127;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 6:
                            clubName = "Vigo Kraken Hunters";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 85645127;

                            homeColor = new Color(88.0f / 255.0f, 230.0f / 255.0f, 230.0f / 255.0f, 255.0f / 255.0f); //Celeste
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 7:
                            clubName = "Tenerife Explorers HC";

                            //foundationYear = 1991;
                            reputation = 3;

                            money = 88645127;

                            homeColor = Color.blue;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 8:
                            clubName = "HC Osasuna Bulls";

                            //foundationYear = 1993;
                            reputation = 3;

                            money = 54155127;

                            homeColor = Color.red;
                            visitorColor = Color.gray;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 9:
                            clubName = "Cartagena Submarines";

                            //foundationYear = 1994;
                            reputation = 3;

                            money = 44155444;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                    }
                }
                else
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Tremecén Bleu HC";

                            //foundationYear = 1999;
                            reputation = 2;

                            money = 30031405;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 1:
                            clubName = "El Eulma Hunters";

                            //foundationYear = 1995;
                            reputation = 2;

                            money = 28051505;

                            homeColor = Color.green;
                            visitorColor = Color.red;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 2:
                            clubName = "HC Biskra Oasis";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 25512505;

                            homeColor = Color.black;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 3:
                            clubName = "Djelfa HC";

                            //foundationYear = 1996;
                            reputation = 2;

                            money = 21512130;

                            homeColor = Color.black;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 4:
                            clubName = "HC Batna Flèches";

                            //foundationYear = 1992;
                            reputation = 2;

                            money = 19212130;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.gray;
                            visitorColor = new Color(255.0f / 255.0f, 100.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Naranja

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 5:
                            clubName = "Annaba Roche HC";

                            //foundationYear = 1995;
                            reputation = 1;

                            money = 16216638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.grey;
                            visitorColor = Color.black;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");
                           
                            break;
                        case 6:
                            clubName = "Skikda HC";

                            //foundationYear = 1989;
                            reputation = 1;

                            money = 14244638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.white;
                            visitorColor = Color.yellow;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 7:
                            clubName = "HC Constantina";

                            //foundationYear = 1991;
                            reputation = 1;

                            money = 12554638;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 8:
                            clubName = "HC Argel Or";

                            //foundationYear = 1993;
                            reputation = 1;

                            money = 13714638;

                            homeColor = new Color(255.0f / 255.0f, 179.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Dorado
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 9:
                            clubName = "Orán HC";

                            //foundationYear = 2005;
                            reputation = 0;

                            money = 10428538;

                            homeColor = Color.blue;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                    }
                }
            }
            else if (valueCountry == 1)
            {
                if (valueDivision == 0)
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Granada Goshawk HC";

                            //foundationYear = 1990;
                            reputation = 5;

                            //expectedContinentPosition = 1;
                            //expectedWorldPosition = 1;

                            money = 198573205;

                            //continentQua = true;
                            //worldQua = true;

                            homeColor = Color.red;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 1:
                            clubName = "HC Madrid Bears";

                            //foundationYear = 1989;
                            reputation = 5;

                            //expectedContinentPosition = 3;

                            money = 186270205;

                            //continentQua = true;

                            homeColor = Color.white;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 2:
                            clubName = "Euskal Aizkora HC";

                            //foundationYear = 1992;
                            reputation = 4;

                            money = 165161405;

                            homeColor = Color.red;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 3:
                            clubName = "Barcelona Salamanders HC";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 124685251;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 4:
                            clubName = "Valencia Pirates";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 101574258;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 5:
                            clubName = "Zaragoza Lions HC";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 92645127;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 6:
                            clubName = "Vigo Kraken Hunters";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 85645127;

                            homeColor = new Color(88.0f / 255.0f, 230.0f / 255.0f, 230.0f / 255.0f, 255.0f / 255.0f); //Celeste
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 7:
                            clubName = "Tenerife Explorers HC";

                            //foundationYear = 1991;
                            reputation = 3;

                            money = 88645127;

                            homeColor = Color.blue;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 8:
                            clubName = "HC Osasuna Bulls";

                            //foundationYear = 1993;
                            reputation = 3;

                            money = 54155127;

                            homeColor = Color.red;
                            visitorColor = Color.gray;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 9:
                            clubName = "Cartagena Submarines";

                            //foundationYear = 1994;
                            reputation = 3;

                            money = 44155444;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                    }
                }
                else
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Tremecén Bleu HC";

                            //foundationYear = 1999;
                            reputation = 2;

                            money = 30031405;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 1:
                            clubName = "El Eulma Hunters";

                            //foundationYear = 1995;
                            reputation = 2;

                            money = 28051505;

                            homeColor = Color.green;
                            visitorColor = Color.red;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 2:
                            clubName = "HC Biskra Oasis";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 25512505;

                            homeColor = Color.black;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 3:
                            clubName = "Djelfa HC";

                            //foundationYear = 1996;
                            reputation = 2;

                            money = 21512130;

                            homeColor = Color.black;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 4:
                            clubName = "HC Batna Flèches";

                            //foundationYear = 1992;
                            reputation = 2;

                            money = 19212130;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.gray;
                            visitorColor = new Color(255.0f / 255.0f, 100.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Naranja

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 5:
                            clubName = "Annaba Roche HC";

                            //foundationYear = 1995;
                            reputation = 1;

                            money = 16216638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.grey;
                            visitorColor = Color.black;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 6:
                            clubName = "Skikda HC";

                            //foundationYear = 1989;
                            reputation = 1;

                            money = 14244638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.white;
                            visitorColor = Color.yellow;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 7:
                            clubName = "HC Constantina";

                            //foundationYear = 1991;
                            reputation = 1;

                            money = 12554638;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 8:
                            clubName = "HC Argel Or";

                            //foundationYear = 1993;
                            reputation = 1;

                            money = 13714638;

                            homeColor = new Color(255.0f / 255.0f, 179.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Dorado
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 9:
                            clubName = "Orán HC";

                            //foundationYear = 2005;
                            reputation = 0;

                            money = 10428538;

                            homeColor = Color.blue;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                    }
                }
            }
            else if (valueCountry == 2)
            {
                if (valueDivision == 0)
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Granada Goshawk HC";

                            //foundationYear = 1990;
                            reputation = 5;

                            //expectedContinentPosition = 1;
                            //expectedWorldPosition = 1;

                            money = 198573205;

                            //continentQua = true;
                            //worldQua = true;

                            homeColor = Color.red;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 1:
                            clubName = "HC Madrid Bears";

                            //foundationYear = 1989;
                            reputation = 5;

                            //expectedContinentPosition = 3;

                            money = 186270205;

                            //continentQua = true;

                            homeColor = Color.white;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 2:
                            clubName = "Euskal Aizkora HC";

                            //foundationYear = 1992;
                            reputation = 4;

                            money = 165161405;

                            homeColor = Color.red;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 3:
                            clubName = "Barcelona Salamanders HC";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 124685251;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 4:
                            clubName = "Valencia Pirates";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 101574258;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 5:
                            clubName = "Zaragoza Lions HC";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 92645127;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 6:
                            clubName = "Vigo Kraken Hunters";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 85645127;

                            homeColor = new Color(88.0f / 255.0f, 230.0f / 255.0f, 230.0f / 255.0f, 255.0f / 255.0f); //Celeste
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 7:
                            clubName = "Tenerife Explorers HC";

                            //foundationYear = 1991;
                            reputation = 3;

                            money = 88645127;

                            homeColor = Color.blue;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 8:
                            clubName = "HC Osasuna Bulls";

                            //foundationYear = 1993;
                            reputation = 3;

                            money = 54155127;

                            homeColor = Color.red;
                            visitorColor = Color.gray;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 9:
                            clubName = "Cartagena Submarines";

                            //foundationYear = 1994;
                            reputation = 3;

                            money = 44155444;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                    }
                }
                else
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Tremecén Bleu HC";

                            //foundationYear = 1999;
                            reputation = 2;

                            money = 30031405;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 1:
                            clubName = "El Eulma Hunters";

                            //foundationYear = 1995;
                            reputation = 2;

                            money = 28051505;

                            homeColor = Color.green;
                            visitorColor = Color.red;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 2:
                            clubName = "HC Biskra Oasis";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 25512505;

                            homeColor = Color.black;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 3:
                            clubName = "Djelfa HC";

                            //foundationYear = 1996;
                            reputation = 2;

                            money = 21512130;

                            homeColor = Color.black;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 4:
                            clubName = "HC Batna Flèches";

                            //foundationYear = 1992;
                            reputation = 2;

                            money = 19212130;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.gray;
                            visitorColor = new Color(255.0f / 255.0f, 100.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Naranja

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 5:
                            clubName = "Annaba Roche HC";

                            //foundationYear = 1995;
                            reputation = 1;

                            money = 16216638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.grey;
                            visitorColor = Color.black;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 6:
                            clubName = "Skikda HC";

                            //foundationYear = 1989;
                            reputation = 1;

                            money = 14244638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.white;
                            visitorColor = Color.yellow;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 7:
                            clubName = "HC Constantina";

                            //foundationYear = 1991;
                            reputation = 1;

                            money = 12554638;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 8:
                            clubName = "HC Argel Or";

                            //foundationYear = 1993;
                            reputation = 1;

                            money = 13714638;

                            homeColor = new Color(255.0f / 255.0f, 179.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Dorado
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 9:
                            clubName = "Orán HC";

                            //foundationYear = 2005;
                            reputation = 0;

                            money = 10428538;

                            homeColor = Color.blue;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                    }
                }
            }
        } /////////////AMÉRICA////////////////////////////////////
        else if (valueContinent == 2)
        {
            if (valueCountry == 0)
            {
                if (valueDivision == 0)
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Granada Goshawk HC";

                            //foundationYear = 1990;
                            reputation = 5;

                            //expectedContinentPosition = 1;
                            //expectedWorldPosition = 1;

                            money = 198573205;

                            //continentQua = true;
                            //worldQua = true;

                            homeColor = Color.red;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 1:
                            clubName = "HC Madrid Bears";

                            //foundationYear = 1989;
                            reputation = 5;

                            //expectedContinentPosition = 3;

                            money = 186270205;

                            //continentQua = true;

                            homeColor = Color.white;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 2:
                            clubName = "Euskal Aizkora HC";

                            //foundationYear = 1992;
                            reputation = 4;

                            money = 165161405;

                            homeColor = Color.red;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 3:
                            clubName = "Barcelona Salamanders HC";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 124685251;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 4:
                            clubName = "Valencia Pirates";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 101574258;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 5:
                            clubName = "Zaragoza Lions HC";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 92645127;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 6:
                            clubName = "Vigo Kraken Hunters";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 85645127;

                            homeColor = new Color(88.0f / 255.0f, 230.0f / 255.0f, 230.0f / 255.0f, 255.0f / 255.0f); //Celeste
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 7:
                            clubName = "Tenerife Explorers HC";

                            //foundationYear = 1991;
                            reputation = 3;

                            money = 88645127;

                            homeColor = Color.blue;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 8:
                            clubName = "HC Osasuna Bulls";

                            //foundationYear = 1993;
                            reputation = 3;

                            money = 54155127;

                            homeColor = Color.red;
                            visitorColor = Color.gray;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 9:
                            clubName = "Cartagena Submarines";

                            //foundationYear = 1994;
                            reputation = 3;

                            money = 44155444;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                    }
                }
                else
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Tremecén Bleu HC";

                            //foundationYear = 1999;
                            reputation = 2;

                            money = 30031405;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 1:
                            clubName = "El Eulma Hunters";

                            //foundationYear = 1995;
                            reputation = 2;

                            money = 28051505;

                            homeColor = Color.green;
                            visitorColor = Color.red;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 2:
                            clubName = "HC Biskra Oasis";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 25512505;

                            homeColor = Color.black;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 3:
                            clubName = "Djelfa HC";

                            //foundationYear = 1996;
                            reputation = 2;

                            money = 21512130;

                            homeColor = Color.black;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 4:
                            clubName = "HC Batna Flèches";

                            //foundationYear = 1992;
                            reputation = 2;

                            money = 19212130;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.gray;
                            visitorColor = new Color(255.0f / 255.0f, 100.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Naranja

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 5:
                            clubName = "Annaba Roche HC";

                            //foundationYear = 1995;
                            reputation = 1;

                            money = 16216638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.grey;
                            visitorColor = Color.black;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 6:
                            clubName = "Skikda HC";

                            //foundationYear = 1989;
                            reputation = 1;

                            money = 14244638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.white;
                            visitorColor = Color.yellow;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 7:
                            clubName = "HC Constantina";

                            //foundationYear = 1991;
                            reputation = 1;

                            money = 12554638;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 8:
                            clubName = "HC Argel Or";

                            //foundationYear = 1993;
                            reputation = 1;

                            money = 13714638;

                            homeColor = new Color(255.0f / 255.0f, 179.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Dorado
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 9:
                            clubName = "Orán HC";

                            //foundationYear = 2005;
                            reputation = 0;

                            money = 10428538;

                            homeColor = Color.blue;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                    }
                }
            }
            else if (valueCountry == 1)
            {
                if (valueDivision == 0)
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Granada Goshawk HC";

                            //foundationYear = 1990;
                            reputation = 5;

                            //expectedContinentPosition = 1;
                            //expectedWorldPosition = 1;

                            money = 198573205;

                            //continentQua = true;
                            //worldQua = true;

                            homeColor = Color.red;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 1:
                            clubName = "HC Madrid Bears";

                            //foundationYear = 1989;
                            reputation = 5;

                            //expectedContinentPosition = 3;

                            money = 186270205;

                            //continentQua = true;

                            homeColor = Color.white;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 2:
                            clubName = "Euskal Aizkora HC";

                            //foundationYear = 1992;
                            reputation = 4;

                            money = 165161405;

                            homeColor = Color.red;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 3:
                            clubName = "Barcelona Salamanders HC";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 124685251;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 4:
                            clubName = "Valencia Pirates";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 101574258;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 5:
                            clubName = "Zaragoza Lions HC";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 92645127;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 6:
                            clubName = "Vigo Kraken Hunters";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 85645127;

                            homeColor = new Color(88.0f / 255.0f, 230.0f / 255.0f, 230.0f / 255.0f, 255.0f / 255.0f); //Celeste
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 7:
                            clubName = "Tenerife Explorers HC";

                            //foundationYear = 1991;
                            reputation = 3;

                            money = 88645127;

                            homeColor = Color.blue;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 8:
                            clubName = "HC Osasuna Bulls";

                            //foundationYear = 1993;
                            reputation = 3;

                            money = 54155127;

                            homeColor = Color.red;
                            visitorColor = Color.gray;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 9:
                            clubName = "Cartagena Submarines";

                            //foundationYear = 1994;
                            reputation = 3;

                            money = 44155444;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                    }
                }
                else
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Tremecén Bleu HC";

                            //foundationYear = 1999;
                            reputation = 2;

                            money = 30031405;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 1:
                            clubName = "El Eulma Hunters";

                            //foundationYear = 1995;
                            reputation = 2;

                            money = 28051505;

                            homeColor = Color.green;
                            visitorColor = Color.red;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 2:
                            clubName = "HC Biskra Oasis";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 25512505;

                            homeColor = Color.black;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 3:
                            clubName = "Djelfa HC";

                            //foundationYear = 1996;
                            reputation = 2;

                            money = 21512130;

                            homeColor = Color.black;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 4:
                            clubName = "HC Batna Flèches";

                            //foundationYear = 1992;
                            reputation = 2;

                            money = 19212130;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.gray;
                            visitorColor = new Color(255.0f / 255.0f, 100.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Naranja

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 5:
                            clubName = "Annaba Roche HC";

                            //foundationYear = 1995;
                            reputation = 1;

                            money = 16216638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.grey;
                            visitorColor = Color.black;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 6:
                            clubName = "Skikda HC";

                            //foundationYear = 1989;
                            reputation = 1;

                            money = 14244638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.white;
                            visitorColor = Color.yellow;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 7:
                            clubName = "HC Constantina";

                            //foundationYear = 1991;
                            reputation = 1;

                            money = 12554638;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 8:
                            clubName = "HC Argel Or";

                            //foundationYear = 1993;
                            reputation = 1;

                            money = 13714638;

                            homeColor = new Color(255.0f / 255.0f, 179.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Dorado
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 9:
                            clubName = "Orán HC";

                            //foundationYear = 2005;
                            reputation = 0;

                            money = 10428538;

                            homeColor = Color.blue;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                    }
                }
            }
            else if (valueCountry == 2)
            {
                if (valueDivision == 0)
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Granada Goshawk HC";

                            //foundationYear = 1990;
                            reputation = 5;

                            //expectedContinentPosition = 1;
                            //expectedWorldPosition = 1;

                            money = 198573205;

                            //continentQua = true;
                            //worldQua = true;

                            homeColor = Color.red;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 1:
                            clubName = "HC Madrid Bears";

                            //foundationYear = 1989;
                            reputation = 5;

                            //expectedContinentPosition = 3;

                            money = 186270205;

                            //continentQua = true;

                            homeColor = Color.white;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 2:
                            clubName = "Euskal Aizkora HC";

                            //foundationYear = 1992;
                            reputation = 4;

                            money = 165161405;

                            homeColor = Color.red;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 3:
                            clubName = "Barcelona Salamanders HC";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 124685251;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 4:
                            clubName = "Valencia Pirates";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 101574258;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 5:
                            clubName = "Zaragoza Lions HC";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 92645127;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 6:
                            clubName = "Vigo Kraken Hunters";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 85645127;

                            homeColor = new Color(88.0f / 255.0f, 230.0f / 255.0f, 230.0f / 255.0f, 255.0f / 255.0f); //Celeste
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 7:
                            clubName = "Tenerife Explorers HC";

                            //foundationYear = 1991;
                            reputation = 3;

                            money = 88645127;

                            homeColor = Color.blue;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 8:
                            clubName = "HC Osasuna Bulls";

                            //foundationYear = 1993;
                            reputation = 3;

                            money = 54155127;

                            homeColor = Color.red;
                            visitorColor = Color.gray;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 9:
                            clubName = "Cartagena Submarines";

                            //foundationYear = 1994;
                            reputation = 3;

                            money = 44155444;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                    }
                }
                else
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Tremecén Bleu HC";

                            //foundationYear = 1999;
                            reputation = 2;

                            money = 30031405;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 1:
                            clubName = "El Eulma Hunters";

                            //foundationYear = 1995;
                            reputation = 2;

                            money = 28051505;

                            homeColor = Color.green;
                            visitorColor = Color.red;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 2:
                            clubName = "HC Biskra Oasis";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 25512505;

                            homeColor = Color.black;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 3:
                            clubName = "Djelfa HC";

                            //foundationYear = 1996;
                            reputation = 2;

                            money = 21512130;

                            homeColor = Color.black;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 4:
                            clubName = "HC Batna Flèches";

                            //foundationYear = 1992;
                            reputation = 2;

                            money = 19212130;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.gray;
                            visitorColor = new Color(255.0f / 255.0f, 100.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Naranja

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 5:
                            clubName = "Annaba Roche HC";

                            //foundationYear = 1995;
                            reputation = 1;

                            money = 16216638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.grey;
                            visitorColor = Color.black;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 6:
                            clubName = "Skikda HC";

                            //foundationYear = 1989;
                            reputation = 1;

                            money = 14244638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.white;
                            visitorColor = Color.yellow;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 7:
                            clubName = "HC Constantina";

                            //foundationYear = 1991;
                            reputation = 1;

                            money = 12554638;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 8:
                            clubName = "HC Argel Or";

                            //foundationYear = 1993;
                            reputation = 1;

                            money = 13714638;

                            homeColor = new Color(255.0f / 255.0f, 179.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Dorado
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 9:
                            clubName = "Orán HC";

                            //foundationYear = 2005;
                            reputation = 0;

                            money = 10428538;

                            homeColor = Color.blue;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                    }
                }
            }
        } ////////////ASIA////////////////////////////////////////
        else if (valueContinent == 3)      
        {
            if (valueCountry == 0) 
            {
                if (valueDivision == 0)
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Granada Goshawk HC";

                            reputation = 5;

                            //expectedContinentPosition = 1;
                            //expectedWorldPosition = 1;

                            money = 200000000;

                            //continentQua = true;
                            //worldQua = true;

                            homeColor = Color.red;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            logo = Resources.Load<Sprite>("UI/TeamLogos/Europa/Spain/1ª/Granada");

                            
                            
                            break;
                        case 1:
                            clubName = "HC Madrid Bears";

                            reputation = 5;

                            //expectedContinentPosition = 3;

                            money = 186000000;

                            //continentQua = true;

                            homeColor = Color.white;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            logo = Resources.Load<Sprite>("UI/TeamLogos/Europa/Spain/1ª/Madrid");

                            break;
                        case 2:
                            clubName = "Euskal Aizkora HC";

                            //foundationYear = 1992;
                            reputation = 4;

                            money = 165000000;

                            homeColor = Color.red;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 3:
                            clubName = "Barcelona Salamanders HC";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 124000000;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 4:
                            clubName = "Valencia Bats";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 101000000;

                            homeColor = Color.black;
                            visitorColor = new Color(255.0f / 255.0f, 127.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f);

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 5:
                            clubName = "Zaragoza Lions HC";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 92000000;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 6:
                            clubName = "Vigo Kraken";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 85000000;

                            homeColor = new Color(88.0f / 255.0f, 230.0f / 255.0f, 230.0f / 255.0f, 255.0f / 255.0f); //Celeste
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 7:
                            clubName = "Mallorca Pirate HC";

                            //foundationYear = 1991;
                            reputation = 3;

                            money = 88000000;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 8:
                            clubName = "HC Pamplona Bulls";

                            //foundationYear = 1993;
                            reputation = 3;

                            money = 54000000;

                            homeColor = Color.red;
                            visitorColor = Color.gray;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 9:
                            clubName = "Exploradores Sevilla";

                            //foundationYear = 1994;
                            reputation = 3;

                            money = 44000000;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                    }
                }
                else
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Gijón Warriors HC";

                            //foundationYear = 1998;
                            reputation = 2;

                            money = 40000000;

                            homeColor = Color.yellow;
                            visitorColor = Color.blue;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/2ª");

                            break;
                        case 1:
                            clubName = "Valladolid Foxes HC";

                            //foundationYear = 1996;
                            reputation = 2;

                            money = 38000000;

                            homeColor = new Color(143.0f / 255.0f, 88.0f / 255.0f, 232.0f / 255.0f, 255.0f / 255.0f); //Violeta
                            visitorColor = Color.white;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/2ª");

                            break;
                        case 2:
                            clubName = "HC Canaries";

                            //foundationYear = 1989;
                            reputation = 2;

                            money = 36512505;

                            homeColor = Color.grey;
                            visitorColor = Color.yellow;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/2ª");

                            break;
                        case 3:
                           clubName = "Seaman Santander HC";

                           //foundationYear = 1996;
                           reputation = 2;

                           money = 32000000;

                           homeColor = Color.green;
                           visitorColor = Color.white;

                           //localEnemies.Add("");
                           //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/2ª");

                            break;
                        case 4:
                           clubName = "HC Málaga Deep Sea";

                           //foundationYear = 1992;
                           reputation = 2;

                           money = 29000000;

                           homeColor = Color.blue;
                           visitorColor = Color.white;

                           //localEnemies.Add("");
                           //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/2ª");

                            break;
                        case 5:
                           clubName = "Vitoria Northern Hunters";

                           //foundationYear = 1995;
                           reputation = 2;

                           money = 26000000;

                           homeColor = Color.green;
                           visitorColor = Color.blue;

                           //localEnemies.Add("");
                           //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/2ª");

                            break;
                        case 6:
                           clubName = "Aviator Murcia HC";

                           //foundationYear = 1989;
                           reputation = 1;

                           money = 24000000;

                           homeColor = Color.red;
                           visitorColor = Color.black;

                           //localEnemies.Add("");
                           //greatEnemies.Add("");

                           //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/2ª");

                            break;
                        case 7:
                           clubName = "Logroño Reds HC";

                           //foundationYear = 1991;
                           reputation = 1;

                           money = 22000000;

                           homeColor = Color.red;
                           visitorColor = Color.yellow;

                           //localEnemies.Add("");
                           //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/2ª");

                            break;
                        case 8:
                           clubName = "Ciudad Real Lynx";

                           //foundationYear = 1993;
                           reputation = 1;

                           money = 18000000;

                           homeColor = Color.blue;
                           visitorColor = Color.green;

                           //localEnemies.Add("");
                           //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/2ª");

                            break;
                        case 9:
                           clubName = "Toledo Kings HC";

                           //foundationYear = 2001;
                           reputation = 1;

                           money = 15000000;

                           homeColor = Color.green;
                           visitorColor = Color.red;

                           //localEnemies.Add("");
                           //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/2ª");

                            break;
                    }
                }
            }      /////////////ESPAÑA/////////////////////////////////
            else if (valueCountry == 1) 
            {
                if (valueDivision == 0)
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Sunderland Black Lions";

                            //foundationYear = 1990;
                            reputation = 5;

                            //expectedContinentPosition = 2;
                            //expectedWorldPosition = 4;

                            money = 190000000;

                            //continentQua = true;
                            //worldQua = true;

                            homeColor = Color.red;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 1:
                            clubName = "Leicester Golden Fox";

                            //foundationYear = 1989;
                            reputation = 5;

                            //expectedContinentPosition = 4;

                            money = 180000000;

                            //continentQua = true;

                            homeColor = Color.white;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 2:
                            clubName = "Liverpool Fenix HC";

                            //foundationYear = 1992;
                            reputation = 4;

                            money = 165000000;

                            homeColor = Color.red;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 3:
                            clubName = "Manchester Devils HC";

                            //foundationYear = 1992;
                            reputation = 4;

                            money = 164000000;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 4:
                            clubName = "HC London Gunners";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 150000000;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 5:
                            clubName = "Newcastle Magpie HC";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 100000000;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 6:
                            clubName = "Brighton Seagulls";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 85000000;

                            homeColor = new Color(88.0f / 255.0f, 230.0f / 255.0f, 230.0f / 255.0f, 255.0f / 255.0f); //Celeste
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 7:
                            clubName = "Sheffield Swords";

                            //foundationYear = 1991;
                            reputation = 3;

                            money = 78000000;

                            homeColor = Color.blue;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 8:
                            clubName = "HC Peacocks Leeds";

                            //foundationYear = 1993;
                            reputation = 3;

                            money = 55000000;

                            homeColor = Color.red;
                            visitorColor = Color.gray;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 9:
                            clubName = "Southampton Saints";

                            //foundationYear = 1994;
                            reputation = 3;

                            money = 44000000;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                    }
                }
                else
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Bristol Robins HC";

                            //foundationYear = 1999;
                            reputation = 2;

                            money = 40000000;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 1:
                            clubName = "Sheffield Owls";

                            //foundationYear = 1995;
                            reputation = 2;

                            money = 34000000;

                            homeColor = Color.green;
                            visitorColor = Color.red;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 2:
                            clubName = "Reading Royals";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 25000000;

                            homeColor = Color.black;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 3:
                            clubName = "Watford Hornets Club";

                            //foundationYear = 1996;
                            reputation = 2;

                            money = 22000000;

                            homeColor = Color.black;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 4:
                            clubName = "HC Blackburn Roses";

                            //foundationYear = 1992;
                            reputation = 2;

                            money = 19000000;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.gray;
                            visitorColor = new Color(255.0f / 255.0f, 100.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Naranja

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 5:
                            clubName = "Hull Tigers";

                            //foundationYear = 1995;
                            reputation = 1;

                            money = 16000000;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.grey;
                            visitorColor = Color.black;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 6:
                            clubName = "Oxford City HC";

                            //foundationYear = 1989;
                            reputation = 1;

                            money = 14000000;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.white;
                            visitorColor = Color.yellow;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 7:
                            clubName = "Cambridge City HC";

                            //foundationYear = 1991;
                            reputation = 1;

                            money = 14000000;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 8:
                            clubName = "Portsmouth Blue Army";

                            //foundationYear = 1993;
                            reputation = 1;

                            money = 13000000;

                            homeColor = new Color(255.0f / 255.0f, 179.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Dorado
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 9:
                            clubName = "Exeter South Guardian";

                            //foundationYear = 2005;
                            reputation = 0;

                            money = 10000000;

                            homeColor = Color.blue;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                    }
                }
            } /////////////INGLATERRA/////////////////////////////
            else if (valueCountry == 2) 
            {
                if (valueDivision == 0)
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Granada Goshawk HC";

                            //foundationYear = 1990;
                            reputation = 5;

                            //expectedContinentPosition = 1;
                            //expectedWorldPosition = 1;

                            money = 198573205;

                            //continentQua = true;
                            //worldQua = true;

                            homeColor = Color.red;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 1:
                            clubName = "HC Madrid Bears";

                            //foundationYear = 1989;
                            reputation = 5;

                            //expectedContinentPosition = 3;

                            money = 186270205;

                            //continentQua = true;

                            homeColor = Color.white;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 2:
                            clubName = "Euskal Aizkora HC";

                            //foundationYear = 1992;
                            reputation = 4;

                            money = 165161405;

                            homeColor = Color.red;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 3:
                            clubName = "Barcelona Salamanders HC";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 124685251;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 4:
                            clubName = "Valencia Pirates";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 101574258;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 5:
                            clubName = "Zaragoza Lions HC";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 92645127;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 6:
                            clubName = "Vigo Kraken Hunters";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 85645127;

                            homeColor = new Color(88.0f / 255.0f, 230.0f / 255.0f, 230.0f / 255.0f, 255.0f / 255.0f); //Celeste
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 7:
                            clubName = "Tenerife Explorers HC";

                            //foundationYear = 1991;
                            reputation = 3;

                            money = 88645127;

                            homeColor = Color.blue;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 8:
                            clubName = "HC Osasuna Bulls";

                            //foundationYear = 1993;
                            reputation = 3;

                            money = 54155127;

                            homeColor = Color.red;
                            visitorColor = Color.gray;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 9:
                            clubName = "Cartagena Submarines";

                            //foundationYear = 1994;
                            reputation = 3;

                            money = 44155444;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                    }
                }
                else
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Tremecén Bleu HC";

                            //foundationYear = 1999;
                            reputation = 2;

                            money = 30031405;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 1:
                            clubName = "El Eulma Hunters";

                            //foundationYear = 1995;
                            reputation = 2;

                            money = 28051505;

                            homeColor = Color.green;
                            visitorColor = Color.red;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 2:
                            clubName = "HC Biskra Oasis";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 25512505;

                            homeColor = Color.black;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 3:
                            clubName = "Djelfa HC";

                            //foundationYear = 1996;
                            reputation = 2;

                            money = 21512130;

                            homeColor = Color.black;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 4:
                            clubName = "HC Batna Flèches";

                            //foundationYear = 1992;
                            reputation = 2;

                            money = 19212130;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.gray;
                            visitorColor = new Color(255.0f / 255.0f, 100.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Naranja

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 5:
                            clubName = "Annaba Roche HC";

                            //foundationYear = 1995;
                            reputation = 1;

                            money = 16216638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.grey;
                            visitorColor = Color.black;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 6:
                            clubName = "Skikda HC";

                            //foundationYear = 1989;
                            reputation = 1;

                            money = 14244638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.white;
                            visitorColor = Color.yellow;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 7:
                            clubName = "HC Constantina";

                            //foundationYear = 1991;
                            reputation = 1;

                            money = 12554638;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 8:
                            clubName = "HC Argel Or";

                            //foundationYear = 1993;
                            reputation = 1;

                            money = 13714638;

                            homeColor = new Color(255.0f / 255.0f, 179.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Dorado
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 9:
                            clubName = "Orán HC";

                            //foundationYear = 2005;
                            reputation = 0;

                            money = 10428538;

                            homeColor = Color.blue;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                    }
                }
            } /////////////ALEMANIA///////////////////////////////
        } /////////////EUROPA/////////////////////////////////////
        else if (valueContinent == 4)
        {
            if (valueCountry == 0)
            {
                if (valueDivision == 0)
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Granada Goshawk HC";

                            //foundationYear = 1990;
                            reputation = 5;

                            //expectedContinentPosition = 1;
                            //expectedWorldPosition = 1;

                            money = 198573205;

                            //continentQua = true;
                            //worldQua = true;

                            homeColor = Color.red;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 1:
                            clubName = "HC Madrid Bears";

                            //foundationYear = 1989;
                            reputation = 5;

                            //expectedContinentPosition = 3;

                            money = 186270205;

                            //continentQua = true;

                            homeColor = Color.white;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 2:
                            clubName = "Euskal Aizkora HC";

                            //foundationYear = 1992;
                            reputation = 4;

                            money = 165161405;

                            homeColor = Color.red;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 3:
                            clubName = "Barcelona Salamanders HC";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 124685251;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 4:
                            clubName = "Valencia Pirates";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 101574258;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 5:
                            clubName = "Zaragoza Lions HC";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 92645127;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 6:
                            clubName = "Vigo Kraken Hunters";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 85645127;

                            homeColor = new Color(88.0f / 255.0f, 230.0f / 255.0f, 230.0f / 255.0f, 255.0f / 255.0f); //Celeste
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 7:
                            clubName = "Tenerife Explorers HC";

                            //foundationYear = 1991;
                            reputation = 3;

                            money = 88645127;

                            homeColor = Color.blue;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 8:
                            clubName = "HC Osasuna Bulls";

                            //foundationYear = 1993;
                            reputation = 3;

                            money = 54155127;

                            homeColor = Color.red;
                            visitorColor = Color.gray;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 9:
                            clubName = "Cartagena Submarines";

                            //foundationYear = 1994;
                            reputation = 3;

                            money = 44155444;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                    }
                }
                else
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Tremecén Bleu HC";

                            //foundationYear = 1999;
                            reputation = 2;

                            money = 30031405;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 1:
                            clubName = "El Eulma Hunters";

                            //foundationYear = 1995;
                            reputation = 2;

                            money = 28051505;

                            homeColor = Color.green;
                            visitorColor = Color.red;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 2:
                            clubName = "HC Biskra Oasis";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 25512505;

                            homeColor = Color.black;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 3:
                            clubName = "Djelfa HC";

                            //foundationYear = 1996;
                            reputation = 2;

                            money = 21512130;

                            homeColor = Color.black;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 4:
                            clubName = "HC Batna Flèches";

                            //foundationYear = 1992;
                            reputation = 2;

                            money = 19212130;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.gray;
                            visitorColor = new Color(255.0f / 255.0f, 100.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Naranja

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 5:
                            clubName = "Annaba Roche HC";

                            //foundationYear = 1995;
                            reputation = 1;

                            money = 16216638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.grey;
                            visitorColor = Color.black;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 6:
                            clubName = "Skikda HC";

                            //foundationYear = 1989;
                            reputation = 1;

                            money = 14244638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.white;
                            visitorColor = Color.yellow;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 7:
                            clubName = "HC Constantina";

                            //foundationYear = 1991;
                            reputation = 1;

                            money = 12554638;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 8:
                            clubName = "HC Argel Or";

                            //foundationYear = 1993;
                            reputation = 1;

                            money = 13714638;

                            homeColor = new Color(255.0f / 255.0f, 179.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Dorado
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 9:
                            clubName = "Orán HC";

                            //foundationYear = 2005;
                            reputation = 0;

                            money = 10428538;

                            homeColor = Color.blue;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                    }
                }
            }
            else if (valueCountry == 1)
            {
                if (valueDivision == 0)
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Granada Goshawk HC";

                            //foundationYear = 1990;
                            reputation = 5;

                            //expectedContinentPosition = 1;
                            //expectedWorldPosition = 1;

                            money = 198573205;

                            //continentQua = true;
                            //worldQua = true;

                            homeColor = Color.red;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 1:
                            clubName = "HC Madrid Bears";

                            //foundationYear = 1989;
                            reputation = 5;

                            //expectedContinentPosition = 3;

                            money = 186270205;

                            //continentQua = true;

                            homeColor = Color.white;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 2:
                            clubName = "Euskal Aizkora HC";

                            //foundationYear = 1992;
                            reputation = 4;

                            money = 165161405;

                            homeColor = Color.red;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 3:
                            clubName = "Barcelona Salamanders HC";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 124685251;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 4:
                            clubName = "Valencia Pirates";

                            //foundationYear = 1992;
                            reputation = 3;

                            money = 101574258;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 5:
                            clubName = "Zaragoza Lions HC";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 92645127;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 6:
                            clubName = "Vigo Kraken Hunters";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 85645127;

                            homeColor = new Color(88.0f / 255.0f, 230.0f / 255.0f, 230.0f / 255.0f, 255.0f / 255.0f); //Celeste
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 7:
                            clubName = "Tenerife Explorers HC";

                            //foundationYear = 1991;
                            reputation = 3;

                            money = 88645127;

                            homeColor = Color.blue;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 8:
                            clubName = "HC Osasuna Bulls";

                            //foundationYear = 1993;
                            reputation = 3;

                            money = 54155127;

                            homeColor = Color.red;
                            visitorColor = Color.gray;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                        case 9:
                            clubName = "Cartagena Submarines";

                            //foundationYear = 1994;
                            reputation = 3;

                            money = 44155444;

                            homeColor = Color.black;
                            visitorColor = Color.white;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Europa/Spain/1ª");

                            break;
                    }
                }
                else
                {
                    switch (clubValue)
                    {
                        case 0:
                            clubName = "Tremecén Bleu HC";

                            //foundationYear = 1999;
                            reputation = 2;

                            money = 30031405;

                            homeColor = Color.blue;
                            visitorColor = Color.black;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 1:
                            clubName = "El Eulma Hunters";

                            //foundationYear = 1995;
                            reputation = 2;

                            money = 28051505;

                            homeColor = Color.green;
                            visitorColor = Color.red;

                            preCupQua = false;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 2:
                            clubName = "HC Biskra Oasis";

                            //foundationYear = 1989;
                            reputation = 3;

                            money = 25512505;

                            homeColor = Color.black;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 3:
                            clubName = "Djelfa HC";

                            //foundationYear = 1996;
                            reputation = 2;

                            money = 21512130;

                            homeColor = Color.black;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 4:
                            clubName = "HC Batna Flèches";

                            //foundationYear = 1992;
                            reputation = 2;

                            money = 19212130;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.gray;
                            visitorColor = new Color(255.0f / 255.0f, 100.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Naranja

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 5:
                            clubName = "Annaba Roche HC";

                            //foundationYear = 1995;
                            reputation = 1;

                            money = 16216638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.grey;
                            visitorColor = Color.black;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 6:
                            clubName = "Skikda HC";

                            //foundationYear = 1989;
                            reputation = 1;

                            money = 14244638;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            homeColor = Color.white;
                            visitorColor = Color.yellow;

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 7:
                            clubName = "HC Constantina";

                            //foundationYear = 1991;
                            reputation = 1;

                            money = 12554638;

                            homeColor = Color.blue;
                            visitorColor = Color.red;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 8:
                            clubName = "HC Argel Or";

                            //foundationYear = 1993;
                            reputation = 1;

                            money = 13714638;

                            homeColor = new Color(255.0f / 255.0f, 179.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); //Dorado
                            visitorColor = Color.black;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                        case 9:
                            clubName = "Orán HC";

                            //foundationYear = 2005;
                            reputation = 0;

                            money = 10428538;

                            homeColor = Color.blue;
                            visitorColor = Color.green;

                            //localEnemies.Add("");
                            //greatEnemies.Add("");

                            //logo = Resources.Load<Sprite>("UI/Flags/TeamLogos/Africa/Argelia/1ª");

                            break;
                    }
                }
            }
        } /////////////OCEANÍA////////////////////////////////////

        if (money > 150000000)
        {
            economyStatus = 0;
        }
        else if (money > 100000000)
        {
            economyStatus = 1;
        }
        else if (money > 75000000)
        {
            economyStatus = 2;
        }
        else if (money > 50000000)
        {
            economyStatus = 3;
        }
        else
        {
            economyStatus = 4;
        }

        return this;
    }
}