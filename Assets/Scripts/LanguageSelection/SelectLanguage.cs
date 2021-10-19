using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLanguage : MonoBehaviour
{
    int posIdioma; //0 - español 1 - ingles
    int row, column; //fila y columna en el menu de idiomas

    bool idiomaActivo; //true menú selección idioma activo, false idioma ya seleccionado

    Controller controller;
    ColorBlock colors;

    
    void Start()
    {
        posIdioma = 0;
        row = 0;
        column = 0;

        controller = GameObject.Find("Controller").GetComponent<Controller>();

        this.transform.GetChild(0).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Selecciona tu idioma"); //Obtenemos el titulo traducido inicialmente al español

        colors = this.transform.GetChild(1).GetChild(row).GetComponent<Button>().colors;
        colors.normalColor = new Color32(255, 255, 65, 50); //Establecemos el color inicial del boton marcado
        this.transform.GetChild(1).GetChild(row).GetComponent<Button>().colors = colors;
    }

    
    
    void Update()
    {
        if (idiomaActivo)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                ChangePosition(-1, 0);
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                ChangePosition(1, 0);
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ChangePosition(0, -1);
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                ChangePosition(0, 1);
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                SelectLanguageMethod(posIdioma);
            }
        }
    }


    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// Selecciona el idioma a usar  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void SelectLanguageMethod (int pos)
    {
        controller.GetDataBase().SetLanguage(pos);
        controller.LanguageSelected();
    }


    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// Activa el menú de idioma  ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void ActiveLanguageMenu (bool on)
    {
        idiomaActivo = on;

        this.gameObject.SetActive(on);
    }


    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// Actualiza interfaz en función del idioma marcado cambiando texto y sombreado del botón //////////////////////////////////////////////////////////////////////////
    void ChangePosition(int vertical, int horizontal)
    {
        colors.normalColor = new Color32(255, 255, 65, 0);
        this.transform.GetChild(1).GetChild(row).GetComponent<Button>().colors = colors;

        row += vertical;
        //column += horizontal;

        if(row > 1)
        {
            row = 0;
        }
        else if (row < 0)
        {
            row = 1;
        }

        /*
        if (column > 1)
        {
            column = 0;
        }
        else if (row < 0)
        {
            column = 1;
        }
        */

        posIdioma = row;

        colors.normalColor = new Color32(255, 255, 65, 50);
        this.transform.GetChild(1).GetChild(row).GetComponent<Button>().colors = colors;

        CambiaTexto();
    }



    void CambiaTexto()
    {
        controller.GetDataBase().SetLanguage(posIdioma);

        this.transform.GetChild(0).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Selecciona tu idioma"); //Obtenemos el titulo traducido

        this.transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Mover"); //Obtenemos la palabra mover
        this.transform.GetChild(2).GetChild(1).GetChild(1).GetComponent<Text>().text = controller.GetDataBase().GetTranslatedWord("Seleccionar"); //Obtenemos la palabra seleccionar
    }
}
