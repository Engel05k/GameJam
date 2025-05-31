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
    [SerializeField] private int timeSayYes;
    [SerializeField] private int timeSayNo;
    [SerializeField] private int timeDidnAct;

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
        timeSayYes++;
        StartCoroutine(NewOptions());
    
    }


    public void Option2()
    {
        Debug.Log("Jugador Elige opcion 2");
        StopCoroutine(NoAct());
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        timeSayNo++;
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
        yesText.text = timeSayYes.ToString();
        noText.text = timeSayNo.ToString();
        noActText.text = timeDidnAct.ToString();
    
    
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
        timeDidnAct++;
        Debug.Log("El Jugador decidio no interactuar");

        StartCoroutine(NewOptions());
        StopCoroutine(NoAct());
    }
}
