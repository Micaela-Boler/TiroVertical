using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class ChangeValues : MonoBehaviour
{
    [Header("TEXT")]
    [SerializeField] TextMeshProUGUI VoText;
    [SerializeField] TextMeshProUGUI gravityText;
    [SerializeField] TextMeshProUGUI estimatedTimeText;
    [SerializeField] TextMeshProUGUI estimatedHeightText;

    [Header("SLIDERS")]
    public Slider force;
    public Slider gravity;

    private float estimatedTime;
    private float estimatedHeight;



    private void Start()
    {
        SetSliderValue(500, 0.5f, 0, force);

        SetSliderValue(-3.73f, -24.79f, -9.8f, gravity);
    }


    private void SetSliderValue(float maxValue, float minValue, float initialValue, Slider slider)
    {
        slider.value = initialValue;

        slider.maxValue = maxValue;
        slider.minValue = minValue;
    }

    public void UpdateText()
    {
        VoText.text = (force.value * 1).ToString("0.0");
        gravityText.text = (gravity.value * 1).ToString("0.0");

        CalculateTime();
        estimatedHeightText.text = (estimatedHeight * 1).ToString("0.0");
        estimatedTimeText.text = (estimatedTime * 1).ToString("0.0");
    }



    private void CalculateTime()
    {
        estimatedTime = force.value / gravity.value * -1;
        estimatedHeight = force.value * force.value / (2 * gravity.value * -1);
    }
}
