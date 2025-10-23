using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private GameObject luces;
    private bool estadoLuces;
    [SerializeField]
    private GameObject sliderIntensidadLuces;

    [SerializeField]
    private GameObject camaras;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        estadoLuces = true;
        sliderIntensidadLuces.gameObject.GetComponent<Slider>().value = 1;
        canvas.gameObject.transform.GetChild(1)
            .gameObject.transform.GetChild(1)
            .gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "Luces Off";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.gameObject.activeSelf)
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1.0f; //Activamos el tiempo para que siga la animación de la cámara
            }
            else { 
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0.0f; //Paramos el tiempo para que se pueda usar en medio de la animación de la cámara
            }
        }
    }

    //Cambia la intensidad de las luces
    public void CambioIntensidad()
    {
        for (int i = 0; i < luces.gameObject.transform.childCount; i++)
        {
            luces.gameObject.transform.GetChild(i).gameObject.GetComponent<Light>().intensity = sliderIntensidadLuces.gameObject.GetComponent<Slider>().value;
        }
    }

    //Cambia el estado de las luces
    public void CambioEstado()
    {
        if (!estadoLuces)
        {
            for (int i = 0; i < luces.gameObject.transform.childCount; i++)
            {
                luces.gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
            estadoLuces = true;
            canvas.gameObject.transform.GetChild(1)
                .gameObject.transform.GetChild(1)
                .gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "Luces Off";
        }
        else
        {
            for (int i = 0; i < luces.gameObject.transform.childCount; i++)
            {
                luces.gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
            estadoLuces = false;
            canvas.gameObject.transform.GetChild(1)
                .gameObject.transform.GetChild(1)
                .gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "Luces On";
        }
    }

    //Cambio de camaras
    public void CambioCamaras(int posCamara)
    {
        for (int i = 0; i < camaras.gameObject.transform.childCount; i++)
        {
            camaras.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        camaras.gameObject.transform.GetChild(posCamara).gameObject.SetActive(true);
    }
}
