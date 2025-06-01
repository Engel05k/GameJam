using UnityEngine;

public class SpawnerNotas : MonoBehaviour
{
    public GameObject[] NotasPrefabs;
    public float tiempo = 1.5f;
    private float temp; 

    private void Update()
    {
        temp += Time.deltaTime;
        if (temp >= tiempo)
        {
            spwanerNotas();
            temp = 0;
        }
    }

    private void spwanerNotas()
    {
        int randomIndex = Random.Range(0, NotasPrefabs.Length);
        GameObject nota = Instantiate(NotasPrefabs[randomIndex], transform.position, Quaternion.identity);
        nota.GetComponent<LogicaNotas>().notaID = randomIndex;
    }
}
