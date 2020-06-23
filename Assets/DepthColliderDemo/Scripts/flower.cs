//using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower : MonoBehaviour {
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "flower";

    }

    void Update()
    {
        if (!this.isActiveAndEnabled)
        {
            this.tag = "Finish";
        }
        else
        {
            this.tag = "flower";
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("empty"))
        {
            gameObject.SetActive(true);
            print("ein wildes flower entkommt");
        }
        print("flower triggered");

    }

}
