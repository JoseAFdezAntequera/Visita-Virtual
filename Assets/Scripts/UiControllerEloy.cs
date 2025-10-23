using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiControllerEloy : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject camaras;
    [SerializeField] private GameObject iluminacion;
    [SerializeField] private GameObject textoApagarLuces;
    [SerializeField] private GameObject sliderIntensidadLuz;

    private bool estaLuzActiva;


    private int i;
    void Start()
    {
        
    }


    void Update()
    {
        if (SceneManager.GetActiveScene().name == "VisitaVirtualConInteractividad")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (canvas.gameObject.activeSelf)
                {
                    canvas.gameObject.SetActive(false);
                }
                else
                {
                    canvas.gameObject.SetActive(true);
                }
            }
        }

    }


    public void CambiarCamaras(int posCamara)
    {
        for (i = 0; i < camaras.gameObject.transform.childCount; i++)
        {
            camaras.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        camaras.gameObject.transform.GetChild(posCamara).gameObject.SetActive(true);
    }

    public void ApagarEncenderLuces()
    {
        estaLuzActiva = false;
        for (i = 0; i < iluminacion.transform.childCount; i++)
        {
            if (iluminacion.transform.GetChild(i).gameObject.activeSelf)
            {
                estaLuzActiva = true;
                iluminacion.transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                estaLuzActiva = false;
                iluminacion.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        if (estaLuzActiva)
        {
            textoApagarLuces.gameObject.GetComponent<TMP_Text>().text = "Encender Luces";

            for (i = 1; i < canvas.gameObject.transform.GetChild(0).gameObject.transform.childCount; i++)
            {
                canvas.gameObject.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else
        {
            textoApagarLuces.gameObject.GetComponent<TMP_Text>().text = "Apagar Luces";

            for (i = 1; i < canvas.gameObject.transform.GetChild(0).gameObject.transform.childCount; i++)
            {
                canvas.gameObject.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    public void CambiarIntensidad()
    {
        for (i = 0; i < iluminacion.transform.childCount; i++)
        {
            iluminacion.transform.GetChild(i).gameObject.GetComponent<Light>().intensity = sliderIntensidadLuz.gameObject.GetComponent<Slider>().value;
        }
    }

    public void CambiarColor(string color)
    {
        for (i = 0; i < iluminacion.transform.childCount; i++)
        {
            if (color == "rojo")
            {
                iluminacion.transform.GetChild(i).gameObject.GetComponent<Light>().color = Color.red;
            }
            else if (color == "amarillo")
            {
                iluminacion.transform.GetChild(i).gameObject.GetComponent<Light>().color = Color.yellow;
            }
            else if (color == "verde")
            {
                iluminacion.transform.GetChild(i).gameObject.GetComponent<Light>().color = Color.green;
            }
            else
            {
                iluminacion.transform.GetChild(i).gameObject.GetComponent<Light>().color = Color.white;
            }
        }
    }
}
