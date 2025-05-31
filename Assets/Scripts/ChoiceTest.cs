using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using TMPro;
public class ChoiceTest : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject buttonYes;
    [SerializeField] private GameObject buttonNo;
    [SerializeField] private int timesSayYes;
    [SerializeField] private int timesSayNo;
    [SerializeField] private int timesDidnAct;

    [SerializeField] private TextMeshProUGUI yesText;
    [SerializeField] private TextMeshProUGUI noText;
    [SerializeField] private TextMeshProUGUI noActText;




    [SerializeField] private float timeToNoAct;


    [SerializeField] private float seconds;
    #endregion
    public void Option1()
    {

        Debug.Log("Jugador Elige opcion 1");
        StopCoroutine(NoAct());
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        timesSayYes++;
        StartCoroutine(NewOptions());
    
    }


    public void Option2()
    {
        Debug.Log("Jugador Elige opcion 2");
        StopCoroutine(NoAct());
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        timesSayNo++;
        StartCoroutine(NewOptions());
    }

    private IEnumerator NewOptions()
    {

        yield return new WaitForSeconds(seconds);
        MakeButtonsAppear();
        ChangeText();


    }

    private void MakeButtonsAppear()
    {
        StopCoroutine(NoAct());
        buttonYes.SetActive(true);
        buttonNo.SetActive(true);
        StartCoroutine(NoAct());

    }
    private void ChangeText()
    {
        yesText.text = timesSayYes.ToString();
        noText.text = timesSayNo.ToString();
        noActText.text = timesDidnAct.ToString();
    
    
    }
    private void Start()
    {
        MakeButtonsAppear();
    }

    private IEnumerator NoAct()
    {
        yield return new WaitForSeconds(timeToNoAct);

        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        timesDidnAct++;
        Debug.Log("El Jugador decidio no interactuar");

        StartCoroutine(NewOptions());
        StopCoroutine(NoAct());
    }
}
