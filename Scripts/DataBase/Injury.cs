using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Injury : MonoBehaviour
{
    public enum InjuryType
    {
        NULL
    }

    public InjuryType injuryType;

    public int duration;

    public Injury() { }

    public Injury StartInjury(int value)
    {
        switch (value)
        {
            case -1:
                injuryType = InjuryType.NULL;
                duration = 0;

                break;
        }
        return this;
    }
}
