using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Battle : MonoBehaviour
{
    private DataBase dataBase;
    //private Controller controller;
    public Club playerTeam, enemyTeam;

    public Sprite[] statusImage; //0 -- Paralyze     1 -- Poison     2 -- Bleed      3 -- Confusion      4 -- Blind
    public Sprite[] portrait; //0 -- Arponer    1 -- Archer    2 -- Wolf   3 -- Executer   4 -- Shield    5 -- Mage   6 -- Paladin   7 -- Robot
    public Sprite[] habilityIcons; //0 -- Attack   1 -- Defensa   2 -- Poison   3 -- Blind   4 -- Bleed   5 -- Paralyze   6 -- Confusion   7 -- AtackSup   8 -- DefSup   9 -- Repetition   10 -- Jumper   11 -- RecoveryMana   12 -- AtaqueRoto   13 -- DefensaRota

    private bool monster;
    private bool localMatch; //Si el jugador es local o visitante
    private bool attackAnimation, playerTurn;
    private bool stateActive, attackingActive;
    private bool hideText = false;
    private bool textActive = false;
    private bool applyEnemyState = false;
    public bool endEnemyTurn = false;

    private string messageText;

    private int stateIndex = 0;
    private int statePlayer = 0;
    private int firstLinePlayer, midLinePlayer, backLinePlayer, firstLineEnemy, midLineEnemy, backLineEnemy; //Número de elementos en cada linea
    private int playerAttack, enemyAttack; //Ataque acumulado en el turno
    private int playerDefence, enemyDefence; //Defensa acumulada en el turno
    private int playerScore, enemyScore;
    private int playerSelected, positionSelected, enemyPlayerSelected, habilitySelected;
    
    private List<int> playerId1, playerId2, playerId3, enemyId1, enemyId2, enemyId3;

    private const int startPlayers = 4;
    private const int cardNumber = 5;
    
    public List<Card> habilityEnemy1, habilityEnemy2, habilityEnemy3, habilityEnemy4; //Lista de habilidades seleccionadas por la IA rival

    public GameObject upbar, leftbar, rightbar, battleArea, skillArea, habilityInfo, commentatorArea;
    
    public RuntimeAnimatorController[] animators; //0 -- Arponero   1 -- Arquero    2 -- Bestia     3 -- Ejecutor   4 -- Escudero   5 -- Mago   6 -- Paladin    7 -- Robot

    private Color damageColor = new Color(204f / 255f, 0f, 0f, 1f);
    private Color neutralColor = new Color(183f / 255f, 183f / 255f, 183f / 255f, 1f);
    private Color supportColor = new Color(54f / 255f, 184f / 255f, 60f / 255f, 1f);
    private Color shieldColor = new Color(25f / 255f, 130f / 255f, 240f / 255f, 1f);


    
    //////////////////////////////////////////////////////////////////////////////////
    //Fase 0 /////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////
    private void Start()
    {
        //controller = GameObject.Find("Controller").GetComponent<Controller>();
        dataBase = GameObject.Find("Battle").GetComponent<DataBase>();

        StartSprites();
        StartBattle(dataBase.spanishClubs[0], dataBase.spanishClubs[1], true);
        HideHabilityInfo();
        HideCommentator();
    }


    private void StartSprites()
    {
        statusImage = new Sprite[5];

        statusImage[0] = Resources.Load<Sprite>("UI/GameUI/Icon/Icon.1_75");
        statusImage[1] = Resources.Load<Sprite>("UI/GameUI/Icon/Icon.1_83");
        statusImage[2] = Resources.Load<Sprite>("UI/GameUI/Icon/Icon.1_19");
        statusImage[3] = Resources.Load<Sprite>("UI/GameUI/Icon/Icon.4_43");
        statusImage[4] = Resources.Load<Sprite>("UI/GameUI/Icon/Icon.2_09");
    }


    
    //////////////////////////////////////////////////////////////////////////////////
    //Fase 1 /////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Inicia el combate y reinicia los valores
    /// </summary>
    public void StartBattle(Club playerClub, Club enemyClub, bool isLocalMatch)
    {
        stateActive = false;

        //cardSelected = -1;
        playerSelected = -1;
        positionSelected = -1;
        stateIndex = 0;

        localMatch = isLocalMatch;
        playerTurn = true;
        attackAnimation = false;

        playerTeam = playerClub;
        enemyTeam = enemyClub;

        playerAttack = 0;
        enemyAttack = 0;
        playerDefence = 0;
        enemyDefence = 0;
        playerScore = enemyScore = 0;

        playerId1 = new List<int>();
        playerId2 = new List<int>();
        playerId3 = new List<int>();
        enemyId1 = new List<int>();
        enemyId2 = new List<int>();
        enemyId3 = new List<int>();

        //HideCards();
        HideInfo();
        SetUpbar();

        SetPlayerTeamInfo(true);
        SetEnemyTeamInfo(true);

        SetPlayerTeamBattle();
        SetEnemyTeamBattle();

        StartAITurn(true);
        PlayerTurn();
    }


    /// <summary>
    /// Prepara la interfaz de los marcadores
    /// </summary>
    private void SetUpbar()
    {
        //Logos
        upbar.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = playerTeam.logo;
        upbar.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = enemyTeam.logo;

        //Ataque-Defensa local
        upbar.transform.GetChild(3).GetChild(0).GetChild(1).GetComponent<Text>().text = "0";
        upbar.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<Text>().text = "0";

        //Ataque-Defensa local
        upbar.transform.GetChild(4).GetChild(0).GetChild(1).GetComponent<Text>().text = "0";
        upbar.transform.GetChild(4).GetChild(1).GetChild(1).GetComponent<Text>().text = "0";

        UpdateScore();
    }

    
    /// <summary>
    /// Prepara la interfaz del equipo local
    /// </summary>
    private void SetPlayerTeamInfo(bool startBattle)
    {
        if (startBattle)
        {
            //Linea
            //Cambiar/////////////////////////////////////////////////////////////////
            playerTeam.playerPosition[0] = 0;
            playerTeam.playerPosition[1] = 4;
            playerTeam.playerPosition[2] = 5;
            playerTeam.playerPosition[3] = 6;
            //////////////////////////////////////////////////////////////////////////

            firstLinePlayer = midLinePlayer = backLinePlayer = 0;

            for (int i = 0; i < 7; i++)
            {
                //Cambiar/////////////////////////////////////////////////////////////////
                if (i < startPlayers)
                {
                    playerTeam.startTeamPlayers.Add(dataBase.playerList[playerTeam.players[i]]);
                }
                else
                {
                    playerTeam.secondTeamPlayers.Add(dataBase.playerList[playerTeam.players[i]]);
                }

                
                //////////////////////////////////////////////////////////////////////////

                if (i < startPlayers)
                {
                    //Info de posición
                    if (playerTeam.playerPosition[i] < 3)
                    {
                        playerId1.Add(i);
                        firstLinePlayer++;
                    }
                    else if (playerTeam.playerPosition[i] < 6)
                    {
                        playerId2.Add(i);
                        midLinePlayer++;
                    }
                    else
                    {
                        playerId3.Add(i);
                        backLinePlayer++;
                    }

                    //Resetear valores
                    playerTeam.startTeamPlayers[i].attack = 0;
                    playerTeam.startTeamPlayers[i].defence = 0;
                    playerTeam.startTeamPlayers[i].actualAttack = 0;
                    playerTeam.startTeamPlayers[i].actualDefence = 0;
                    playerTeam.startTeamPlayers[i].actualEnergyRecovery = playerTeam.startTeamPlayers[i].energyRecovery;

                    playerTeam.startTeamPlayers[i].totalStates = 0;
                    playerTeam.startTeamPlayers[i].jumper = false;
                    playerTeam.startTeamPlayers[i].repetitive = false;
                    playerTeam.startTeamPlayers[i].confusion = false;
                    playerTeam.startTeamPlayers[i].paralyze = false;
                    playerTeam.startTeamPlayers[i].bleed = false;
                    playerTeam.startTeamPlayers[i].blind = false;
                    playerTeam.startTeamPlayers[i].poison = false;

                    playerTeam.startTeamPlayers[i].confusionTurn = 0;
                    playerTeam.startTeamPlayers[i].paralyzeTurn = 0;
                    playerTeam.startTeamPlayers[i].bleedTurn = 0;
                    playerTeam.startTeamPlayers[i].blindTurn = 0;
                    playerTeam.startTeamPlayers[i].poisonTurn = 0;
                    playerTeam.startTeamPlayers[i].jumperTurn = 0;
                    playerTeam.startTeamPlayers[i].repetitiveTurn = 0;

                    //Nombre
                    leftbar.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<Text>().text = playerTeam.startTeamPlayers[i].playerName.Substring(0, 1) + ". " + playerTeam.startTeamPlayers[i].playerSurname;

                    //Marcador
                    leftbar.transform.GetChild(0).GetChild(i).GetChild(1).GetChild(2).GetComponent<Image>().sprite = GetPortrait(playerTeam.startTeamPlayers[i].position);

                    //Vida
                    playerTeam.startTeamPlayers[i].actualLife = playerTeam.startTeamPlayers[i].life;
                    leftbar.transform.GetChild(0).GetChild(i).GetChild(1).GetChild(0).localScale = new Vector3(1, 1, 1);
                    leftbar.transform.GetChild(0).GetChild(i).GetChild(2).GetComponent<Text>().text = playerTeam.startTeamPlayers[i].life + "/" + playerTeam.startTeamPlayers[i].life;

                    //Energía
                    playerTeam.startTeamPlayers[i].actualEnergy = playerTeam.startTeamPlayers[i].energy;
                    leftbar.transform.GetChild(0).GetChild(i).GetChild(1).GetChild(1).localScale = new Vector3(1, 1, 1);
                    leftbar.transform.GetChild(0).GetChild(i).GetChild(3).GetComponent<Text>().text = playerTeam.startTeamPlayers[i].energy + "/" + playerTeam.startTeamPlayers[i].energy;

                    //Ataque
                    leftbar.transform.GetChild(0).GetChild(i).GetChild(4).GetChild(1).GetComponent<Text>().text = "0";

                    //Defensa
                    leftbar.transform.GetChild(0).GetChild(i).GetChild(5).GetChild(1).GetComponent<Text>().text = "0";

                    //Bajas
                    leftbar.transform.GetChild(0).GetChild(i).GetChild(6).GetChild(1).GetComponent<Text>().text = playerTeam.startTeamPlayers[i].kills.ToString();

                    //Info
                    for (int j = 0; j < 11; j++)
                    {
                        leftbar.transform.GetChild(0).GetChild(i).GetChild(7).GetChild(j).gameObject.SetActive(false);
                    }
                }
                else
                {
                    //Resetear valores
                    playerTeam.secondTeamPlayers[i - startPlayers].attack = 0;
                    playerTeam.secondTeamPlayers[i - startPlayers].defence = 0;
                    playerTeam.secondTeamPlayers[i - startPlayers].actualAttack = 0;
                    playerTeam.secondTeamPlayers[i - startPlayers].actualDefence = 0;
                    playerTeam.secondTeamPlayers[i - startPlayers].actualEnergyRecovery = playerTeam.secondTeamPlayers[i - startPlayers].energyRecovery;
               
                    playerTeam.secondTeamPlayers[i - startPlayers].totalStates = 0;
                    playerTeam.secondTeamPlayers[i - startPlayers].jumper = false;
                    playerTeam.secondTeamPlayers[i - startPlayers].repetitive = false;
                    playerTeam.secondTeamPlayers[i - startPlayers].confusion = false;
                    playerTeam.secondTeamPlayers[i - startPlayers].paralyze = false;
                    playerTeam.secondTeamPlayers[i - startPlayers].bleed = false;
                    playerTeam.secondTeamPlayers[i - startPlayers].blind = false;
                    playerTeam.secondTeamPlayers[i - startPlayers].poison = false;
                    
                    playerTeam.secondTeamPlayers[i - startPlayers].confusionTurn = 0;
                    playerTeam.secondTeamPlayers[i - startPlayers].paralyzeTurn = 0;
                    playerTeam.secondTeamPlayers[i - startPlayers].bleedTurn = 0;
                    playerTeam.secondTeamPlayers[i - startPlayers].blindTurn = 0;
                    playerTeam.secondTeamPlayers[i - startPlayers].poisonTurn = 0;
                    playerTeam.secondTeamPlayers[i - startPlayers].jumperTurn = 0;
                    playerTeam.secondTeamPlayers[i - startPlayers].repetitiveTurn = 0;
                   
                    //Nombre
                    leftbar.transform.GetChild(1).GetChild(i - startPlayers).GetChild(0).GetComponent<Text>().text = playerTeam.secondTeamPlayers[i - startPlayers].playerName.Substring(0, 1) + ". " + playerTeam.secondTeamPlayers[i - startPlayers].playerSurname;

                    //Marcador
                    leftbar.transform.GetChild(1).GetChild(i - startPlayers).GetChild(1).GetChild(2).GetComponent<Image>().sprite = GetPortrait(playerTeam.secondTeamPlayers[i - startPlayers].position);

                    //Vida
                    playerTeam.secondTeamPlayers[i - startPlayers].actualLife = playerTeam.secondTeamPlayers[i - startPlayers].life;
                    leftbar.transform.GetChild(1).GetChild(i - startPlayers).GetChild(1).GetChild(0).localScale = new Vector3(1, 1, 1);
                    leftbar.transform.GetChild(1).GetChild(i - startPlayers).GetChild(2).GetComponent<Text>().text = playerTeam.secondTeamPlayers[i - startPlayers].life + "/" + playerTeam.secondTeamPlayers[i - startPlayers].life;

                    //Energía
                    playerTeam.secondTeamPlayers[i - startPlayers].actualEnergy = playerTeam.secondTeamPlayers[i - startPlayers].energy;
                    leftbar.transform.GetChild(1).GetChild(i - startPlayers).GetChild(1).GetChild(1).localScale = new Vector3(1, 1, 1);
                    leftbar.transform.GetChild(1).GetChild(i - startPlayers).GetChild(3).GetComponent<Text>().text = playerTeam.secondTeamPlayers[i - startPlayers].energy + "/" + playerTeam.secondTeamPlayers[i - startPlayers].energy;

                    //Bajas
                    leftbar.transform.GetChild(1).GetChild(i - startPlayers).GetChild(4).GetChild(1).GetComponent<Text>().text = playerTeam.secondTeamPlayers[i - startPlayers].kills.ToString();
                }
            }

            //Cambiar/////////////////////////////////////////////////////////////////
            playerTeam.startTeamPlayers[0].line = 0;
            playerTeam.startTeamPlayers[0].linePosition = 0;

            playerTeam.startTeamPlayers[1].line = 1;
            playerTeam.startTeamPlayers[1].linePosition = 1;

            playerTeam.startTeamPlayers[2].line = 1;
            playerTeam.startTeamPlayers[2].linePosition = 2;

            playerTeam.startTeamPlayers[3].line = 2;
            playerTeam.startTeamPlayers[3].linePosition = 0;
            //////////////////////////////////////////////////////////////////////////
        }
        else
        {
            for (int i = 0; i < startPlayers; i++)
            {
                //Energía
                playerTeam.startTeamPlayers[i].actualEnergy += playerTeam.startTeamPlayers[i].energyRecovery;
                
                if (playerTeam.startTeamPlayers[i].actualEnergy > playerTeam.startTeamPlayers[i].energy)
                {
                    playerTeam.startTeamPlayers[i].actualEnergy = playerTeam.startTeamPlayers[i].energy;
                }
                
                float auxScaleX = (float)playerTeam.startTeamPlayers[i].actualEnergy / (float)playerTeam.startTeamPlayers[i].energy;
                leftbar.transform.GetChild(0).GetChild(i).GetChild(1).GetChild(1).localScale = new Vector3(auxScaleX, 1, 1);
                leftbar.transform.GetChild(0).GetChild(i).GetChild(3).GetComponent<Text>().text = playerTeam.startTeamPlayers[i].actualEnergy + "/" + playerTeam.startTeamPlayers[i].energy;
            }
        }
    }


    /// <summary>
    /// Prepara la interfaz del equipo visitante
    /// </summary>
    private void SetEnemyTeamInfo(bool startBattle)
    {
        if (startBattle)
        {
            //Linea
            //Cambiar/////////////////////////////////////////////////////////////////
            enemyTeam.playerPosition[0] = 1;
            enemyTeam.playerPosition[1] = 2;
            enemyTeam.playerPosition[2] = 3;
            enemyTeam.playerPosition[3] = 6;
            //////////////////////////////////////////////////////////////////////////

            firstLineEnemy = midLineEnemy = backLineEnemy = 0;

            for (int i = 0; i < 7; i++)
            {
                //Cambiar/////////////////////////////////////////////////////////////////
                if (i < startPlayers)
                {
                    enemyTeam.startTeamPlayers.Add(dataBase.playerList[enemyTeam.players[i]]);
                }
                else
                {
                    enemyTeam.secondTeamPlayers.Add(dataBase.playerList[enemyTeam.players[i]]);
                }

                
                //////////////////////////////////////////////////////////////////////////

                if (i < startPlayers)
                {
                    //Info de posición
                    if (enemyTeam.playerPosition[i] < 3)
                    {
                        enemyId1.Add(i);
                        firstLineEnemy++;
                    }
                    else if (enemyTeam.playerPosition[i] < 6)
                    {
                        enemyId2.Add(i);
                        midLineEnemy++;
                    }
                    else
                    {
                        enemyId3.Add(i);
                        backLineEnemy++;
                    }

                    //Resetear valores
                    enemyTeam.startTeamPlayers[i].attack = 0;
                    enemyTeam.startTeamPlayers[i].defence = 0;
                    enemyTeam.startTeamPlayers[i].actualAttack = 0;
                    enemyTeam.startTeamPlayers[i].actualDefence = 0;
                    enemyTeam.startTeamPlayers[i].actualEnergyRecovery = playerTeam.startTeamPlayers[i].energyRecovery;

                    enemyTeam.startTeamPlayers[i].totalStates = 0;
                    enemyTeam.startTeamPlayers[i].jumper = false;
                    enemyTeam.startTeamPlayers[i].repetitive = false;
                    enemyTeam.startTeamPlayers[i].confusion = false;
                    enemyTeam.startTeamPlayers[i].paralyze = false;
                    enemyTeam.startTeamPlayers[i].bleed = false;
                    enemyTeam.startTeamPlayers[i].blind = false;
                    enemyTeam.startTeamPlayers[i].poison = false;

                    enemyTeam.startTeamPlayers[i].confusionTurn = 0;
                    enemyTeam.startTeamPlayers[i].paralyzeTurn = 0;
                    enemyTeam.startTeamPlayers[i].bleedTurn = 0;
                    enemyTeam.startTeamPlayers[i].blindTurn = 0;
                    enemyTeam.startTeamPlayers[i].poisonTurn = 0;
                    enemyTeam.startTeamPlayers[i].jumperTurn = 0;
                    enemyTeam.startTeamPlayers[i].repetitiveTurn = 0;

                    //Nombre
                    rightbar.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<Text>().text = enemyTeam.startTeamPlayers[i].playerName.Substring(0, 1) + ". " + enemyTeam.startTeamPlayers[i].playerSurname;

                    //Marcador
                    rightbar.transform.GetChild(0).GetChild(i).GetChild(1).GetChild(2).GetComponent<Image>().sprite = GetPortrait(enemyTeam.startTeamPlayers[i].position);

                    //Vida
                    enemyTeam.startTeamPlayers[i].actualLife = enemyTeam.startTeamPlayers[i].life;
                    rightbar.transform.GetChild(0).GetChild(i).GetChild(1).GetChild(0).localScale = new Vector3(1, 1, 1);
                    rightbar.transform.GetChild(0).GetChild(i).GetChild(2).GetComponent<Text>().text = enemyTeam.startTeamPlayers[i].life + "/" + enemyTeam.startTeamPlayers[i].life;

                    //Energía
                    enemyTeam.startTeamPlayers[i].actualEnergy = enemyTeam.startTeamPlayers[i].energy;
                    rightbar.transform.GetChild(0).GetChild(i).GetChild(1).GetChild(1).localScale = new Vector3(1, 1, 1);
                    rightbar.transform.GetChild(0).GetChild(i).GetChild(3).GetComponent<Text>().text = enemyTeam.startTeamPlayers[i].energy + "/" + enemyTeam.startTeamPlayers[i].energy;

                    //Ataque
                    rightbar.transform.GetChild(0).GetChild(i).GetChild(4).GetChild(1).GetComponent<Text>().text = "0";

                    //Defensa
                    rightbar.transform.GetChild(0).GetChild(i).GetChild(5).GetChild(1).GetComponent<Text>().text = "0";

                    //Bajas
                    rightbar.transform.GetChild(0).GetChild(i).GetChild(6).GetChild(1).GetComponent<Text>().text = enemyTeam.startTeamPlayers[i].kills.ToString();

                    //Info
                    for (int j = 0; j < 11; j++)
                    {
                        rightbar.transform.GetChild(0).GetChild(i).GetChild(7).GetChild(j).gameObject.SetActive(false);
                    }
                }
                else
                {
                    //Resetear valores
                    enemyTeam.secondTeamPlayers[i - startPlayers].attack = 0;
                    enemyTeam.secondTeamPlayers[i - startPlayers].defence = 0;
                    enemyTeam.secondTeamPlayers[i - startPlayers].actualAttack = 0;
                    enemyTeam.secondTeamPlayers[i - startPlayers].actualDefence = 0;
                    enemyTeam.secondTeamPlayers[i - startPlayers].actualEnergyRecovery = enemyTeam.secondTeamPlayers[i - startPlayers].energyRecovery;

                    enemyTeam.secondTeamPlayers[i - startPlayers].totalStates = 0;
                    enemyTeam.secondTeamPlayers[i - startPlayers].jumper = false;
                    enemyTeam.secondTeamPlayers[i - startPlayers].repetitive = false;
                    enemyTeam.secondTeamPlayers[i - startPlayers].confusion = false;
                    enemyTeam.secondTeamPlayers[i - startPlayers].paralyze = false;
                    enemyTeam.secondTeamPlayers[i - startPlayers].bleed = false;
                    enemyTeam.secondTeamPlayers[i - startPlayers].blind = false;
                    enemyTeam.secondTeamPlayers[i - startPlayers].poison = false;

                    enemyTeam.secondTeamPlayers[i - startPlayers].confusionTurn = 0;
                    enemyTeam.secondTeamPlayers[i - startPlayers].paralyzeTurn = 0;
                    enemyTeam.secondTeamPlayers[i - startPlayers].bleedTurn = 0;
                    enemyTeam.secondTeamPlayers[i - startPlayers].blindTurn = 0;
                    enemyTeam.secondTeamPlayers[i - startPlayers].poisonTurn = 0;
                    enemyTeam.secondTeamPlayers[i - startPlayers].jumperTurn = 0;
                    enemyTeam.secondTeamPlayers[i - startPlayers].repetitiveTurn = 0;

                    //Nombre
                    rightbar.transform.GetChild(1).GetChild(i - startPlayers).GetChild(0).GetComponent<Text>().text = enemyTeam.secondTeamPlayers[i - startPlayers].playerName.Substring(0, 1) + ". " + enemyTeam.secondTeamPlayers[i - startPlayers].playerSurname;

                    //Marcador
                    rightbar.transform.GetChild(1).GetChild(i - startPlayers).GetChild(1).GetChild(2).GetComponent<Image>().sprite = GetPortrait(enemyTeam.secondTeamPlayers[i - startPlayers].position);

                    //Vida
                    enemyTeam.secondTeamPlayers[i - startPlayers].actualLife = enemyTeam.secondTeamPlayers[i - startPlayers].life;
                    rightbar.transform.GetChild(1).GetChild(i - startPlayers).GetChild(1).GetChild(0).localScale = new Vector3(1, 1, 1);
                    rightbar.transform.GetChild(1).GetChild(i - startPlayers).GetChild(2).GetComponent<Text>().text = enemyTeam.secondTeamPlayers[i - startPlayers].life + "/" + enemyTeam.secondTeamPlayers[i - startPlayers].life;

                    //Energía
                    enemyTeam.secondTeamPlayers[i - startPlayers].actualEnergy = enemyTeam.secondTeamPlayers[i - startPlayers].energy;
                    rightbar.transform.GetChild(1).GetChild(i - startPlayers).GetChild(1).GetChild(1).localScale = new Vector3(1, 1, 1);
                    rightbar.transform.GetChild(1).GetChild(i - startPlayers).GetChild(3).GetComponent<Text>().text = enemyTeam.secondTeamPlayers[i - startPlayers].energy + "/" + enemyTeam.secondTeamPlayers[i - startPlayers].energy;

                    //Bajas
                    rightbar.transform.GetChild(1).GetChild(i - startPlayers).GetChild(4).GetChild(1).GetComponent<Text>().text = enemyTeam.secondTeamPlayers[i - startPlayers].kills.ToString();
                }
            }

            //Cambiar/////////////////////////////////////////////////////////////////
            enemyTeam.startTeamPlayers[0].line = 0;
            enemyTeam.startTeamPlayers[0].linePosition = 1;

            enemyTeam.startTeamPlayers[1].line = 0;
            enemyTeam.startTeamPlayers[1].linePosition = 2;

            enemyTeam.startTeamPlayers[2].line = 1;
            enemyTeam.startTeamPlayers[2].linePosition = 0;

            enemyTeam.startTeamPlayers[3].line = 2;
            enemyTeam.startTeamPlayers[3].linePosition = 0;
            //////////////////////////////////////////////////////////////////////////
        }
        else
        {
            for (int i = 0; i < startPlayers; i++)
            {
                //Energía
                enemyTeam.startTeamPlayers[i].actualEnergy += enemyTeam.startTeamPlayers[i].energyRecovery;

                if (enemyTeam.startTeamPlayers[i].actualEnergy > enemyTeam.startTeamPlayers[i].energy)
                {
                    enemyTeam.startTeamPlayers[i].actualEnergy = enemyTeam.startTeamPlayers[i].energy;
                }

                float auxScaleX = (float)enemyTeam.startTeamPlayers[i].actualEnergy / (float)enemyTeam.startTeamPlayers[i].energy;
                rightbar.transform.GetChild(0).GetChild(i).GetChild(1).GetChild(1).localScale = new Vector3(auxScaleX, 1, 1);
                rightbar.transform.GetChild(0).GetChild(i).GetChild(3).GetComponent<Text>().text = enemyTeam.startTeamPlayers[i].actualEnergy + "/" + enemyTeam.startTeamPlayers[i].energy;
            }
        }
    }


    /// <summary>
    /// Prepara los controladores de animación
    /// </summary>
    private RuntimeAnimatorController SetPlayerAnimator(Player.Position pos)
    {
        RuntimeAnimatorController selectedAnimation;

        switch (pos)
        {
            case Player.Position.ARPONER:
                selectedAnimation = animators[0];
                break;
            case Player.Position.ARCHER:
                selectedAnimation = animators[1];
                break;
            case Player.Position.EXECUTER:
                selectedAnimation = animators[3];
                break;
            case Player.Position.SHIELD:
                selectedAnimation = animators[4];
                break;
            case Player.Position.MAGICIAN:
                selectedAnimation = animators[5];
                break;
            case Player.Position.PALADIN:
                selectedAnimation = animators[6];
                break;
            default:
                selectedAnimation = animators[7];
                break;
        }

        return selectedAnimation;
    }


    /// <summary>
    /// Prepara la zona de combate del equipo aliado 
    /// </summary>
    private void SetPlayerTeamBattle()
    {
        RuntimeAnimatorController runtimeAnimator;
        Animator auxAnimator;

        for (int i = 0; i < 9; i++)
        {
            if (i < 3)
            {
                battleArea.transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).gameObject.SetActive(false);
                battleArea.transform.GetChild(0).GetChild(0).GetChild(i).GetChild(1).GetComponent<Button>().interactable = false;
                battleArea.transform.GetChild(0).GetChild(0).GetChild(i).GetChild(1).gameObject.SetActive(false);
               
            }
            else if (i < 6)
            {
                battleArea.transform.GetChild(0).GetChild(1).GetChild(i - 3).GetChild(0).gameObject.SetActive(false);
                battleArea.transform.GetChild(0).GetChild(1).GetChild(i - 3).GetChild(1).GetComponent<Button>().interactable = false;
                battleArea.transform.GetChild(0).GetChild(1).GetChild(i - 3).GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                battleArea.transform.GetChild(0).GetChild(2).GetChild(i - 6).GetChild(0).gameObject.SetActive(false);
                battleArea.transform.GetChild(0).GetChild(2).GetChild(i - 6).GetChild(1).GetComponent<Button>().interactable = false;
                battleArea.transform.GetChild(0).GetChild(2).GetChild(i - 6).GetChild(1).gameObject.SetActive(false);
            }
        }
        
        for (int i = 0; i < 4; i++)
        {
            runtimeAnimator = SetPlayerAnimator(playerTeam.startTeamPlayers[i].position);

            if (playerTeam.playerPosition[i] < 3)
            {
                battleArea.transform.GetChild(0).GetChild(0).GetChild(playerTeam.playerPosition[i]).GetChild(1).GetComponent<Animator>().runtimeAnimatorController = runtimeAnimator;
                auxAnimator = battleArea.transform.GetChild(0).GetChild(0).GetChild(playerTeam.playerPosition[i]).GetChild(1).GetComponent<Animator>();

                battleArea.transform.GetChild(0).GetChild(0).GetChild(playerTeam.playerPosition[i]).GetChild(0).gameObject.SetActive(true);
                battleArea.transform.GetChild(0).GetChild(0).GetChild(playerTeam.playerPosition[i]).GetChild(1).gameObject.SetActive(true);

                battleArea.transform.GetChild(0).GetChild(0).GetChild(playerTeam.playerPosition[i]).GetChild(1).GetComponent<Button>().interactable = true;

                battleArea.transform.GetChild(0).GetChild(0).GetChild(playerTeam.playerPosition[i]).GetChild(0).GetComponent<Text>().text = playerTeam.startTeamPlayers[i].playerName.Substring(0, 1) + ". " + playerTeam.startTeamPlayers[i].playerSurname;
            }
            else if (playerTeam.playerPosition[i] < 6)
            {
                battleArea.transform.GetChild(0).GetChild(1).GetChild(playerTeam.playerPosition[i] - 3).GetChild(1).GetComponent<Animator>().runtimeAnimatorController = runtimeAnimator;
                auxAnimator = battleArea.transform.GetChild(0).GetChild(1).GetChild(playerTeam.playerPosition[i] - 3).GetChild(1).GetComponent<Animator>();

                battleArea.transform.GetChild(0).GetChild(1).GetChild(playerTeam.playerPosition[i] - 3).GetChild(0).gameObject.SetActive(true);
                battleArea.transform.GetChild(0).GetChild(1).GetChild(playerTeam.playerPosition[i] - 3).GetChild(1).gameObject.SetActive(true);

                battleArea.transform.GetChild(0).GetChild(1).GetChild(playerTeam.playerPosition[i] - 3).GetChild(1).GetComponent<Button>().interactable = true;

                battleArea.transform.GetChild(0).GetChild(1).GetChild(playerTeam.playerPosition[i] - 3).GetChild(0).GetComponent<Text>().text = playerTeam.startTeamPlayers[i].playerName.Substring(0, 1) + ". " + playerTeam.startTeamPlayers[i].playerSurname;
            }
            else
            {
                battleArea.transform.GetChild(0).GetChild(2).GetChild(playerTeam.playerPosition[i] - 6).GetChild(1).GetComponent<Animator>().runtimeAnimatorController = runtimeAnimator;
                auxAnimator = battleArea.transform.GetChild(0).GetChild(2).GetChild(playerTeam.playerPosition[i] - 6).GetChild(1).GetComponent<Animator>();

                battleArea.transform.GetChild(0).GetChild(2).GetChild(playerTeam.playerPosition[i] - 6).GetChild(0).gameObject.SetActive(true);
                battleArea.transform.GetChild(0).GetChild(2).GetChild(playerTeam.playerPosition[i] - 6).GetChild(1).gameObject.SetActive(true);

                battleArea.transform.GetChild(0).GetChild(2).GetChild(playerTeam.playerPosition[i] - 6).GetChild(1).GetComponent<Button>().interactable = true;

                battleArea.transform.GetChild(0).GetChild(2).GetChild(playerTeam.playerPosition[i] - 6).GetChild(0).GetComponent<Text>().text = playerTeam.startTeamPlayers[i].playerName.Substring(0, 1) + ". " + playerTeam.startTeamPlayers[i].playerSurname;
            }
            
            auxAnimator.SetBool("Local", true);
        }
    }


    /// <summary>
    /// Prepara la zona de combate del equipo enemigo
    /// </summary>
    private void SetEnemyTeamBattle()
    {
        RuntimeAnimatorController runtimeAnimator;
        Animator auxAnimator;

        for (int i = 0; i < 9; i++)
        {
            if (i < 3)
            {
                battleArea.transform.GetChild(1).GetChild(0).GetChild(i).GetChild(0).gameObject.SetActive(false);
                battleArea.transform.GetChild(1).GetChild(0).GetChild(i).GetChild(1).GetComponent<Button>().interactable = false;
                battleArea.transform.GetChild(1).GetChild(0).GetChild(i).GetChild(1).gameObject.SetActive(false);
            }
            else if (i < 6)
            {
                battleArea.transform.GetChild(1).GetChild(1).GetChild(i - 3).GetChild(0).gameObject.SetActive(false);
                battleArea.transform.GetChild(1).GetChild(1).GetChild(i - 3).GetChild(1).GetComponent<Button>().interactable = false;
                battleArea.transform.GetChild(1).GetChild(1).GetChild(i - 3).GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                battleArea.transform.GetChild(1).GetChild(2).GetChild(i - 6).GetChild(0).gameObject.SetActive(false);
                battleArea.transform.GetChild(1).GetChild(2).GetChild(i - 6).GetChild(1).GetComponent<Button>().interactable = false;
                battleArea.transform.GetChild(1).GetChild(2).GetChild(i - 6).GetChild(1).gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < 4; i++)
        {
            runtimeAnimator = SetPlayerAnimator(enemyTeam.startTeamPlayers[i].position);

            if (enemyTeam.playerPosition[i] < 3)
            {
                battleArea.transform.GetChild(1).GetChild(0).GetChild(enemyTeam.playerPosition[i]).GetChild(1).GetComponent<Animator>().runtimeAnimatorController = runtimeAnimator;
                auxAnimator = battleArea.transform.GetChild(1).GetChild(0).GetChild(enemyTeam.playerPosition[i]).GetChild(1).GetComponent<Animator>();

                battleArea.transform.GetChild(1).GetChild(0).GetChild(enemyTeam.playerPosition[i]).GetChild(0).gameObject.SetActive(true);
                battleArea.transform.GetChild(1).GetChild(0).GetChild(enemyTeam.playerPosition[i]).GetChild(1).gameObject.SetActive(true);

                battleArea.transform.GetChild(1).GetChild(0).GetChild(enemyTeam.playerPosition[i]).GetChild(0).GetComponent<Text>().text = enemyTeam.startTeamPlayers[i].playerName.Substring(0, 1) + ". " + enemyTeam.startTeamPlayers[i].playerSurname;
            }
            else if (enemyTeam.playerPosition[i] < 6)
            {
                battleArea.transform.GetChild(1).GetChild(1).GetChild(enemyTeam.playerPosition[i] - 3).GetChild(1).GetComponent<Animator>().runtimeAnimatorController = runtimeAnimator;
                auxAnimator = battleArea.transform.GetChild(1).GetChild(1).GetChild(enemyTeam.playerPosition[i] - 3).GetChild(1).GetComponent<Animator>();

                battleArea.transform.GetChild(1).GetChild(1).GetChild(enemyTeam.playerPosition[i] - 3).GetChild(0).gameObject.SetActive(true);
                battleArea.transform.GetChild(1).GetChild(1).GetChild(enemyTeam.playerPosition[i] - 3).GetChild(1).gameObject.SetActive(true);

                battleArea.transform.GetChild(1).GetChild(1).GetChild(enemyTeam.playerPosition[i] - 3).GetChild(0).GetComponent<Text>().text = enemyTeam.startTeamPlayers[i].playerName.Substring(0, 1) + ". " + enemyTeam.startTeamPlayers[i].playerSurname;
            }
            else
            {
                battleArea.transform.GetChild(1).GetChild(2).GetChild(enemyTeam.playerPosition[i] - 6).GetChild(1).GetComponent<Animator>().runtimeAnimatorController = runtimeAnimator;
                auxAnimator = battleArea.transform.GetChild(1).GetChild(2).GetChild(enemyTeam.playerPosition[i] - 6).GetChild(1).GetComponent<Animator>();

                battleArea.transform.GetChild(1).GetChild(2).GetChild(enemyTeam.playerPosition[i] - 6).GetChild(0).gameObject.SetActive(true);
                battleArea.transform.GetChild(1).GetChild(2).GetChild(enemyTeam.playerPosition[i] - 6).GetChild(1).gameObject.SetActive(true);

                battleArea.transform.GetChild(1).GetChild(2).GetChild(enemyTeam.playerPosition[i] - 6).GetChild(0).GetComponent<Text>().text = enemyTeam.startTeamPlayers[i].playerName.Substring(0, 1) + ". " + enemyTeam.startTeamPlayers[i].playerSurname;
            }

            auxAnimator.SetBool("Local", false);
        }
    }



    //////////////////////////////////////////////////////////////////////////////////
    //Fase 2 /////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Selecciona las habilidades que va a emplear cada uno de los enemigos
    /// </summary>
    private void EnergyRecovery()
    {
        for (int i = 0; i < startPlayers; i++)
        {
            if (playerTeam.startTeamPlayers[i].actualLife > 0)
            {
                playerTeam.startTeamPlayers[i].actualEnergy += playerTeam.startTeamPlayers[i].actualEnergyRecovery;

                if (playerTeam.startTeamPlayers[i].actualEnergy > playerTeam.startTeamPlayers[i].energy)
                {
                    playerTeam.startTeamPlayers[i].actualEnergy = playerTeam.startTeamPlayers[i].energy;
                }
            }
            
            if (enemyTeam.startTeamPlayers[i].actualLife > 0)
            {
                enemyTeam.startTeamPlayers[i].actualEnergy += enemyTeam.startTeamPlayers[i].actualEnergyRecovery;

                if (enemyTeam.startTeamPlayers[i].actualEnergy > enemyTeam.startTeamPlayers[i].energy)
                {
                    enemyTeam.startTeamPlayers[i].actualEnergy = enemyTeam.startTeamPlayers[i].energy;
                }
            }
        }
    }


    /// <summary>
    /// Selecciona las habilidades que va a emplear cada uno de los enemigos
    /// </summary>
    private void StartAITurn(bool firstTurn)
    {
        int defenseProb, negativeProb, supportProb; //Probabilidad del tipo de habilidad
        int atckNorProb, atckJumpProb; //Probabildiades del tipo de ataque

        habilityEnemy1 = new List<Card>();
        habilityEnemy2 = new List<Card>();
        habilityEnemy3 = new List<Card>();
        habilityEnemy4 = new List<Card>();

        for (int i = 0; i < startPlayers; i++)
        {
            Card auxCard;

            //Posee la habilidad
            List<int> haveSupport = new List<int>();
            List<int> haveAttackNormal = new List<int>();
            List<int> haveAttackJump = new List<int>();
            List<int> haveAttackRepet = new List<int>();
            List<int> haveDefense = new List<int>();
            List<int> haveNegative = new List<int>();

            //Fija las probabilidades en función del tipo de personaje
            switch (enemyTeam.startTeamPlayers[i].position)
            {
                case Player.Position.ARCHER:
                    defenseProb = 15;
                    supportProb = 15;
                    negativeProb = 15;

                    atckNorProb = 10;
                    atckJumpProb = 60;

                    break;
                case Player.Position.ARPONER:
                    defenseProb = 35;
                    supportProb = 10;
                    negativeProb = 15;

                    atckNorProb = 35;
                    atckJumpProb = 25;

                    break;
                case Player.Position.EXECUTER:
                    defenseProb = 20;
                    supportProb = 5;
                    negativeProb = 25;

                    atckNorProb = 10;
                    atckJumpProb = 30;

                    break;
                case Player.Position.MAGICIAN:
                    defenseProb = 10;
                    supportProb = 15;
                    negativeProb = 20;

                    atckNorProb = 20;
                    atckJumpProb = 40;

                    break;
                case Player.Position.PALADIN:
                    defenseProb = 30;
                    supportProb = 15;
                    negativeProb = 15;

                    atckNorProb = 20;
                    atckJumpProb = 40;

                    break;
                case Player.Position.ROBOT:
                    defenseProb = 25;
                    supportProb = 25;
                    negativeProb = 25;

                    atckNorProb = 20;
                    atckJumpProb = 40;

                    break;
                case Player.Position.SHIELD:
                    defenseProb = 50;
                    supportProb = 10;
                    negativeProb = 10;

                    atckNorProb = 20;
                    atckJumpProb = 40;

                    break;
                default:
                    defenseProb = 25;
                    supportProb = 25;
                    negativeProb = 25;

                    atckNorProb = 20;
                    atckJumpProb = 40;

                    break;
            }

            //Determina el número de ataque máximo que hará en este turno
            int minValue = enemyTeam.startTeamPlayers[i].habilitys[0].manaCost;//Menor coste de maná para determinar el máximo de ataque que se pueden lanzar en un turno

            //Se fija el valor mínimo y añade las habilidades que se poseen
            for (int j = 0; j < cardNumber; j++)
            {
                if (minValue > enemyTeam.startTeamPlayers[i].habilitys[j].manaCost)
                {
                    minValue = enemyTeam.startTeamPlayers[i].habilitys[j].manaCost;
                }
               
                if (enemyTeam.startTeamPlayers[i].habilitys[j].type == Card.Type.ATTACK)
                {
                    if (enemyTeam.startTeamPlayers[i].habilitys[j].effect == Card.Effect.NONE)
                    {
                        haveAttackNormal.Add(j);
                    }
                    else if (enemyTeam.startTeamPlayers[i].habilitys[j].effect == Card.Effect.JUMP)
                    {
                        haveAttackJump.Add(j);
                    }
                    else
                    {
                        haveAttackRepet.Add(j);
                    }
                }
                else if (enemyTeam.startTeamPlayers[i].habilitys[j].type == Card.Type.DEFENSE)
                {
                    haveDefense.Add(j);
                }
                else if (enemyTeam.startTeamPlayers[i].habilitys[j].type == Card.Type.SUPPORT)
                {
                    haveSupport.Add(j);
                }
                else
                {
                    haveNegative.Add(j);
                }
            }

            int maxRepetition = enemyTeam.startTeamPlayers[i].actualEnergy / minValue; //Número máximo de ataques que se puede lanzar un turno
            int maxHabilityUsed = maxRepetition;

            if (maxRepetition > 1)
            {
                int minRepetition = 1;

                if (firstTurn)
                {
                    minRepetition = enemyTeam.startTeamPlayers[i].actualEnergyRecovery / minValue;
                }

                maxHabilityUsed = Random.Range(minRepetition, maxRepetition); //Número máximo de ataques que se van a lanzar

                if (maxHabilityUsed == 1) //En caso de que solo se vaya a lanzar solo una habilidad se vuelve a sortear salvo que solo se pueda lanzar 1
                {
                    maxHabilityUsed = Random.Range(minRepetition, maxRepetition);
                }
            }

            //Se seleccionan las habilidades que se van a usar
            for (int j = 0; j < maxHabilityUsed; j++)
            {
                int auxValue = Random.Range(0, 100);
                
                if (auxValue < defenseProb && haveDefense.Count > 0)
                {
                    auxValue = Random.Range(0, haveDefense.Count);
                    auxCard = enemyTeam.startTeamPlayers[i].habilitys[haveDefense[auxValue]];

                    if (auxCard.manaCost < enemyTeam.startTeamPlayers[i].actualEnergy)
                    {
                        enemyTeam.startTeamPlayers[i].actualEnergy -= auxCard.manaCost;

                        enemyTeam.startTeamPlayers[i].actualDefence += auxCard.power + enemyTeam.startTeamPlayers[i].defence;
                        rightbar.transform.GetChild(0).GetChild(i).GetChild(5).GetChild(1).GetComponent<Text>().text = enemyTeam.startTeamPlayers[i].actualDefence.ToString();

                        enemyDefence += auxCard.power;
                        upbar.transform.GetChild(4).GetChild(1).GetChild(1).GetComponent<Text>().text = enemyDefence.ToString();
                    }
                    else
                    {
                        haveDefense.RemoveAt(auxValue);
                    }
                }
                else if (auxValue < (defenseProb + negativeProb) && haveNegative.Count > 0)
                {
                    auxValue = Random.Range(0, haveNegative.Count);
                    auxCard = enemyTeam.startTeamPlayers[i].habilitys[haveNegative[auxValue]];

                    if (auxCard.manaCost < enemyTeam.startTeamPlayers[i].actualEnergy)
                    {
                        if (i == 0)
                        {
                            habilityEnemy1.Add(auxCard);
                        }
                        else if (i == 1)
                        {
                            habilityEnemy2.Add(auxCard);
                        }
                        else if (i == 2)
                        {
                            habilityEnemy3.Add(auxCard);
                        }
                        else
                        {
                            habilityEnemy4.Add(auxCard);
                        }

                        enemyTeam.startTeamPlayers[i].actualEnergy -= auxCard.manaCost;
                    }
                    else
                    {
                        haveNegative.RemoveAt(auxValue);
                    }
                }
                else if (auxValue < (defenseProb + negativeProb + supportProb) && haveSupport.Count > 0)
                {
                    auxValue = Random.Range(0, haveSupport.Count);
                    auxCard = enemyTeam.startTeamPlayers[i].habilitys[haveSupport[auxValue]];

                    if (auxCard.manaCost < enemyTeam.startTeamPlayers[i].actualEnergy)
                    {
                        if (i == 0)
                        {
                            habilityEnemy1.Add(auxCard);
                        }
                        else if (i == 1)
                        {
                            habilityEnemy2.Add(auxCard);
                        }
                        else if (i == 2)
                        {
                            habilityEnemy3.Add(auxCard);
                        }
                        else
                        {
                            habilityEnemy4.Add(auxCard);
                        }

                        enemyTeam.startTeamPlayers[i].actualEnergy -= auxCard.manaCost;
                    }
                    else
                    {
                        haveSupport.RemoveAt(auxValue);
                    }
                }
                else if (haveAttackRepet.Count > 0 || haveAttackNormal.Count > 0 || haveAttackJump.Count > 0) //Ataques
                {
                    int damage = 0;

                    bool notNormal = false;
                    bool notJump = false;
                    bool notRep = false;
                    bool doDamage = false;
                    bool apply = false;

                    while (!apply)
                    {
                        auxValue = Random.Range(0, 100);

                        if (auxValue < atckNorProb && haveAttackNormal.Count > 0 && !notNormal) //Ataques normales
                        {
                            auxValue = Random.Range(0, haveAttackNormal.Count);
                            auxCard = enemyTeam.startTeamPlayers[i].habilitys[haveAttackNormal[auxValue]];

                            if (auxCard.manaCost < enemyTeam.startTeamPlayers[i].actualEnergy)
                            {
                                doDamage = true;

                                if (i == 0)
                                {
                                    habilityEnemy1.Add(auxCard);
                                }
                                else if (i == 1)
                                {
                                    habilityEnemy2.Add(auxCard);
                                }
                                else if (i == 2)
                                {
                                    habilityEnemy3.Add(auxCard);
                                }
                                else
                                {
                                    habilityEnemy4.Add(auxCard);
                                }

                                damage = auxCard.power;
                                enemyTeam.startTeamPlayers[i].actualEnergy -= auxCard.manaCost;

                                apply = true;
                            }
                            else
                            {
                                haveAttackNormal.RemoveAt(auxValue);

                                if (haveAttackNormal.Count == 0)
                                {
                                    notNormal = true;
                                }
                            }


                        }
                        else if (auxValue < atckNorProb + atckJumpProb && haveAttackJump.Count > 0 && !notJump) //Ataques con salto
                        {
                            auxValue = Random.Range(0, haveAttackJump.Count);
                            auxCard = enemyTeam.startTeamPlayers[i].habilitys[haveAttackJump[auxValue]];

                            if (auxCard.manaCost < enemyTeam.startTeamPlayers[i].actualEnergy)
                            {
                                doDamage = true;

                                if (i == 0)
                                {
                                    habilityEnemy1.Add(auxCard);
                                }
                                else if (i == 1)
                                {
                                    habilityEnemy2.Add(auxCard);
                                }
                                else if (i == 2)
                                {
                                    habilityEnemy3.Add(auxCard);
                                }
                                else
                                {
                                    habilityEnemy4.Add(auxCard);
                                }

                                damage = auxCard.power;
                                enemyTeam.startTeamPlayers[i].actualEnergy -= auxCard.manaCost;

                                apply = true;
                            }
                            else
                            {
                                haveAttackJump.RemoveAt(auxValue);

                                if (haveAttackJump.Count == 0)
                                {
                                    notJump = true;
                                }
                            }
                        }
                        else if (haveAttackRepet.Count > 0 && !notRep) //Ataques con repetición
                        {
                            auxValue = Random.Range(0, haveAttackRepet.Count);
                            auxCard = enemyTeam.startTeamPlayers[i].habilitys[haveAttackRepet[auxValue]];

                            if (auxCard.manaCost < enemyTeam.startTeamPlayers[i].actualEnergy)
                            {
                                int repetition = Random.Range(1, auxCard.repetition + 1);
                                doDamage = true;

                                if (i == 0)
                                {
                                    habilityEnemy1.Add(auxCard);
                                }
                                else if (i == 1)
                                {
                                    habilityEnemy2.Add(auxCard);
                                }
                                else if (i == 2)
                                {
                                    habilityEnemy3.Add(auxCard);
                                }
                                else
                                {
                                    habilityEnemy4.Add(auxCard);
                                }

                                damage = auxCard.power * repetition;
                                enemyTeam.startTeamPlayers[i].actualEnergy -= auxCard.manaCost;

                                apply = true;
                            }
                            else
                            {
                                haveAttackRepet.RemoveAt(auxValue);

                                if (haveAttackRepet.Count == 0)
                                {
                                    notRep = true;
                                }
                            }
                        }
                        else
                        {
                            apply = true;
                        }

                        if (notNormal && notJump && notRep)
                        {
                            j--;
                            apply = true;
                        }
                    }

                    if (doDamage)
                    {
                        enemyTeam.startTeamPlayers[i].actualAttack += damage;
                        enemyAttack += damage;

                        rightbar.transform.GetChild(0).GetChild(i).GetChild(4).GetChild(1).GetComponent<Text>().text = enemyTeam.startTeamPlayers[i].actualAttack.ToString();
                        upbar.transform.GetChild(4).GetChild(0).GetChild(1).GetComponent<Text>().text = enemyAttack.ToString();
                    }
                }
                else if (haveAttackRepet.Count > 0 || haveAttackNormal.Count > 0 || haveAttackJump.Count > 0 || haveSupport.Count > 0 || haveNegative.Count > 0 || haveDefense.Count > 0)
                {
                    j--;
                }
            }

            float auxScaleX = (float)enemyTeam.startTeamPlayers[i].actualEnergy / (float)enemyTeam.startTeamPlayers[i].energy;
            rightbar.transform.GetChild(0).GetChild(i).GetChild(1).GetChild(1).localScale = new Vector3(auxScaleX, 1, 1);
            rightbar.transform.GetChild(0).GetChild(i).GetChild(3).GetComponent<Text>().text = enemyTeam.startTeamPlayers[i].actualEnergy + "/" + enemyTeam.startTeamPlayers[i].energy;
        }
    }



    //////////////////////////////////////////////////////////////////////////////////
    //Fase 3 /////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Seleccionar jugador y mostrar cartas
    /// </summary>
    public void PositionSelected(int position)
    {
        positionSelected = position;

        if (playerTurn)
        {
            for (int i = 0; i < 4; i++)
            {
                if (playerTeam.playerPosition[i] == position)
                {
                    playerSelected = i;
                    ShowInfo(playerTeam.startTeamPlayers[i]);
                }
            }
        }
    }


    /// <summary>
    /// Aplica las habilidades que selecciona el jugador
    /// </summary>
    public void ApplyHability(int habilityIndex)
    {
        if (!attackAnimation)
        {
            Card auxCard;
            Animator auxAnimator, auxDamageAnimator;

            bool endMatch = false;
            bool kill;

            float auxScaleX;

            int lineSelected;
            int auxPositionSelected = positionSelected;
            int target = 0;
            int auxId = 0;
            int auxState = -1;

            auxCard = playerTeam.startTeamPlayers[playerSelected].habilitys[habilityIndex];

            playerTeam.startTeamPlayers[playerSelected].actualEnergy -= auxCard.manaCost;
            auxScaleX = (float)playerTeam.startTeamPlayers[playerSelected].actualEnergy / (float)playerTeam.startTeamPlayers[playerSelected].energy;
            leftbar.transform.GetChild(0).GetChild(playerSelected).GetChild(1).GetChild(1).localScale = new Vector3(auxScaleX, 1, 1);
            leftbar.transform.GetChild(0).GetChild(playerSelected).GetChild(3).GetComponent<Text>().text = playerTeam.startTeamPlayers[playerSelected].actualEnergy + "/" + playerTeam.startTeamPlayers[playerSelected].energy;
            
            //Prepara las animaciones de combate
            if (playerTeam.playerPosition[playerSelected] < 3)
            {
                lineSelected = 0;
                auxAnimator = battleArea.transform.GetChild(0).GetChild(0).GetChild(playerTeam.playerPosition[playerSelected]).GetChild(1).GetComponent<Animator>();
            }
            else if (playerTeam.playerPosition[playerSelected] < 6)
            {
                auxPositionSelected = positionSelected - 3;
                lineSelected = 1;
                auxAnimator = battleArea.transform.GetChild(0).GetChild(1).GetChild(playerTeam.playerPosition[playerSelected] - 3).GetChild(1).GetComponent<Animator>();
            }
            else
            {
                auxPositionSelected = positionSelected - 6;
                lineSelected = 2;
                auxAnimator = battleArea.transform.GetChild(0).GetChild(2).GetChild(playerTeam.playerPosition[playerSelected] - 6).GetChild(1).GetComponent<Animator>();
            }

            if (auxCard.type == Card.Type.DEFENSE)
            {
                battleArea.transform.GetChild(0).GetChild(lineSelected).GetChild(auxPositionSelected).GetChild(3).GetComponent<Text>().color = shieldColor;
                battleArea.transform.GetChild(0).GetChild(lineSelected).GetChild(auxPositionSelected).GetChild(3).GetComponent<Text>().text = auxCard.power.ToString();
                auxDamageAnimator = battleArea.transform.GetChild(0).GetChild(lineSelected).GetChild(auxPositionSelected).GetChild(3).GetComponent<Animator>();
                auxDamageAnimator.SetTrigger("DamageValue");

                playerTeam.startTeamPlayers[playerSelected].actualDefence += auxCard.power + playerTeam.startTeamPlayers[playerSelected].defence;
                leftbar.transform.GetChild(0).GetChild(playerSelected).GetChild(5).GetChild(1).GetComponent<Text>().text = playerTeam.startTeamPlayers[playerSelected].actualDefence.ToString();

                playerDefence += auxCard.power;
                upbar.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<Text>().text = "" + playerDefence;

                SetCommentorMessage(auxCard, playerTeam.startTeamPlayers[playerSelected], null, false, -1, -1);
            }
            else if (auxCard.type == Card.Type.ATTACK)
            {
                int damage = 0;
                int repetition = 1;

                if (auxCard.effect == Card.Effect.NONE || auxCard.effect == Card.Effect.REPETITION)
                {
                    if (firstLineEnemy > 0)
                    {
                        if (firstLineEnemy == 1)
                        {
                            auxId = enemyId1[0];
                        }
                        else
                        {
                            target = Random.Range(0, enemyId1.Count);
                            auxId = enemyId1[target];
                        }
                    }
                    else if (midLineEnemy > 0)
                    {
                        if (midLineEnemy == 1)
                        {
                            auxId = enemyId2[0];
                        }
                        else
                        {
                            target = Random.Range(0, enemyId2.Count);
                            auxId = enemyId2[target];
                        }
                    }
                    else
                    {
                        if (backLineEnemy == 1)
                        {
                            auxId = enemyId3[0];
                        }
                        else
                        {
                            target = Random.Range(0, enemyId3.Count);
                            auxId = enemyId3[target];
                        }
                    }

                    if (auxCard.effect == Card.Effect.REPETITION)
                    {
                        repetition = Random.Range(1, auxCard.repetition + 1);
                        damage = auxCard.power * repetition;
                    }
                    else
                    {
                        damage = auxCard.power;
                    }

                    playerTeam.startTeamPlayers[playerSelected].actualAttack += damage;
                    playerAttack += damage;

                    leftbar.transform.GetChild(0).GetChild(playerSelected).GetChild(4).GetChild(1).GetComponent<Text>().text = playerTeam.startTeamPlayers[playerSelected].actualAttack.ToString();
                    upbar.transform.GetChild(3).GetChild(0).GetChild(1).GetComponent<Text>().text = playerAttack.ToString();
                }
                else if (auxCard.effect == Card.Effect.JUMP)
                {
                    if (firstLineEnemy > 0)
                    {
                        if (midLineEnemy > 0)
                        {
                            if (midLineEnemy == 1)
                            {
                                auxId = enemyId2[0];
                            }
                            else
                            {
                                target = Random.Range(0, enemyId2.Count);
                                auxId = enemyId2[target];
                            }
                        }
                        else if (backLineEnemy > 0)
                        {
                            if (backLineEnemy == 1)
                            {
                                auxId = enemyId3[0];
                            }
                            else
                            {
                                target = Random.Range(0, enemyId3.Count);
                                auxId = enemyId3[target];
                            }
                        }
                        else
                        {
                            if (firstLineEnemy == 1)
                            {
                                auxId = enemyId1[0];
                            }
                            else
                            {
                                target = Random.Range(0, enemyId1.Count);
                                auxId = enemyId1[target];
                            }
                        }
                    }
                    else if (midLineEnemy > 0)
                    {
                        if (backLineEnemy > 0)
                        {
                            if (backLineEnemy == 1)
                            {
                                auxId = enemyId3[0];
                            }
                            else
                            {
                                target = Random.Range(0, enemyId3.Count);
                                auxId = enemyId3[target];
                            }
                        }
                        else
                        {
                            if (midLineEnemy == 1)
                            {
                                auxId = enemyId2[0];
                            }
                            else
                            {
                                target = Random.Range(0, enemyId2.Count);
                                auxId = enemyId2[target];
                            }
                        }
                    }
                    else
                    {
                        if (backLineEnemy == 1)
                        {
                            auxId = enemyId3[0];
                        }
                        else
                        {
                            target = Random.Range(0, enemyId3.Count);
                            auxId = enemyId3[target];
                        }
                    }

                    damage = auxCard.power;
                    playerTeam.startTeamPlayers[playerSelected].actualAttack += damage;
                    leftbar.transform.GetChild(0).GetChild(playerSelected).GetChild(4).GetChild(1).GetComponent<Text>().text = playerTeam.startTeamPlayers[playerSelected].actualAttack.ToString();

                    playerAttack += damage;
                    upbar.transform.GetChild(3).GetChild(0).GetChild(1).GetComponent<Text>().text = playerAttack.ToString();
                }

                kill = ApplyDamage(auxId, damage, playerTeam.startTeamPlayers[playerSelected], repetition, 0, auxCard);

                if (kill)
                {
                    endMatch = KillFighter(true, enemyTeam.startTeamPlayers[auxId], target);
                }
            }
            else if (auxCard.type == Card.Type.SUPPORT)
            {
                Sprite auxIcon = null;
                bool newState = false;

                switch (auxCard.support)
                {
                    case Card.Support.ATTACK:
                        if (playerTeam.startTeamPlayers[playerSelected].attack == 0)
                        {
                            newState = true;
                            auxIcon = habilityIcons[7];
                        }

                        auxState = 10;

                        if (playerTeam.startTeamPlayers[playerSelected].attack < 5)
                        {
                            playerTeam.startTeamPlayers[playerSelected].attack += auxCard.power;
                        }

                        break;
                    case Card.Support.DEFENSE:
                        if (playerTeam.startTeamPlayers[playerSelected].defence == 0)
                        {
                            newState = true;
                            auxIcon = habilityIcons[8];
                        }

                        auxState = 11;

                        if (playerTeam.startTeamPlayers[playerSelected].defence < 5)
                        {
                            playerTeam.startTeamPlayers[playerSelected].defence += auxCard.power;
                        }

                        break;
                    case Card.Support.HEALTH:
                        playerTeam.startTeamPlayers[playerSelected].actualLife += auxCard.power;

                        if (playerTeam.startTeamPlayers[playerSelected].actualLife > playerTeam.startTeamPlayers[playerSelected].life)
                        {
                            playerTeam.startTeamPlayers[playerSelected].actualLife = playerTeam.startTeamPlayers[playerSelected].life;
                        }

                        break;
                    case Card.Support.JUMPER:
                        auxState = 8;

                        if (!playerTeam.startTeamPlayers[playerSelected].jumper)
                        {
                            newState = true;
                            auxIcon = habilityIcons[10];
                            playerTeam.startTeamPlayers[playerSelected].jumper = true;
                        }

                        if (playerTeam.startTeamPlayers[playerSelected].jumperTurn < 5)
                        {
                            playerTeam.startTeamPlayers[playerSelected].jumperTurn += auxCard.power;
                        }

                        break;
                    case Card.Support.REPETITIVE:
                        auxState = 7;

                        if (!playerTeam.startTeamPlayers[playerSelected].repetitive)
                        {
                            newState = true;
                            auxIcon = habilityIcons[9];
                            playerTeam.startTeamPlayers[playerSelected].repetitive = true;
                        }

                        if (playerTeam.startTeamPlayers[playerSelected].repetitiveTurn < 5)
                        {
                            playerTeam.startTeamPlayers[playerSelected].repetitiveTurn += auxCard.power;
                        }

                        break;
                    case Card.Support.RECOVERYMANA:
                        auxState = 9;

                        if (playerTeam.startTeamPlayers[playerSelected].actualEnergyRecovery != playerTeam.startTeamPlayers[playerSelected].energyRecovery)
                        {
                            newState = true;
                            auxIcon = habilityIcons[11];
                            playerTeam.startTeamPlayers[playerSelected].actualEnergyRecovery += auxCard.power;
                        }

                        break;
                }
                
                if (newState)
                {
                    int states = playerTeam.startTeamPlayers[playerSelected].totalStates;

                    playerTeam.startTeamPlayers[playerSelected].states.Add(auxState);
                    playerTeam.startTeamPlayers[playerSelected].totalStates++;

                    leftbar.transform.GetChild(0).GetChild(playerSelected).GetChild(7).GetChild(states).gameObject.SetActive(true);
                    leftbar.transform.GetChild(0).GetChild(playerSelected).GetChild(7).GetChild(states).GetComponent<Image>().sprite = auxIcon;
                }

                SetCommentorMessage(auxCard, playerTeam.startTeamPlayers[playerSelected], null, newState, -1, auxState);

                ApplySupport(auxPositionSelected, playerTeam.startTeamPlayers[playerSelected].position, auxCard.support);
            }
            else if (auxCard.type == Card.Type.NEGATIVE)
            {
                Sprite auxIcon = null;
                bool newState = false;

                if (firstLineEnemy > 0)
                {
                    if (firstLineEnemy == 1)
                    {
                        auxId = enemyId1[0];
                    }
                    else
                    {
                        target = Random.Range(0, enemyId1.Count);
                        auxId = enemyId1[target];
                    }
                }
                else if (midLineEnemy > 0)
                {
                    if (midLineEnemy == 1)
                    {
                        auxId = enemyId2[0];
                    }
                    else
                    {
                        target = Random.Range(0, enemyId2.Count);
                        auxId = enemyId2[target];
                    }
                }
                else
                {
                    if (backLineEnemy == 1)
                    {
                        auxId = enemyId3[0];
                    }
                    else
                    {
                        target = Random.Range(0, enemyId3.Count);
                        auxId = enemyId3[target];
                    }
                }

                switch (auxCard.support)
                {
                    case Card.Support.ATTACK:
                        if (enemyTeam.startTeamPlayers[auxId].attack == 0)
                        {
                            newState = true;
                            auxIcon = habilityIcons[12];
                        }

                        auxState = 12;

                        if (newState || enemyTeam.startTeamPlayers[auxId].attack > -5)
                        {
                            enemyTeam.startTeamPlayers[auxId].attack -= auxCard.power;
                        }

                        break;

                    case Card.Support.DEFENSE:
                        if (enemyTeam.startTeamPlayers[auxId].defence == 0)
                        {
                            newState = true;
                            auxIcon = habilityIcons[13];
                        }

                        auxState = 13;

                        if (newState || enemyTeam.startTeamPlayers[auxId].defence > -5)
                        {
                            enemyTeam.startTeamPlayers[auxId].defence -= auxCard.power;
                        }

                        break;

                    case Card.Support.BLEED:
                        if (!enemyTeam.startTeamPlayers[auxId].bleed)
                        {
                            newState = true;
                            enemyTeam.startTeamPlayers[auxId].bleed = true;
                            auxIcon = habilityIcons[4];
                        }

                        auxState = 4;

                        if (newState || enemyTeam.startTeamPlayers[auxId].bleedTurn < 10)
                        {
                            enemyTeam.startTeamPlayers[auxId].bleedTurn += auxCard.power;
                        }

                        break;

                    case Card.Support.BLIND:
                        if (!enemyTeam.startTeamPlayers[auxId].blind)
                        {
                            newState = true;
                            enemyTeam.startTeamPlayers[auxId].blind = true;
                            auxIcon = habilityIcons[3];
                        }

                        auxState = 3;

                        if (newState || enemyTeam.startTeamPlayers[auxId].blindTurn < 5)
                        {
                            enemyTeam.startTeamPlayers[auxId].blindTurn += auxCard.power;
                        }

                        break;

                    case Card.Support.CONFUSION:
                        if (!enemyTeam.startTeamPlayers[auxId].confusion)
                        {
                            newState = true;
                            enemyTeam.startTeamPlayers[auxId].confusion = true;
                            auxIcon = habilityIcons[6];
                        }

                        auxState = 6;

                        if (newState || enemyTeam.startTeamPlayers[auxId].confusionTurn < 5)
                        {
                            enemyTeam.startTeamPlayers[auxId].confusionTurn += auxCard.power;
                        }

                        break;

                    case Card.Support.PARALYZE:
                        if (!enemyTeam.startTeamPlayers[auxId].paralyze)
                        {
                            newState = true;
                            enemyTeam.startTeamPlayers[auxId].paralyze = true;
                            auxIcon = habilityIcons[5];
                        }

                        auxState = 5;

                        if (newState || enemyTeam.startTeamPlayers[auxId].paralyzeTurn < 5)
                        {
                            enemyTeam.startTeamPlayers[auxId].paralyzeTurn += auxCard.power;
                        }

                        break;

                    case Card.Support.POISON:
                        if (!enemyTeam.startTeamPlayers[auxId].poison)
                        {
                            newState = true;
                            enemyTeam.startTeamPlayers[auxId].poison = true;
                            auxIcon = habilityIcons[2];
                        }

                        auxState = 2;

                        if (newState || enemyTeam.startTeamPlayers[auxId].poisonTurn < 5)
                        {
                            enemyTeam.startTeamPlayers[auxId].poisonTurn += auxCard.power;
                        }

                        break;
                }

                if (newState)
                {
                    int states = enemyTeam.startTeamPlayers[auxId].totalStates;

                    enemyTeam.startTeamPlayers[auxId].states.Add(auxState);
                    enemyTeam.startTeamPlayers[auxId].totalStates++;

                    rightbar.transform.GetChild(0).GetChild(auxId).GetChild(7).GetChild(states).gameObject.SetActive(true);
                    rightbar.transform.GetChild(0).GetChild(auxId).GetChild(7).GetChild(states).GetComponent<Image>().sprite = auxIcon;
                }
                
                SetCommentorMessage(auxCard, playerTeam.startTeamPlayers[playerSelected], enemyTeam.startTeamPlayers[auxId], newState, -1, auxState);

                ApplyNegative(auxId, playerTeam.startTeamPlayers[playerSelected].position, auxCard.support);
            }

            auxAnimator.SetTrigger("Attack");

            for (int i = 0; i < 5; i++)
            {
                CheckHabilitys(i);
            }

            //Maná
            skillArea.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = playerTeam.startTeamPlayers[playerSelected].actualEnergy + "/" + playerTeam.startTeamPlayers[playerSelected].energy;
            //Ataque
            skillArea.transform.GetChild(1).GetChild(2).GetComponent<Text>().text = playerTeam.startTeamPlayers[playerSelected].actualAttack.ToString();
            //Defensa
            skillArea.transform.GetChild(1).GetChild(3).GetComponent<Text>().text = playerTeam.startTeamPlayers[playerSelected].actualDefence.ToString();
            //Bajas
            skillArea.transform.GetChild(1).GetChild(4).GetComponent<Text>().text = playerTeam.startTeamPlayers[playerSelected].kills.ToString();

            StartCoroutine(WaitAttack());
            StartCoroutine(WaitAttackToKill(endMatch));
        }
    }


    /// <summary>
    /// Mostrar la información del jugador seleccionado
    /// </summary>
    private void ShowInfo(Player auxPlayer)
    {
        skillArea.transform.GetChild(0).gameObject.SetActive(true);
        skillArea.transform.GetChild(1).gameObject.SetActive(true);

        //Imagen de perfil
        skillArea.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = GetPortrait(auxPlayer.position);
        //Nombre
        skillArea.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = auxPlayer.playerName + " " + auxPlayer.playerSurname;

        //Habilidades
        for (int i = 0; i < 5; i++)
        {
            skillArea.transform.GetChild(0).GetChild(3).GetChild(i).GetComponent<Image>().sprite = auxPlayer.habilitys[i].artWork;
            CheckHabilitys(i);
        }

        //Vida
        skillArea.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = auxPlayer.actualLife + "/" + auxPlayer.life;
        //Mana
        skillArea.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = auxPlayer.actualEnergy + "/" + auxPlayer.energy;
        //Ataque
        skillArea.transform.GetChild(1).GetChild(2).GetComponent<Text>().text = auxPlayer.actualAttack.ToString();
        //Defensa
        skillArea.transform.GetChild(1).GetChild(3).GetComponent<Text>().text = auxPlayer.actualDefence.ToString();
        //Bajas
        skillArea.transform.GetChild(1).GetChild(4).GetComponent<Text>().text = auxPlayer.kills.ToString();
    }


    /// <summary>
    /// Mostrar la información de la habilidad sobre la que se situa el ratón
    /// </summary>
    public void ShowHabilityInfo(int selectedValue)
    {
        Card aux;
        Sprite icon;

        aux = playerTeam.startTeamPlayers[playerSelected].habilitys[selectedValue];

        habilityInfo.SetActive(true);

        switch (playerTeam.startTeamPlayers[playerSelected].habilitys[selectedValue].type)
        {
            case Card.Type.ATTACK:
                icon = habilityIcons[0];
                break;
            case Card.Type.DEFENSE:
                icon = habilityIcons[1];
                break;
            default:
                switch (playerTeam.startTeamPlayers[playerSelected].habilitys[selectedValue].support)
                {
                    case Card.Support.ATTACK:
                        if (aux.type == Card.Type.NEGATIVE)
                        {
                            icon = habilityIcons[12];
                        }
                        else
                        {
                            icon = habilityIcons[7];
                        }

                        break;
                    case Card.Support.DEFENSE:
                        if (aux.type == Card.Type.NEGATIVE)
                        {
                            icon = habilityIcons[13];
                        }
                        else
                        {
                            icon = habilityIcons[8];
                        }

                        break;
                    case Card.Support.POISON:
                        icon = habilityIcons[2];
                        break;
                    case Card.Support.BLIND:
                        icon = habilityIcons[3];
                        break;
                    case Card.Support.BLEED:
                        icon = habilityIcons[4];
                        break;
                    case Card.Support.PARALYZE:
                        icon = habilityIcons[5];
                        break;
                    case Card.Support.REPETITIVE:
                        icon = habilityIcons[9];
                        break;
                    case Card.Support.JUMPER:
                        icon = habilityIcons[10];
                        break;
                    case Card.Support.RECOVERYMANA:
                        icon = habilityIcons[11];
                        break;
                    default:
                        icon = habilityIcons[6];
                        break;
                }
                break;
        }

        habilityInfo.transform.GetChild(0).GetComponent<Text>().text = aux.name;
        habilityInfo.transform.GetChild(1).GetComponent<Text>().text = aux.power.ToString();
        habilityInfo.transform.GetChild(2).GetComponent<Text>().text = aux.manaCost.ToString();
        habilityInfo.transform.GetChild(3).GetComponent<Text>().text = aux.description;
        habilityInfo.transform.GetChild(4).GetComponent<Image>().sprite = icon;
    }


    /// <summary>
    /// Comprueba si se pueden emplear las habilidades y lo refleja en la interfaz
    /// </summary>
    private void CheckHabilitys(int id)
    {
        if (playerTeam.startTeamPlayers[playerSelected].habilitys[id].manaCost <= playerTeam.startTeamPlayers[playerSelected].actualEnergy)
        {
            skillArea.transform.GetChild(0).GetChild(3).GetChild(id).GetComponent<Button>().interactable = true;
        }
        else
        {
            skillArea.transform.GetChild(0).GetChild(3).GetChild(id).GetComponent<Button>().interactable = false;
        }
    }


    /// <summary>
    /// Oculta la info de las habilidades
    /// </summary>
    public void HideHabilityInfo()
    {
        habilityInfo.SetActive(false);
    }


    /// <summary>
    /// Devuelve la imagen del personaje según el rol
    /// </summary>
    private Sprite GetPortrait(Player.Position pos)
    {
        Sprite aux;

        switch (pos)
        {
            case Player.Position.ARPONER:
                aux = portrait[0];
                break;
            case Player.Position.ARCHER:
                aux = portrait[1];
                break;
            case Player.Position.WOLF:
                aux = portrait[2];
                break;
            case Player.Position.EXECUTER:
                aux = portrait[3];
                break;
            case Player.Position.SHIELD:
                aux = portrait[4];
                break;
            case Player.Position.MAGICIAN:
                aux = portrait[5];
                break;
            case Player.Position.PALADIN:
                aux = portrait[6];
                break;
            default:
                aux = portrait[7];
                break;
        }

        return aux;
    }


    /// <summary>
    /// Realiza el cálculo de daño, devuelve true si mata al objetivo
    /// </summary>
    private bool ApplyDamage(int auxId, int cardPower, Player attacker, int repetition, int state, Card card)
    {
        bool kill = false;

        int damage;
        int textColor = 0; //0 -- Blanco   1 -- Rojo   2 -- Verde
        int auxIndex, auxLine; //Índice del jugador que va a recibir el daño

        Animator auxAnimator, auxDamageAnimator;

        string auxType;

        auxType = GetType(attacker.position);
        
        if (enemyTeam.playerPosition[auxId] < 3)
        {
            auxIndex = enemyTeam.playerPosition[auxId];
            auxLine = 0;
        }
        else if (enemyTeam.playerPosition[auxId] < 6)
        {
            auxIndex = enemyTeam.playerPosition[auxId] - 3;
            auxLine = 1;
        }
        else
        {
            auxIndex = enemyTeam.playerPosition[auxId] - 6;
            auxLine = 2;
        }

        damage = cardPower - enemyTeam.startTeamPlayers[auxId].actualDefence;

        enemyTeam.startTeamPlayers[auxId].actualDefence -= cardPower;

        if (enemyTeam.startTeamPlayers[auxId].actualDefence < 0)
        {
            enemyTeam.startTeamPlayers[auxId].actualDefence = 0;
        }

        rightbar.transform.GetChild(0).GetChild(auxId).GetChild(5).GetChild(1).GetComponent<Text>().text = enemyTeam.startTeamPlayers[auxId].actualDefence.ToString();

        if (damage > 0)
        {
            textColor = 1;
            enemyTeam.startTeamPlayers[auxId].actualLife -= damage;

            if (enemyTeam.startTeamPlayers[auxId].actualLife <= 0)
            {
                enemyTeam.startTeamPlayers[auxId].actualLife = 0;
                kill = true;
            }

            float auxScaleX = (float)enemyTeam.startTeamPlayers[auxId].actualLife / (float)enemyTeam.startTeamPlayers[auxId].life;
            rightbar.transform.GetChild(0).GetChild(auxId).GetChild(1).GetChild(0).localScale = new Vector3(auxScaleX, 1, 1);
            rightbar.transform.GetChild(0).GetChild(auxId).GetChild(2).GetComponent<Text>().text = enemyTeam.startTeamPlayers[auxId].actualLife + "/" + enemyTeam.startTeamPlayers[auxId].life;
        }
        else
        {
            damage = 0;
        }

        if (textColor == 0)
        {
            battleArea.transform.GetChild(1).GetChild(auxLine).GetChild(auxIndex).GetChild(3).GetComponent<Text>().color = neutralColor;
        }
        else if (textColor == 1)
        {
            battleArea.transform.GetChild(1).GetChild(auxLine).GetChild(auxIndex).GetChild(3).GetComponent<Text>().color = damageColor;
        }

        if (repetition > 1)
        {
            battleArea.transform.GetChild(1).GetChild(auxLine).GetChild(auxIndex).GetChild(3).GetComponent<Text>().text = damage.ToString();
        }
        else
        {
            battleArea.transform.GetChild(1).GetChild(auxLine).GetChild(auxIndex).GetChild(3).GetComponent<Text>().text = damage.ToString();
        }

        auxDamageAnimator = battleArea.transform.GetChild(1).GetChild(auxLine).GetChild(auxIndex).GetChild(3).GetComponent<Animator>();
        auxDamageAnimator.SetTrigger("DamageValue");

        auxAnimator = battleArea.transform.GetChild(1).GetChild(auxLine).GetChild(auxIndex).GetChild(2).GetComponent<Animator>();
        auxAnimator.SetTrigger(auxType);

        //Selecciona los comentarios
        SetCommentorMessage(card, attacker, enemyTeam.startTeamPlayers[auxId], false, damage, state);

        return kill;
    }


    /// <summary>
    /// Realiza la animación de efecto negativo
    /// </summary>
    private void ApplyNegative(int auxId, Player.Position position, Card.Support support)
    {
        int auxIndex, auxLine; //Índice del jugador que va a recibir el daño
        string auxType, auxSupport;
        Animator auxAnimator, auxDamageAnimator;

        auxType = GetType(position);

        switch (support)
        {
            case Card.Support.ATTACK:
                auxSupport = dataBase.GetTranslatedWord("Baja Ataque");
                break;
            case Card.Support.DEFENSE:
                auxSupport = dataBase.GetTranslatedWord("Baja Defensa");
                break;
            case Card.Support.POISON:
                auxSupport = dataBase.GetTranslatedWord("Envenenado");
                break;
            case Card.Support.CONFUSION:
                auxSupport = dataBase.GetTranslatedWord("Confundido");
                break;
            case Card.Support.PARALYZE:
                auxSupport = dataBase.GetTranslatedWord("Paralizado");
                break;
            case Card.Support.BLEED:
                auxSupport = dataBase.GetTranslatedWord("Sangrando");
                break;
            case Card.Support.BLIND:
                auxSupport = dataBase.GetTranslatedWord("Cegado");
                break;
            default:
                auxSupport = dataBase.GetTranslatedWord("ERROR");
                break;
        }

        if (enemyTeam.playerPosition[auxId] < 3)
        {
            auxIndex = enemyTeam.playerPosition[auxId];
            auxLine = 0;
        }
        else if (enemyTeam.playerPosition[auxId] < 6)
        {
            auxIndex = enemyTeam.playerPosition[auxId] - 3;
            auxLine = 1;
        }
        else
        {
            auxIndex = enemyTeam.playerPosition[auxId] - 6;
            auxLine = 2;
        }

        auxAnimator = battleArea.transform.GetChild(1).GetChild(auxLine).GetChild(auxIndex).GetChild(2).GetComponent<Animator>();
        battleArea.transform.GetChild(1).GetChild(auxLine).GetChild(auxIndex).GetChild(3).GetComponent<Text>().color = damageColor;
        battleArea.transform.GetChild(1).GetChild(auxLine).GetChild(auxIndex).GetChild(3).GetComponent<Text>().text = auxSupport;
        auxDamageAnimator = battleArea.transform.GetChild(1).GetChild(auxLine).GetChild(auxIndex).GetChild(3).GetComponent<Animator>();

        auxAnimator.SetTrigger(auxType);
        auxDamageAnimator.SetTrigger("DamageValue");
    }


    /// <summary>
    /// Realiza la animación de efecto apoyo
    /// </summary>
    private void ApplySupport(int auxId, Player.Position position, Card.Support support)
    {
        int auxIndex, auxLine; //Índice del jugador que va a recibir el daño
        string auxType, auxSupport;
        Animator auxAnimator, auxDamageAnimator;

        auxType = GetType(position);

        switch (support)
        {
            case Card.Support.ATTACK:
                auxSupport = dataBase.GetTranslatedWord("Sube Ataque");
                break;
            case Card.Support.DEFENSE:
                auxSupport = dataBase.GetTranslatedWord("Sube Defensa");
                break;
            case Card.Support.JUMPER:
                auxSupport = dataBase.GetTranslatedWord("Saltador");
                break;
            case Card.Support.REPETITIVE:
                auxSupport = dataBase.GetTranslatedWord("Repetitivo");
                break;
            case Card.Support.RECOVERYMANA:
                auxSupport = dataBase.GetTranslatedWord("Recupera Mana");
                break;
            //case Card.Support.HEALTH:
            //auxSupport = dataBase.GetTranslatedWord("Recupera Mana");
            //break;
            default:
                auxSupport = dataBase.GetTranslatedWord("ERROR");
                break;
        }

        if (playerTeam.playerPosition[auxId] < 3)
        {
            auxIndex = playerTeam.playerPosition[auxId];
            auxLine = 0;
        }
        else if (playerTeam.playerPosition[auxId] < 6)
        {
            auxIndex = playerTeam.playerPosition[auxId] - 3;
            auxLine = 1;
        }
        else
        {
            auxIndex = playerTeam.playerPosition[auxId] - 6;
            auxLine = 2;
        }

        auxAnimator = battleArea.transform.GetChild(0).GetChild(auxLine).GetChild(auxIndex).GetChild(2).GetComponent<Animator>();
        battleArea.transform.GetChild(0).GetChild(auxLine).GetChild(auxIndex).GetChild(3).GetComponent<Text>().color = supportColor;
        battleArea.transform.GetChild(0).GetChild(auxLine).GetChild(auxIndex).GetChild(3).GetComponent<Text>().text = auxSupport;
        auxDamageAnimator = battleArea.transform.GetChild(0).GetChild(auxLine).GetChild(auxIndex).GetChild(3).GetComponent<Animator>();

        auxAnimator.SetTrigger(auxType);
        auxDamageAnimator.SetTrigger("DamageValue");
    }


    /// <summary>
    /// Termina el turno del jugador
    /// </summary>
    public void EndTurn()
    {
        HideInfo();

        if (habilityEnemy1.Count <= 0)
        {
            if (habilityEnemy2.Count > 0)
            {
                enemyPlayerSelected = 1;
            }
            else if (habilityEnemy3.Count > 0)
            {
                enemyPlayerSelected = 2;
            }
            else
            {
                enemyPlayerSelected = 3;
            }
        }
        else
        {
            enemyPlayerSelected = 0;
        }

        endEnemyTurn = false;
        HideHabilityInfo();
        ApplyPlayerStates(statePlayer);
    }



    //////////////////////////////////////////////////////////////////////////////////
    //Fase 4 /////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Realiza la animación de efecto apoyo
    /// - id: Identificador del personaje al que se le aplica
    /// </summary>
    public void ApplyEnemyStates(int id)
    {
        bool kill = false;
        bool endMatch = false;
        bool endState = false; //Último turno en el que se aplica el estado seleccionado
        bool finishApplyState = true; //Determina si ya se han aplicado todos los estados
        bool applyState = false;

        int state;
        int damage = 0;
        Debug.Log(id + "/" + enemyTeam.startTeamPlayers[id].totalStates + "/" + stateIndex);
        if (enemyTeam.startTeamPlayers[id].totalStates > 0 && enemyTeam.startTeamPlayers[id].actualLife > 0)
        {
            applyState = true;
            state = enemyTeam.startTeamPlayers[id].states[stateIndex];
            
            switch (state)
            {
                //2 -- Poison
                case 2:
                    enemyTeam.startTeamPlayers[id].poisonTurn--;

                    damage = (int)(enemyTeam.startTeamPlayers[id].life * 0.1f);
                    
                    if (damage <= 0)
                    {
                        damage = 1;
                    }

                    if (enemyTeam.startTeamPlayers[id].poisonTurn == 0)
                    {
                        enemyTeam.startTeamPlayers[id].poison = false;
                        endState = true;
                    }

                    break;
                //3 -- Blind
                case 3:
                    enemyTeam.startTeamPlayers[id].blindTurn--;

                    if (enemyTeam.startTeamPlayers[id].blindTurn == 0)
                    {
                        enemyTeam.startTeamPlayers[id].blind = false;

                        endState = true;
                    }

                    break;
                //4 -- Bleed
                case 4:
                    damage = enemyTeam.startTeamPlayers[id].bleedTurn;

                    enemyTeam.startTeamPlayers[id].bleedTurn--;

                    if (enemyTeam.startTeamPlayers[id].bleedTurn == 0)
                    {
                        enemyTeam.startTeamPlayers[id].bleed = false;

                        endState = true;
                    }

                    break;
                //5 -- Paralyze
                case 5:
                    enemyTeam.startTeamPlayers[id].paralyzeTurn--;

                    if (enemyTeam.startTeamPlayers[id].paralyzeTurn == 0)
                    {
                        enemyTeam.startTeamPlayers[id].paralyze = false;

                        endState = true;
                    }

                    break;
                //6 -- Confusion
                case 6:
                    enemyTeam.startTeamPlayers[id].confusionTurn--;

                    if (enemyTeam.startTeamPlayers[id].confusionTurn == 0)
                    {
                        enemyTeam.startTeamPlayers[id].confusion = false;
                        endState = true;
                    }

                    break;
                //7 -- AtackSup
                case 7:

                    break;
                //8 -- DefSup
                case 8:

                    break;
                //9 -- Repetition
                case 9:
                    enemyTeam.startTeamPlayers[id].repetitive = false;
                    endState = true;

                    break;
                //10 -- Jumper
                case 10:
                    enemyTeam.startTeamPlayers[id].jumper = false;
                    endState = true;

                    break;
                //11 -- RecoveryMana
                case 11:
                    enemyTeam.startTeamPlayers[id].actualEnergyRecovery -= 5;

                    if (enemyTeam.startTeamPlayers[id].actualEnergyRecovery == enemyTeam.startTeamPlayers[id].energyRecovery)
                    {
                        endState = true;
                    }

                    break;
                //12 -- AtaqueRoto
                case 12:

                    break;
                //13 -- DefensaRota
                case 13:

                    break;
            }

            if (damage > 0)
            {
                kill = ApplyDamage(id, damage, enemyTeam.startTeamPlayers[id], 0, state, null);
            }
            
            if (endState)
            {
                UpdateEnemyStates(id, stateIndex);
                enemyTeam.startTeamPlayers[id].states.RemoveAt(stateIndex);
                enemyTeam.startTeamPlayers[id].totalStates--;
                stateIndex--;
            }

            if (kill)
            {
                endMatch = KillFighter(true, enemyTeam.startTeamPlayers[id], id);

                if (!endMatch)
                {
                    finishApplyState = NextState();
                }
            }
            else
            {
                finishApplyState = NextState();
            }

            SetCommentorMessage(null, null, enemyTeam.startTeamPlayers[id], false, damage, state);
        }
        else
        {
            finishApplyState = NextState();
        }
       
        if (applyState)
        {
            StartCoroutine(WaitState(finishApplyState, endMatch));
            StartCoroutine(WaitAttack());
        }
        else
        {
            if (!endMatch)
            {
                if (!finishApplyState)
                {
                    stateActive = true;
                    ApplyEnemyStates(statePlayer);
                }
                else
                {
                    stateActive = false;
                    StartAITurn(false);
                    PlayerTurn();
                }
            }
        }
    }


    /// <summary>
    /// Actualiza la lista de estados tras el efecto negativo o de apoyo
    /// - localPlayer: El jugador pertenece al equipo local
    /// - playerId: Identificador del personaje al que se le aplica
    /// </summary>
    private void UpdateEnemyStates(int playerId, int statePosition)
    {
        if (enemyTeam.startTeamPlayers[playerId].totalStates != statePosition + 1)
        {
            Debug.Log("bucle borrado");
            for (int i = statePosition; i < playerTeam.startTeamPlayers[playerId].totalStates - 1; i++)
            {
                rightbar.transform.GetChild(0).GetChild(playerId).GetChild(7).GetChild(i).GetComponent<Image>().sprite = rightbar.transform.GetChild(0).GetChild(playerId).GetChild(7).GetChild(i + 1).GetComponent<Image>().sprite;
            }

            rightbar.transform.GetChild(0).GetChild(playerId).GetChild(7).GetChild(playerTeam.startTeamPlayers[playerId].totalStates - 1).gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("borro");
            rightbar.transform.GetChild(0).GetChild(playerId).GetChild(7).GetChild(statePosition).gameObject.SetActive(false);
        }
    }


    
    /// <summary>
    /// Oculta la información del personaje
    /// </summary>
    private void HideInfo()
    {
        skillArea.transform.GetChild(0).gameObject.SetActive(false);
        skillArea.transform.GetChild(1).gameObject.SetActive(false);
    }



    //////////////////////////////////////////////////////////////////////////////////
    //Fase 5 /////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Inicia el turno del enemigo
    /// </summary>
    private void EnemyTurn()
    {
        enemyPlayerSelected = 0;
        habilitySelected = 0;

        if (habilityEnemy1.Count == 0 || enemyTeam.startTeamPlayers[0].actualLife == 0)
        {
            if (habilityEnemy2.Count > 0 || enemyTeam.startTeamPlayers[1].actualLife == 0)
            {
                enemyPlayerSelected = 1;
            }
            else if (habilityEnemy3.Count > 0 || enemyTeam.startTeamPlayers[2].actualLife == 0)
            {
                enemyPlayerSelected = 2;
            }
            else
            {
                enemyPlayerSelected = 3;
            }
        }

        playerTurn = false;
        ApplyEnemyHability();
    }


    /// <summary>
    /// Realiza el cálculo de daño, devuelve true si mata al objetivo
    /// auxId -- Identificador del objetivo al que se va a golpear
    /// cardPower -- daño a realizar sin contar la defensa del objetivo
    /// enemyPlayer -- info del atacante
    /// repetition -- número de veces que se golpea
    /// state -- 0: ataque  1: veneno  2: sangrado
    /// </summary>
    private bool ApplyEnemyDamage(int auxId, int cardPower, Player enemyPlayer, int state, Card card)
    {
        bool kill = false;

        int damage;
        int textColor = 0; //0 -- Blanco   1 -- Rojo   2 -- Verde
        int auxIndex, auxLine; //Índice del jugador que va a recibir el daño

        Animator auxAnimator, auxDamageAnimator;

        string auxType;

        auxType = GetType(enemyPlayer.position);

        if (playerTeam.playerPosition[auxId] < 3)
        {
            auxIndex = playerTeam.playerPosition[auxId];
            auxLine = 0;
        }
        else if (playerTeam.playerPosition[auxId] < 6)
        {
            auxIndex = playerTeam.playerPosition[auxId] - 3;
            auxLine = 1;
        }
        else
        {
            auxIndex = playerTeam.playerPosition[auxId] - 6;
            auxLine = 2;
        }

        damage = cardPower - playerTeam.startTeamPlayers[auxId].actualDefence;
        playerTeam.startTeamPlayers[auxId].actualDefence -= cardPower;

        if (playerTeam.startTeamPlayers[auxId].actualDefence < 0)
        {
            playerTeam.startTeamPlayers[auxId].actualDefence = 0;
        }

        leftbar.transform.GetChild(0).GetChild(auxId).GetChild(5).GetChild(1).GetComponent<Text>().text = playerTeam.startTeamPlayers[auxId].actualDefence.ToString();

        if (damage > 0)
        {
            textColor = 1;
            playerTeam.startTeamPlayers[auxId].actualLife -= damage;

            if (playerTeam.startTeamPlayers[auxId].actualLife <= 0)
            {
                playerTeam.startTeamPlayers[auxId].actualLife = 0;
                kill = true;
            }

            float auxScaleX = (float)playerTeam.startTeamPlayers[auxId].actualLife / (float)playerTeam.startTeamPlayers[auxId].life;
            leftbar.transform.GetChild(0).GetChild(auxId).GetChild(1).GetChild(0).localScale = new Vector3(auxScaleX, 1, 1);
            leftbar.transform.GetChild(0).GetChild(auxId).GetChild(2).GetComponent<Text>().text = playerTeam.startTeamPlayers[auxId].actualLife + "/" + playerTeam.startTeamPlayers[auxId].life;
        }
        
        if (textColor == 0)
        {
            battleArea.transform.GetChild(0).GetChild(auxLine).GetChild(auxIndex).GetChild(3).GetComponent<Text>().color = neutralColor;
        }
        else if (textColor == 1)
        {
            battleArea.transform.GetChild(0).GetChild(auxLine).GetChild(auxIndex).GetChild(3).GetComponent<Text>().color = damageColor;
        }

        battleArea.transform.GetChild(0).GetChild(auxLine).GetChild(auxIndex).GetChild(3).GetComponent<Text>().text = damage.ToString();

        auxDamageAnimator = battleArea.transform.GetChild(0).GetChild(auxLine).GetChild(auxIndex).GetChild(3).GetComponent<Animator>();
        auxDamageAnimator.SetTrigger("DamageValue");

        auxAnimator = battleArea.transform.GetChild(0).GetChild(auxLine).GetChild(auxIndex).GetChild(2).GetComponent<Animator>();
        auxAnimator.SetTrigger(auxType);

        //Selecciona los comentarios
        SetCommentorMessage(card, enemyPlayer, playerTeam.startTeamPlayers[auxId], false, damage, state);

        return kill;
    }


    /// <summary>
    /// Aplica las habilidades que selecciona el jugador
    /// </summary>
    public void ApplyEnemyHability()
    {
        Card auxCard;
        Animator auxAnimator;
        
        if (enemyPlayerSelected == 0)
        {
            auxCard = habilityEnemy1[habilitySelected];
        }
        else if (enemyPlayerSelected == 1)
        {
            auxCard = habilityEnemy2[habilitySelected];
        }
        else if (enemyPlayerSelected == 2)
        {
            auxCard = habilityEnemy3[habilitySelected];
        }
        else
        {
            auxCard = habilityEnemy4[habilitySelected];
        }
        
        //Prepara las animaciones de combate
        if (enemyTeam.playerPosition[enemyPlayerSelected] < 3)
        {
            auxAnimator = battleArea.transform.GetChild(1).GetChild(0).GetChild(enemyTeam.playerPosition[enemyPlayerSelected]).GetChild(1).GetComponent<Animator>();
        }
        else if (enemyTeam.playerPosition[enemyPlayerSelected] < 6)
        {
            auxAnimator = battleArea.transform.GetChild(1).GetChild(1).GetChild(enemyTeam.playerPosition[enemyPlayerSelected] - 3).GetChild(1).GetComponent<Animator>();
        }
        else
        {
            auxAnimator = battleArea.transform.GetChild(1).GetChild(2).GetChild(enemyTeam.playerPosition[enemyPlayerSelected] - 6).GetChild(1).GetComponent<Animator>();
        }

        ApplyEnemyType(auxCard);

        auxAnimator.SetTrigger("Attack");

        StartCoroutine(WaitAttack());
    }


    /// <summary>
    /// Ejecuta el ataque del personaje visitante
    /// </summary>
    public void ApplyEnemyType(Card auxCard)
    {
        bool kill;
        bool endMatch = false;

        int target = 0;
        int auxId = 0;
        int auxState = -1;

        if (auxCard.type == Card.Type.ATTACK)
        {
            int damage = 0;
            int repetition;

            if (auxCard.effect == Card.Effect.NONE || auxCard.effect == Card.Effect.REPETITION)
            {
                if (firstLinePlayer > 0)
                {
                    if (firstLinePlayer == 1)
                    {
                        auxId = playerId1[0];
                    }
                    else
                    {
                        target = Random.Range(0, playerId1.Count);
                        auxId = playerId1[target];
                    }
                }
                else if (midLinePlayer > 0)
                {
                    if (midLinePlayer == 1)
                    {
                        auxId = playerId2[0];
                    }
                    else
                    {
                        target = Random.Range(0, playerId2.Count);
                        auxId = playerId2[target];
                    }
                }
                else
                {
                    if (backLinePlayer == 1)
                    {
                        auxId = playerId3[0];
                    }
                    else
                    {
                        target = Random.Range(0, playerId3.Count);
                        auxId = playerId3[target];
                    }
                }

                if (auxCard.effect == Card.Effect.REPETITION)
                {
                    repetition = Random.Range(1, auxCard.repetition + 1);
                    damage = auxCard.power * repetition;
                }
                else
                {
                    damage = auxCard.power;
                }

                enemyTeam.startTeamPlayers[enemyPlayerSelected].actualAttack += damage;
                enemyAttack += damage;
            }
            else if (auxCard.effect == Card.Effect.JUMP)
            {
                if (firstLinePlayer > 0)
                {
                    if (midLinePlayer > 0)
                    {
                        if (midLinePlayer == 1)
                        {
                            auxId = playerId2[0];
                        }
                        else
                        {
                            target = Random.Range(0, playerId2.Count);
                            auxId = playerId2[target];
                        }
                    }
                    else if (backLinePlayer > 0)
                    {
                        if (backLinePlayer == 1)
                        {
                            auxId = playerId3[0];
                        }
                        else
                        {
                            target = Random.Range(0, playerId3.Count);
                            auxId = playerId3[target];
                        }
                    }
                    else
                    {
                        if (firstLinePlayer == 1)
                        {
                            auxId = playerId1[0];
                        }
                        else
                        {
                            target = Random.Range(0, playerId1.Count);
                            auxId = playerId1[target];
                        }
                    }
                }
                else if (midLinePlayer > 0)
                {
                    if (backLinePlayer > 0)
                    {
                        if (backLinePlayer == 1)
                        {
                            auxId = playerId3[0];
                        }
                        else
                        {
                            target = Random.Range(0, playerId3.Count);
                            auxId = playerId3[target];
                        }
                    }
                    else
                    {
                        if (midLinePlayer == 1)
                        {
                            auxId = playerId2[0];
                        }
                        else
                        {
                            target = Random.Range(0, playerId2.Count);
                            auxId = playerId2[target];
                        }
                    }
                }
                else
                {
                    if (backLinePlayer == 1)
                    {
                        auxId = playerId3[0];
                    }
                    else
                    {
                        target = Random.Range(0, playerId3.Count);
                        auxId = playerId3[target];
                    }
                }

                damage = auxCard.power;
                enemyTeam.startTeamPlayers[enemyPlayerSelected].actualAttack += damage;
            }

            kill = ApplyEnemyDamage(auxId, damage, enemyTeam.startTeamPlayers[enemyPlayerSelected], 0, auxCard);

            if (kill)
            {
                endMatch = KillFighter(false, playerTeam.startTeamPlayers[target], target);
            }
        }
        else if (auxCard.type == Card.Type.SUPPORT)
        {
            Sprite auxIcon = null;
            bool newState = false;

            switch (auxCard.support)
            {
                case Card.Support.ATTACK:
                    if (enemyTeam.startTeamPlayers[enemyPlayerSelected].actualAttack == 0)
                    {
                        newState = true;
                        auxIcon = habilityIcons[7];
                    }
                    
                    auxState = 10;

                    if (enemyTeam.startTeamPlayers[enemyPlayerSelected].actualAttack < 5)
                    {
                        enemyTeam.startTeamPlayers[enemyPlayerSelected].actualAttack += auxCard.power;
                    }

                    break;

                case Card.Support.DEFENSE:
                    if (enemyTeam.startTeamPlayers[enemyPlayerSelected].actualDefence == 0)
                    {
                        newState = true;
                        auxIcon = habilityIcons[8];
                    }

                    auxState = 11;

                    if (enemyTeam.startTeamPlayers[enemyPlayerSelected].actualDefence < 5)
                    {
                        enemyTeam.startTeamPlayers[enemyPlayerSelected].actualDefence += auxCard.power;
                    }

                    break;

                case Card.Support.HEALTH:
                    enemyTeam.startTeamPlayers[enemyPlayerSelected].actualLife += auxCard.power;

                    if (enemyTeam.startTeamPlayers[enemyPlayerSelected].actualLife > enemyTeam.startTeamPlayers[enemyPlayerSelected].life)
                    {
                        enemyTeam.startTeamPlayers[enemyPlayerSelected].actualLife = enemyTeam.startTeamPlayers[enemyPlayerSelected].life;
                    }

                    break;

                case Card.Support.JUMPER:
                    if (!enemyTeam.startTeamPlayers[enemyPlayerSelected].jumper)
                    {
                        newState = true;
                        auxIcon = habilityIcons[10];
                        enemyTeam.startTeamPlayers[enemyPlayerSelected].jumper = true;
                    }

                    auxState = 8;

                    if (enemyTeam.startTeamPlayers[enemyPlayerSelected].jumperTurn < 5)
                    {
                        enemyTeam.startTeamPlayers[enemyPlayerSelected].jumperTurn += auxCard.power;
                    }

                    break;

                case Card.Support.REPETITIVE:
                    if (!enemyTeam.startTeamPlayers[enemyPlayerSelected].repetitive)
                    {
                        newState = true;
                        auxIcon = habilityIcons[9];
                        enemyTeam.startTeamPlayers[enemyPlayerSelected].repetitive = true;
                    }

                    auxState = 7;

                    if (enemyTeam.startTeamPlayers[enemyPlayerSelected].repetitiveTurn < 5)
                    {
                        enemyTeam.startTeamPlayers[enemyPlayerSelected].repetitiveTurn += auxCard.power;
                    }

                    break;

                case Card.Support.RECOVERYMANA:
                    if (enemyTeam.startTeamPlayers[enemyPlayerSelected].actualEnergyRecovery != enemyTeam.startTeamPlayers[enemyPlayerSelected].energyRecovery)
                    {
                        newState = true;
                        auxIcon = habilityIcons[11];
                        enemyTeam.startTeamPlayers[enemyPlayerSelected].actualEnergyRecovery += auxCard.power;
                    }

                    auxState = 9;

                    break;
            }

            if (newState)
            {
                int states = enemyTeam.startTeamPlayers[enemyPlayerSelected].totalStates;

                enemyTeam.startTeamPlayers[enemyPlayerSelected].states.Add(auxState);
                enemyTeam.startTeamPlayers[enemyPlayerSelected].totalStates++;

                rightbar.transform.GetChild(0).GetChild(enemyPlayerSelected).GetChild(7).GetChild(states).gameObject.SetActive(true);
                rightbar.transform.GetChild(0).GetChild(enemyPlayerSelected).GetChild(7).GetChild(states).GetComponent<Image>().sprite = auxIcon;
            }

            SetCommentorMessage(auxCard, enemyTeam.startTeamPlayers[enemyPlayerSelected], null, newState, -1, auxState);
            ApplyEnemySupport(enemyTeam.startTeamPlayers[enemyPlayerSelected].position, auxCard.support);
        }
        else if (auxCard.type == Card.Type.NEGATIVE)
        {
            Sprite auxIcon = null;
            bool newState = false;

            if (firstLineEnemy > 0)
            {
                if (firstLinePlayer == 1)
                {
                    auxId = playerId1[0];
                }
                else
                {
                    target = Random.Range(0, playerId1.Count);
                    auxId = playerId1[target];
                }
            }
            else if (midLinePlayer > 0)
            {
                if (midLinePlayer == 1)
                {
                    auxId = playerId2[0];
                }
                else
                {
                    target = Random.Range(0, playerId2.Count);
                    auxId = playerId2[target];
                }
            }
            else
            {
                if (backLinePlayer == 1)
                {
                    auxId = playerId3[0];
                }
                else
                {
                    target = Random.Range(0, playerId3.Count);
                    auxId = playerId3[target];
                }
            }

            switch (auxCard.support)
            {
                case Card.Support.ATTACK:
                    if (playerTeam.startTeamPlayers[auxId].actualAttack == 0)
                    {
                        newState = true;
                        auxIcon = habilityIcons[12];
                    }

                    auxState = 12;

                    if (playerTeam.startTeamPlayers[auxId].actualAttack > -5)
                    {
                        playerTeam.startTeamPlayers[auxId].actualAttack -= auxCard.power;
                    }

                    break;
                case Card.Support.DEFENSE:
                    if (playerTeam.startTeamPlayers[auxId].actualDefence == 0)
                    {
                        newState = true;
                        auxIcon = habilityIcons[13];
                    }

                    auxState = 13;

                    if (playerTeam.startTeamPlayers[auxId].actualDefence > -5)
                    {
                        playerTeam.startTeamPlayers[auxId].actualDefence -= auxCard.power;
                    }

                    break;
                case Card.Support.BLEED:
                    if (!playerTeam.startTeamPlayers[auxId].bleed)
                    {
                        newState = true;
                        playerTeam.startTeamPlayers[auxId].bleed = true;
                        auxIcon = habilityIcons[4];
                    }

                    auxState = 4;

                    if (playerTeam.startTeamPlayers[auxId].bleedTurn < 5)
                    {
                        playerTeam.startTeamPlayers[auxId].bleedTurn += auxCard.power;
                    }

                    break;
                case Card.Support.BLIND:
                    if (!playerTeam.startTeamPlayers[auxId].blind)
                    {
                        newState = true;
                        playerTeam.startTeamPlayers[auxId].blind = true;
                        auxIcon = habilityIcons[3];
                    }

                    auxState = 3;

                    if (playerTeam.startTeamPlayers[auxId].blindTurn < 5)
                    {
                        playerTeam.startTeamPlayers[auxId].blindTurn += auxCard.power;
                    }

                    break;
                case Card.Support.CONFUSION:
                    if (!playerTeam.startTeamPlayers[auxId].confusion)
                    {
                        newState = true;
                        playerTeam.startTeamPlayers[auxId].confusion = true;
                        auxIcon = habilityIcons[6];
                    }

                    auxState = 6;

                    if (playerTeam.startTeamPlayers[auxId].confusionTurn < 5)
                    {
                        playerTeam.startTeamPlayers[auxId].confusionTurn += auxCard.power;
                    }

                    break;
                case Card.Support.PARALYZE:
                    if (!playerTeam.startTeamPlayers[auxId].paralyze)
                    {
                        newState = true;
                        playerTeam.startTeamPlayers[auxId].paralyze = true;
                        auxIcon = habilityIcons[5];
                    }

                    auxState = 5;

                    if (playerTeam.startTeamPlayers[auxId].paralyzeTurn < 5)
                    {
                        playerTeam.startTeamPlayers[auxId].paralyzeTurn += auxCard.power;
                    }

                    break;
                case Card.Support.POISON:
                    if (!playerTeam.startTeamPlayers[auxId].poison)
                    {
                        newState = true;
                        playerTeam.startTeamPlayers[auxId].poison = true;
                        auxIcon = habilityIcons[2];
                    }

                    auxState = 2;

                    if (playerTeam.startTeamPlayers[auxId].poisonTurn < 5)
                    {
                        playerTeam.startTeamPlayers[auxId].poisonTurn += auxCard.power;
                    }

                    break;
            }

            if (newState)
            {
                int states = playerTeam.startTeamPlayers[auxId].totalStates;

                playerTeam.startTeamPlayers[auxId].states.Add(auxState);
                playerTeam.startTeamPlayers[auxId].totalStates++;

                leftbar.transform.GetChild(0).GetChild(auxId).GetChild(7).GetChild(states).gameObject.SetActive(true);
                leftbar.transform.GetChild(0).GetChild(auxId).GetChild(7).GetChild(states).GetComponent<Image>().sprite = auxIcon;
            }

            SetCommentorMessage(auxCard, enemyTeam.startTeamPlayers[enemyPlayerSelected], playerTeam.startTeamPlayers[auxId], newState, -1, auxState);
            ApplyEnemyNegative(auxId, enemyTeam.startTeamPlayers[enemyPlayerSelected].position, auxCard.support);
        }

        StartCoroutine(WaitAttackToKill(endMatch));
    }


    /// <summary>
    /// Realiza la animación de efecto negativo del enemigo
    /// </summary>
    private void ApplyEnemyNegative(int auxId, Player.Position position, Card.Support support)
    {
        int auxIndex, auxLine; //Índice del jugador que va a recibir el daño
        string auxType, auxSupport;
        Animator auxAnimator, auxDamageAnimator;

        auxType = GetType(position);

        switch (support)
        {
            case Card.Support.ATTACK:
                auxSupport = dataBase.GetTranslatedWord("Baja Ataque");
                break;
            case Card.Support.DEFENSE:
                auxSupport = dataBase.GetTranslatedWord("Baja Defensa");
                break;
            case Card.Support.POISON:
                auxSupport = dataBase.GetTranslatedWord("Envenenado");
                break;
            case Card.Support.CONFUSION:
                auxSupport = dataBase.GetTranslatedWord("Confundido");
                break;
            case Card.Support.PARALYZE:
                auxSupport = dataBase.GetTranslatedWord("Paralizado");
                break;
            case Card.Support.BLEED:
                auxSupport = dataBase.GetTranslatedWord("Sangrando");
                break;
            case Card.Support.BLIND:
                auxSupport = dataBase.GetTranslatedWord("Cegado");
                break;
            default:
                auxSupport = dataBase.GetTranslatedWord("ERROR");
                break;
        }

        if (playerTeam.playerPosition[auxId] < 3)
        {
            auxIndex = playerTeam.playerPosition[auxId];
            auxLine = 0;
        }
        else if (playerTeam.playerPosition[auxId] < 6)
        {
            auxIndex = playerTeam.playerPosition[auxId] - 3;
            auxLine = 1;
        }
        else
        {
            auxIndex = playerTeam.playerPosition[auxId] - 6;
            auxLine = 2;
        }

        auxAnimator = battleArea.transform.GetChild(0).GetChild(auxLine).GetChild(auxIndex).GetChild(2).GetComponent<Animator>();
        battleArea.transform.GetChild(0).GetChild(auxLine).GetChild(auxIndex).GetChild(3).GetComponent<Text>().color = damageColor;
        battleArea.transform.GetChild(0).GetChild(auxLine).GetChild(auxIndex).GetChild(3).GetComponent<Text>().text = auxSupport;
        auxDamageAnimator = battleArea.transform.GetChild(0).GetChild(auxLine).GetChild(auxIndex).GetChild(3).GetComponent<Animator>();

        auxAnimator.SetTrigger(auxType);
        auxDamageAnimator.SetTrigger("DamageValue");
    }


    /// <summary>
    /// Realiza la animación de efecto apoyo enemigo
    /// </summary>
    private void ApplyEnemySupport(Player.Position position, Card.Support support)
    {
        int auxLine; //Índice del jugador que va a recibir el daño
        string auxType, auxSupport;
        Animator auxAnimator, auxDamageAnimator;

        auxType = GetType(position);

        switch (support)
        {
            case Card.Support.ATTACK:
                auxSupport = dataBase.GetTranslatedWord("Sube Ataque");
                break;
            case Card.Support.DEFENSE:
                auxSupport = dataBase.GetTranslatedWord("Sube Defensa");
                break;
            case Card.Support.JUMPER:
                auxSupport = dataBase.GetTranslatedWord("Saltador");
                break;
            case Card.Support.REPETITIVE:
                auxSupport = dataBase.GetTranslatedWord("Repetitivo");
                break;
            case Card.Support.RECOVERYMANA:
                auxSupport = dataBase.GetTranslatedWord("Recupera Mana");
                break;
            //case Card.Support.HEALTH:
            //auxSupport = dataBase.GetTranslatedWord("Recupera Mana");
            //break;
            default:
                auxSupport = dataBase.GetTranslatedWord("ERROR");
                break;
        }

        if (enemyTeam.playerPosition[enemyPlayerSelected] < 3)
        {
            auxLine = 0;
        }
        else if (enemyTeam.playerPosition[enemyPlayerSelected] < 6)
        {
            auxLine = 1;
        }
        else
        {
            auxLine = 2;
        }

        int auxPosition = enemyTeam.playerPosition[enemyPlayerSelected] % 3;

        auxAnimator = battleArea.transform.GetChild(1).GetChild(auxLine).GetChild(auxPosition).GetChild(2).GetComponent<Animator>();
        battleArea.transform.GetChild(1).GetChild(auxLine).GetChild(auxPosition).GetChild(3).GetComponent<Text>().color = supportColor;
        battleArea.transform.GetChild(1).GetChild(auxLine).GetChild(auxPosition).GetChild(3).GetComponent<Text>().text = auxSupport;
        auxDamageAnimator = battleArea.transform.GetChild(1).GetChild(auxLine).GetChild(auxPosition).GetChild(3).GetComponent<Animator>();

        auxAnimator.SetTrigger(auxType);
        auxDamageAnimator.SetTrigger("DamageValue");
    }



    //////////////////////////////////////////////////////////////////////////////////
    //Fase 6 /////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Realiza la animación de efecto apoyo
    /// - localTurn: El estado se aplica a un personaje local
    /// - id: Identificador del personaje al que se le aplica
    /// </summary>
    public void ApplyPlayerStates(int id)
    {
        bool kill = false;
        bool endMatch = false;
        bool endState = false; //Último turno en el que se aplica el estado seleccionado
        bool finishApplyState = true; //Determina si ya se han aplicado todos los estados
        bool applyState = false;

        int state;
        int damage = 0;

        //Animator auxAnimator, auxDamageAnimator;
        //Debug.Log(id + "/" + playerTeam.startTeamPlayers[id].totalStates);
        if (playerTeam.startTeamPlayers[id].totalStates > 0 && playerTeam.startTeamPlayers[id].actualLife > 0)
        {
            applyState = true;
            state = playerTeam.startTeamPlayers[id].states[id];

            int type = -1;
            
            switch (state)
            {
                //2 -- Poison
                case 2:
                    type = 1;
                    playerTeam.startTeamPlayers[id].poisonTurn--;

                    damage = (int)(playerTeam.startTeamPlayers[id].life * 0.1f);

                    if (damage <= 0)
                    {
                        damage = 1;
                    }

                    if (playerTeam.startTeamPlayers[id].poisonTurn == 0)
                    {
                        playerTeam.startTeamPlayers[id].poison = false;

                        endState = true;
                    }

                    break;
                //3 -- Blind
                case 3:
                    type = 3;
                    playerTeam.startTeamPlayers[id].blindTurn--;

                    if (playerTeam.startTeamPlayers[id].blindTurn == 0)
                    {
                        playerTeam.startTeamPlayers[id].blind = false;

                        endState = true;
                    }

                    break;
                //4 -- Bleed
                case 4:
                    type = 2;
                    damage = playerTeam.startTeamPlayers[id].bleedTurn;

                    playerTeam.startTeamPlayers[id].bleedTurn--;

                    if (playerTeam.startTeamPlayers[id].bleedTurn == 0)
                    {
                        playerTeam.startTeamPlayers[id].bleed = false;

                        endState = true;
                    }

                    break;
                //5 -- Paralyze
                case 5:
                    type = 4;
                    playerTeam.startTeamPlayers[id].paralyzeTurn--;

                    if (playerTeam.startTeamPlayers[id].paralyzeTurn == 0)
                    {
                        playerTeam.startTeamPlayers[id].paralyze = false;

                        endState = true;
                    }

                    break;
                //6 -- Confusion
                case 6:
                    type = 5;
                    playerTeam.startTeamPlayers[id].confusionTurn--;

                    if (playerTeam.startTeamPlayers[id].confusionTurn == 0)
                    {
                        playerTeam.startTeamPlayers[id].confusion = false;

                        endState = true;
                    }

                    break;
                //7 -- AtackSup
                case 7:

                    break;
                //8 -- DefSup
                case 8:

                    break;
                //9 -- Repetition
                case 9:
                    type = 6;
                    playerTeam.startTeamPlayers[id].repetitive = false;
                    endState = true;

                    break;
                //10 -- Jumper
                case 10:
                    type = 7;
                    playerTeam.startTeamPlayers[id].jumper = false;
                    endState = true;

                    break;
                //11 -- RecoveryMana
                case 11:
                    type = 8;
                    playerTeam.startTeamPlayers[id].actualEnergyRecovery -= 5;

                    if (playerTeam.startTeamPlayers[id].actualEnergyRecovery == playerTeam.startTeamPlayers[id].energyRecovery)
                    {
                        endState = true;
                    }

                    break;
                //12 -- AtaqueRoto
                case 12:

                    break;
                //13 -- DefensaRota
                case 13:

                    break;
            }

            if (damage > 0)
            {
                kill = ApplyDamage(id, damage, playerTeam.startTeamPlayers[id], 0, type, null);
            }

            if (endState)
            {
                UpdatePlayerStates(id, stateIndex);
                playerTeam.startTeamPlayers[id].states.RemoveAt(stateIndex);
                playerTeam.startTeamPlayers[id].totalStates--;
                stateIndex--;
            }

            if (kill)
            {
                endMatch = KillFighter(true, playerTeam.startTeamPlayers[id], id);

                if (!endMatch)
                {
                    finishApplyState = NextState();
                }
            }
            else
            {
                finishApplyState = NextState();
            }
            
            SetCommentorMessage(null, null, playerTeam.startTeamPlayers[id], false, damage, type);
        }
        else
        {
            finishApplyState = NextState();
        }

        if (applyState)
        {
            StartCoroutine(WaitState(finishApplyState, endMatch));
            StartCoroutine(WaitAttack());
        }
        else
        {
            if (!endMatch)
            {
                if (!finishApplyState)
                {
                    stateActive = true;
                    ApplyPlayerStates(statePlayer);
                }
                else
                {
                    stateActive = false;
                    EnemyTurn();
                }
            }
        }
    }


    /// <summary>
    /// Actualiza la lista de estados tras el efecto negativo o de apoyo
    /// - localPlayer: El jugador pertenece al equipo local
    /// - playerId: Identificador del personaje al que se le aplica
    /// </summary>
    private void UpdatePlayerStates(int playerId, int statePosition)
    {
        if (playerTeam.startTeamPlayers[playerId].totalStates != statePosition + 1)
        {
            for (int i = statePosition; i < playerTeam.startTeamPlayers[playerId].totalStates - 1; i++)
            {
                leftbar.transform.GetChild(0).GetChild(playerId).GetChild(7).GetChild(i).GetComponent<Image>().sprite = leftbar.transform.GetChild(0).GetChild(playerId).GetChild(7).GetChild(i + 1).GetComponent<Image>().sprite;
            }

            leftbar.transform.GetChild(0).GetChild(playerId).GetChild(7).GetChild(playerTeam.startTeamPlayers[playerId].totalStates - 1).gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("borro");
            leftbar.transform.GetChild(0).GetChild(playerId).GetChild(7).GetChild(statePosition).gameObject.SetActive(false);
        }
    }


    /// <summary>
    /// Reinicia los índices de estado y de jugador y comprueba si se ha finalizado el proceso de estado
    /// </summary>
    private bool NextState()
    {
        bool stateFinish;

        stateIndex++;

        if (playerTurn)
        {
            if(playerTeam.startTeamPlayers[statePlayer].totalStates > stateIndex)
            {
                stateFinish = false;
            }
            else
            {
                statePlayer++;
                stateIndex = 0;

                if (statePlayer == startPlayers)
                {
                    statePlayer = 0;

                    stateFinish = true;
                }
                else
                {
                    stateFinish = false;
                }
            }
        }
        else
        {
            Debug.Log(enemyTeam.startTeamPlayers[statePlayer].totalStates + "/" + stateIndex);
            if (enemyTeam.startTeamPlayers[statePlayer].totalStates > stateIndex)
            {
                stateFinish = false;
            }
            else
            {
                statePlayer++;
                stateIndex = 0;

                if (statePlayer == startPlayers)
                {
                    statePlayer = 0;

                    stateFinish = true;
                }
                else
                {
                    stateFinish = false;
                }
            }
        }

        Debug.Log(playerTurn + " / " + stateIndex);

        return stateFinish;
    }



    //////////////////////////////////////////////////////////////////////////////////
    //Fase 7 /////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Inicializa los valores del turno
    /// </summary>
    private void PlayerTurn()
    {
        SetPlayerTeamInfo(false);
        playerTurn = true;
        applyEnemyState = false;
    }


    /// <summary>
    /// Elimina el luchador del combate
    /// - local: Perteneciente al equipo local
    /// - auxPlayer: Personaje a borrar
    /// - target: ID del personaje a borrar 0 - Número de elementos 
    /// </summary>
    bool KillFighter(bool local, Player auxPlayer, int target)
    {
        bool end = false;
        int position = auxPlayer.linePosition;
        int line = auxPlayer.line;
        int auxTeamID; //0 --> muere local, 1 --> muere visitante

        if (local)
        {
            auxTeamID = 1;

            if (line == 0)
            {
                firstLineEnemy--;
                enemyId1.RemoveAt(target);
            }
            else if (line == 1)
            {
                midLineEnemy--;
                enemyId2.RemoveAt(target);
            }
            else
            {
                backLineEnemy--;
                enemyId3.RemoveAt(target);
            }

            if (!monster)
            {
                playerScore += 5;
            }
            else
            {

            }

            if (firstLineEnemy == 0 && midLineEnemy == 0 && backLineEnemy == 0)
            {
                end = true;
            }
        }
        else
        {
            auxTeamID = 0;

            position = playerTeam.playerPosition[target] % 3;

            if (line == 0)
            {
                firstLinePlayer--;
                playerId1.RemoveAt(target);
            }
            else if (line == 1)
            {
                midLinePlayer--;
                playerId2.RemoveAt(target);
            }
            else
            {
                backLinePlayer--;
                playerId3.RemoveAt(target);
            }
        }

        battleArea.transform.GetChild(auxTeamID).GetChild(line).GetChild(position).gameObject.SetActive(false);
        UpdateScore();


        return end;
    }


    /// <summary>
    /// Termina el combate
    /// </summary>
    void EndMatch(bool local)
    {
        if (local)
        {
            Debug.Log("Combate terminado gana local");
        }
        else
        {
            Debug.Log("Combate terminado gana visitante");
        }
    }



    //////////////////////////////////////////////////////////////////////////////////
    //Comentarista ///////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Ocultar el cuadro de comentario y limpiar texto
    /// </summary>
    private void HideCommentator()
    {
        commentatorArea.gameObject.SetActive(false);
        hideText = false;
        textActive = false;
    }


    /// <summary>
    /// Quita los comentarios al hacer click o lo muestra en funcion de si está o no activo
    /// </summary>
    public void NextMessage()
    {
        if (textActive && !attackAnimation && hideText)
        {
            HideCommentator();
            
            if (stateActive)
            {
                if (playerTurn)
                {
                    ApplyPlayerStates(statePlayer);
                }
                else
                {
                    ApplyEnemyStates(statePlayer);
                }
            }
            else if (!playerTurn && !attackAnimation && !applyEnemyState)
            {
                if (!endEnemyTurn)
                {
                    ApplyEnemyHability();
                }
                else
                {
                    ApplyEnemyStates(statePlayer);
                }
            }
        }
        else if (!textActive)
        {
            textActive = true;
            commentatorArea.gameObject.SetActive(true);

            StartCoroutine(Spell());
        }
    }


    /// <summary>
    /// Establece el mensaje del comentarista y lo muestra. 
    /// Sup --> 0: nada     1: support      2: negative 
    /// </summary>
    private void SetCommentorMessage(Card habilitySelected, Player attacker, Player defender, bool newState, int damage, int state)
    {
        int random;
        string key = "ERROR";
        string name, name2, attackName;

        if (habilitySelected == null)
        {
            switch (state)
            {
                /*
                case Card.Support.ATTACK:
                        auxState = 12;
                case Card.Support.DEFENSE:
                        auxState = 13;
                 */
                case 2: //Veneno
                    if (defender.poisonTurn > 0)
                    {
                        key = "Veneno 1";
                    }
                    else
                    {
                        key = "Veneno 2";
                    }

                    messageText = dataBase.GetTranslatedWord(key);

                    name = defender.playerSurname;
                    messageText = string.Format(messageText, name);

                    break;

                case 3: //Blind
                    if (defender.blindTurn > 0)
                    {
                        key = "Cegado 1";
                    }
                    else
                    {
                        key = "Cegado 2";
                    }

                    messageText = dataBase.GetTranslatedWord(key);

                    name = defender.playerSurname;
                    messageText = string.Format(messageText, name);

                    break;

                case 4: //Sangrado
                    if (defender.bleedTurn > 0)
                    {
                        key = "Sangrado 1";
                    }
                    else
                    {
                        key = "Sangrado 2";
                    }

                    messageText = dataBase.GetTranslatedWord(key);

                    name = defender.playerSurname;
                    messageText = string.Format(messageText, name);

                    break;
                
                case 5: //paralyze
                    if (defender.paralyzeTurn > 0)
                    {
                        key = "Paralizado 1";
                    }
                    else
                    {
                        key = "Paralizado 2";
                    }

                    messageText = dataBase.GetTranslatedWord(key);

                    name = defender.playerSurname;
                    messageText = string.Format(messageText, name);

                    break;

                case 6: //confusion
                    if (defender.confusionTurn > 0)
                    {
                        key = "Confundido 1";
                    }
                    else
                    {
                        key = "Confundido 2";
                    }

                    messageText = dataBase.GetTranslatedWord(key);

                    name = defender.playerSurname;
                    messageText = string.Format(messageText, name);

                    break;

                case 7: //repetition
                    if (defender.repetitiveTurn > 0)
                    {
                        key = "Repeticion 3";
                    }
                    else
                    {
                        key = "Repeticion 2";
                    }

                    messageText = dataBase.GetTranslatedWord(key);

                    name = defender.playerSurname;
                    messageText = string.Format(messageText, name);

                    break;

                case 8: //jumper
                    if (defender.jumperTurn > 0)
                    {
                        key = "Saltador 3";
                    }
                    else
                    {
                        key = "Saltador 2";
                    }

                    messageText = dataBase.GetTranslatedWord(key);

                    name = defender.playerSurname;
                    messageText = string.Format(messageText, name);

                    break;
                /*
            case 9: //recovery
                if (defender.bleedTurn > 0)
                {
                    key = "Sangrado 1";
                }
                else
                {
                    key = "Sangrado 2";
                }

                messageText = dataBase.GetTranslatedWord(key);

                name = defender.playerSurname;
                messageText = string.Format(messageText, name);

                break;
                */
                case 10: //attack positive
                    if (defender.jumperTurn > 0)
                    {
                        //key = "Saltador 3";
                    }
                    else
                    {
                        //key = "Saltador 2";
                    }

                    messageText = dataBase.GetTranslatedWord(key);

                    //name = defender.playerSurname;
                    //messageText = string.Format(messageText, name);

                    break;

                case 11: //defence positive
                    if (defender.jumperTurn > 0)
                    {
                        //key = "Saltador 3";
                    }
                    else
                    {
                        //key = "Saltador 2";
                    }

                    messageText = dataBase.GetTranslatedWord(key);

                    //name = defender.playerSurname;
                    //messageText = string.Format(messageText, name);

                    break;

                case 12: //attack negative
                    if (defender.jumperTurn > 0)
                    {
                        //key = "Saltador 3";
                    }
                    else
                    {
                        //key = "Saltador 2";
                    }

                    messageText = dataBase.GetTranslatedWord(key);

                    //name = defender.playerSurname;
                    //messageText = string.Format(messageText, name);

                    break;

                case 13: //defend negative
                    if (defender.jumperTurn > 0)
                    {
                        //key = "Saltador 3";
                    }
                    else
                    {
                        //key = "Saltador 2";
                    }

                    messageText = dataBase.GetTranslatedWord(key);

                    //name = defender.playerSurname;
                    //messageText = string.Format(messageText, name);

                    break;
            }
        }
        else if (habilitySelected.type == Card.Type.DEFENSE)
        {
            if (attacker.actualDefence > 12)
            {
                random = Random.Range(1, dataBase.languageDictionary.GetNumberMessages(3) + 1);
                key = "Comentario defensa fuerte " + random;

                messageText = dataBase.GetTranslatedWord(key);
            }
            else if (attacker.actualDefence < 5)
            {
                random = Random.Range(1, dataBase.languageDictionary.GetNumberMessages(5) + 1);
                key = "Comentario debil defensa " + random;

                messageText = dataBase.GetTranslatedWord(key);
            }
            else
            {
                name = attacker.playerSurname;

                random = Random.Range(1, dataBase.languageDictionary.GetNumberMessages(4) + 1);
                key = "Comentario defensa " + random;

                messageText = dataBase.GetTranslatedWord(key);

                if (random == 1)
                {
                    messageText = string.Format(messageText, name);

                }
                else if (random == 2)
                {
                    attackName = habilitySelected.name;

                    messageText = string.Format(messageText, name, attackName);
                }
            }
        }
        else if (habilitySelected.type == Card.Type.NEGATIVE)
        {
            name = defender.playerSurname;

            switch (state)
            {
                /*
                  case 2: //Veneno
                case 3: //Blind
                case 4: //Sangrado
                case 5: //paralyze
                case 6: //confusion
                case 7: //repetition
                case 8: //jumper
                case 9: //recovery
                case 10: //attack positive
                case 11: //defence positive
                case 12: //attack negative
                case 13: //defend negative
                    */
                case 2: //Veneno
                    if (newState)
                    {
                        key = "Veneno 3";
                    }
                    else
                    {
                        key = "Veneno 4";
                    }

                    break;
                case 4: //Sangrado
                    if (newState)
                    {
                        key = "Sangrado 3";
                    }
                    else
                    {
                        key = "Sangrado 4";
                    }

                    break;
                case 3: //Blind
                    if (newState)
                    {
                        key = "Cegado 3";
                    }
                    else
                    {
                        key = "Cegado 4";
                    }

                    break;
                case 5: //paralyze
                    if (newState)
                    {
                        key = "Paralizado 3";
                    }
                    else
                    {
                        key = "Paralizado 4";
                    }

                    break;
                case 6: //confusion
                    if (newState)
                    {
                        key = "Confundido 3";
                    }
                    else
                    {
                        key = "Confundido 4";
                    }

                    break;
                case 9: //recovery
                    if (newState)
                    {
                        key = "Recupera 3";
                    }
                    else
                    {
                        key = "Recupera 4";
                    }

                    break;
            }

            messageText = dataBase.GetTranslatedWord(key);
            messageText = string.Format(messageText, name);
        }
        else if (habilitySelected.type == Card.Type.SUPPORT)
        {
            name = attacker.playerSurname;

            switch (state)
            {
                case 7: //repetition
                    if (newState)
                    {
                        key = "Repeticion 1";
                    }
                    else
                    {
                        key = "Repeticion 3";
                    }

                    break;
                case 8: //jumper
                    if (newState)
                    {
                        key = "Saltador 1";
                    }
                    else
                    {
                        key = "Saltador 3";
                    }

                    break;
                case 9: //recovery
                    if (newState)
                    {
                        key = "Recupera 1";
                    }
                    else
                    {
                        key = "Recupera 2";
                    }

                    break;
            }

            messageText = dataBase.GetTranslatedWord(key);
            messageText = string.Format(messageText, name);
        }
        else
        {
            switch (state)
            {
                case 0: //ataque normal
                    if (damage <= 0)
                    {
                        random = Random.Range(1, dataBase.languageDictionary.GetNumberMessages(2) + 1);
                        key = "Comentario debil ataque " + random;

                        messageText = dataBase.GetTranslatedWord(key);

                        if (random == 1)
                        {
                            name = defender.playerSurname;
                            messageText = string.Format(messageText, name);
                        }
                    }
                    else if (damage > 9)
                    {
                        random = Random.Range(1, dataBase.languageDictionary.GetNumberMessages(0) + 1);
                        key = "Comentario ataque fuerte " + random;

                        messageText = dataBase.GetTranslatedWord(key);

                        if (random == 1)
                        {
                            name = attacker.playerSurname;
                            messageText = string.Format(messageText, name);
                        }
                    }
                    else
                    {
                        random = Random.Range(1, dataBase.languageDictionary.GetNumberMessages(2) + 1);
                        key = "Comentario ataque " + random;

                        messageText = dataBase.GetTranslatedWord(key);

                        if (random == 1)
                        {
                            if (habilitySelected != null)
                            {
                                name = attacker.playerSurname;
                                attackName = habilitySelected.name;
                                name2 = defender.playerSurname;

                                messageText = string.Format(messageText, name, attackName, name2);
                            }
                            else
                            {
                                messageText = "ERROR: Carta perdida en aplicar daño enemigo";
                            }
                        }
                        else if (random == 2)
                        {
                            name = attacker.playerSurname;

                            messageText = string.Format(messageText, name);
                        }
                    }

                    break;
            }
        }

        NextMessage();
    }



    //////////////////////////////////////////////////////////////////////////////////
    //Tipos //////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Devuelve el tipo del personaje
    /// </summary>
    private string GetType(Player.Position position)
    {
        string auxType;

        switch (position)
        {
            case Player.Position.ARCHER:
                auxType = "Archer";
                break;
            case Player.Position.ARPONER:
                auxType = "Arponer";
                break;
            case Player.Position.EXECUTER:
                auxType = "Executer";
                break;
            case Player.Position.MAGICIAN:
                auxType = "Mage";
                break;
            case Player.Position.PALADIN:
                auxType = "Paladin";
                break;
            case Player.Position.SHIELD:
                auxType = "Shield";
                break;
            case Player.Position.ROBOT:
                auxType = "Robot";
                break;
            default:
                auxType = "Wolf";
                break;
        }

        return auxType;
    }



    //////////////////////////////////////////////////////////////////////////////////
    //Marcador ///////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Actualiza el resultado
    /// </summary>
    private void UpdateScore()
    {
        upbar.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = playerScore.ToString();
        upbar.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = enemyScore.ToString();
    }



    //////////////////////////////////////////////////////////////////////////////////
    //Corrutinas /////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Espera a que termine la animación del ataque
    /// </summary>
    private IEnumerator WaitAttack()
    {
        attackAnimation = true;

        yield return new WaitForSeconds(1.5f);

        attackAnimation = false;
    }


    /// <summary>
    /// Esspera a que se produzca el ataque para borrar al jugador
    /// </summary>
    private IEnumerator WaitAttackToKill(bool endMatch)
    {
        yield return new WaitForSeconds(1.4f);

        if (endMatch)
        {
            EndMatch(localMatch);
        }
        else
        {
            if (!playerTurn)
            {
                habilitySelected++;
                
                if (enemyPlayerSelected == 0)
                {
                    if (habilityEnemy1.Count == habilitySelected)
                    {
                        habilitySelected = 0;

                        if (habilityEnemy2.Count > 0)
                        {
                            enemyPlayerSelected = 1;
                        }
                        else if (habilityEnemy3.Count > 0)
                        {
                            enemyPlayerSelected = 2;
                        }
                        else if (habilityEnemy4.Count > 0)
                        {
                            enemyPlayerSelected = 3;
                        }
                        else
                        {
                            endEnemyTurn = true;
                        }
                    }
                }
                else if (enemyPlayerSelected == 1)
                {
                    if (habilityEnemy2.Count == habilitySelected || habilityEnemy2.Count == 0)
                    {
                        habilitySelected = 0;

                        if (habilityEnemy3.Count > 0)
                        {
                            enemyPlayerSelected = 2;
                        }
                        else if (habilityEnemy4.Count > 0)
                        {
                            enemyPlayerSelected = 3;
                        }
                        else
                        {
                            endEnemyTurn = true;
                        }
                    }
                }
                else if (enemyPlayerSelected == 2)
                {
                    if (habilityEnemy3.Count == habilitySelected || habilityEnemy3.Count == 0)
                    {
                        habilitySelected = 0;

                        if (habilityEnemy4.Count > 0)
                        {
                            enemyPlayerSelected = 3;
                        }
                        else
                        {
                            endEnemyTurn = true;
                        }
                    }
                }
                else
                {
                    if (habilityEnemy4.Count == habilitySelected || habilityEnemy4.Count == 0)
                    {
                        endEnemyTurn = true;
                    }
                }
            }
        }
    }


    /// <summary>
    /// Espera a que termine la animación del estado
    /// </summary>
    private IEnumerator WaitState(bool finishState, bool endMatch)
    {
        stateActive = false;

        yield return new WaitForSeconds(1.5f);
        
        if (!endMatch)
        {
            if (!finishState)
            {
                stateActive = true;
            }
            else
            {
                if (playerTurn)
                {
                    EnemyTurn();
                }
                else
                {
                    Debug.Log("Entra 2");
                    PlayerTurn();
                    EnergyRecovery();
                    StartAITurn(false);
                }
            }
        }
    }


    /// <summary>
    /// Deletrea el texto
    /// </summary>
    public IEnumerator Spell()
    {
        commentatorArea.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "";

        yield return new WaitForSeconds(.1f);

        for (int i = 0; i < messageText.Length + 1; i++)
        {
            commentatorArea.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = messageText.Substring(0, i);
            yield return new WaitForSeconds(.01f);
        }

        if (messageText == commentatorArea.transform.GetChild(0).GetChild(1).GetComponent<Text>().text)
        {
            hideText = true;
        }
    }
}
