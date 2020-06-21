using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickW : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("You have clicked Wolf!");
    }

        void OnMouseOver()
    {
        //Debug.Log("Mouse is over Wolf.");
        transform.localScale = new Vector3(1.2F, 1.2F, 1.2F);
    }

    void OnMouseExit()
    {
        //Debug.Log("Mouse is no longer on Wolf.");
        transform.localScale = new Vector3(1F, 1F, 1F);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
