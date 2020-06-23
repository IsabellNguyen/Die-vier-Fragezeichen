using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showDelay : MonoBehaviour
{
    public AudioSource intro;
    private int count = 0;
    public Transform[] collectables;
    public int i = 1;
    public int waitTime = 1;

    public AudioClip bling;
    
    // Start is called before the first frame update
    void Start()
    {
        intro = GetComponent<AudioSource>();
        collectables = this.GetComponentsInChildren<Transform>(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (!intro.isPlaying&& i < collectables.Length-1)
        {
            intro.clip = bling;
            count++;
            
            if(count % waitTime == 0)
            {
                intro.Play();
                i++;
                collectables[i].gameObject.SetActive(true);
                
            }
        }
    }
}

