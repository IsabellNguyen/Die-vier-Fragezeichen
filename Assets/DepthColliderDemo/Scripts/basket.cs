using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket : MonoBehaviour
{
    public Transform child;
    // Start is called before the first frame update
    void Update()
    {
        if (child.childCount > 4)
        {
            print("Well done!");
            
        }
       
    }



}
