using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GarageDoor : MonoBehaviour
{
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
        if (gameObject.GetComponent<Animator>().GetBool("PuertaGarageOpen")) gameObject.GetComponent<Animator>().SetBool("PuertaGarageOpen", false);
        else gameObject.GetComponent<Animator>().SetBool("PuertaGarageOpen", true);

    }
}
