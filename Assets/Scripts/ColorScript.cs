using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ColorScript : MonoBehaviour
{      
    [SerializeField] private List<Color> colorList;
    [SerializeField] private SpriteRenderer panelImage;   
    private int colorNumber;
    [SerializeField] private float holaa;
    [SerializeField] bool pressedButton;
    StatsScript stats;
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("GameController").GetComponent<StatsScript>();
        panelImage = GetComponent<SpriteRenderer>();
        ChangeColor();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        holaa = StatsScript.felicidad;
        if (pressedButton)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                
            }
        }
        ChangeColor();
    }
    
    void ChangeColor()
    {
        if (!pressedButton)
        {
            if (StatsScript.felicidad > 80)
            {
                panelImage.color = colorList[0];                
            }
            else if (StatsScript.felicidad > 60)
            {
                panelImage.color = colorList[1];
            }
            else if (StatsScript.felicidad > 40)
            {
                panelImage.color = colorList[2];
            }
            else if (StatsScript.felicidad > 20)
            {
                panelImage.color = colorList[3];
            }
            else
            {
                panelImage.color = colorList[4];
            }
        }
        else
        {
            if (colorNumber < colorList.Count)
            {
                panelImage.color = colorList[colorNumber];
                colorNumber++;
            }
            else
            {
                colorNumber = 0;
            }
        }
    }
}
