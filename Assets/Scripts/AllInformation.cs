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

    public ShotInformation shotInformation;
    [SerializeField] TMP_InputField inputField;
    private float timeInfo;
    private string shotName;


    public void UpdateAndShowInformation()
    {
        timeInfo = firstPartInformation.firstPartTime;

        FreeFallInfo();
        VerticalShotInfo();
        GeneralInformation();
        GetInfo();
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



    public void GetShotName()
    {
       shotName = inputField.text;
       Debug.Log("NOMBRE INGRESADO:" + shotName);
    }

    private void GetInfo()
    {
        shotInformation.a_shotName = shotName;

        shotInformation.gravity = changeValues.gravity.value;
        shotInformation.totalTime = currentValues.time;
        shotInformation.maxHeight = firstPartInformation.maxHeight;

        shotInformation.verticalShotTime = timeInfo;
        shotInformation.verticalShotVo = changeValues.force.value;
        shotInformation.verticalShotVf = firstPartInformation.finalTargetVelocity;

        shotInformation.freeFallTime = currentValues.time - timeInfo;
        shotInformation.freeFallVo = firstPartInformation.finalTargetVelocity;
        shotInformation.freeFallVf = changeValues.force.value;
    }
    
    public void SaveInformation()
    {
        GetInfo();
        FindObjectOfType<Firebase>().PostData(shotInformation);
    }
    
}
