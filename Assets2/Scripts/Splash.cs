using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{

    void Start()
    {
        Invoke("CambiarEscena", 3.0f);
    }

    public void CambiarEscena()
    {
        SceneManager.LoadScene("MenuPrincipal"); 
    }
}
