using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketShowDelay : MonoBehaviour
{
    public AudioSource intro;
    public int waitTime = 320;
    private int count = 0;

    public AudioSource grass;

    public GameObject child;
    public Transform parent;

    public GameObject hand;
    

    // Update is called once per frame
    void Update()
    {
        if (!intro.isPlaying)
        {
            count++;
            ongoing();
        }
    }

    public bool ongoing()
    {
        if (count == waitTime)
        {

            grass.Play();
            child.transform.SetParent(parent);
            child.transform.localPosition = new Vector3(1, -5.7f, 0);
            child.transform.localScale = new Vector3(1, 1, 20);
            child.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            hand.gameObject.tag = "empty";
            return true;
        }
        else if (count > waitTime)
        {
            return false;
        }
        return true;
    }
}

