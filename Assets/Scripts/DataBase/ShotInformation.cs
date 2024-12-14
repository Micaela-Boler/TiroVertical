using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DataTracker;

[System.Serializable]
public class ShotInformation
{
    public string a_shotName;

    public float gravity;
    public float totalTime;
    public float maxHeight;

    public float verticalShotTime;
    public float verticalShotVo;
    public float verticalShotVf;

    public float freeFallTime;
    public float freeFallVo;
    public float freeFallVf;
}