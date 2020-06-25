using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointFlower : MonoBehaviour
{
    private GestureListener GestureListener;

    void Start()
    {
        gameObject.tag = "empty";

        // get the gestures listener
        GestureListener = Camera.main.GetComponent<GestureListener>();
    }
    
    void Update()
    {
        KinectManager kinectManager = KinectManager.Instance;
        if ((!kinectManager || !kinectManager.IsInitialized() || !kinectManager.IsUserDetected()))
            return;
        //gameObject.transform.position += new Vector3 (0,1f,0);
        if (this.transform.childCount == 0)
        {
            gameObject.tag = "empty";
        }
        else if(this.transform.GetChild(0).tag == "weedFinish")
        {
            gameObject.tag = "evil";
        }
        else
        if (this.transform.GetChild(0).tag == "flowerFinish")
        {
            gameObject.tag = "joint";
        }

        if (GestureListener) 
        {
            if (GestureListener.IsSwipeRight())
            {
                print("waved");
            }
        }
            
    }

    void OnTriggerEnter2D(Collider2D col)
    {   gameObject.GetComponent<AudioSource>().Play();
            


        
            gameObject.GetComponent<AudioSource>().Play();

        
    }
}
