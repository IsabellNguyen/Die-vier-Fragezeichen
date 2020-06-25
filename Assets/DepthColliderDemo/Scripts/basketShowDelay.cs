using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketShowDelay : MonoBehaviour
{
    public AudioSource intro;
    public int waitTime = 30;
    private int count = 0;

    public AudioSource grass;

    public GameObject child;
    public Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!intro.isPlaying)
        {
            count++;
            if (count == waitTime)
            {
                grass.Play();
                child.transform.SetParent(parent);
                //child.transform.localPosition = new Vector3(0, 0, 0);
                child.transform.localPosition = new Vector3(-3,-2, 0);
                child.transform.localScale = new Vector3(1, 1, 20);
                child.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }

        }
    }
}

