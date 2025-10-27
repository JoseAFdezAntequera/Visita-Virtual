using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PickerColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField]
    private GameObject luces;

    [Header("UI Image con el atlas de colores")]
    public RawImage colorAtlasImage; // mejor usar RawImage si el atlas no es Sprite
    public Texture2D colorAtlasTexture; // textura real usada por la RawImage

    [Header("Destino donde mostrar el color")]
    public Image colorPreview; // opcional: un Image que mostrará el color seleccionado

    [Header("Opcional: Texto donde mostrar valor HEX")]
    public Text hexText;

    private bool _isPointerOver;

    void Reset()
    {
        colorAtlasImage = GetComponent<RawImage>();
        if (colorAtlasImage != null)
            colorAtlasTexture = colorAtlasImage.texture as Texture2D;
    }

    void Start()
    {
        if (colorAtlasImage != null && colorAtlasTexture == null)
            colorAtlasTexture = colorAtlasImage.texture as Texture2D;

        if (colorAtlasTexture == null)
            Debug.LogWarning("⚠️ No hay textura asignada al atlas de colores.");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isPointerOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isPointerOver = false;
    }

    public void OnPointerClick (PointerEventData eventData)
    {
        if (!_isPointerOver || colorAtlasTexture == null)
            return;

        // Convierte la posición del puntero a coordenadas locales dentro del rectángulo de la imagen
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            colorAtlasImage.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localPoint
        );

        // Normaliza la posición (0..1)
        Rect rect = colorAtlasImage.rectTransform.rect;
        float normalizedX = Mathf.InverseLerp(rect.xMin, rect.xMax, localPoint.x);
        float normalizedY = Mathf.InverseLerp(rect.yMin, rect.yMax, localPoint.y);

        // Convierte a coordenadas de textura
        int texX = Mathf.Clamp(Mathf.RoundToInt(normalizedX * colorAtlasTexture.width), 0, colorAtlasTexture.width - 1);
        int texY = Mathf.Clamp(Mathf.RoundToInt(normalizedY * colorAtlasTexture.height), 0, colorAtlasTexture.height - 1);

        // Obtiene el color bajo el cursor
        Color color = colorAtlasTexture.GetPixel(texX, texY);

        // Actualiza preview y texto
        if (colorPreview != null)
            colorPreview.color = color;

        for (int i = 0; i < luces.gameObject.transform.childCount; i++)
        {
            luces.gameObject.transform.GetChild(i).gameObject.GetComponent<Light>().color = color;
        }

        if (hexText != null)
            hexText.text = ColorUtility.ToHtmlStringRGB(color);
    }
}
