using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebase : MonoBehaviour
{
    private string baseURL = "https://tirovertical-caidalibre-default-rtdb.firebaseio.com";
    private string shotName;


    private string BuildURL()
    {
        return baseURL + "/" + shotName  + ".json";
    }


    //POST DATA//
    public void PostData(ShotInformation shotInformation)
    {
        shotName = shotInformation.a_shotName;
        RestClient.Post(BuildURL(), shotInformation, postHelper);
    }

    public void postHelper(RequestException exception, ResponseHelper response)
    {
        Debug.Log(response.StatusCode + " data: " + response.Text);
    }
}
