using System;
using System.Collections.Generic;


[System.Serializable]
public class Player : object
{
    public enum Position
    {
        ARPONER,
        SHIELD,
        ARCHER,
        MAGICIAN,
        EXECUTER,
        PALADIN,
        WOLF,
        ROBOT
    }

    public string playerSurname;
    public string playerName;

    public int id;

    //public int continent;
    //public int country;
    //public int day, month, year;

    public Position position; // posicion predominante
    public int line, linePosition;

    //Estadisticas
    public int life, actualLife;
    public int energy, actualEnergy;
    public int experience, actualExperience;

    public int level;
    public int quality;

    //Estadisticas en combate
    public int attack;            
    public int defence;           
    public int actualAttack, actualDefence;     //Valor total de defensa acumulada en el turno
    public int kills;
    public int energyRecovery;
    public int actualEnergyRecovery;

    //habilidades especiales
    public Skill[] skills;

    //Cartas
    public Card[] habilitys;

    //Salud
    //public Injury injury;
    public int totalStates;
    public List<int> states;

    public bool jumper;
    public bool repetitive;
    public bool confusion, paralyze, bleed, blind, poison;
    public int confusionTurn, paralyzeTurn, bleedTurn, blindTurn, poisonTurn, jumperTurn, repetitiveTurn;
    //public int confusionPercentage, paralyzePercentage, blindPercentage;

    //Salario
    public float monyMonth;
    public int contractYears;

    //Valor mercado
    public int value;

    public int happines; //0 - infeliz, 1 - poco feliz 2 - aceptable 3 - feliz 4 - excelente


    public Player() { }


    public Player StartPlayer(int index)
    {
        id = index;
        happines = 2;

        jumper = repetitive = false;
        confusionTurn = paralyzeTurn = bleedTurn = blindTurn = poisonTurn = jumperTurn = repetitiveTurn = 0;

        line = -1;
        linePosition = -1;

        //injury = new Injury();
        //injury.StartInjury(-1);

        totalStates = 0;
        states = new List<int>();

        experience = 0;

        attack = actualAttack = 0;
        defence = actualDefence = 0;

        kills = 0;
        energyRecovery = 10;

        habilitys = new Card[5];

        switch (index)
        {
            case 0:
                playerName = "Antonio";
                playerSurname = "Fernández";

                position = Position.PALADIN;

                //Estadisticas
                life = 80;
                energy = 15;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
            case 1:
                playerName = "Joaquín";
                playerSurname = "Ñíguez";

                position = Position.MAGICIAN;

                //Estadisticas
                life = 50;
                energy = 50;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
            case 2:
                playerName = "Lola";
                playerSurname = "Ruiz";

                position = Position.ARCHER;

                //Estadisticas
                life = 80;
                energy = 15;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
            case 3:
                playerName = "Nombre";
                playerSurname = "Apellido";

                position = Position.ARPONER;

                //Estadisticas
                life = 80;
                energy = 15;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
            case 4:
                playerName = "Nombre";
                playerSurname = "Apellido";

                position = Position.SHIELD;

                //Estadisticas
                life = 80;
                energy = 15;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
            case 5:
                playerName = "Nombre";
                playerSurname = "Apellido";

                position = Position.PALADIN;

                //Estadisticas
                life = 80;
                energy = 15;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
            case 6:
                playerName = "Nombre";
                playerSurname = "Apellido";

                position = Position.PALADIN;

                //Estadisticas
                life = 80;
                energy = 15;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
            case 7:
                playerName = "Visitante";
                playerSurname = "Uno";

                position = Position.SHIELD;

                //Estadisticas
                life = 40;
                energy = 25;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
            case 8:
                playerName = "Visitante";
                playerSurname = "Dos";

                position = Position.EXECUTER;

                //Estadisticas
                life = 40;
                energy = 20;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
            case 9:
                playerName = "Visitante";
                playerSurname = "Tres";

                position = Position.PALADIN;

                //Estadisticas
                life = 5;
                energy = 30;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
            case 10:
                playerName = "Visitante";
                playerSurname = "Cuatro";

                position = Position.ARPONER;

                //Estadisticas
                life = 5;
                energy = 25;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
            case 11:
                playerName = "Nombre";
                playerSurname = "Apellido";

                position = Position.PALADIN;

                //Estadisticas
                life = 80;
                energy = 15;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
            case 12:
                playerName = "Nombre";
                playerSurname = "Apellido";

                position = Position.PALADIN;

                //Estadisticas
                life = 80;
                energy = 15;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
            case 13:
                playerName = "Nombre";
                playerSurname = "Apellido";

                position = Position.PALADIN;

                //Estadisticas
                life = 80;
                energy = 15;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
            case 14:
                playerName = "Nombre";
                playerSurname = "Apellido";

                position = Position.PALADIN;

                //Estadisticas
                life = 80;
                energy = 15;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
            case 15:
                playerName = "Nombre";
                playerSurname = "Apellido";

                position = Position.PALADIN;

                //Estadisticas
                life = 80;
                energy = 15;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
            case 16:
                playerName = "Antonio";
                playerSurname = "Fernández";

                position = Position.PALADIN;

                //Estadisticas
                life = 80;
                energy = 15;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
            case 18:
                playerName = "Antonio";
                playerSurname = "Fernández";

                position = Position.PALADIN;

                //Estadisticas
                life = 80;
                energy = 15;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
            case 19:
                playerName = "Antonio";
                playerSurname = "Fernández";

                position = Position.PALADIN;

                //Estadisticas
                life = 80;
                energy = 15;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
            case 20:
                playerName = "Antonio";
                playerSurname = "Fernández";

                position = Position.PALADIN;

                //Estadisticas
                life = 80;
                energy = 15;

                //Salario
                monyMonth = 0;
                contractYears = 0;

                //Valor mercado
                value = 0;

                break;
        }
        return this;
    }
}
