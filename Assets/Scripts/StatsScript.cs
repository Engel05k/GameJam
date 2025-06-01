using UnityEngine;

public class StatsScript : MonoBehaviour
{
    public float energia = 50;
    public float felicidad = 50;
    public float socialSkills = 50;
    public int day = 1;
    public int scene = 1;

    public void ChangeConfidence(float change)
    {
        felicidad += change;
    }
    public void ChangesocialSkills(float change)
    {
        socialSkills += change;
    }
    public void ChangeHealth(float change)
    {
        energia += change;
    }
    public float TotalHealth()
    {
        return Mathf.FloorToInt((energia + felicidad + socialSkills) / 3f);
    }
}
