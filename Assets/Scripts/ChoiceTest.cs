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
    [SerializeField] TextManager textManager;


    [SerializeField] private bool buttonPress = false;
    [SerializeField] private float timeToNoAct;


    [SerializeField] private float seconds;    
    #endregion
    public void Option1()
    {

        Debug.Log("Jugador Elige opcion 1");
        buttonPress = true;
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);        

    }


    public void Option2()
    {
        Debug.Log("Jugador Elige opcion 2");
        buttonPress = true;
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
       

    }

    public IEnumerator NewOptions()
    {
        if (buttonPress)
        {

            yield return new WaitForSeconds(seconds);
            MakeButtonsAppear();
        }
        else
        {
            Debug.Log("buttonPress pasa a true");

            buttonPress= true;
            yield return new WaitForSeconds(seconds);
            MakeButtonsAppear();
        }
           


    }

    private void MakeButtonsAppear()
    {
        buttonYes.SetActive(true);
        buttonNo.SetActive(true);
        buttonPress = false;
        StartCoroutine(NoAct());

    }
    private void Start()
    {
        MakeButtonsAppear();        
    }

    private IEnumerator NoAct()
    {

        yield return new WaitForSeconds(timeToNoAct);

        if (buttonPress == false)
        {
            buttonYes.SetActive(false);
            buttonNo.SetActive(false);
            textManager.ChangeText();
            Debug.Log("El Jugador decidio no interactuar");

        }

    }

    public void test()
    {
        StartCoroutine(NewOptions());
    }
}
