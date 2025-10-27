using UnityEngine;

public class Silla : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (this.gameObject.transform.parent.gameObject.GetComponent<Animator>().GetBool("estadoSilla") == false)
        {
            this.gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("estadoSilla", true);
        }
        else
        {
            this.gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("estadoSilla", false);
        }
        
    }
    private void OnMouseEnter()
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }
    private void OnMouseExit()
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
