//using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower : MonoBehaviour {


    public GameObject child;
    public Transform parent;

    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if(sprite.name=="tulpe"||sprite.name == "gänse")
        {
            gameObject.tag = "flower";
        }
        else
        {
            gameObject.tag = "weed";
        }
        child = this.gameObject;
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("empty")&& (gameObject.tag == "flower"))
        {
            this.GetComponent<AudioSource>().Play();
            child.transform.SetParent(parent);
            child.transform.localPosition = new Vector3(0, 0, 0);
            child.transform.localScale = new Vector3(0.5f, 0.5f, 20);
            child.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            this.tag += "Finish";
        }

        if (col.gameObject.CompareTag("empty") && ( gameObject.tag == "weed"))
        {
            print(col.gameObject.tag);
            this.GetComponent<AudioSource>().Play();
        }

    }

}
