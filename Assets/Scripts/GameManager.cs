using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public float secondPartTime; //hacer que la variale sea la de information storage??
    private bool finishGame = false;
    public ActualValues ActualValues;
   // public FirstPartInformation firstPartInformation;
    //[SerializeField] GameObject panel;


    [SerializeField] List<GameObject> UIElements;
    [SerializeField] List<TextMeshProUGUI> texts;
    [SerializeField] GameObject resetButton;
    public bool start = false;

    //ACTIVA EL CARTEL
    //HACE QUE APAREZCAN LOS TEXTOS DE ALTURA MAXIMA Y TIEMPO PARA LLEGAR A LA CIMA
    // BOTON DE RESETEO



    /*
    public void FinishSimulator()
    {
        if (finishGame)
        {
            secondPartTime = ActualValues.time - firstPartInformation.firstPartTime;
            panel.SetActive(true);
            Time.timeScale = 0;
        }

        finishGame = true;
    }
    */

    ///START///
    public void StartSimulator()
    {
        start = true;
        DesactivateUIElements();
    }

    public void DesactivateUIElements()
    {
        for (int i = 0; i < UIElements.Count; i++) 
        {
            UIElements[i].gameObject.SetActive(false);
        }

        resetButton.SetActive(true);
    }

    public void ResetScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
