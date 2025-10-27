using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ModoFiesta : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject FPSController;
    [SerializeField]
    private Texture2D manoCursor;
    [SerializeField]
    private GameObject mano;

    private void OnMouseEnter()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
    }

    private void OnMouseDown()
    {
        if (!gameObject.transform.parent.GetComponent<AudioSource>().isPlaying) gameObject.transform.parent.GetComponent<AudioSource>().Play();
        else gameObject.transform.parent.GetComponent<AudioSource>().Stop();

        if (!canvas.gameObject.transform.GetChild(2).gameObject.activeSelf)
        {
            canvas.gameObject.transform.GetChild(2).gameObject.SetActive(true);

            FPSController.gameObject.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.SetCursor(manoCursor, Vector2.zero, CursorMode.Auto);
            mano.SetActive(false);
        } 
    }
}
