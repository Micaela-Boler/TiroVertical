using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstPartInformation : MonoBehaviour
{
    public float finalTargetVelocity;
    public float firstPartTime;
    public float maxHeight;

    [Header("SHOW VALUES")]
    [SerializeField] List<TextMeshProUGUI> texts;
    [SerializeField] GameObject firstPartCanvas;

    [Header("TARGET")]
    public Target target;

    [Header("OTHER SCRIPTS")]
    public CurrentValues actualValues;
    public GameManager gameManager;



    private void Start()
    {
        firstPartCanvas.SetActive(false);
    }

    private void Update()
    {
        UpdateInfo();
    }



    private void UpdateInfo()
    {
        float currentHeight = target.transform.position.y;

        if (currentHeight > maxHeight)
        {
            GetFirstPartInfo();   
        }
        else if (currentHeight < maxHeight -0.2 && gameManager.start)
        {
            firstPartCanvas.SetActive(true);
            UpdateText();
        }
    }

    private void GetFirstPartInfo()
    {
        firstPartTime = actualValues.time;
        maxHeight = target.transform.position.y;
        finalTargetVelocity = target.rb.velocity.y; 
    }

    public void UpdateText()
    {
        texts[0].text = (maxHeight * 1).ToString("0.0") + "m";
        texts[1].text = (firstPartTime * 1).ToString("0.0") + "s";
    }
}
