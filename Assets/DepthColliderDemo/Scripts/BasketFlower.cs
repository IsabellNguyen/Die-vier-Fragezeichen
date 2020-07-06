//using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketFlower : MonoBehaviour
{
    public Transform child;
    public Transform parent;
    public float position = -1f;
    public AudioClip bling;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "basketFlower";
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("joint")&&gameObject.tag=="basketFlower")
        {
            this.GetComponent<AudioSource>().clip = bling;
            this.GetComponent<AudioSource>().Play();
            child = col.gameObject.transform.GetChild(0);
            child.transform.SetParent(parent);
            child.transform.localPosition = new Vector3(position, 0, 0);
            child.transform.localScale = new Vector3(1f, 1f, 20);
            child.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            position += 0.5f;

            
        }
        
    }

}
