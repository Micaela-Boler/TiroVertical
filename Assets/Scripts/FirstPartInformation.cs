using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstPartInformation : MonoBehaviour
{
    public float firstPartTime;
    float maxHeight;

    [Header("TEXTS")]
    [SerializeField] List<TextMeshProUGUI> texts;

    [Header("TARGET")]
    public Target target;

    [Header("OTHER SCRIPTS")]
    public ActualValues actualValues;



    private void Update()
    {
        GetMaxHeight();
    }


    private void GetMaxHeight()
    {
        float currentHeight = target.transform.position.y;

        if (currentHeight > maxHeight)
        {
            maxHeight = target.transform.position.y;
            GetFirstPartTime();
            UpdateText();  
        }    
    }

    private void GetFirstPartTime()
    {
        firstPartTime = actualValues.time;
    }

    public void UpdateText()
    {
        texts[0].text = (maxHeight * 1).ToString("0.0");
        texts[1].text = (firstPartTime * 1).ToString("0.0");
    }
}
