using UnityEngine;
using UnityEngine.SceneManagement;
public class Creditos : MonoBehaviour
{
    
    void Start()
    {
        Invoke("WaitToEnd",27);
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
   
    public void WaitToEnd()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
}
