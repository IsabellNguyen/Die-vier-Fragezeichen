using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class won : MonoBehaviour
{
  
    private bool outroPlayed = false;
    public bool outroGo = false;
    public AudioClip outro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (outroGo&&!outroPlayed)
        {
            this.GetComponent<AudioSource>().clip = outro;
            this.GetComponent<AudioSource>().Play();

            outroPlayed = true;
        }
    }
}
