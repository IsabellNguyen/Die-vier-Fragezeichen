//using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weed : MonoBehaviour
{


    public GameObject child;
    public Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "weed";
        child = this.gameObject;
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("empty") && gameObject.tag == "weed")
        {

            child.transform.SetParent(parent);
            child.transform.localPosition = new Vector3(0, 0, 0);
            child.transform.localScale = new Vector3(0.5f, 0.5f, 20);
            child.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            this.tag = "Finish";
        }

    }

}
