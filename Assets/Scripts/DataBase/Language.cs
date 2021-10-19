using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
    public Dictionary<string, string> spanish;
    public Dictionary<string, string> english;

    private const int strongAttack = 2;
    private const int attack = 2;
    private const int weakAttack = 2;

    private const int strongDefense = 2;
    private const int defense = 2;
    private const int weakDefense = 2;

    private const int jumpAttack = 3;
    private const int repetitionAttack = 3;

    private const int poison = 3;
    private const int bleed = 3;
    private const int blind = 3;
    private const int confuse = 3;
    private const int jump = 2;
    private const int repetiton = 2;
    private const int manaRecovery = 4;



    void Awake()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///Español /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        spanish = new Dictionary<string, string>();

        spanish.Add("Project Hunter", "Project Hunter");
        spanish.Add("Selecciona tu idioma", "Selecciona tu idioma");
        spanish.Add("Mover", "Mover");
        spanish.Add("Seleccionar", "Seleccionar");

        //Menú principal
        spanish.Add("Nueva Partida", "Nueva Partida");
        spanish.Add("Crear Club", "Crear Club");
        spanish.Add("Cargar Partida", "Cargar Partida");
        spanish.Add("Opciones", "Opciones");
        spanish.Add("Créditos", "Créditos");
        spanish.Add("Salir", "Salir");
        spanish.Add("Elige un equipo y empieza tu aventura", "Elige un equipo y empieza tu aventura");
        spanish.Add("Diseña y gestiona tu propio club", "Diseña y gestiona tu propio club");
        spanish.Add("Carga una partida guardada", "Carga una partida guardada");
        spanish.Add("Cambia los ajustes del juego", "Cambia los ajustes del juego");

        //Nueva Partida
        spanish.Add("Nombre", "Nombre");
        spanish.Add("Apellido", "Apellido");
        spanish.Add("Día", "Día");
        spanish.Add("Mes", "Mes");
        spanish.Add("Año", "Año");
        spanish.Add("Nacionalidad", "Nacionalidad");
        spanish.Add("Experiencia Jugador", "Experiencia Jugador");
        spanish.Add("Experiencia Entrenando", "Experiencia Entrenando");
        spanish.Add("Volver", "Volver");
        spanish.Add("Siguiente", "Siguiente");

        //Nacionalidades
        //Europa
        spanish.Add("España", "España");
        spanish.Add("GB", "GB");
        spanish.Add("Francia", "Francia");
        spanish.Add("Italia", "Italia");
        spanish.Add("Alemania", "Alemania");
        spanish.Add("Croacia", "Croacia");
        spanish.Add("Dinamarca", "Dinamarca");
        spanish.Add("Finlandia", "Finlandia");
        spanish.Add("Grecia", "Grecia");
        spanish.Add("Irlanda", "Irlanda");
        spanish.Add("Islandia", "Islandia");
        spanish.Add("Polonia", "Polonia");
        spanish.Add("Portugal", "Portugal");
        spanish.Add("Rusia", "Rusia");
        spanish.Add("Suecia", "Suecia");
        spanish.Add("Ucrania", "Ucrania");
        spanish.Add("Serbia", "Serbia");

        //Africa
        spanish.Add("Angola", "Angola");
        spanish.Add("Argelia", "Argelia");
        spanish.Add("Burkina", "Burkina");
        spanish.Add("Camerún", "Camerún");
        spanish.Add("Egipto", "Egipto");
        spanish.Add("Ghana", "Ghana");
        spanish.Add("Guinea", "Guinea");
        spanish.Add("Marruecos", "Marruecos");
        spanish.Add("Nigeria", "Nigeria");
        spanish.Add("Senegal", "Senegal");
        spanish.Add("Sudáfrica", "Sudáfrica");
        spanish.Add("Togo", "Togo");

        //Asia
        spanish.Add("Arabia", "Arabia");
        spanish.Add("China", "China");
        spanish.Add("EAU", "EAU");
        spanish.Add("Filipinas", "Filipinas");
        spanish.Add("India", "India");
        spanish.Add("Irán", "Irán");
        spanish.Add("Israel", "Israel");
        spanish.Add("Japón", "Japón");
        spanish.Add("Corea", "Corea");
        spanish.Add("Malasia", "Malasia");
        spanish.Add("Pakistán", "Pakistán");
        spanish.Add("Singapur", "Singapur");
        spanish.Add("Tailandia", "Tailandia");
        spanish.Add("Vietnam", "Vietnam");

        //Oceania
        spanish.Add("Australia", "Australia");
        spanish.Add("N. Zelanda", "N. Zelanda");
        spanish.Add("Samoa", "Samoa");
        spanish.Add("Tonga", "Tonga");

        //
        spanish.Add("Fecha de Nacimiento", "Fecha de Nacimiento");
        spanish.Add("Continente", "Continente");

        //Experiencia jugador
        spanish.Add("Estrella mundial", "Estrella mundial");
        spanish.Add("Se me reconoce", "Se me reconoce");
        spanish.Add("Suplente habitual", "Suplente habitual");
        spanish.Add("Debuté", "Debuté");
        spanish.Add("Ni pisé la arena", "Ni pisé la arena");

        //Experiencia entrenador
        spanish.Add("Leyenda viva", "Leyenda viva");
        spanish.Add("Gran maestro", "Gran maestro");
        spanish.Add("Habitual del banquillo", "Habitual del banquillo");
        spanish.Add("Duré poco", "Duré poco");
        spanish.Add("Mi primer día", "Mi primer día");

        //America
        spanish.Add("Argentina", "Argentina");
        spanish.Add("Brasil", "Brasil");
        spanish.Add("Canada", "Canada");
        spanish.Add("Chile", "Chile");
        spanish.Add("Colombia", "Colombia");
        spanish.Add("C. Rica", "C. Rica");
        spanish.Add("Cuba", "Cuba");
        spanish.Add("Ecuador", "Ecuador");
        spanish.Add("Honduras", "Honduras");
        spanish.Add("Jamaica", "Jamaica");
        spanish.Add("México", "México");
        spanish.Add("Nicaragua", "Nicaragua");
        spanish.Add("Paraguay", "Paraguay");
        spanish.Add("Perú", "Perú");
        spanish.Add("Salvador", "Salvador");
        spanish.Add("Uruguay", "Uruguay");
        spanish.Add("EEUU", "EEUU");

        //Continentes
        spanish.Add("África", "África");
        spanish.Add("América", "América");
        spanish.Add("Asia", "Asia");
        spanish.Add("Europa", "Europa");
        spanish.Add("Oceanía", "Oceanía");

        //Economía
        spanish.Add("Rico", "Rico");
        spanish.Add("Potente", "Potente");
        spanish.Add("Estable", "Estable");
        spanish.Add("Aceptable", "Aceptable");
        spanish.Add("Deficiente", "Deficiente");

        spanish.Add("Crear", "Crear");

        //Menú Selección Club
        spanish.Add("Reputación", "Reputación");
        spanish.Add("Economia", "Economía");
        spanish.Add("Prevision", "Previsión temporada");
        spanish.Add("Conti", "Comp. Continental");
        spanish.Add("Mundial", "Comp. Mundial");

        //Sí-No
        spanish.Add("Si", "Sí");
        spanish.Add("No", "No");

        //Botones banda izquierda
        spanish.Add("Inicio", "Inicio");
        spanish.Add("Buzón", "Buzón");
        spanish.Add("Equipo", "Equipo");
        spanish.Add("Táctica", "Táctica");
        spanish.Add("Entrenamiento", "Entrenamiento");
        spanish.Add("Empleados", "Empleados");
        spanish.Add("Formación", "Formación");
        spanish.Add("Hospital", "Hospital");
        spanish.Add("Calendario", "Calendario");
        spanish.Add("Competiciones", "Competiciones");
        spanish.Add("Ojeo", "Ojeo");
        spanish.Add("Fichajes", "Fichajes");
        spanish.Add("Buscar", "Buscar");
        spanish.Add("Info Club", "Info Club");
        spanish.Add("Direccion", "Dirección");

        //Botones menu
        spanish.Add("HM", "HM");
        spanish.Add("Continuar", "Continuar");

        //Texto Home
        spanish.Add("Pantalla Inicio", "Pantalla Inicio");
        spanish.Add("Perfil", "Perfil");
        spanish.Add("Contrato", "Contrato");

        //Texto Club Info
        spanish.Add("Información del Club", "Información del Club");
        spanish.Add("Club", "Club");
        spanish.Add("Instalaciones", "Instalaciones");

        //Estados alterados
        spanish.Add("Baja Ataque", "Ataque -");
        spanish.Add("Sube Ataque", "Ataque +");
        spanish.Add("Baja Defensa", "Defensa -");
        spanish.Add("Sube Defensa", "Defensa +");
        spanish.Add("Envenenado", "Envenenado");
        spanish.Add("Confundido", "Confundido");
        spanish.Add("Paralizado", "Paralizado");
        spanish.Add("Sangrando", "Sangrando");
        spanish.Add("Cegado", "Cegado");
        spanish.Add("Saltador", "Saltador");
        spanish.Add("Repetitivo", "Repetitivo");
        spanish.Add("Recupera Mana", "Energía +");
        spanish.Add("ERROR", "ERROR");

        ///////////////////////////////////////////
        ///////////////////////////////////////////
        //Comentarios
        ///////////////////////////////////////////
        ///////////////////////////////////////////
        
        spanish.Add("Comentario ataque fuerte 1", "Gran golde de {0}.");
        spanish.Add("Comentario ataque fuerte 2", "Ese ataque le ha tenido que doler, mañana se levantará con un bonito recuerdo.");

        spanish.Add("Comentario ataque 1", "{0} usa {1} contra {2}.");
        spanish.Add("Comentario ataque 2", "{0} se lanza al ataque.");

        spanish.Add("Comentario rompe defensa 1", "{0} se ha quedado sin escudo tras ese último golpe.");

        spanish.Add("Comentario debil ataque 1", "Parece que {0} ni ha notado ese último ataque.");
        spanish.Add("Comentario debil ataque 2", "Van a tener que golpear más fuerte si quieren llevarse los puntos.");

        spanish.Add("Comentario ataque salto 1", "Ese ataque es capaz de saltarse la primera linea defensiva de cualquier equipo.");
        spanish.Add("Comentario ataque salto 2", "{0} ha evitado la primera linea defensiva usando {1}.");
        spanish.Add("Comentario ataque salto 3", "Si la defensa de {0} no hace nada {1} lo va a pasar mal.");

        spanish.Add("Comentario defensa fuerte 1", "Esa defensa es de las más sólidas que haya visto.");
        spanish.Add("Comentario defensa fuerte 2", "Va a costar mucho abrirse paso con esa defensa.");

        spanish.Add("Comentario defensa 1", "{0} se prepara para el golpe.");
        spanish.Add("Comentario defensa 2", "{0} emplea {1} para defenderse.");

        spanish.Add("Comentario debil defensa 1", "Con esa defensa lo va a pasar muy mal.");
        spanish.Add("Comentario debil defensa 2", "Esa defensa es tan frágil que parece hecha de papel.");

        spanish.Add("Veneno 1", "{0} sufre por el veneno y aún no se ha recuperado.");
        spanish.Add("Veneno 2", "{0} sufre por el veneno, pero parece que se ha recuperado.");
        spanish.Add("Veneno 3", "{0} ha sido envenenado.");
        spanish.Add("Veneno 4", "Empeora el envenenamiento de {0}.");

        spanish.Add("Sangrado 1", "{0} sufre por el sangrado y aún no se ha recuperado.");
        spanish.Add("Sangrado 2", "{0} sufre por el sangrado, pero parece que se ha logrado curar.");
        spanish.Add("Sangrado 3", "{0} ha sufrido heridas profundas y sangra por ellas.");
        spanish.Add("Sangrado 4", "Empeoran las heridas de {0}.");

        spanish.Add("Cegado 1", "{0} no ve bien y aún no se ha recuperado.");
        spanish.Add("Cegado 2", "{0} ya vuelve a ver bien.");
        spanish.Add("Cegado 3", "{0} está cegado.");
        spanish.Add("Cegado 4", "Empeora la visión de {0}.");

        spanish.Add("Paralizado 1", "{0} le cuesta moverse y aún no se ha recuperado.");
        spanish.Add("Paralizado 2", "{0} ya vuelve a moverse bien.");
        spanish.Add("Paralizado 3", "{0} está paralizado.");
        spanish.Add("Paralizado 4", "Empeora la parálisis de {0}.");

        spanish.Add("Confundido 1", "{0} está confundido y aún no se ha recuperado.");
        spanish.Add("Confundido 2", "{0} ya vuelve a moverse bien.");
        spanish.Add("Confundido 3", "{0} está confundido.");
        spanish.Add("Confundido 4", "Empeora la confusión de {0}.");

        spanish.Add("Repeticion 1", "{0} se mueve especialmente rápido.");
        spanish.Add("Repeticion 2", "{0} ya vuelve a moverse normal.");
        spanish.Add("Repeticion 3", "{0} parece que va a aguantar esa velocidad.");

        spanish.Add("Saltador 1", "{0} parece que es capaz de evitar la primera línea.");
        spanish.Add("Saltador 2", "{0} ya no es capaz de evitar la primera línea.");
        spanish.Add("Saltador 3", "{0} seguirá siendo capaz de evitar la primera línea.");

        spanish.Add("Recupera 1", "{0} es capaz de recuperar más maná que de costumbre.");
        spanish.Add("Recupera 2", "{0} ya no recupera tanto maná.");
        spanish.Add("Recupera 3", "{0} recupera menos maná que de costumbre.");
        spanish.Add("Recupera 4", "{0} recupera el maná habitual.");


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///Inglés //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        english = new Dictionary<string, string>();

        english.Add("Project Hunter", "Project Hunter");
        english.Add("Selecciona tu idioma", "Select your language");
        english.Add("Mover", "Move");
        english.Add("Seleccionar", "Select");

        //Menú principal
        english.Add("Nueva Partida", "New Game");
        english.Add("Crear Club", "Create Club");
        english.Add("Cargar Partida", "Load Game");
        english.Add("Opciones", "Options");
        english.Add("Créditos", "Credits");
        english.Add("Salir", "Exit");
        english.Add("Elige un equipo y empieza tu aventura", "Choose a team and start your adventure");
        english.Add("Diseña y gestiona tu propio club", "Design and manage your own club");
        english.Add("Carga una partida guardada", "Load a saved game");
        english.Add("Cambia los ajustes del juego", "Change the game's settings");

        //Nueva Partida
        english.Add("Nombre", "Name");
        english.Add("Apellido", "Surname");
        english.Add("Día", "Day");
        english.Add("Mes", "Month");
        english.Add("Año", "Year");
        english.Add("Nacionalidad", "Nationality");
        english.Add("Experiencia Jugador", "Player Experience");
        english.Add("Experiencia Entrenando", "Training Experience");
        english.Add("Volver", "Back");
        english.Add("Siguiente", "Next");

        //Nacionalidades
        //Europa
        english.Add("España", "Spain");
        english.Add("GB", "UK");
        english.Add("Francia", "France");
        english.Add("Italia", "Italy");
        english.Add("Alemania", "Germany");
        english.Add("Croacia", "Croatia");
        english.Add("Dinamarca", "Denmark");
        english.Add("Finlandia", "Finland");
        english.Add("Grecia", "Greece");
        english.Add("Irlanda", "Ireland");
        english.Add("Islandia", "Iceland");
        english.Add("Polonia", "Poland");
        english.Add("Portugal", "Portugal");
        english.Add("Rusia", "Russia");
        english.Add("Suecia", "Sweden");
        english.Add("Ucrania", "Ukraine");
        english.Add("Serbia", "Serbia");

        //Africa
        english.Add("Angola", "Angola");
        english.Add("Argelia", "Algeria");
        english.Add("Burkina", "Burkina");
        english.Add("Camerún", "Cameroon");
        english.Add("Egipto", "Egypt");
        english.Add("Ghana", "Ghana");
        english.Add("Guinea", "Guinea");
        english.Add("Marruecos", "Morocco");
        english.Add("Nigeria", "Nigeria");
        english.Add("Senegal", "Senegal");
        english.Add("Sudáfrica", "South Africa");
        english.Add("Togo", "Togo");

        //Asia
        english.Add("Arabia", "Arabia");
        english.Add("China", "China");
        english.Add("EAU", "UAE");
        english.Add("Filipinas", "Philippines");
        english.Add("India", "India");
        english.Add("Irán", "Iran");
        english.Add("Israel", "Israel");
        english.Add("Japón", "Japan");
        english.Add("Corea", "Korea");
        english.Add("Malasia", "Malaysia");
        english.Add("Pakistán", "Pakistan");
        english.Add("Singapur", "Singapore");
        english.Add("Tailandia", "Thailand");
        english.Add("Vietnam", "Vietnam");

        //Oceania
        english.Add("Australia", "Australia");
        english.Add("N. Zelanda", "N. Zealand");
        english.Add("Samoa", "Samoa");
        english.Add("Tonga", "Tonga");

        //
        english.Add("Fecha de Nacimiento", "Date of Birth");
        english.Add("Continente", "Continent");

        //Experiencia jugador
        english.Add("Estrella mundial", "World star");
        english.Add("Se me reconoce", "Famous");
        english.Add("Suplente habitual", "Usual alternate");
        english.Add("Debuté", "Debuted");
        english.Add("Ni pisé la arena", "I never hunted");

        //Experiencia entrenador
        english.Add("Leyenda viva", "Living legend");
        english.Add("Gran maestro", "Great master");
        english.Add("Habitual del banquillo", "Regular bench");
        english.Add("Duré poco", "Very little");
        english.Add("Mi primer día", "First day");

        //America
        english.Add("Argentina", "Argentina");
        english.Add("Brasil", "Brasil");
        english.Add("Canada", "Canada");
        english.Add("Chile", "Chile");
        english.Add("Colombia", "Colombia");
        english.Add("C. Rica", "C. Rica");
        english.Add("Cuba", "Cuba");
        english.Add("Ecuador", "Ecuador");
        english.Add("Honduras", "Honduras");
        english.Add("Jamaica", "Jamaica");
        english.Add("México", "Mexico");
        english.Add("Nicaragua", "Nicaragua");
        english.Add("Paraguay", "Paraguay");
        english.Add("Perú", "Peru");
        english.Add("Salvador", "Salvador");
        english.Add("Uruguay", "Uruguay");
        english.Add("EEUU", "USA");

        //Continentes
        english.Add("África", "Africa");
        english.Add("América", "America");
        english.Add("Asia", "Asia");
        english.Add("Europa", "Europe");
        english.Add("Oceanía", "Oceania");

        //Economía
        english.Add("Rico", "Rich");
        english.Add("Potente", "Powerful");
        english.Add("Estable", "Stable");
        english.Add("Aceptable", "Acceptable");
        english.Add("Deficiente", "Deficient");

        english.Add("Crear", "Create");

        //Menú Selección Club
        english.Add("Reputación", "Reputation");
        english.Add("Economia", "Economy");
        english.Add("Prevision", "Season forecast");
        english.Add("Conti", "Continental Comp.");
        english.Add("Mundial", "World Comp.");

        //Sí-No
        english.Add("Si", "Yes");
        english.Add("No", "No");

        //Botones banda izquierda
        english.Add("Inicio", "Home");
        english.Add("Buzón", "MailBox");
        english.Add("Equipo", "Team");
        english.Add("Táctica", "Tactic");
        english.Add("Entrenamiento", "Training");
        english.Add("Empleados", "Empleados");
        english.Add("Formación", "Employees");
        english.Add("Hospital", "Hospital");
        english.Add("Calendario", "Calendar");
        english.Add("Competiciones", "Competitions");
        english.Add("Ojeo", "Scout");
        english.Add("Fichajes", "Transfer");
        english.Add("Buscar", "Search");
        english.Add("Info Club", "Club Info");
        english.Add("Direccion", "Direction");

        //Botones menu
        english.Add("HM", "HM");
        english.Add("Continuar", "Continue");

        //Texto Home
        english.Add("Pantalla Inicio", "Home Menu");
        english.Add("Perfil", "Profile");
        english.Add("Contrato", "Contract");

        //Texto Club Info
        english.Add("Información del Club", "Club Information");
        english.Add("Club", "Club");
        english.Add("Instalaciones", "Installations");

        //Estados alterados
        english.Add("Baja Ataque", "Attack -");
        english.Add("Sube Ataque", "Attack +");
        english.Add("Baja Defensa", "Defense -");
        english.Add("Sube Defensa", "Defense +");
        english.Add("Envenenado", "Poisoned");
        english.Add("Confundido", "Confused");
        english.Add("Paralizado", "Paralyzed");
        english.Add("Sangrando", "Bleeding");
        english.Add("Cegado", "Blind");
        english.Add("Saltador", "Jumper");
        english.Add("Repetitivo", "Repetitive");
        english.Add("Recupera Mana", "Energy +");
        english.Add("ERROR", "ERROR");
    }


    public int GetNumberMessages(int type)
    {
        int auxNumber = -1;

        switch (type)
        {
            case 0:
                auxNumber = strongAttack;
                break;
            case 1:
                auxNumber = attack;
                break;
            case 2:
                auxNumber = weakAttack;
                break;
            case 3:
                auxNumber = strongDefense;
                break;
            case 4:
                auxNumber = defense;
                break;
            case 5:
                auxNumber = weakDefense;
                break;
            case 6:
                auxNumber = jumpAttack;
                break;
            case 7:
                auxNumber = repetitionAttack;
                break;
            case 8:
                auxNumber = poison;
                break;
            case 9:
                auxNumber = bleed;
                break;
            case 10:
                auxNumber = blind;
                break;
            case 11:
                auxNumber = confuse;
                break;
            case 12:
                auxNumber = jump;
                break;
            case 13:
                auxNumber = repetiton;
                break;
            case 14:
                auxNumber = manaRecovery;
                break;
        }

        return auxNumber;
    }
}
