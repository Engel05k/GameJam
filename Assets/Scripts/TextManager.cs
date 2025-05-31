using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class TextManager : MonoBehaviour
{
    private StatsScript statsScript;
    [SerializeField] private List<DialogueDay> DialoguesPerDay;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] TextMeshProUGUI textDay;
    [SerializeField] private float typingSpeed = 0.03f;
    private Coroutine currentCoroutine;

    void Start()
    {
        statsScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<StatsScript>();
        ShowCurrentDialog();
        ChangeDay();
    }
    public void ChangeText()
    {
        {
            DialogueDay currentDay = DialoguesPerDay.Find(d => d.dia == statsScript.day);
            if (currentDay == null)
            {
                Debug.Log("No hay dialogos para este dia");
                return;
            }

            DialogueScene nextScene = currentDay.scene.Find(s => s.scene == statsScript.scene + 1);

            if (nextScene != null)
            {
                statsScript.scene++;
                StartTyping(nextScene.text);
            }
            else
            {
                statsScript.day++;
                statsScript.scene = 1;
                ChangeDay();

                currentDay = DialoguesPerDay.Find(d => d.dia == statsScript.day);
                if (currentDay != null && currentDay.scene.Count > 0)
                {
                    StartTyping(currentDay.scene[0].text);
                }
                else
                {
                    StartTyping("No hay mas dialogos");
                    Debug.LogWarning("No se encontraron dialogos para el dia" + statsScript.day);
                }
            }
        }
    }
    private void ShowCurrentDialog()
    {
        DialogueDay currentDay = DialoguesPerDay.Find(d => d.dia == statsScript.day);
        if (currentDay == null)
        {
            Debug.LogWarning("No se encontraron dialogos para el dia" + statsScript.day);
            return;
        }

        DialogueScene currentScene = currentDay.scene.Find(s => s.scene == statsScript.scene);

        if (currentScene != null)
        {
            StartTyping(currentScene.text);
        }
        else
        {
            StartTyping("No hay dialogo para esta escena");
        }
    }

    private void StartTyping(string textToType)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(TypeText(textToType));
    }

    private IEnumerator TypeText(string fullText)
    {
        textMeshProUGUI.text = "";
        foreach (char c in fullText)
        {
            textMeshProUGUI.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void ChangeDay ()
    {
        textDay.text = "Día " + statsScript.day;
    }
}
