using UnityEngine;

public class Bici : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private GameObject ObjetosJosan;

    private void Start()
    {
        ObjetosJosan = gameObject.transform.parent.gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && gameObject.transform.parent == player.transform) {
            //Animamos las ruedas hacia adelante
            gameObject.transform.GetChild(4).
                gameObject.transform.GetChild(0).
                gameObject.GetComponent<Animator>().SetTrigger("Avanza");
            gameObject.transform.GetChild(5).gameObject.GetComponent<Animator>().SetTrigger("Avanza");

            //Paramos el sonido de pasos
            player.GetComponent<AudioSource>().mute = true;
        }

        if (Input.GetKeyDown(KeyCode.S) && gameObject.transform.parent == player.transform)
        {
            //Animamos las ruedas hacia atras
            gameObject.transform.GetChild(4).
                gameObject.transform.GetChild(0).
                gameObject.GetComponent<Animator>().SetTrigger("Retrocede");
            gameObject.transform.GetChild(5).gameObject.GetComponent<Animator>().SetTrigger("Retrocede");

            //Paramos el sonido de pasos
            player.GetComponent<AudioSource>().mute = true;
        }

        if (Input.GetKeyDown(KeyCode.Q) && gameObject.transform.parent == player.transform)
        {
            //Activamos el sonido de pasos
            player.GetComponent<AudioSource>().mute = false;

            //Devolvemos la bici a su sitio en la herarquia
            gameObject.transform.SetParent(ObjetosJosan.transform);

        }

        //Giramos a la izquierda
        if (Input.GetKeyDown(KeyCode.A) && gameObject.transform.parent == player.transform) 
            gameObject.transform.GetChild(4).gameObject.GetComponent<Animator>().SetTrigger("GiroIzquierda");

        //Giramos a la derecha
        if (Input.GetKeyDown(KeyCode.D) && gameObject.transform.parent == player.transform) 
            gameObject.transform.GetChild(4).gameObject.GetComponent<Animator>().SetTrigger("GiroDerecha");

    }

    private void OnMouseDown()
    {
        //Movemos la bici dentro de player
        gameObject.transform.SetParent(player.transform);

        //La posicionamos correctamente
        gameObject.transform.position = player.transform.position;
        gameObject.transform.rotation = player.transform.rotation;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                    gameObject.transform.position.y - 0.93f,
                                                    gameObject.transform.position.z);

        //Subimos al player a la altura de la bici
        player.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x,
                                                           player.gameObject.transform.position.y + 0.5f,
                                                           player.gameObject.transform.position.z);
    }
}
