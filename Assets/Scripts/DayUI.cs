using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.Collections.Generic;
using System.Collections;

public class DayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private int day;
    [SerializeField] private string scene;
    [SerializeField] private float alpha;
    public static int uiDay = 0;

    private void Start()
    {

        if (text == null)
        {
            text = gameObject.GetComponent<TextMeshProUGUI>();
        }
        

  
        StartCoroutine(ChangeNumberUI());


    }

    private IEnumerator ChangeNumberUI()
    {
        yield return new WaitForSeconds(3f);
        uiDay++;
        text.text = uiDay.ToString();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(scene);

    }

    private void Update()
    {

    }


}
