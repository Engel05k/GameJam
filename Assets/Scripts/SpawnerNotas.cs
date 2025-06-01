using UnityEngine;

public class SpawnerNotas : MonoBehaviour
{
    [Header("Notas")]
    public GameObject[] NotasPrefabs;

    [Header("Frecuencia de Spawneo")]
    public float spawnRate = 2f;
    private float timer;

    [Header("Altura aleatoria")]
    public float minH = -2f;
    public float maxH = 2f;

    [Header("Parent")]
    public Transform contenedorNotas;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnNota();
            timer = 0f;
        }
    }

    private void SpawnNota()
    {
        float alturaY = Random.Range(minH, maxH);
        Vector3 spawnPosition = transform.position + new Vector3(0, alturaY, 0);

        int randomIndex = Random.Range(0, NotasPrefabs.Length);
        GameObject nota = Instantiate(NotasPrefabs[randomIndex], spawnPosition, Quaternion.identity);

        if (contenedorNotas != null)
        {
            nota.transform.SetParent(contenedorNotas);
        }

        LogicaNotas logica = nota.GetComponent<LogicaNotas>();
        if (logica != null)
        {
            logica.notaID = randomIndex;
        }
    }
}

