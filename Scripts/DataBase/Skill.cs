using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : System.Object
{
    public enum Hability
    {
        NULL,
        EXTRADAMAGE
    }

    public Hability hability;

    public int power; //0 - bronce 1 - plata 2 - oro


    public Skill() { }


    public Skill StartSkill(int value, int powerValue)
    {
        switch (value)
        {
            case -1:
                hability = Hability.NULL;
                power = powerValue;

                break;
        }

        return this;
    } 
}
