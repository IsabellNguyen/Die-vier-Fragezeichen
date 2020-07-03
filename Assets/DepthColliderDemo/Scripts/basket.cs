using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket : MonoBehaviour
{
    public AudioClip outro;
    public GameObject hand;

   
    // Start is called before the first frame update
    void Update()
    {
        if (this.transform.childCount > 4&&!Outro())
        {
            Outro();
        }
       
    }

    public bool Outro()
    {
        hand.gameObject.tag = "end";
        this.GetComponent<AudioSource>().clip = outro;
        this.GetComponent<AudioSource>().Play();
        return true;
    }

}
