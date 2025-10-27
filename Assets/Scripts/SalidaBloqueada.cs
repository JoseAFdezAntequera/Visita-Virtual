using UnityEngine;
using TMPro; 

public class BloqueoSalida : MonoBehaviour
{
    [SerializeField] public GameObject mensajeUI;     
    public float duracionMensaje = 2f;

    private bool mostrandoMensaje = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !mostrandoMensaje)
        {
            StartCoroutine(MostrarMensaje());
        }
    }

    private System.Collections.IEnumerator MostrarMensaje()
    {
        mostrandoMensaje = true;
        mensajeUI.SetActive(true);
        yield return new WaitForSeconds(duracionMensaje);
        mensajeUI.SetActive(false);
        mostrandoMensaje = false;
    }
}