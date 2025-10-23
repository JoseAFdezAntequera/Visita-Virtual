using UnityEngine;
using UnityEngine.SceneManagement;

public class Salir : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }
}
