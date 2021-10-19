using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    int actualLanguage;

    Controller controller;



    void Awake()
    {
        actualLanguage = 0;

        controller = GameObject.Find("Controller").GetComponent<Controller>();
    }



    public void ActiveMainMenu(bool on)
    {
        this.gameObject.SetActive(on);

        if (on)
        {
            int newLanguage = controller.GetDataBase().GetLanguage();

            if (actualLanguage != newLanguage)
            {
                //Nueva Partida
                this.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Nueva Partida");
                this.transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Elige un equipo y empieza tu aventura");

                //Crear Equipo
                this.transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Crear Club");
                this.transform.GetChild(2).GetChild(1).GetChild(1).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Diseña y gestiona tu propio club");

                //Cargar Partida
                this.transform.GetChild(2).GetChild(2).GetChild(0).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Cargar Partida");
                this.transform.GetChild(2).GetChild(2).GetChild(1).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Carga una partida guardada");

                //Opciones
                this.transform.GetChild(2).GetChild(3).GetChild(0).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Opciones");
                this.transform.GetChild(2).GetChild(3).GetChild(1).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Cambia los ajustes del juego");

                //Créditos
                this.transform.GetChild(2).GetChild(4).GetChild(0).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Créditos");

                //Salir
                this.transform.GetChild(2).GetChild(5).GetChild(0).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Salir");

                actualLanguage = newLanguage;
            }
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// Nueva partida ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void OpenNewGame(bool on)
    {

        if (on)
        {

        }
    }

   

    void NewGame()
    {
        
    }


    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// Crear club ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void OpenCreateMenu(bool on)
    {

    }
    


    void CreateClub()
    {

    }


    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// Cargar partida ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void OpenLoadMenu(bool on)
    {

    }


    public void LoadGame()
    {

    }


    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// Menú opciones ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void OpenOptionMenu(bool on)
    {

    }


    public void OptionMenu()
    {

    }


    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// Créditos /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void OpenCreditMenu(bool on)
    {
        
    }


    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// Salir juego //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void ExitGame()
    {
        Application.Quit();
    }
}
