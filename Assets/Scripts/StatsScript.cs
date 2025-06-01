using UnityEngine;

public class StatsScript : MonoBehaviour
{
    public int felicidad = 50;   
    public int day = 1;
    public int scene = 1;

    public void ChangeConfidence(int change)
    {
        felicidad += change;
    }    
    public int TotalHealth()
    {
        return felicidad;  
    }
}
