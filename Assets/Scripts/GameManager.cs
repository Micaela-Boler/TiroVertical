using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public AllInformation allInformation;
    private bool finishGame = false;
    [SerializeField] GameObject panel;
    [SerializeField] List<GameObject> AllUIElements;


    [SerializeField] List<GameObject> UIElements;
    [SerializeField] GameObject resetButton;
    public bool start = false;



    private void Start()
    {
        panel.SetActive(false);
    }


    private void DesactivateUIElements(List<GameObject> elements)
    {
        for (int i = 0; i < elements.Count; i++)
        {
            elements[i].gameObject.SetActive(false);
        }
    }



    ///END///
    public void FinishSimulator()
    {
        if (finishGame)
        {
            allInformation.UpdateAndShowInformation();
            DesactivateUIElements(AllUIElements);
            panel.SetActive(true);
            start = false;

            Time.timeScale = 0;
        }

        finishGame = true;
    }
    


    ///START///
    public void StartSimulator()
    {
        start = true;
        resetButton.SetActive(true);
        DesactivateUIElements(UIElements);
    }

    public void ResetScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
}
