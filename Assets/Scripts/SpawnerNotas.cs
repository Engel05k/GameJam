using System.Collections;
using UnityEngine;

public class SpawnerNotas : MonoBehaviour
{

    public static int darOQuitar;
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
    [SerializeField] private MusicMinigame minigame;

    [SerializeField] private float notesAmount = 0;
    [SerializeField] private float maxAmount;

    [SerializeField] private bool maxxed = false;
    [SerializeField] private bool results;
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

        if (notesAmount >= maxAmount)
        {
            maxxed = true;
            StartCoroutine(ObtainNumber());
            return;

        }

        float alturaY = Random.Range(minH, maxH);
        Vector3 spawnPosition = transform.position + new Vector3(0, alturaY, 0);

        int randomIndex = Random.Range(0, NotasPrefabs.Length);
        GameObject nota = Instantiate(NotasPrefabs[randomIndex], spawnPosition, Quaternion.identity);

        notesAmount++;

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

    private IEnumerator ObtainNumber()
    {

        if (maxxed)
        {
            yield return new WaitForSeconds(3f);


            if (minigame.notestouched > minigame.notesmisseds)
            {
                results = true;
                Debug.Log(" resuktadi " + results);
            }
            else if (minigame.notestouched < minigame.notesmisseds)
            {
                results = false;
                Debug.Log(" resuktadi " + results);
            }
            else 
            {
                darOQuitar = 0;
            }
            

            if (results)
            {
                darOQuitar = 5;
            }
            else
            {
                darOQuitar = -5;
            }



        }
        



    }
}

