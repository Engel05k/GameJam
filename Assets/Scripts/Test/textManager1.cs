using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class textManager1 : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] private GameObject buttonYes;
    [SerializeField] private GameObject buttonNo;
    [SerializeField] private TextManager textManager;

    [Header("Timers")]
    [SerializeField] private float timeToNoAct = 5f;
    [SerializeField] private float seconds = 1f;

    private bool buttonPress = false;

    private void Start()
    {
        MakeButtonsAppear();
    }

    public void Option1()
    {
        Debug.Log("Jugador elige opción 1");
        buttonPress = true;
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        StartCoroutine(NewOptions());
    }

    public void Option2()
    {
        Debug.Log("Jugador elige opción 2");
        buttonPress = true;
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        StartCoroutine(NewOptions());
    }

    public void Test()
    {
        StartCoroutine(NewOptions());
    }

    public IEnumerator NewOptions()
    {
        if (!buttonPress)
        {
            Debug.Log("buttonPress pasa a true");
            buttonPress = true;
        }

        yield return new WaitForSeconds(seconds);
        MakeButtonsAppear();
    }

    private void MakeButtonsAppear()
    {
        if (buttonYes != null) buttonYes.SetActive(true);
        if (buttonNo != null) buttonNo.SetActive(true);

        buttonPress = false;
        StartCoroutine(NoAct());
    }

    private IEnumerator NoAct()
    {
        yield return new WaitForSeconds(timeToNoAct);

        if (!buttonPress)
        {
            if (buttonYes != null) buttonYes.SetActive(false);
            if (buttonNo != null) buttonNo.SetActive(false);

            if (textManager != null)
            {
                textManager.ChangeText();
            }
            else
            {
                Debug.LogWarning("TextManager no está asignado en el Inspector.");
            }

            Debug.Log("El jugador no interactuó.");
        }
    }
}