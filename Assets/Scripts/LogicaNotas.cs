using TMPro;
using UnityEngine;

public class LogicaNotas : MonoBehaviour
{
    public float velocidad = 1.5f;
    public int notaID;
    public bool adentro = false;
    void Update()
    {
        transform.position += Vector3.right * -velocidad * Time.deltaTime;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Linea"))
        {
            adentro = true;
        }
        if(collision.CompareTag("Fuera"))
        {
            adentro=false;
        }
    }
}
