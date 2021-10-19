using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    int actualLanguage;
    int actualLanguageClub;

    Controller controller;

    List<string> month28;
    List<string> month30;
    List<string> month31;
    List<string> yearList;

    List<string> europa;
    List<string> asia;
    List<string> africa;
    List<string> america;
    List<string> oceania;

    DataBase db;

    string nameM, surname;

    int month, day, year;
    int continent; //0 Africa 1 America 2 Asia 3 europa 4 oceania
    int countryID;
    int playerExperience, trainerExperience;
    int selectedClub;

    public Sprite redStar, blackStar;

    void Awake()
    {
        actualLanguage = actualLanguageClub = -1;
        selectedClub = -1;

        controller = GameObject.Find("Controller").GetComponent<Controller>();

        month28 = new List<string>();
        month30 = new List<string>();
        month31 = new List<string>();
        yearList = new List<string>();

        for(int i = 1; i < 32; i++)
        {
            if(i < 29)
            {
                month28.Add(i + "");
            }

            if (i < 31)
            {
                month30.Add(i + "");
            }

            month31.Add(i + "");
        }

        month = 0;
        continent = 0;

        europa = new List<string>();
        asia = new List<string>();
        africa = new List<string>();
        america = new List<string>();
        oceania = new List<string>();

        db = controller.GetDataBase();
    }

    
    //Vuelve al menú principal
    public void GoMainMenu()
    {
        NewGameActive(false);
        controller.ActiveMainMenu(true);
    }


    //Activa la selección del club
    public void GoNext()
    {
        day = this.transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Dropdown>().value;
        year = int.Parse(yearList[this.transform.GetChild(0).GetChild(2).GetChild(5).GetComponent<Dropdown>().value]);

        playerExperience = this.transform.GetChild(0).GetChild(4).GetChild(1).GetComponent<Dropdown>().value; //0 máxima experiencia (más facil)
        trainerExperience = this.transform.GetChild(0).GetChild(4).GetChild(3).GetComponent<Dropdown>().value; //0 máxima experiencia (más facil)

        controller.GetDataBase().SetBornManager(month, day, year);
        controller.GetDataBase().SetNationalityManager(continent, countryID);
        controller.GetDataBase().SetExperienceManager(playerExperience, trainerExperience);
        controller.GetDataBase().SetNameManager(nameM, surname);

        NewClubActive(true);
    }


    //Vuelve a la creación de manager
    public void GoBack() 
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        this.transform.GetChild(1).gameObject.SetActive(false);
    }


    //Comprueba si se han completado todos los campos para poder continuar
    public void CheckNext() 
    {
        StartCoroutine(CheckInsert());
    }



    IEnumerator CheckInsert()
    {
        yield return new WaitForEndOfFrame();

        bool on = false;

        nameM = this.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(2).GetComponent<Text>().text;
        surname = this.transform.GetChild(0).GetChild(1).GetChild(3).GetChild(2).GetComponent<Text>().text;

        if (nameM.Length > 0 && surname.Length > 0)
        {
            on = true;
        }

        this.transform.GetChild(0).GetChild(5).GetChild(0).GetComponent<Button>().interactable = on;
    }


    //Cambia el número de días en función del mes
    public void CheckMonth() 
    {
        StartCoroutine(ChangeMonth());
    }



    IEnumerator ChangeMonth()
    {
        yield return new WaitForEndOfFrame();
        month = this.transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Dropdown>().value;

        Dropdown days = this.transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Dropdown>();
        days.ClearOptions();

        //enero es el mes 0
        if (month == 1)
        {
            days.AddOptions(month28);
        }
        else if (month == 3 || month == 5 || month == 8 || month == 10)
        {
            days.AddOptions(month30);
        }
        else
        {
            days.AddOptions(month31);
        }
    }


    //Cambia el texto del país en función del continente
    public void ChangeContinent()
    {
        continent = this.transform.GetChild(0).GetChild(3).GetChild(1).GetComponent<Dropdown>().value;

        StartCoroutine(ChangeCountry());
    }



    IEnumerator ChangeCountry()
    {
        yield return new WaitForEndOfFrame();

        Dropdown country = this.transform.GetChild(0).GetChild(3).GetChild(3).GetComponent<Dropdown>();
        country.ClearOptions();

        if (continent == 0)
        {
            country.AddOptions(africa);
        }
        else if (continent == 1)
        {
            country.AddOptions(america);
        }
        else if (continent == 2)
        {
            country.AddOptions(asia);
        }
        else if (continent == 3)
        {
            country.AddOptions(europa);
        }
        else
        {
            country.AddOptions(oceania);
        }
    }


    //Cambia la imagen de la bandera
    public void ChangeFlag()
    {
        StartCoroutine(NewFlag());
    }



    IEnumerator NewFlag()
    {
        yield return new WaitForEndOfFrame();
        countryID = this.transform.GetChild(0).GetChild(3).GetChild(3).GetComponent<Dropdown>().value;

        this.transform.GetChild(0).GetChild(3).GetChild(4).GetComponent<Image>().sprite = controller.GetDataBase().GetFlag(continent, countryID);
    }


    //Activa el menú new game y cambia el texto si el idioma es cambiado
    public void NewGameActive(bool on)
    {
        this.gameObject.SetActive(on);

        if (on)
        {
            int newLanguage = controller.GetDataBase().GetLanguage();

            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(false);

            if (actualLanguage != newLanguage)
            {
                actualLanguage = newLanguage;

                //Botón volver
                this.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Volver");

                //Nombre
                this.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Nombre") + ":";
                this.transform.GetChild(0).GetChild(1).GetChild(2).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Apellido") + ":";

                //Edad
                this.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Mes") + ":";
                this.transform.GetChild(0).GetChild(2).GetChild(2).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Día") + ":";
                this.transform.GetChild(0).GetChild(2).GetChild(4).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Año") + ":";
                this.transform.GetChild(0).GetChild(2).GetChild(6).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Fecha de Nacimiento");

                //Nacionalidad
                this.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Continente") + ":";
                this.transform.GetChild(0).GetChild(3).GetChild(2).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Nacionalidad") + ":";

                //Experiencia
                this.transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Experiencia Jugador") + ":";
                this.transform.GetChild(0).GetChild(4).GetChild(2).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Experiencia Entrenando") + ":";

                Dropdown player = this.transform.GetChild(0).GetChild(4).GetChild(1).GetComponent<Dropdown>();
                player.ClearOptions();
                List<string> playerOptions = new List<string>();

                Dropdown trainer = this.transform.GetChild(0).GetChild(4).GetChild(3).GetComponent<Dropdown>();
                trainer.ClearOptions();
                List<string> trainerOptions = new List<string>();

                Dropdown continentDropdown = this.transform.GetChild(0).GetChild(3).GetChild(1).GetComponent<Dropdown>();
                continentDropdown.ClearOptions();
                List<string> continentList = new List<string>();

                Dropdown yearDropdown = this.transform.GetChild(0).GetChild(2).GetChild(5).GetComponent<Dropdown>();

                oceania.Add(controller.GetDataBase().GetTranslatedWord("Australia"));
                oceania.Add(controller.GetDataBase().GetTranslatedWord("N. Zelanda"));
                oceania.Add(controller.GetDataBase().GetTranslatedWord("Samoa"));
                oceania.Add(controller.GetDataBase().GetTranslatedWord("Tonga"));

                continentList.Add(controller.GetDataBase().GetTranslatedWord("África"));
                continentList.Add(controller.GetDataBase().GetTranslatedWord("América"));
                continentList.Add(controller.GetDataBase().GetTranslatedWord("Asia"));
                continentList.Add(controller.GetDataBase().GetTranslatedWord("Europa"));
                continentList.Add(controller.GetDataBase().GetTranslatedWord("Oceanía"));

                playerOptions.Add(controller.GetDataBase().GetTranslatedWord("Estrella mundial"));
                playerOptions.Add(controller.GetDataBase().GetTranslatedWord("Se me reconoce"));
                playerOptions.Add(controller.GetDataBase().GetTranslatedWord("Suplente habitual"));
                playerOptions.Add(controller.GetDataBase().GetTranslatedWord("Debuté"));
                playerOptions.Add(controller.GetDataBase().GetTranslatedWord("Ni pisé la arena"));

                trainerOptions.Add(controller.GetDataBase().GetTranslatedWord("Leyenda viva"));
                trainerOptions.Add(controller.GetDataBase().GetTranslatedWord("Gran maestro"));
                trainerOptions.Add(controller.GetDataBase().GetTranslatedWord("Habitual del banquillo"));
                trainerOptions.Add(controller.GetDataBase().GetTranslatedWord("Duré poco"));
                trainerOptions.Add(controller.GetDataBase().GetTranslatedWord("Mi primer día"));

                africa.Add(controller.GetDataBase().GetTranslatedWord("Angola"));
                africa.Add(controller.GetDataBase().GetTranslatedWord("Argelia"));
                africa.Add(controller.GetDataBase().GetTranslatedWord("Burkina"));
                africa.Add(controller.GetDataBase().GetTranslatedWord("Camerún"));
                africa.Add(controller.GetDataBase().GetTranslatedWord("Egipto"));
                africa.Add(controller.GetDataBase().GetTranslatedWord("Ghana"));
                africa.Add(controller.GetDataBase().GetTranslatedWord("Guinea"));
                africa.Add(controller.GetDataBase().GetTranslatedWord("Marruecos"));
                africa.Add(controller.GetDataBase().GetTranslatedWord("Nigeria"));
                africa.Add(controller.GetDataBase().GetTranslatedWord("Senegal"));
                africa.Add(controller.GetDataBase().GetTranslatedWord("Sudáfrica"));
                africa.Add(controller.GetDataBase().GetTranslatedWord("Togo"));

                asia.Add(controller.GetDataBase().GetTranslatedWord("Arabia"));
                asia.Add(controller.GetDataBase().GetTranslatedWord("China"));
                asia.Add(controller.GetDataBase().GetTranslatedWord("EAU"));
                asia.Add(controller.GetDataBase().GetTranslatedWord("Filipinas"));
                asia.Add(controller.GetDataBase().GetTranslatedWord("India"));
                asia.Add(controller.GetDataBase().GetTranslatedWord("Irán"));
                asia.Add(controller.GetDataBase().GetTranslatedWord("Israel"));
                asia.Add(controller.GetDataBase().GetTranslatedWord("Japón"));
                asia.Add(controller.GetDataBase().GetTranslatedWord("Corea"));
                asia.Add(controller.GetDataBase().GetTranslatedWord("Malasia"));
                asia.Add(controller.GetDataBase().GetTranslatedWord("Pakistán"));
                asia.Add(controller.GetDataBase().GetTranslatedWord("Singapur"));
                asia.Add(controller.GetDataBase().GetTranslatedWord("Tailandia"));
                asia.Add(controller.GetDataBase().GetTranslatedWord("Vietnam"));

                europa.Add(controller.GetDataBase().GetTranslatedWord("España"));
                europa.Add(controller.GetDataBase().GetTranslatedWord("GB"));
                europa.Add(controller.GetDataBase().GetTranslatedWord("Francia"));
                europa.Add(controller.GetDataBase().GetTranslatedWord("Italia"));
                europa.Add(controller.GetDataBase().GetTranslatedWord("Alemania"));
                europa.Add(controller.GetDataBase().GetTranslatedWord("Croacia"));
                europa.Add(controller.GetDataBase().GetTranslatedWord("Dinamarca"));
                europa.Add(controller.GetDataBase().GetTranslatedWord("Finlandia"));
                europa.Add(controller.GetDataBase().GetTranslatedWord("Grecia"));
                europa.Add(controller.GetDataBase().GetTranslatedWord("Irlanda"));
                europa.Add(controller.GetDataBase().GetTranslatedWord("Islandia"));
                europa.Add(controller.GetDataBase().GetTranslatedWord("Polonia"));
                europa.Add(controller.GetDataBase().GetTranslatedWord("Portugal"));
                europa.Add(controller.GetDataBase().GetTranslatedWord("Rusia"));
                europa.Add(controller.GetDataBase().GetTranslatedWord("Suecia"));
                europa.Add(controller.GetDataBase().GetTranslatedWord("Ucrania"));
                europa.Add(controller.GetDataBase().GetTranslatedWord("Serbia"));

                america.Add(controller.GetDataBase().GetTranslatedWord("Argentina"));
                america.Add(controller.GetDataBase().GetTranslatedWord("Brasil"));
                america.Add(controller.GetDataBase().GetTranslatedWord("Canada"));
                america.Add(controller.GetDataBase().GetTranslatedWord("Chile"));
                america.Add(controller.GetDataBase().GetTranslatedWord("Colombia"));
                america.Add(controller.GetDataBase().GetTranslatedWord("C. Rica"));
                america.Add(controller.GetDataBase().GetTranslatedWord("Cuba"));
                america.Add(controller.GetDataBase().GetTranslatedWord("Ecuador"));
                america.Add(controller.GetDataBase().GetTranslatedWord("Honduras"));
                america.Add(controller.GetDataBase().GetTranslatedWord("Jamaica"));
                america.Add(controller.GetDataBase().GetTranslatedWord("México"));
                america.Add(controller.GetDataBase().GetTranslatedWord("Nicaragua"));
                america.Add(controller.GetDataBase().GetTranslatedWord("Paraguay"));
                america.Add(controller.GetDataBase().GetTranslatedWord("Perú"));
                america.Add(controller.GetDataBase().GetTranslatedWord("Salvador"));
                america.Add(controller.GetDataBase().GetTranslatedWord("Uruguay"));
                america.Add(controller.GetDataBase().GetTranslatedWord("EEUU"));

                yearDropdown.ClearOptions();

                for(int i = 2002; i >= 1920; i--)
                {
                    yearList.Add(i.ToString());
                }

                player.AddOptions(playerOptions);
                trainer.AddOptions(trainerOptions);
                continentDropdown.AddOptions(continentList);
                yearDropdown.AddOptions(yearList);

                //Botón siguiente
                this.transform.GetChild(0).GetChild(5).GetChild(0).GetChild(0).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Siguiente");

                CheckMonth();
                ChangeContinent();
            }
        }
    }



    void NewClubActive(bool on)
    {
        this.gameObject.SetActive(on);

        if (on)
        {
            int newLanguage = controller.GetDataBase().GetLanguage();

            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(true);

            if (actualLanguageClub != newLanguage)
            {
                actualLanguageClub = newLanguage;

                //Botón volver
                this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Volver");

                //Lista de opciones
                this.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Dropdown>().ClearOptions();
                List<string> continentOptions = new List<string>();

                continentOptions.Add(db.GetTranslatedWord("África"));
                continentOptions.Add(db.GetTranslatedWord("América"));
                continentOptions.Add(db.GetTranslatedWord("Asia"));
                continentOptions.Add(db.GetTranslatedWord("Europa"));
                continentOptions.Add(db.GetTranslatedWord("Oceanía"));

                this.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Dropdown>().AddOptions(continentOptions);

                UpdateCountryDropdown();

                this.transform.GetChild(1).GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Crear");
            }
        }
    }


    //Actualiza las ligas en función del continente
    public void UpdateCountryDropdown()
    {
        this.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Dropdown>().ClearOptions();
        List<string> leagueOptions = new List<string>();

        int continentClub = this.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Dropdown>().value;
        int countryClub = this.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Dropdown>().value;
        int division = this.transform.GetChild(1).GetChild(1).GetChild(2).GetComponent<Dropdown>().value;

        if (continentClub == 0)
        {
            leagueOptions.Add(db.GetTranslatedWord("Egipto"));
            leagueOptions.Add(db.GetTranslatedWord("Nigeria"));
            leagueOptions.Add(db.GetTranslatedWord("Sudáfrica"));
        }
        else if (continentClub == 1)
        {
            leagueOptions.Add(db.GetTranslatedWord("Brasil"));
            leagueOptions.Add(db.GetTranslatedWord("Canada"));
            leagueOptions.Add(db.GetTranslatedWord("EEUU"));
        }
        else if (continentClub == 2)
        {
            leagueOptions.Add(db.GetTranslatedWord("China"));
            leagueOptions.Add(db.GetTranslatedWord("Corea"));
            leagueOptions.Add(db.GetTranslatedWord("Japón"));
        }
        else if (continentClub == 3)
        {
            leagueOptions.Add(db.GetTranslatedWord("Alemania"));
            leagueOptions.Add(db.GetTranslatedWord("España"));
            leagueOptions.Add(db.GetTranslatedWord("GB"));
        }
        else
        {
            leagueOptions.Add(db.GetTranslatedWord("Australia"));
            leagueOptions.Add(db.GetTranslatedWord("N. Zelanda"));
        }

        this.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Dropdown>().AddOptions(leagueOptions);

        UpdateClubInfo(continentClub, countryClub, -1, division);
    }


    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Actualiza la información sobre el club seleccionado //////////////////////////////////////////////////////////////////////////////////////////////////////////
    void UpdateClubInfo(int continentClub, int countryClub, int club, int division)
    {
        GameObject clubInfo = this.transform.GetChild(1).GetChild(0).GetChild(1).gameObject;

        if (club != -1)
        {
            Club targetClub;

            if (continentClub == 0)
            {
                if (countryClub == 0)
                {
                    if (division == 0)
                    {
                        targetClub = db.GetArgelianL1Club(club);
                    }
                    else
                    {
                        targetClub = db.GetArgelianL2Club(club);
                    }
                }
                else if (countryClub == 1)
                {
                    if (division == 0)
                    {
                        targetClub = db.GetNigerianL1Club(club);
                    }
                    else
                    {
                        targetClub = db.GetNigerianL2Club(club);
                    }
                }
                else
                {
                    if (division == 0)
                    {
                        targetClub = db.GetSAfricaL1Club(club);
                    }
                    else
                    {
                        targetClub = db.GetSAfricaL1Club(club);
                    }
                }
            }
            else if (continentClub == 1)
            {
                if (countryClub == 0)
                {
                    if (division == 0)
                    {
                        targetClub = db.GetBrasilianL1Club(club);
                    }
                    else
                    {
                        targetClub = db.GetBrasilianL2Club(club);
                    }
                }
                else if (countryClub == 1)
                {
                    if (division == 0)
                    {
                        targetClub = db.GetCanadianL1Club(club);
                    }
                    else
                    {
                        targetClub = db.GetCanadianL2Club(club);
                    }
                }
                else
                {
                    if (division == 0)
                    {
                        targetClub = db.GetAmericanL1Club(club);
                    }
                    else
                    {
                        targetClub = db.GetAmericanL2Club(club);
                    }
                }
            }
            else if (continentClub == 2)
            {
                if (countryClub == 0)
                {
                    if (division == 0)
                    {
                        targetClub = db.GetChineseL1Club(club);
                    }
                    else
                    {
                        targetClub = db.GetChineseL2Club(club);
                    }
                }
                else if (countryClub == 1)
                {
                    if (division == 0)
                    {
                        targetClub = db.GetKoreanL1Club(club);
                    }
                    else
                    {
                        targetClub = db.GetKoreanL2Club(club);
                    }
                }
                else
                {
                    if (division == 0)
                    {
                        targetClub = db.GetJapanL1Club(club);
                    }
                    else
                    {
                        targetClub = db.GetJapanL2Club(club);
                    }
                }
            }
            else if (continentClub == 3)
            {
                if (countryClub == 0)
                {
                    if (division == 0)
                    {
                        targetClub = db.GetRussianL1Club(club);
                    }
                    else
                    {
                        targetClub = db.GetRussianL2Club(club);
                    }
                }
                else if (countryClub == 1)
                {
                    if (division == 0)
                    {
                        targetClub = db.GetSpanishL1Club(club);
                    }
                    else
                    {
                        targetClub = db.GetSpanishL2Club(club);
                    }
                }
                else
                {
                    if (division == 0)
                    {
                        targetClub = db.GetUkL1Club(club);
                    }
                    else
                    {
                        targetClub = db.GetUkL1Club(club);
                    }
                }
            }
            else
            {
                if (countryClub == 0)
                {
                    if (division == 0)
                    {
                        targetClub = db.GetAustralianL1Club(club);
                    }
                    else
                    {
                        targetClub = db.GetAustralianL2Club(club);
                    }
                }
                else
                {
                    if (division == 0)
                    {
                        targetClub = db.GetNzL1Club(club);
                    }
                    else
                    {
                        targetClub = db.GetNzL2Club(club);
                    }
                }
            }

            int reputation = targetClub.reputation;
            int economy = targetClub.economyStatus;
            int position = targetClub.expectedLeaguePosition;
            //bool continental = targetClub.continentQua;
            //bool world = targetClub.worldQua;

            clubInfo.transform.GetChild(0).GetComponent<Text>().text = db.GetTranslatedWord("Reputación");

            for (int i = 0; i < 5; i++)
            {
                if(reputation > i)
                {
                    clubInfo.transform.GetChild(1).GetChild(i).GetComponent<Image>().sprite = redStar;
                }
                else
                {
                    clubInfo.transform.GetChild(1).GetChild(i).GetComponent<Image>().sprite = blackStar;
                }
            }

            if(economy == 0)
            {
                clubInfo.transform.GetChild(2).GetComponent<Text>().text = db.GetTranslatedWord("Economia") + ": " + db.GetTranslatedWord("Rico");
            }
            else if (economy == 1)
            {
                clubInfo.transform.GetChild(2).GetComponent<Text>().text = db.GetTranslatedWord("Economia") + ": " + db.GetTranslatedWord("Potente");
            }
            else if (economy == 2)
            {
                clubInfo.transform.GetChild(2).GetComponent<Text>().text = db.GetTranslatedWord("Economia") + ": " + db.GetTranslatedWord("Estable");
            }
            else if (economy == 3)
            {
                clubInfo.transform.GetChild(2).GetComponent<Text>().text = db.GetTranslatedWord("Economia") + ": " + db.GetTranslatedWord("Aceptable");
            }
            else if (economy == 4)
            {
                clubInfo.transform.GetChild(2).GetComponent<Text>().text = db.GetTranslatedWord("Economia") + ": " + db.GetTranslatedWord("Deficiente");
            }


            clubInfo.transform.GetChild(3).GetComponent<Text>().text = db.GetTranslatedWord("Prevision") + ": " + position + "º";

            string auxYes;
            /*
            if (continental)
            {
                auxYes = db.GetTranslatedWord("Si");
            }
            else
            {
                auxYes = db.GetTranslatedWord("No");
            }
            */
            auxYes = db.GetTranslatedWord("No");

            clubInfo.transform.GetChild(4).GetComponent<Text>().text = db.GetTranslatedWord("Conti") + ": " + auxYes;
            /*
            if (world)
            {
                auxYes = db.GetTranslatedWord("Si");
            }
            else
            {
                auxYes = db.GetTranslatedWord("No");
            }
            */
            auxYes = db.GetTranslatedWord("No");
            clubInfo.transform.GetChild(5).GetComponent<Text>().text = db.GetTranslatedWord("Mundial") + ": " + auxYes;
        }
        else
        {
            selectedClub = club;

            for (int i = 0; i < 5; i++)
            {
                clubInfo.transform.GetChild(1).GetChild(i).GetComponent<Image>().sprite = blackStar;
            }

            clubInfo.transform.GetChild(2).GetComponent<Text>().text = db.GetTranslatedWord("Economia") + ": ";
            clubInfo.transform.GetChild(3).GetComponent<Text>().text = db.GetTranslatedWord("Prevision") + ": ";
            clubInfo.transform.GetChild(4).GetComponent<Text>().text = db.GetTranslatedWord("Conti") + ": ";
            clubInfo.transform.GetChild(5).GetComponent<Text>().text = db.GetTranslatedWord("Mundial") + ": ";

            for(int i = 0; i < 10; i++)
            {
                Club targetClub;

                if (continentClub == 0)
                {
                    if (countryClub == 0)
                    {
                        if (division == 0)
                        {
                            targetClub = db.GetArgelianL1Club(i);
                        }
                        else
                        {
                            targetClub = db.GetArgelianL2Club(i);
                        }
                    }
                    else if (countryClub == 1)
                    {
                        if (division == 0)
                        {
                            targetClub = db.GetNigerianL1Club(i);
                        }
                        else
                        {
                            targetClub = db.GetNigerianL2Club(i);
                        }
                    }
                    else
                    {
                        if (division == 0)
                        {
                            targetClub = db.GetSAfricaL1Club(i);
                        }
                        else
                        {
                            targetClub = db.GetSAfricaL1Club(i);
                        }
                    }
                }
                else if (continentClub == 1)
                {
                    if (countryClub == 0)
                    {
                        if (division == 0)
                        {
                            targetClub = db.GetBrasilianL1Club(i);
                        }
                        else
                        {
                            targetClub = db.GetBrasilianL2Club(i);
                        }
                    }
                    else if (countryClub == 1)
                    {
                        if (division == 0)
                        {
                            targetClub = db.GetCanadianL1Club(i);
                        }
                        else
                        {
                            targetClub = db.GetCanadianL2Club(i);
                        }
                    }
                    else
                    {
                        if (division == 0)
                        {
                            targetClub = db.GetAmericanL1Club(i);
                        }
                        else
                        {
                            targetClub = db.GetAmericanL2Club(i);
                        }
                    }
                }
                else if (continentClub == 2)
                {
                    if (countryClub == 0)
                    {
                        if (division == 0)
                        {
                            targetClub = db.GetChineseL1Club(i);
                        }
                        else
                        {
                            targetClub = db.GetChineseL2Club(i);
                        }
                    }
                    else if (countryClub == 1)
                    {
                        if (division == 0)
                        {
                            targetClub = db.GetKoreanL1Club(i);
                        }
                        else
                        {
                            targetClub = db.GetKoreanL2Club(i);
                        }
                    }
                    else
                    {
                        if (division == 0)
                        {
                            targetClub = db.GetJapanL1Club(i);
                        }
                        else
                        {
                            targetClub = db.GetJapanL2Club(i);
                        }
                    }
                }
                else if (continentClub == 3)
                {
                    if (countryClub == 0)
                    {
                        if (division == 0)
                        {
                            targetClub = db.GetRussianL1Club(i);
                        }
                        else
                        {
                            targetClub = db.GetRussianL2Club(i);
                        }
                    }
                    else if (countryClub == 1)
                    {
                        if (division == 0)
                        {
                            targetClub = db.GetSpanishL1Club(i);
                        }
                        else
                        {
                            targetClub = db.GetSpanishL2Club(i);
                        }
                    }
                    else
                    {
                        if (division == 0)
                        {
                            targetClub = db.GetUkL1Club(i);
                        }
                        else
                        {
                            targetClub = db.GetUkL1Club(i);
                        }
                    }
                }
                else
                {
                    if (countryClub == 0)
                    {
                        if (division == 0)
                        {
                            targetClub = db.GetAustralianL1Club(i);
                        }
                        else
                        {
                            targetClub = db.GetAustralianL2Club(i);
                        }
                    }
                    else
                    {
                        if (division == 0)
                        {
                            targetClub = db.GetNzL1Club(i);
                        }
                        else
                        {
                            targetClub = db.GetNzL2Club(i);
                        }
                    }
                }

                this.transform.GetChild(1).GetChild(1).GetChild(3 + i).GetChild(0).GetComponent<Text>().text = targetClub.clubName;
                this.transform.GetChild(1).GetChild(1).GetChild(3 + i).GetChild(2).GetComponent<Image>().sprite = targetClub.logo;
            }
        }
    }



    public void SelectClubButton(int club)
    {
        int continentClub = this.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Dropdown>().value;
        int countryClub = this.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Dropdown>().value;
        int division = this.transform.GetChild(1).GetChild(1).GetChild(2).GetComponent<Dropdown>().value;
        selectedClub = club;

        UpdateClubInfo(continentClub, countryClub, club, division);
    }


    // Actualiza la interfaz al cambiar continente, pais o division
    public void ChangeValueInterface()
    {
        StartCoroutine(UpdateInterface());
    }



    IEnumerator UpdateInterface()
    {
        yield return new WaitForEndOfFrame();

        int continentClub = this.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Dropdown>().value;
        int countryClub = this.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Dropdown>().value;
        int division = this.transform.GetChild(1).GetChild(1).GetChild(2).GetComponent<Dropdown>().value;

        UpdateClubInfo(continentClub, countryClub, -1, division);
        ActivateCreate(false);
    }


    //Activa la opción de crear partida
    public void ActivateCreate(bool on)
    {
        this.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<Button>().interactable = on;
    }



    public void CreateNewGame()
    {
        int continentClub = this.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Dropdown>().value;
        int countryClub = this.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Dropdown>().value;
        int division = this.transform.GetChild(1).GetChild(1).GetChild(2).GetComponent<Dropdown>().value;
        int clubIndex = division * 10 + selectedClub;
        
        controller.GetDataBase().SetTrainingClub(continentClub, countryClub, division, clubIndex);
        NewGameActive(false);
        controller.ActiveMainMenu(false);
        controller.GetGameMenu().StartGame();
    }
}
