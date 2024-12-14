using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextData : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> prefabTexts;
    [SerializeField] TMP_InputField inputField;

    public void ChangeGeneralText(float gravity, float height, float totalTime)
    {
        UpdateText(prefabTexts[0], gravity, "m/s2");
        UpdateText(prefabTexts[1], totalTime, "s");
        UpdateText(prefabTexts[2], height, "m/s");
    }

    public void ChangeVerticalShotText(float time, float vf, float vo)
    {
        UpdateText(prefabTexts[3], time, "s");
        UpdateText(prefabTexts[4], vf, "m/s");
        UpdateText(prefabTexts[5], vo, "m/s");
    }

    public void ChangeFreeFallText(float time, float vf, float vo)
    {
        UpdateText(prefabTexts[6], time, "s");
        UpdateText(prefabTexts[7], vf, "m/s");
        UpdateText(prefabTexts[8], vo, "m/s");
    }

    private void UpdateText(TextMeshProUGUI text, float value, string unit)
    {
        text.text = value.ToString("0.0") + unit;
    }


    public void LoadData()
    {
        FindObjectOfType<Firebase>().GetData(inputField.text);
    }
}
