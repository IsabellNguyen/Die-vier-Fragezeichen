//using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "flower";
    }

    void Update()
    {
        if (!this.GetComponent<SpriteRenderer>().enabled)
        {
            gameObject.tag = "Finish";
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("empty"))
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

}
