using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Draw : MonoBehaviour
{
    [Header("Canvas Images")]
    [SerializeField] private RawImage playerCanvasImage;
    [SerializeField] private RawImage referenceCanvasImage;

    [Header("Textures")]
    [SerializeField] private Texture2D[] patternTextures;

    [Header("Draw")]
    [SerializeField] private Color drawColor = Color.black;
    [SerializeField] private int brushSize = 5;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI resultText;

    private Texture2D playerTexture;
    private Texture2D originalReferenceTexture;
    private bool isDrawing = false;

    private void Start()
    {
        if (playerCanvasImage != null)
        {
            playerCanvasImage.gameObject.SetActive(false);
        }
        if (referenceCanvasImage != null)
        {
            referenceCanvasImage.gameObject.SetActive(false);
        }
        StartCoroutine(SetupTextures());
    }

    private IEnumerator SetupTextures()
    {
        yield return new WaitForSeconds(1.2f);
        if (playerCanvasImage != null)
        {
            playerCanvasImage.gameObject.SetActive(true);
        }
        if (referenceCanvasImage != null)
        {
            referenceCanvasImage.gameObject.SetActive(true);
        }
        if (patternTextures != null && patternTextures.Length > 0)
        {
            Texture2D selected = patternTextures[Random.Range(0, patternTextures.Length)];
            originalReferenceTexture = selected;
            Texture2D faded = new Texture2D(selected.width, selected.height, TextureFormat.RGBA32, false);
            faded.filterMode = FilterMode.Point;
            Color[] pixels = selected.GetPixels();
            for (int i = 0; i < pixels.Length; i++) pixels[i].a = 0.2f;
            faded.SetPixels(pixels);
            faded.Apply();
            referenceCanvasImage.texture = faded;
            referenceCanvasImage.gameObject.SetActive(true);
            CreateBlankTexture(playerCanvasImage, selected.width, selected.height);
            playerCanvasImage.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDrawing = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
        }
        if (isDrawing)
        {
            DrawAtMousePosition();
        }
    }

    private void DrawAtMousePosition()
    {
        Vector2 inputPosition;
        if (Input.touchCount > 0)
        {
            inputPosition = Input.GetTouch(0).position;
        }
        else
        {
            inputPosition = Input.mousePosition;
        }
        Camera cam = Camera.main;
        if (cam == null || playerCanvasImage == null)
        {
            return;
        }
        RectTransform rect = playerCanvasImage.rectTransform;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, Input.mousePosition, cam, out Vector2 localPoint))
        {
            Vector2 size = rect.rect.size;
            Vector2 normalizedPoint = new Vector2(
                (localPoint.x + size.x * 0.5f) / size.x,
                (localPoint.y + size.y * 0.5f) / size.y
            );
            int x = Mathf.RoundToInt(normalizedPoint.x * playerTexture.width);
            int y = Mathf.RoundToInt(normalizedPoint.y * playerTexture.height);
            DrawAt(x, y);
        }
    }

    private void DrawAt(int x, int y)
    {
        for (int i = -brushSize; i <= brushSize; i++)
        {
            for (int j = -brushSize; j <= brushSize; j++)
            {
                int px = x + i;
                int py = y + j;
                if (px >= 0 && py >= 0 && px < playerTexture.width && py < playerTexture.height)
                {
                    playerTexture.SetPixel(px, py, drawColor);
                }
            }
        }
        playerTexture.Apply();
    }

    private void CreateBlankTexture(RawImage rawImage, int width, int height)
    {
        Texture2D newTexture = new Texture2D(width, height, TextureFormat.RGBA32, false);
        newTexture.filterMode = FilterMode.Point;
        Color[] fillColor = new Color[width * height];
        for (int i = 0; i < fillColor.Length; i++)
        {
            fillColor[i] = Color.clear;
        }
        newTexture.SetPixels(fillColor);
        newTexture.Apply();
        rawImage.texture = newTexture;
        if (rawImage == playerCanvasImage)
        {
            playerTexture = newTexture;
        }
    }

    public void HideCanvases()
    {
        if (playerCanvasImage != null)
        {
            playerCanvasImage.gameObject.SetActive(false);
        }
        if (referenceCanvasImage != null)
        {
            referenceCanvasImage.gameObject.SetActive(false);
        }
    }

    public Texture2D GetPlayerTexture() => playerTexture;
    public Texture2D GetReferenceTexture() => originalReferenceTexture;

    public void CompareDrawings()
    {
        if (playerTexture == null || originalReferenceTexture == null)
        {
            return;
        }
        if (playerTexture.width != originalReferenceTexture.width || playerTexture.height != originalReferenceTexture.height)
        {
            return;
        }
        Color[] playerPixels = playerTexture.GetPixels();
        Color[] referencePixels = originalReferenceTexture.GetPixels();
        int matchingPixels = 0;
        int totalPixels = playerPixels.Length;
        for (int i = 0; i < totalPixels; i++)
        {
            Color a = playerPixels[i];
            Color b = referencePixels[i];
            if (a.a > 0.1f && b.a > 0.1f)
            {
                float diff = Mathf.Abs(a.r - b.r) + Mathf.Abs(a.g - b.g) + Mathf.Abs(a.b - b.b);
                if (diff < 0.3f)
                {
                    matchingPixels++;
                }
            }
        }
        float similarity = (float)matchingPixels / totalPixels * 100f;
        Debug.Log($"Similitud: {similarity:F2}%");
        if (resultText != null)
        {
            resultText.text = $"Score: {similarity:F2}%";
        }
    }
}