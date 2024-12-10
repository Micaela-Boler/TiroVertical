using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using System;

public class DBConnector : MonoBehaviour
{
    private const string FireBaseURL = "https://simuladoresdata-default-rtdb.firebaseio.com/"; //AÑADIR URL DE PROYECTO DE FIREBASE
    private const string Environment = "TEST"; //TEST
    
    
    public static DBConnector instance; //SINGLETON
    void Awake()
    {
        instance = this;
    }


    #region GET

    //endpoint es la ultima parte de la url
    private string formatURL(string endPoint)
    {
        return FireBaseURL + Environment + "/" + endPoint + ".json";
    }

    public void GetJson(string endpoint)
    {
        //RestClient + metodo que se va a usar Get, Post, Delete etc.
        //Then: espera a conseguir la URL y despues hace algo - 
        // Catch = se utiliza para evitar que se rompa el proyecto
        RestClient.Get(formatURL(endpoint)).Then(handledResponse).Catch(handledError);
    }


    // ResponseHelper = Agarra los datos (codigos y textos dificiles de entender) que provienen de la pagina y los interpreta
    private void handledResponse(ResponseHelper responseHelper)
    {
        Debug.Log(responseHelper.Text);
    }

    // Metodo que se usa dentro de catch
    private void handledError(Exception error)
    {
        Debug.Log(error.Message);

    }
    #endregion
}
