//using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketFlower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "basketFlower";
    }

    void Update()
    {
        if (this.GetComponent<SpriteRenderer>().enabled)
        {
            gameObject.tag = "Finish";
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        print("basket triggered");
        if (col.gameObject.CompareTag("joint")&&gameObject.tag=="basketFlower")
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            print("ein wildes basketFlower erscheint");
        }
        
    }

}
