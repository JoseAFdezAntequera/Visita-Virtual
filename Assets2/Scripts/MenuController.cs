using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ButtonsController(string escena)
    {
        switch (escena)
        {
            case "VisitaVirtualSinInteractividad":
                SceneManager.LoadScene(escena);
                break;

            case "VisitaVirtualConInteractividad":
                SceneManager.LoadScene(escena);
                break;

            case "VisitaVirtualPrimeraPersona":
                SceneManager.LoadScene(escena);
                break;

            case "MenuPrincipal":
                SceneManager.LoadScene(escena);
                break;
        }
    }
}
