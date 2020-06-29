using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickRK : MonoBehaviour
{
    GameObject LichtRK;
    //LichtRK = GameObject.Find("LichtRK");
    void OnMouseDown()
    {
        Debug.Log("You have clicked Rotkäppchen!");
        //Scene.ChangeToScene(1);
        SceneManager.LoadScene(1);
    }

    void OnMouseOver()
    {
        //Debug.Log("Mouse is over Rotkäppchen.");
        transform.localScale = new Vector3(1.1F, 1.1F, 1.1F);
        LichtRK.SetActive(true);
    }

    void OnMouseExit()
    {
        //Debug.Log("Mouse is no longer on Rotkäppchen.");
        transform.localScale = new Vector3(1F, 1F, 1F);
        LichtRK.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        LichtRK = GameObject.Find("LichtRK");
        LichtRK.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject.Find("LichtRK");
        //LichtRK = GameObject.Find("LichtRK");
    }
}
