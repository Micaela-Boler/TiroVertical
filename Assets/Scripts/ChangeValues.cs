using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChangeValues : MonoBehaviour
{
    [Header("TEXT")]
    [SerializeField] TextMeshProUGUI VoText;
    [SerializeField] TextMeshProUGUI gravityText;

    [Header("SLIDERS")]
    public Slider force;
    public Slider gravity;
    


    private void Start()
    {
        SetSliderValue(50, 0, 0, force);

        SetSliderValue(0, -10, -9.8f, gravity);
    }

    private void SetSliderValue(float maxValue, float minValue, float initialValue, Slider slider)
    {
        slider.value = initialValue;

        slider.maxValue = maxValue;
        slider.minValue = minValue;
    }

    public void UpdateText()
    {
        VoText.text = (force.value * 10).ToString("0");
        gravityText.text = (gravity.value * 1).ToString("0.0");
        //METODO PARA MODIFICAR TEXTO DE CALCULO - HACER CALCULO EN OTRA CLASE
    }
}
