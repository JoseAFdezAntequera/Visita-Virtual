using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class UI : MonoBehaviour
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

    [SerializeField]
    private GameObject FPSController;
    [SerializeField]
    private Texture2D manoCursor;
    [SerializeField]
    private GameObject mano;
    private bool modoFiesta;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        estadoLuces = true;
        modoFiesta = false;
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
            else
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0.0f; //Paramos el tiempo para que se pueda usar en medio de la animación de la cámara
            }
        }

        //ModoFiesta
        if (modoFiesta)
        {
            Color[] colores = { Color.cyan, Color.magenta, Color.red, Color.yellow, Color.blue, Color.green, Color.white };

            for (int i = 0; i < luces.gameObject.transform.childCount; i++)
            {
                luces.gameObject.transform.GetChild(i).gameObject.GetComponent<Light>().color = colores[Random.Range(0, 6)];
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

    //ModoFiesta
    public void ModoFiestaOn()
    {
        modoFiesta = true;
        estadoLuces = true;

        canvas.gameObject.transform.GetChild(2).gameObject.SetActive(false);

        FPSController.gameObject.GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(manoCursor, Vector2.zero, CursorMode.Auto);
        mano.SetActive(true);
    }

    public void ModoFiestaOff()
    {
        modoFiesta = false;
        estadoLuces = false;

        canvas.gameObject.transform.GetChild(2).gameObject.SetActive(false);

        for (int i = 0; i < luces.gameObject.transform.childCount; i++)
        {
            luces.gameObject.transform.GetChild(i).gameObject.GetComponent<Light>().color = Color.white;
        }

        FPSController.gameObject.GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(manoCursor, Vector2.zero, CursorMode.Auto);
        mano.SetActive(true);
    }
}
