using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour //clase encargada del control de escenas y demás elementos de gestión
{
    DataBase dataBase;
    SelectLanguage selectLanguage;
    MainMenu mainMenu;
    NewGame newGame;
    GameMenu gameMenu;


    void Awake()
    {
        dataBase = this.GetComponent<DataBase>();
        selectLanguage = GameObject.Find("Language").GetComponent<SelectLanguage>();
        mainMenu = GameObject.Find("MainMenu").GetComponent<MainMenu>();
        newGame = GameObject.Find("NewGame").GetComponent<NewGame>();
        gameMenu = GameObject.Find("Game").GetComponent<GameMenu>();
    }



    private void Start()
    {
        ActiveLanguageMenu(true);
        ActiveMainMenu(false);
        ActiveNewGame(false);
    }


    ///////////////////////////////////////////////////////////////////////////////////////
    /// Métodos de activación de menús ////////////////////////////////////////////////////
    void ActiveLanguageMenu(bool on)
    {
        selectLanguage.ActiveLanguageMenu(on);
    }



    public void ActiveMainMenu(bool on)
    {
        mainMenu.ActiveMainMenu(on);
    }



    public void ActiveNewGame(bool on)
    {
        newGame.NewGameActive(on);
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Devolución de base de datos //////////////////////////////////////////////////////////
    public DataBase GetDataBase()
    {
        return dataBase;
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Determina el idioma seleccionado y cambia de menú ////////////////////////////////////
    public void LanguageSelected()
    {
        ActiveLanguageMenu(false);
        ActiveMainMenu(true);
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    /// Devuelve el gameMenu /////////////////////////////////////////////////////////////////
    public GameMenu GetGameMenu()
    {
        return gameMenu;
    }
}
