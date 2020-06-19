using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointFlower : MonoBehaviour
{

   void Start()
    {
        gameObject.tag = "empty";
    }
    
    void Update()
    {

        //gameObject.transform.position += new Vector3 (0,1f,0);
        if (this.GetComponent<SpriteRenderer>().enabled)
        {
            gameObject.tag = "joint";
        }
        else {
            gameObject.tag = "empty";
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.CompareTag("flower")&&gameObject.tag=="empty")
        {
            gameObject.GetComponent<AudioSource>().Play();
            this.GetComponent<SpriteRenderer>().enabled = true;
        }


        if (col.gameObject.CompareTag("basketFlower")&& gameObject.tag == "joint")
        {
            gameObject.GetComponent<AudioSource>().Play();
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
