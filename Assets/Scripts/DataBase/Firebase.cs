using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Internal;
using UnityEngine;
using static DataTracker;

public class Firebase : MonoBehaviour
{
    private string baseURL = "https://tirovertical-caidalibre-default-rtdb.firebaseio.com/";
    private string shotName;


    private string BuildURL()
    {
        return baseURL + "/" + shotName  + ".json";
    }



    //POST DATA//
    public void PostData(ShotInformation shotInformation)
    {
        RestClient.Put(baseURL + shotInformation.a_shotName + ".json", shotInformation, putHelper);
    }

    public void putHelper(RequestException exception, ResponseHelper response)
    {
        Debug.Log(response.StatusCode + " data: " + response.Text);
    }



    //GET DATA//
    public void GetData(string newShotName)
    {
        shotName = newShotName;
        RestClient.Get<ShotInformation>(baseURL + newShotName + ".json").Then(callback =>
        {
            if (callback != null)
            {
                FindObjectOfType<TextData>().ChangeGeneralText(callback.gravity, callback.maxHeight, callback.totalTime);
                FindObjectOfType<TextData>().ChangeVerticalShotText(callback.verticalShotTime, callback.verticalShotVf, callback.verticalShotVo);
                FindObjectOfType<TextData>().ChangeFreeFallText(callback.freeFallTime, callback.freeFallVf, callback.freeFallVo);
            }
            else
            {
                Debug.LogError("No se recibieron datos de Firebase.");
            }
        }).Catch(error =>
        {
            Debug.LogError("Error al obtener datos de Firebase: " + error.Message);
        });
    }
}
