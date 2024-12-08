using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class CurrentValues : MonoBehaviour
{
    public float time;
    private float height;
    private float targetVelocity;

    [Header("TARGET")]
    [SerializeField] GameObject target;

    [Header("OTHER SCRIPTS")]
    public Target jump;
    public GameManager manager;

    [Header("TEXT")]
    [SerializeField] TextMeshProUGUI actualTime;
    [SerializeField] TextMeshProUGUI actualHeight;
    [SerializeField] TextMeshProUGUI actualVelocity;



    void Update()
    {
        if (manager.start)
        {
            GetCurrentValues();
            UpdateText();
        }
    }


    private void GetCurrentValues()
    {
        time += Time.deltaTime;
        height = target.transform.position.y;
        targetVelocity = jump.rb.velocity.magnitude * 10;
    }

    private void UpdateText()
    {
        actualTime.text = (time * 1).ToString("0.0");
        actualHeight.text = (height * 1).ToString("0.0");
        actualVelocity.text = (targetVelocity * 1).ToString("0.0");
    }
}
