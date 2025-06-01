using UnityEngine;

public class StatsScript : MonoBehaviour
{
    static public int felicidad = 50;   
    static public int day = 1;
    static public int scene = 1;

    public void ChangeConfidence(int change)
    {
        felicidad += change;
    }    
    public int TotalHealth()
    {
        return felicidad;  
    }
}
