using UnityEngine;

public class StatsScript1 : MonoBehaviour
{
    public static int felicidad = 50;
    public static int day = 1;
    public static int scene = 1;

    public void ChangeConfidence(int change)
    {
        felicidad += change;
    }

    public int TotalHealth()
    {
        return felicidad;
    }
}
