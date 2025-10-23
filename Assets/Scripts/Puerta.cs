using UnityEngine;

public class Puerta : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (this.gameObject.GetComponent<Animator>().GetBool("estadoPuerta") == false)
        {
            this.gameObject.GetComponent<Animator>().SetBool("estadoPuerta", true);
        }
        else
        {
            this.gameObject.GetComponent<Animator>().SetBool("estadoPuerta", false);
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
