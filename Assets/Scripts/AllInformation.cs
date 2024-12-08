using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AllInformation : MonoBehaviour
{
    public FirstPartInformation firstPartInformation;
    public CurrentValues currentValues;
    public ChangeValues changeValues;
    public Target target;

    [SerializeField] List<TextMeshProUGUI> vo;
    [SerializeField] List<TextMeshProUGUI> vf;
    [SerializeField] List<TextMeshProUGUI> time;

    [SerializeField] TextMeshProUGUI height;
    [SerializeField] TextMeshProUGUI gravity;
    [SerializeField] TextMeshProUGUI totalTime;

    private float timeInfo;


    public void UpdateAndShowInformation()
    {
        timeInfo = firstPartInformation.firstPartTime;

        FreeFallInfo();
        VerticalShotInfo();
        GeneralInformation();
    }


    private void FreeFallInfo()
    {
        UpdateText(vo[1], firstPartInformation.finalTargetVelocity, "m/s");
        UpdateText(time[1], currentValues.time - timeInfo, "s");
        UpdateText(vf[1], changeValues.force.value, "m/s");
    }

    private void VerticalShotInfo()
    {
        UpdateText(vo[0], changeValues.force.value, "m/s");
        UpdateText(time[0], timeInfo, "s");
        UpdateText(vf[0], firstPartInformation.finalTargetVelocity, "m/s");
    }

    private void GeneralInformation()
    {
        UpdateText(totalTime, currentValues.time, "s");
        UpdateText(gravity, changeValues.gravity.value, "m/s2");
        UpdateText(height, firstPartInformation.maxHeight, "m");
    }

    private void UpdateText(TextMeshProUGUI text , float value, string unit)
    {
        text.text = (value * 1).ToString("0.0") + unit;
    }
    
}
