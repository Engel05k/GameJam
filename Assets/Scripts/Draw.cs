using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Draw : MonoBehaviour
{
    [Header("Canvas Images")]
    [SerializeField] private RawImage playerCanvasImage;
    [SerializeField] private RawImage referenceCanvasImage;

    [Header("Reference Sprites")]
    [SerializeField] private Sprite[] patternSprites;

    [Header("Draw Settings")]
    [SerializeField] private Color drawColor = Color.black;
    [SerializeField] private int brushSize = 5;
    [SerializeField] private float brushHardness = 0.8f; 

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI resultText;

    private Texture2D playerTexture;
    private Texture2D originalReferenceTexture;
    private bool isDrawing = false;
    private Vector2 lastDrawPosition;

    private void Start()
    {
        InitializeCanvases();
        StartCoroutine(SetupTextures());
    }

    private void InitializeCanvases()
    {
        playerCanvasImage.gameObject.SetActive(false);
        referenceCanvasImage.gameObject.SetActive(false);
    }

    private IEnumerator SetupTextures()
    {
        yield return new WaitForSeconds(1.2f);

        if (patternSprites != null && patternSprites.Length > 0)
        {
            Sprite selectedSprite = patternSprites[Random.Range(0, patternSprites.Length)];
            SetupReferenceTexture(selectedSprite);
            SetupPlayerTexture(selectedSprite);

            playerCanvasImage.gameObject.SetActive(true);
            referenceCanvasImage.gameObject.SetActive(true);
        }
    }

    private void SetupReferenceTexture(Sprite sprite)
    {
        originalReferenceTexture = GetTextureFromSprite(sprite);
        Texture2D fadedTexture = CreateFadedTextureFromSprite(sprite);
        referenceCanvasImage.texture = fadedTexture;
    }

    private void SetupPlayerTexture(Sprite sprite)
    {
        CreateBlankTexture(playerCanvasImage, originalReferenceTexture.width, originalReferenceTexture.height);
        playerCanvasImage.texture = playerTexture;
    }

    private Texture2D GetTextureFromSprite(Sprite sprite)
    {
        if (sprite == null) return null;
        Texture2D newTexture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
        Color[] pixels = sprite.texture.GetPixels(
            (int)sprite.rect.x,
            (int)sprite.rect.y,
            (int)sprite.rect.width,
            (int)sprite.rect.height);

        newTexture.SetPixels(pixels);
        newTexture.Apply();
        return newTexture;
    }

    private Texture2D CreateFadedTextureFromSprite(Sprite sprite)
    {
        Texture2D originalTex = GetTextureFromSprite(sprite);
        if (originalTex == null) return null;

        Texture2D faded = new Texture2D(originalTex.width, originalTex.height, TextureFormat.RGBA32, false);
        Color[] pixels = originalTex.GetPixels();

        for (int i = 0; i < pixels.Length; i++)
        {
            if (pixels[i].a > 0)
            {
                pixels[i].a = 0.5f; //opacidad del 50%
            }
        }

        faded.SetPixels(pixels);
        faded.Apply();
        return faded;
    }

    private void Update()
    {
        HandleDrawingInput();
    }

    private void HandleDrawingInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDrawing = true;
            lastDrawPosition = GetNormalizedMousePosition();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
        }

        if (isDrawing)
        {
            Vector2 currentPosition = GetNormalizedMousePosition();
            DrawAtMousePosition();
            lastDrawPosition = currentPosition;
        }
    }

    private Vector2 GetNormalizedMousePosition()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            playerCanvasImage.rectTransform,
            Input.mousePosition,
            null,
            out Vector2 localPos);

        Rect rect = playerCanvasImage.rectTransform.rect;
        return new Vector2(
            (localPos.x + rect.width * 0.5f) / rect.width,
            (localPos.y + rect.height * 0.5f) / rect.height);
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
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, inputPosition, cam, out Vector2 localPoint))
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
        float radius = brushSize;
        float hardness = brushHardness;

        for (int i = -brushSize; i <= brushSize; i++)
        {
            for (int j = -brushSize; j <= brushSize; j++)
            {
                int px = x + i;
                int py = y + j;

                if (px >= 0 && py >= 0 && px < playerTexture.width && py < playerTexture.height)
                {
                    float distance = Mathf.Sqrt(i * i + j * j);
                    if (distance <= radius)
                    {
                        float alpha = Mathf.Clamp01(1f - (distance / radius));
                        alpha = Mathf.Pow(alpha, 1f / hardness);

                        Color existingColor = playerTexture.GetPixel(px, py);
                        Color blendedColor = Color.Lerp(existingColor, drawColor, alpha * drawColor.a);
                        blendedColor.a = Mathf.Clamp01(existingColor.a + alpha * drawColor.a);

                        playerTexture.SetPixel(px, py, blendedColor);
                    }
                }
            }
        }

        playerTexture.Apply();
    }

    private void CreateBlankTexture(RawImage rawImage, int width, int height)
    {
        playerTexture = new Texture2D(width, height, TextureFormat.RGBA32, false)
        {
            filterMode = FilterMode.Bilinear,
            wrapMode = TextureWrapMode.Clamp
        };

        Color[] fillColor = new Color[width * height];
        for (int i = 0; i < fillColor.Length; i++)
        {
            fillColor[i] = Color.clear;
        }

        playerTexture.SetPixels(fillColor);
        playerTexture.Apply();
        rawImage.texture = playerTexture;
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
            Debug.LogError("Las dimensiones de la textura del jugador y la referencia no coinciden.");
            return;
        }

        Color[] playerPixels = playerTexture.GetPixels();
        Color[] referencePixels = originalReferenceTexture.GetPixels();

        int totalRelevantPixels = 0;
        int matchingPixels = 0;

        float referenceAlphaThreshold = 0.1f; 
        float playerAlphaThreshold = 0.1f;

        for (int i = 0; i < referencePixels.Length; i++)
        {
            if (referencePixels[i].a >= referenceAlphaThreshold)
            {
                totalRelevantPixels++;

                if (playerPixels[i].a >= playerAlphaThreshold)
                {
                    matchingPixels++;
                }
            }
        }

        float similarity = totalRelevantPixels > 0
            ? (float)matchingPixels / totalRelevantPixels * 100f
            : 0f;

        Debug.Log($"Similitud: {similarity:F2}%");

        if (resultText != null)
        {
            resultText.text = $"Score: {similarity:F2}%";
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
}