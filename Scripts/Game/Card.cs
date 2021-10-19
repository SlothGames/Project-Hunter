using UnityEngine;


[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public enum Type
    {
        ATTACK,     //Ataque directo
        DEFENSE,    //Defensa directa
        SUPPORT,    //Apoyo a un aliado
        NEGATIVE    //Efecto negativo a un enemigo
    }

    public enum Effect
    {
        NONE,       //Ninguno
        REPETITION, //Se lanza varias veces
        JUMP        //Puede atacar a otra linea
    }

    public enum Support
    {
        NONE,
        HEALTH,
        ATTACK,
        DEFENSE,
        POISON,
        CONFUSION,
        PARALYZE,
        BLEED,
        BLIND,
        JUMPER,
        REPETITIVE,
        RECOVERYMANA
    }

    public new string name;
    public string englishName;
    public string description;
    public string englishDescription;

    public Sprite artWork;
    public Sprite background;

    public int manaCost;
    public int power;
    
    public Type type;
    public Effect effect;
    public Support support;

    public int repetition;
    public int percentage;

    public bool used;
}
