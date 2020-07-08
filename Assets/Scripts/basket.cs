using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket : MonoBehaviour
{
    public AudioClip outro;
    public GameObject hand;
    public Transform child;
    public Transform parent;

    private int outroState = 0;

    void Update()
    {
       // print(this.transform.childCount);
        if (this.transform.childCount > 4 &&outroState == 0)
        {
            hand.gameObject.tag = "end";
            Outro();

        }
       
    }

    public bool Outro()
    {
        if ( outroState == 0 && this.transform.childCount > 4)
        {
            this.GetComponent<AudioSource>().clip = outro;
            this.GetComponent<AudioSource>().Play();
            child.transform.SetParent(parent);
            child.transform.localPosition = new Vector3(0, -0.5f, 0);
            child.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            child.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 45));
            
            outroState++;
            return true;
        }
        else
            return false;
    }

}
