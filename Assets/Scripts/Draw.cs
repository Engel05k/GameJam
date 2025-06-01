using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Draw : MonoBehaviour
{
    Coroutine drawing;
    [SerializeField] private Rect drawBounds = new Rect(-5f, -3f, 10f, 6f);

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
        GameObject newGameObject = Instantiate(Resources.Load("Line") as GameObject, Vector3.zero, Quaternion.identity);
        LineRenderer line = newGameObject.GetComponent<LineRenderer>();
        line.positionCount = 0;

        while (true)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;

            if (drawBounds.Contains(position))
            {
                line.positionCount++;
                line.SetPosition(line.positionCount - 1, position);
            }

            yield return null;
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 center = new Vector3(drawBounds.x + drawBounds.width / 2, drawBounds.y + drawBounds.height / 2, 0);
        Vector3 size = new Vector3(drawBounds.width, drawBounds.height, 0);
        Gizmos.DrawWireCube(center, size);
    }
}
