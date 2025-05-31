using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    private StatsScript statsScript;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] TextMeshProUGUI textDay;


    void Start()
    {
        statsScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<StatsScript>();
        if (statsScript.day == 1 && statsScript.scene == 1)
        {
            textMeshProUGUI.text = "Hola, Soy Max, un estudiante de la carrera de diseño de videojuegos.";
            statsScript.scene += 1;
            ChangeDay();
        }
    }
    public void ChangeText()
    {

        if (statsScript.day == 1 && statsScript.scene == 2)
        {
            textMeshProUGUI.text = "Tengo una vida muy simple... Aburrida... No ocurre nada, no hago mucho.";
        }
        if (statsScript.day == 1 && statsScript.scene == 3)
        {
            textMeshProUGUI.text = "Lo único por lo que me preocupo, es no decepcionar a mis padres...";
        }
        if (statsScript.day == 1 && statsScript.scene == 4)
        {
            textMeshProUGUI.text = "otro día igual... Esperemos que el proximo tambien sea así...";
        }
        if (statsScript.day == 1 && statsScript.scene == 5)
        {
            textMeshProUGUI.text = "voy a ver mi celular antes de dormir";
            statsScript.day += 1;
            statsScript.scene = 1;            
            return;
        }
        if (statsScript.day == 2 && statsScript.scene == 1)
        {
            textMeshProUGUI.text = "Buenos días... supongo";
            ChangeDay();
        }
        if (statsScript.day == 2 && statsScript.scene == 2)
        {
            textMeshProUGUI.text = "No quería ir a clase hoy, pero que diran mis compañeros si falto mucho";
        }
        if (statsScript.day == 2 && statsScript.scene == 3)
        {
            textMeshProUGUI.text = "Creo saber la respuesta...";
        }
        if (statsScript.day == 2 && statsScript.scene == 4)
        {
            textMeshProUGUI.text = "Lo único por lo que me preocupo, es no decepcionar a mis padres...2.4";
        }
        if (statsScript.day == 2 && statsScript.scene == 5)
        {
            textMeshProUGUI.text = "Lo único por lo que me preocupo, es no decepcionar a mis padres...2.5";
            statsScript.day += 1;
            statsScript.scene = 1;            
            return;
        }
        if (statsScript.day == 3 && statsScript.scene == 1)
        {
            textMeshProUGUI.text = "Lo único por lo que me preocupo, es no decepcionar a mis padres...3.1";
            ChangeDay();
        }
        if (statsScript.day == 3 && statsScript.scene == 2)
        {
            textMeshProUGUI.text = "Lo único por lo que me preocupo, es no decepcionar a mis padres...3.2";
        }
        if (statsScript.day == 3 && statsScript.scene == 3)
        {
            textMeshProUGUI.text = "Lo único por lo que me preocupo, es no decepcionar a mis padres...3.3";
        }
        if (statsScript.day == 3 && statsScript.scene == 4)
        {
            textMeshProUGUI.text = "Lo único por lo que me preocupo, es no decepcionar a mis padres...3.4";
        }
        if (statsScript.day == 3 && statsScript.scene == 5)
        {
            textMeshProUGUI.text = "Lo único por lo que me preocupo, es no decepcionar a mis padres...3.5";
            statsScript.day += 1;
            statsScript.scene = 1;            
            return;
        }
        if (statsScript.day == 4 && statsScript.scene == 1)
        {
            textMeshProUGUI.text = "Lo único por lo que me preocupo, es no decepcionar a mis padres...4.1";
            ChangeDay();
        }
        if (statsScript.day == 4 && statsScript.scene == 2)
        {
            textMeshProUGUI.text = "Lo único por lo que me preocupo, es no decepcionar a mis padres...4.2";
        }
        if (statsScript.day == 4 && statsScript.scene == 3)
        {
            textMeshProUGUI.text = "Lo único por lo que me preocupo, es no decepcionar a mis padres...4.3";
        }
        if (statsScript.day == 4 && statsScript.scene == 4)
        {
            textMeshProUGUI.text = "Lo único por lo que me preocupo, es no decepcionar a mis padres...4.4";
        }
        if (statsScript.day == 4 && statsScript.scene == 5)
        {
            textMeshProUGUI.text = "Lo único por lo que me preocupo, es no decepcionar a mis padres...4.5";
            statsScript.day += 1;
            statsScript.scene = 1;           
            return;
        }
        statsScript.scene += 1;
    }
    void ChangeDay ()
    {
        textDay.text = "Día " + statsScript.day;
    }
}
