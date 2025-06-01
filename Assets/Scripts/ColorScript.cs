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
    [SerializeField] bool pressedButton;
    StatsScript stats;
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("GameController").GetComponent<StatsScript>();
        panelImage = GetComponent<SpriteRenderer>();
        ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (pressedButton)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                ChangeColor();
            }
        }        
    }
    
    void ChangeColor()
    {
        if (!pressedButton)
        {
            if (stats.TotalHealth() > 80)
            {
                panelImage.color = colorList[0];                
            }
            else if (stats.TotalHealth() > 60)
            {
                panelImage.color = colorList[1];
            }
            else if (stats.TotalHealth() > 40)
            {
                panelImage.color = colorList[2];
            }
            else if (stats.TotalHealth() > 20)
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
