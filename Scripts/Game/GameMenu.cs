using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    bool gameActive;

    bool homeActive, boxActive, teamActive, tacticActive, trainingActive, employeeActive, rookieActive, hospitalActive, calendarActive, competitionActive, scoutActive,
         transferActive, searchActive, infoClubActive, directionActive, economyActive;
    int homeIndex; //0 - Main 1 - Profile 2 - Contract
    int competitionIndex;
    int clubInfoIndex; //0 - Perfil
    int[] actualLanguage; //0 - Buttons 1 - Home Main 2 - Profile 3 - Contract 4 - Competition 5 - club info profile 6 - club info window 7 - club installation 

    DataBase db;
    Controller controller;
    Club selectedClub;
    public GameObject loadScrean;

    //Main
    GameObject nextMatch, leagueTable;

    Profile profile;


    private void Awake()
    {
        ActiveLoadScrean(false);
    }



    void Start()
    {
        gameActive = true;

        controller = GameObject.Find("Controller").GetComponent<Controller>();
        db = controller.GetDataBase();

        //Main
        nextMatch = this.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject;
        leagueTable = this.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject;

        //0 - home main     1 - home profile    2 - home contract
        actualLanguage = new int[20];

        for(int i = 0; i < actualLanguage.Length; i++)
        {
            actualLanguage[i] = -1;
        }

        ActiveGameButtons(false);
        ActiveUpBar(false, -1);

        homeActive = false;
        homeIndex = -1;

        ActiveHome(false);
        ActiveBox(false);
        ActiveTeam(false);
        ActiveTactic(false);
        ActiveTraining(false);
        ActiveEmployee(false);
        ActiveRookies(false);
        ActiveHospital(false);
        ActiveCalendar(false);
        ActiveCompetition(false);
        ActiveScout(false);
        ActiveTransfer(false);
        ActiveSearch(false);
        ActiveClubInfo(false);
        ActiveDirection(false);
        ActiveEconomy(false);

        gameActive = false;
    }



    public void ActiveLoadScrean(bool on)
    {
        loadScrean.SetActive(on);
    }



    public void StartGame()
    {
        ActiveLoadScrean(true);
        StartCoroutine(PrepareGame());
    }



    IEnumerator PrepareGame()
    {
        int[] trainingClub = db.GetTrainingClub();
        this.transform.GetChild(1).GetChild(5).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Continuar"); //Boton continuar

        selectedClub = db.GetTeam(trainingClub[0], trainingClub[1], trainingClub[2]);
        this.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = selectedClub.logo;

        ActiveUpBar(true, 0);
        ActiveGameButtons(true);

        gameActive = true;
        ActiveHomeMain(true);

        yield return new WaitForEndOfFrame();

        ActiveLoadScrean(false);
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Establece la botonera del juego ////////////////////////////////////
    void ActiveGameButtons(bool on)
    {
        this.transform.GetChild(0).gameObject.SetActive(on);

        if (actualLanguage[0] != db.GetLanguage())
        {
            actualLanguage[0] = db.GetLanguage();

            this.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Inicio"); //Inicio
            this.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Buzón"); //Buzón
            this.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Equipo"); //Equipo
            this.transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Táctica"); //Tactica
            this.transform.GetChild(0).GetChild(5).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Entrenamiento"); //Entrenamiento
            this.transform.GetChild(0).GetChild(6).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Empleados"); //Empleado
            this.transform.GetChild(0).GetChild(7).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Formación"); //Formación
            this.transform.GetChild(0).GetChild(8).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Hospital"); //Hospital
            this.transform.GetChild(0).GetChild(9).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Calendario"); //Calendario
            this.transform.GetChild(0).GetChild(10).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Competiciones"); //Competicion
            this.transform.GetChild(0).GetChild(11).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Ojeo"); //Ojeo
            this.transform.GetChild(0).GetChild(12).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Fichajes"); //Fichaje
            this.transform.GetChild(0).GetChild(13).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Buscar"); //Buscar
            this.transform.GetChild(0).GetChild(14).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Info Club"); //Info
            this.transform.GetChild(0).GetChild(15).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Dirección"); //Direccion
            this.transform.GetChild(0).GetChild(16).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Dirección"); //Economia
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Establece la barra del juego ////////////////////////////////////////////////////////
    void ActiveUpBar(bool on, int value)
    {
        this.transform.GetChild(1).gameObject.SetActive(on);

        int totalButton;

        if (on)
        {
            switch (value)
            {
                case 0:
                    this.transform.GetChild(1).GetChild(3).GetComponent<Text>().text = db.GetTranslatedWord("Pantalla Inicio"); //Titulo cabecera

                    this.transform.GetChild(1).GetChild(2).GetChild(1).gameObject.SetActive(true);
                    this.transform.GetChild(1).GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Inicio");

                    this.transform.GetChild(1).GetChild(2).GetChild(2).gameObject.SetActive(true);
                    this.transform.GetChild(1).GetChild(2).GetChild(2).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Perfil");

                    this.transform.GetChild(1).GetChild(2).GetChild(3).gameObject.SetActive(true);
                    this.transform.GetChild(1).GetChild(2).GetChild(3).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Contrato");

                    for (int i = 3; i < 8; i++)
                    {
                        this.transform.GetChild(1).GetChild(2).GetChild(1 + i).gameObject.SetActive(false);
                    }
                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:

                    break;
                case 8:

                    break;
                case 9:
                    this.transform.GetChild(1).GetChild(3).GetComponent<Text>().text = db.GetTranslatedWord("Información del Club"); //Titulo cabecera

                    this.transform.GetChild(1).GetChild(2).GetChild(1).gameObject.SetActive(true);
                    this.transform.GetChild(1).GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Perfil");

                    for (int i = 1; i < 8; i++)
                    {
                        this.transform.GetChild(1).GetChild(2).GetChild(1 + i).gameObject.SetActive(false);
                    }
                    break;
                case 10:

                    break;
                case 11:

                    break;
                case 12:

                    break;
                case 13://Club info
                    this.transform.GetChild(1).GetChild(3).GetComponent<Text>().text = db.GetTranslatedWord("Información del Club"); //Titulo cabecera

                    this.transform.GetChild(1).GetChild(2).GetChild(1).gameObject.SetActive(true);
                    this.transform.GetChild(1).GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Perfil");

                    this.transform.GetChild(1).GetChild(2).GetChild(2).gameObject.SetActive(true);
                    this.transform.GetChild(1).GetChild(2).GetChild(2).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Club");

                    this.transform.GetChild(1).GetChild(2).GetChild(3).gameObject.SetActive(true);
                    this.transform.GetChild(1).GetChild(2).GetChild(3).GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Instalaciones");

                    for (int i = 3; i < 8; i++)
                    {
                        this.transform.GetChild(1).GetChild(2).GetChild(1 + i).gameObject.SetActive(false);
                    }
                    break;
                case 14:

                    break;
                case 15:

                    break;
            }
        }
    }



    public void UpButton(int value)
    {
        if (homeActive)
        {
            if(value == 0)
            {
                ActiveHomeMain(true);
            }
            else if (value == 1)
            {
                ActiveHomeProfile(true);
            }
            else
            {
                ActiveHomeContract(true);
            }
        }
        else if (boxActive)
        {
            if(value == 0)
            {

            }
        }
        else if (teamActive)
        {
            if (value == 0)
            {

            }
            else if (value == 1)
            {

            }
            else
            {

            }
        }
        else if (tacticActive)
        {
            if (value == 0)
            {

            }
            else if (value == 1)
            {

            }
            else
            {

            }
        }
        else if (trainingActive)
        {
            if (value == 0)
            {

            }
            else if (value == 1)
            {

            }
            else
            {

            }
        }
        else if (employeeActive)
        {
            if (value == 0)
            {

            }
            else if (value == 1)
            {

            }
            else
            {

            }
        }
        else if (rookieActive)
        {
            if (value == 0)
            {

            }
            else if (value == 1)
            {

            }
            else
            {

            }
        }
        else if (hospitalActive)
        {
            if (value == 0)
            {

            }
            else if (value == 1)
            {

            }
            else
            {

            }
        }
        else if (calendarActive)
        {
            if (value == 0)
            {

            }
            else if (value == 1)
            {

            }
            else
            {

            }
        }
        else if (competitionActive)
        {
            if (value == 0)
            {
                ActiveCompetitionMain(true);
            }
            else if (value == 1)
            {

            }
            else
            {

            }
        }
        else if (scoutActive)
        {
            if (value == 0)
            {

            }
            else if (value == 1)
            {

            }
            else
            {

            }
        }
        else if (transferActive)
        {
            if (value == 0)
            {

            }
            else if (value == 1)
            {

            }
            else
            {

            }
        }
        else if (searchActive)
        {
            if (value == 0)
            {

            }
            else if (value == 1)
            {

            }
            else
            {

            }
        }
        else if (infoClubActive)
        {
            if (value == 0)
            {
                ActiveClubInfoProfile(true);
            }
            else if (value == 1)
            {
                ActiveClubInfoClubWindow(true);
            }
            else
            {
                ActiveClubInfoInstallation(true);
            }
        }
        else if (directionActive)
        {
            if (value == 0)
            {

            }
            else if (value == 1)
            {

            }
            else
            {

            }
        }
        else if (economyActive)
        {
            if (value == 0)
            {

            }
            else if (value == 1)
            {

            }
            else
            {

            }
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Cierra la pantalla que estuviera abierta antes de iniciar la nueva seleccionada /////
    void RefreshInterface()
    {
        if (homeActive)
        {
            ActiveHome(false);
        }
        else if (boxActive)
        {
            ActiveBox(false);
        }
        else if (teamActive)
        {
            ActiveTeam(false);
        }
        else if (tacticActive)
        {
            ActiveTactic(false);
        }
        else if (trainingActive)
        {
            ActiveTraining(false);
        }
        else if (employeeActive)
        {
            ActiveEmployee(false);
        }
        else if (rookieActive)
        {
            ActiveRookies(false);
        }
        else if (hospitalActive)
        {
            ActiveHospital(false);
        }
        else if (calendarActive)
        {
            ActiveCalendar(false);
        }
        else if (competitionActive)
        {
            ActiveCompetition(false);
        }
        else if (scoutActive)
        {
            ActiveScout(false);
        }
        else if (transferActive)
        {
            ActiveTransfer(false);
        }
        else if (searchActive)
        {
            ActiveSearch(false);
        }
        else if (infoClubActive)
        {
            ActiveClubInfo(false);
        }
        else if (directionActive)
        {
            ActiveDirection(false);
        }
        else if (economyActive)
        {
            ActiveHome(false);
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Activa el menú Home /////////////////////////////////////////////////////////////////
    void ActiveHome(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                RefreshInterface();
                ActiveUpBar(true, 0);
                profile = db.GetProfile();
            }
            else
            {
                ActiveHomeMain(false);
                ActiveHomeContract(false);
                ActiveHomeProfile(false);
            }

            homeActive = on;
        }
    }



    public void ActiveHomeMain(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                if (homeActive)
                {
                    RefreshHome();
                }
                else
                {
                    ActiveHome(on);
                }

                if (actualLanguage[1] != db.GetLanguage())
                {
                    actualLanguage[1] = db.GetLanguage();

                    //traducir texto
                }

                NextMatchMain();
                LeagueTableMain();
                CalendarMain();
                DirectionMain();
                EconomyMain();

                homeIndex = 0;
            }

            this.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(on);
        }
    }



    void NextMatchMain()
    {
        Club localClub = null;
        Club visitClub = null;
        League league = db.GetLeague(profile.continentClub, profile.countryClub, profile.divisionClub);
        //int totalDays;

        int teamIndex = db.GetProfile().clubIndex;
        int actualMatch = league.actualMatch;
        int[,] matchs;

        switch (actualMatch)
        {
            case 0:
                matchs = league.matchs;
                break;
            case 1:
                matchs = league.matchs1;
                break;
            case 2:
                matchs = league.matchs2;
                break;
            case 3:
                matchs = league.matchs3;
                break;
            case 4:
                matchs = league.matchs4;
                break;
            case 5:
                matchs = league.matchs5;
                break;
            case 6:
                matchs = league.matchs6;
                break;
            case 7:
                matchs = league.matchs7;
                break;
            case 8:
                matchs = league.matchs8;
                break;
            case 9:
                matchs = league.matchs9;
                break;
            case 10:
                matchs = league.matchs10;
                break;
            case 11:
                matchs = league.matchs11;
                break;
            case 12:
                matchs = league.matchs12;
                break;
            case 13:
                matchs = league.matchs13;
                break;
            case 14:
                matchs = league.matchs14;
                break;
            case 15:
                matchs = league.matchs15;
                break;
            case 16:
                matchs = league.matchs16;
                break;
            default:
                matchs = league.matchs17;
                break;
        }
        
        for(int i = 0; i < 5; i++)
        {
            if (matchs[i, 0] == teamIndex)
            {
                localClub = db.GetTeam(profile.continentClub, profile.countryClub, teamIndex);
                visitClub = db.GetTeam(profile.continentClub, profile.countryClub, matchs[i, 1]);

                break;
            }
            else if (matchs[i, 1] == teamIndex)
            {
                visitClub = db.GetTeam(profile.continentClub, profile.countryClub, teamIndex);
                localClub = db.GetTeam(profile.continentClub, profile.countryClub, matchs[i, 0]);

                break;
            }
        }

        if(localClub != null)
        {
            nextMatch.transform.GetChild(1).GetComponent<Image>().sprite = localClub.logo;
            nextMatch.transform.GetChild(2).GetComponent<Image>().sprite = visitClub.logo;
            nextMatch.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = localClub.clubName;
            nextMatch.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = visitClub.clubName;
            nextMatch.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = league.leagueName;
            //nextMatch.transform.GetChild(6).GetComponent<Text>().text = ; días restantes
        }
    }



    void LeagueTableMain()
    {
        Club club1, club2;
        int[] league = db.GetLeagueTeam(profile.continentClub, profile.countryClub, profile.divisionClub);

        for(int i = 0; i < league.Length; i++)
        {
            for(int j = 0; j < league.Length - 1; j++)
            {
                club1 = db.GetTeam(profile.continentClub, profile.countryClub, league[j]);
                club2 = db.GetTeam(profile.continentClub, profile.countryClub, league[j + 1]);

                if(club1.actualLeaguePoints < club2.actualLeaguePoints)
                {
                    int aux;
                    aux = league[j];
                    league[j] = league[j + 1];
                    league[j + 1] = aux;
                }
            }
        }

        for(int i = 0; i < league.Length; i++)
        {
            club1 = db.GetTeam(profile.continentClub, profile.countryClub, league[i]);

            leagueTable.transform.GetChild(2 + i).GetChild(1).GetComponent<Text>().text = (i + 1) + "";

            if (club1.ascent)
            {
                leagueTable.transform.GetChild(2 + i).GetChild(2).GetComponent<Text>().text = "A";
            }
            else if (club1.descent)
            {
                leagueTable.transform.GetChild(2 + i).GetChild(2).GetComponent<Text>().text = "D";
            }
            else if (club1.leagueChampion)
            {
                leagueTable.transform.GetChild(2 + i).GetChild(2).GetComponent<Text>().text = "C";
            }
            else
            {
                leagueTable.transform.GetChild(2 + i).GetChild(2).GetComponent<Text>().text = "";
            }
            /*
            else if (club1.continentNextSeason)
            {
                if(profile.continentClub == 0)
                {
                    leagueTable.transform.GetChild(2 + i).GetChild(2).GetComponent<Text>().text = "Af";
                }
                else if (profile.continentClub == 1)
                {
                    leagueTable.transform.GetChild(2 + i).GetChild(2).GetComponent<Text>().text = "Am";
                }
                else if (profile.continentClub == 1)
                {
                    leagueTable.transform.GetChild(2 + i).GetChild(2).GetComponent<Text>().text = "As";
                }
                else if (profile.continentClub == 1)
                {
                    leagueTable.transform.GetChild(2 + i).GetChild(2).GetComponent<Text>().text = "Eu";
                }
                else
                {
                    leagueTable.transform.GetChild(2 + i).GetChild(2).GetComponent<Text>().text = "Oc";
                }
            }
            */

            leagueTable.transform.GetChild(2 + i).GetChild(3).GetChild(0).GetComponent<Text>().text = club1.clubName;
            leagueTable.transform.GetChild(2 + i).GetChild(3).GetChild(1).GetComponent<Image>().sprite = club1.logo;

            leagueTable.transform.GetChild(2 + i).GetChild(4).GetComponent<Text>().text = "" + club1.leagueMatchs;
            leagueTable.transform.GetChild(2 + i).GetChild(5).GetComponent<Text>().text = "" + club1.leagueWins;
            leagueTable.transform.GetChild(2 + i).GetChild(6).GetComponent<Text>().text = "" + club1.leagueDraws;
            leagueTable.transform.GetChild(2 + i).GetChild(7).GetComponent<Text>().text = "" + club1.leagueLoses;
            leagueTable.transform.GetChild(2 + i).GetChild(8).GetComponent<Text>().text = "" + club1.actualLeaguePoints;
        }
    }



    void CalendarMain()
    {

    }



    void DirectionMain()
    {

    }



    void EconomyMain()
    {

    }



    void ActiveHomeProfile(bool on)
    {
        if (gameActive)
        {
            //ActiveHome(on);

            this.transform.GetChild(2).GetChild(0).GetChild(1).gameObject.SetActive(on);
        }
    }



    void ActiveHomeContract(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                if (homeActive)
                {
                    RefreshHome();
                }
                else
                {
                    ActiveHome(on);
                }

                if (actualLanguage[3] != db.GetLanguage())
                {
                    actualLanguage[3] = db.GetLanguage();

                    //traducir texto
                }



                homeIndex = 2;
            }

            this.transform.GetChild(2).GetChild(0).GetChild(2).gameObject.SetActive(on);
        }
    }



    void RefreshHome()
    {
        if(homeIndex == 0)
        {
            ActiveHomeMain(false);
        }
        else if (homeIndex == 1)
        {
            ActiveHomeProfile(false);
        }
        else
        {
            ActiveHomeContract(false);
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Activa el menú Box /////////////////////////////////////////////////////////////////
    public void ActiveBox(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                RefreshInterface();
                ActiveUpBar(true, 1);
            }
            else
            {

            }

            boxActive = on;
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Activa el menú Team /////////////////////////////////////////////////////////////////
    public void ActiveTeam(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                RefreshInterface();
                ActiveUpBar(true, 2);
            }
            else
            {

            }

            teamActive = on;
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Activa el menú Tactic /////////////////////////////////////////////////////////////////
    public void ActiveTactic(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                RefreshInterface();
                ActiveUpBar(true, 3);
            }
            else
            {

            }

            tacticActive = on;
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Activa el menú Training /////////////////////////////////////////////////////////////////
    public void ActiveTraining(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                RefreshInterface();
                ActiveUpBar(true, 4);
            }
            else
            {

            }

            trainingActive = on;
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Activa el menú Employee /////////////////////////////////////////////////////////////////
    public void ActiveEmployee(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                RefreshInterface();
                ActiveUpBar(true, 5);
            }
            else
            {

            }

            employeeActive = on;
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Activa el menú Rookies /////////////////////////////////////////////////////////////////
    public void ActiveRookies(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                RefreshInterface();
                ActiveUpBar(true, 6);
            }
            else
            {

            }

            rookieActive = on;
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Activa el menú Hospital /////////////////////////////////////////////////////////////////
    public void ActiveHospital(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                RefreshInterface();
                ActiveUpBar(true, 7);
            }
            else
            {

            }

            hospitalActive = on;
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Activa el menú Calendar /////////////////////////////////////////////////////////////////
    public void ActiveCalendar(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                RefreshInterface();
                ActiveUpBar(true, 8);
            }
            else
            {

            }

            calendarActive = on;
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Activa el menú Competition /////////////////////////////////////////////////////////////////
    public void ActiveCompetition(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                RefreshInterface();
                ActiveUpBar(true, 9);
                profile = db.GetProfile();
            }
            else
            {
                ActiveCompetitionMain(false);
            }

            competitionActive = on;
        }
    }


    public void ActiveCompetitionMain(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                if (competitionActive)
                {
                    //RefreshCompetition();
                }
                else
                {
                    ActiveCompetition(on);
                }

                if (actualLanguage[4] != db.GetLanguage())
                {
                    actualLanguage[4] = db.GetLanguage();

                    //traducir texto
                }



                competitionIndex = 0;
            }

            this.transform.GetChild(2).GetChild(9).GetChild(0).gameObject.SetActive(on);
        }
    }


    /*
    void RefreshCompetition()
    {
        if (homeIndex == 0)
        {
            ActiveHomeMain(false);
        }
        else if (homeIndex == 1)
        {
            ActiveHomeProfile(false);
        }
        else
        {
            ActiveHomeContract(false);
        }
    }
    */

    //////////////////////////////////////////////////////////////////////////////////////////
    /// Activa el menú Scout /////////////////////////////////////////////////////////////////
    public void ActiveScout(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                RefreshInterface();
                ActiveUpBar(true, 10);
            }
            else
            {

            }

            scoutActive = on;
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Activa el menú Transfer /////////////////////////////////////////////////////////////////
    public void ActiveTransfer(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                RefreshInterface();
                ActiveUpBar(true, 11);
            }
            else
            {

            }

            transferActive = on;
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Activa el menú Search /////////////////////////////////////////////////////////////////
    public void ActiveSearch(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                RefreshInterface();
                ActiveUpBar(true, 12);
            }
            else
            {

            }

            searchActive = on;
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Activa el menú ClubInfo /////////////////////////////////////////////////////////////////
    public void ActiveClubInfo(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                RefreshInterface(); profile = db.GetProfile();
                ActiveUpBar(true, 13);
            }
            else
            {
                ActiveClubInfoProfile(false);
                ActiveClubInfoClubWindow(false);
                ActiveClubInfoInstallation(false);
            }

            infoClubActive = on;
        }
    }



    public void ActiveClubInfoProfile(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                if (infoClubActive)
                {
                    RefreshClubInfo();
                }
                else
                {
                    ActiveClubInfo(on);
                }

                if (actualLanguage[5] != db.GetLanguage())
                {
                    actualLanguage[5] = db.GetLanguage();

                    //traducir texto
                }

                clubInfoIndex = 0;
            }

            this.transform.GetChild(2).GetChild(13).GetChild(0).gameObject.SetActive(on);
        }
    }



    void ActiveClubInfoClubWindow(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                if (infoClubActive)
                {
                    RefreshClubInfo();
                }
                else
                {
                    ActiveClubInfo(on);
                }

                if (actualLanguage[6] != db.GetLanguage())
                {
                    actualLanguage[6] = db.GetLanguage();

                    //traducir texto
                }

                clubInfoIndex = 1;
            }

            this.transform.GetChild(2).GetChild(13).GetChild(1).gameObject.SetActive(on);
        }
    }



    void ActiveClubInfoInstallation(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                if (infoClubActive)
                {
                    RefreshClubInfo();
                }
                else
                {
                    ActiveClubInfo(on);
                }

                if (actualLanguage[7] != db.GetLanguage())
                {
                    actualLanguage[7] = db.GetLanguage();

                    //traducir texto
                }

                clubInfoIndex = 2;
            }

            this.transform.GetChild(2).GetChild(13).GetChild(2).gameObject.SetActive(on);
        }
    }



    void RefreshClubInfo()
    {
        if (clubInfoIndex == 0)
        {
            ActiveClubInfoProfile(false);
        }
        else if (clubInfoIndex == 1)
        {
            ActiveClubInfoClubWindow(false);
        }
        else
        {
            ActiveClubInfoInstallation(false);
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Activa el menú Direction /////////////////////////////////////////////////////////////////
    public void ActiveDirection(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                RefreshInterface();
                ActiveUpBar(true, 14);
            }
            else
            {

            }

            directionActive = on;
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Activa el menú Economy /////////////////////////////////////////////////////////////////
    public void ActiveEconomy(bool on)
    {
        if (gameActive)
        {
            if (on)
            {
                RefreshInterface();
                ActiveUpBar(true, 15);
            }
            else
            {

            }

            economyActive = on;
        }
    }
}
