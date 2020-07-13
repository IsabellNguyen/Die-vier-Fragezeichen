using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointFlower : MonoBehaviour
{
    public basketShowDelay show;
    public basket flowers;

    void Start()
    {
        gameObject.tag = "end";
    }
    
    void Update()
    {
       if (!show.ongoing() && !flowers.Outro())
       {
            if (this.transform.childCount == 0)
                gameObject.tag = "empty";
            
            else if (this.transform.GetChild(0).tag == "weedFinish")
                gameObject.tag = "evil";
            
            else if (this.transform.GetChild(0).tag == "flowerFinish")
                gameObject.tag = "joint";
       }           
    }
}
