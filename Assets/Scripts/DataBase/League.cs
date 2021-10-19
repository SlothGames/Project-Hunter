using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class League : System.Object
{
    public string leagueName;

    public int totalPrize;

    public int ascent, descent;
    public int actualMatch;
    public int[] day, month; //Fechas del partido

    public int[,] matchs;
    public int[,] matchs1;
    public int[,] matchs2;
    public int[,] matchs3;
    public int[,] matchs4;
    public int[,] matchs5;
    public int[,] matchs6;
    public int[,] matchs7;
    public int[,] matchs8;
    public int[,] matchs9;
    public int[,] matchs10;
    public int[,] matchs11;
    public int[,] matchs12;
    public int[,] matchs13;
    public int[,] matchs14;
    public int[,] matchs15;
    public int[,] matchs16;
    public int[,] matchs17;

    public List<bool> played;
    public List<int> localScore;
    public List<int> visitorScore;

    public League() { }

    public void StartLeague (int continent, int country, int division)
    {
        actualMatch = 0;

        day = new int[18];
        month = new int[18];

        matchs = new int[5, 2];
        matchs1 = new int[5, 2];
        matchs2 = new int[5, 2];
        matchs3 = new int[5, 2];
        matchs4 = new int[5, 2];
        matchs5 = new int[5, 2];
        matchs6 = new int[5, 2];
        matchs7 = new int[5, 2];
        matchs8 = new int[5, 2];
        matchs9 = new int[5, 2];
        matchs10 = new int[5, 2];
        matchs11 = new int[5, 2];
        matchs12 = new int[5, 2];
        matchs13 = new int[5, 2];
        matchs14 = new int[5, 2];
        matchs15 = new int[5, 2];
        matchs16 = new int[5, 2];
        matchs17 = new int[5, 2];

        StartMatchs();

        ascent = descent = -1;

        played = new List<bool>();
        localScore = new List<int>();
        visitorScore = new List<int>();

        if (continent == 0)
        {
            if (country == 0)
            {
                if (division == 0)
                {
                    leagueName = "Algérie L1";

                    totalPrize = 50000000;
                }
                else
                {
                    leagueName = "Algérie L2";

                    totalPrize = 25000000;
                }
            }
            else if (country == 1)
            {
                if (division == 0)
                {
                    leagueName = "Nigerian Super League";

                    totalPrize = 75000000;
                }
                else
                {
                    leagueName = "Nigerian Honor League";

                    totalPrize = 37000000;
                }
            }
            else
            {
                if (division == 0)
                {
                    leagueName = "Suid-Afrikaanse League";

                    totalPrize = 60000000;
                }
                else
                {
                    leagueName = "Tweede Suid-Afrikaanse";

                    totalPrize = 30000000;
                }
            }
        }
        else if (continent == 1)
        {
            if (country == 0)
            {
                if (division == 0)
                {
                    leagueName = "Brasileirão A";

                    totalPrize = 40000000;
                }
                else
                {
                    leagueName = "Brasileirão B";

                    totalPrize = 20000000;
                }
            }
            else if (country == 1)
            {
                if (division == 0)
                {
                    leagueName = "Canadian Supreme League";

                    totalPrize = 70000000;
                }
                else
                {
                    leagueName = "Canadian League";

                    totalPrize = 35000000;
                }
            }
            else
            {
                if (division == 0)
                {
                    leagueName = "MLH";

                    totalPrize = 55000000;
                }
                else
                {
                    leagueName = "SLH";

                    totalPrize = 27000000;
                }
            }
        }
        else if (continent == 2)
        {
            if (country == 0)
            {
                if (division == 0)
                {
                    leagueName = "Chinese Great League";

                    totalPrize = 80000000;
                }
                else
                {
                    leagueName = "Chinese Second League";

                    totalPrize = 45000000;
                }
            }
            else if (country == 1)
            {
                if (division == 0)
                {
                    leagueName = "KH League";

                    totalPrize = 60000000;
                }
                else
                {
                    leagueName = "KS League";

                    totalPrize = 30000000;
                }
            }
            else
            {
                if (division == 0)
                {
                    leagueName = "Nihon Meiyo Rīgu";

                    totalPrize = 100000000;
                }
                else
                {
                    leagueName = "Nihon Dai Rīgu";

                    totalPrize = 50000000;
                }
            }
        }
        else if (continent == 3)
        {
            if (country == 0)
            {
                if (division == 0)
                {
                    leagueName = "Primera Española";

                    totalPrize = 120000000;
                }
                else
                {
                    leagueName = "Segunda Española";

                    totalPrize = 60000000;
                }
            }
            else if (country == 1)
            {
                if (division == 0)
                {
                    leagueName = "Rossiyskaya Liga";

                    totalPrize = 60000000;
                }
                else
                {
                    leagueName = "Vtoroy Liga";

                    totalPrize = 30000000;
                }
            }
            else
            {
                if (division == 0)
                {
                    leagueName = "Premier British";

                    totalPrize = 9000000;
                }
                else
                {
                    leagueName = "British Championship";

                    totalPrize = 45000000;
                }
            }
        }
        else
        {
            if (country == 0)
            {
                if (division == 0)
                {
                    leagueName = "Australian National";

                    totalPrize = 55000000;
                }
                else
                {
                    leagueName = "Australian National B";

                    totalPrize = 25000000;
                }
            }
            else
            {
                if (division == 0)
                {
                    leagueName = "New Zealand Champions";

                    totalPrize = 45000000;
                }
                else
                {
                    leagueName = "New Zealand Honor";

                    totalPrize = 27000000;
                }
            }
        }
    }



    void StartMatchs()
    {
        int local = 0; //partidos que juega de local
        int visitor = 0; //partidos que juega de visitante

        int localTeam = 0;
        int visitorTeam = 0;

        for(int i = 0; i < 5; i++)
        {
            int aux = Random.Range(0, 2);

            if (aux == 0 && local < 5) //local y menos de 9 partidos como local
            {
                local++;

                localTeam = i*2 % 10;
                visitorTeam = (1 + i*2) % 10;
            }
            else if (aux == 1 && visitor < 5) //visitante y menos de 9 partidos como visitante
            {
                visitor++;

                visitorTeam = i*2 % 10;
                localTeam = (1 + i*2) % 10;
            }
            else //visitante pero mas de 9 partidos como visitante
            {
                local++;
            }

            for (int j = 0; j < 9; j++)
            {
                localTeam = (localTeam + j) % 18;
                visitorTeam = (visitorTeam + j) % 18;

                switch (j)
                {
                    case 0:
                        matchs[i, 0] = localTeam;
                        matchs[i, 1] = visitorTeam;
                        
                        matchs9[i, 0] = visitorTeam;
                        matchs9[i, 1] = localTeam;
                        break;
                    case 1:
                        matchs3[i, 0] = localTeam;
                        matchs3[i, 1] = visitorTeam;

                        matchs12[i, 0] = visitorTeam;
                        matchs12[i, 1] = localTeam;
                        break;
                    case 2:
                        matchs2[i, 0] = localTeam;
                        matchs2[i, 1] = visitorTeam;

                        matchs11[i, 0] = visitorTeam;
                        matchs11[i, 1] = localTeam;
                        break;
                    case 3:
                        matchs8[i, 0] = localTeam;
                        matchs8[i, 1] = visitorTeam;

                        matchs17[i, 0] = visitorTeam;
                        matchs17[i, 1] = localTeam;
                        break;
                    case 4:
                        matchs4[i, 0] = localTeam;
                        matchs4[i, 1] = visitorTeam;

                        matchs13[i, 0] = visitorTeam;
                        matchs13[i, 1] = localTeam;
                        break;
                    case 5:
                        matchs6[i, 0] = localTeam;
                        matchs6[i, 1] = visitorTeam;

                        matchs15[i, 0] = visitorTeam;
                        matchs15[i, 1] = localTeam;
                        break;
                    case 6:
                        matchs5[i, 0] = localTeam;
                        matchs5[i, 1] = visitorTeam;

                        matchs14[i, 0] = visitorTeam;
                        matchs14[i, 1] = localTeam;
                        break;
                    case 7:
                        matchs7[i, 0] = localTeam;
                        matchs7[i, 1] = visitorTeam;

                        matchs16[i, 0] = visitorTeam;
                        matchs16[i, 1] = localTeam;
                        break;
                    case 8:
                        matchs1[i, 0] = localTeam;
                        matchs1[i, 1] = visitorTeam;

                        matchs10[i, 0] = visitorTeam;
                        matchs10[i, 1] = localTeam;
                        break;
                }
            }
        }
    }
}
