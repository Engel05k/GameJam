using System.Collections;
using UnityEngine;

public class Draw : MonoBehaviour
{
    Coroutine drawing;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartLine();
        }
        if (Input.GetMouseButtonUp(0))
        {
            FinishLine();
        }
    }

    private void StartLine()
    {
        if (drawing != null)
        {
            StopCoroutine(drawing);
        }

        Debug.Log("Comenzando nueva línea...");
        drawing = StartCoroutine(DrawLine());
    }

    private void FinishLine()
    {
        if (drawing != null)
        {
            StopCoroutine(drawing);
            drawing = null;
        }
    }

    IEnumerator DrawLine()
    {
        GameObject newGameObject = Instantiate(Resources.Load("Line") as GameObject, new Vector3(0, 0, 0), Quaternion.identity);
        LineRenderer line = newGameObject.GetComponent<LineRenderer>();
        line.positionCount = 0;

        while (true)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, position);
            yield return null;
        }
    }
}
