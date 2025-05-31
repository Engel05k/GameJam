using UnityEngine;

public class StatsScript : MonoBehaviour
{
    public float mentalHealth = 50;
    public float selfConfidence = 50;
    public float socialSkills = 50;
    public int day = 1;
    public int scene = 1;    

    public void ChangeConfidence(float change)
    {
        selfConfidence += change;
    }
    public void ChangesocialSkills(float change)
    {
        socialSkills += change;
    }
    public void ChangeHealth(float change)
    {
        mentalHealth += change;
    }       
}
