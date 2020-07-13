using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MyMessageListener : MonoBehaviour
{
 

    // Use this for initialization
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {

        

    }
    // Invoked when a line of data is received from the serial device.

    void OnMessageArrived(string msg) //void OnMessageArrived(string msg)
    {
     Debug.Log("Arrived: " + msg);

        if (msg == "Rotkaeppchen erkannt")
        {
            SceneManager.LoadScene(sceneName: "Blumenpflücken");
        }

    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}
 