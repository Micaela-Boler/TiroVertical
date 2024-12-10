using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DataTracker : MonoBehaviour
{
    //56:30
    //BUSCAR LA DOCUMENTACION DEL SCRIPT Y EN BASE A ESO CREAR UN DATATRACKER (MAINSCRIPT) PROPIO Y PERSONALIZADO

    private string baseURL = "https://tirovertical-caidalibre-default-rtdb.firebaseio.com"; //URL SIN BARRITA AL FINAL PORQUE YA ESTA EN BUILD.URL()
    public string gameName = "Shot";
    private readonly string Environment = "TEST";


    [Serializable] //SE UTILIZA PARA PODER CONVERTIRLO EN EL TEXTO DENTRO DEL SERVIDOR, ES DECIR LA INFO DE GAME, ENTRE SESIONES
    public class Game
    {
        public int timeStarted;
        public int timeEnded;

        public Shot[] shots; //PARA QUE SHOT SE RELACIONES CON GAME
    }

    [Serializable]
    public class Shot
    {
        //poner variables del tiro como la fuerza, el angulo, etc.
    }


    private string BuildURL()
    {
        return baseURL + "/" + Environment + "/" + gameName + ".json";
    }


    #region GET
    // DEVUELVE DATOS DEL SERVIDOR
    public void Get()
    {
        RestClient.Get(BuildURL(), GetHelper);
    }

    //STATUS CODE, DEVUELVE UN NUMERO TE INDICA EL STATUS: 200 ESTA TODO BIEN - 400 ES ERROR NUESTRO - 500 ERROR DEL SERVIDOR
    // RESPONSE SE USA EN TIPO TEXT PARA QUE SEA MAS SIMPLE LEERLO
    public void GetHelper(RequestException exception, ResponseHelper response)
    {
        Game game = JsonUtility.FromJson<Game>(response.Text);
        Debug.Log(game); //PASA LOS DATOS DE JSON A TEXTO PARA VISUALIZAR MEJOR LA INFO
        
        foreach (Shot shot in game.shots) 
        {
            Debug.Log(shot/*INFO DE TIRO, HACAER VARIAS LINEAS PARA TODA LA INFO*/);
        }

        Debug.Log(response.StatusCode + " data: " + response.Text);
    }
    #endregion


    public void Put() //sobrescribe
    {
       Game game = CreateGame();
       Shot shot = createShot();
        game.shots = new[] //NO HACE FALTA, O REEMPLAZAR POR ARRAEGLO DE SHOTS
        {
           shot, shot, shot,
        };

        RestClient.Put(BuildURL(), game, putHelper); //NECESITA GAME PARA SABER A DONDE MANDARLO
    }

    public Shot createShot()
    {
        Shot shot = new Shot();
        //variables de info de tiro shot.angleX = --
        return shot;
    }

    public Game CreateGame() //SE SACA DEL PUT PARA MEJOR ORGANIZACIÓN, SE PUEDE PONER EN OTRA CLASE
    {
        Game game = new Game();
        game.timeEnded = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(); //UTC LA FECHA EN EL MOMENTO DE AHORA, VA EN UNA FORMA DE ESCRIBIR LA FECHA NEUTRAL - UNIXTIME REPRESENTA EL DIA DE HOY EN NUMERO ENTERO
        game.timeStarted = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        return game;
    }

    public void putHelper(RequestException exception, ResponseHelper response)
    {
        Debug.Log(response.StatusCode + " data: " + response.Text);
    }
}


