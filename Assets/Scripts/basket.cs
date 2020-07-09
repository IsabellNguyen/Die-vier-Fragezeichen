using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket : MonoBehaviour
{
    public GameObject hand;
    public GameObject child;
    public Transform parent;
    public won won;
   
    private int outroState = 0;

    void Start()
    {
        won = won.GetComponent<won>();
    }
    void Update()
    {
       // print(this.transform.childCount);
        if (child.transform.childCount > 4 &&outroState == 0)
        {
            hand.gameObject.tag = "end";
            Outro();

        }
          
    }

    public bool Outro()
    {
        if ( outroState == 0 && child.transform.childCount > 4)
        {
            
            child.transform.SetParent(parent);
            child.transform.localPosition = new Vector3(0, -0.5f, 0);
            child.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            child.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 45));
            won.outroGo = true;
            outroState++;
            return true;
            
        }
        else
            return false;
    }

}
