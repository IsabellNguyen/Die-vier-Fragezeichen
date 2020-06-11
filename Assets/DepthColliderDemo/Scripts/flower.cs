using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower : MonoBehaviour
{

    public KinectWrapper.NuiSkeletonPositionIndex TrackedJoint = KinectWrapper.NuiSkeletonPositionIndex.HandRight;

    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "flower";
    }

    // Update is called once per frame
    void Update()
    {
        KinectManager manager = KinectManager.Instance;
        if (manager && manager.IsInitialized())
        {
            int iJointIndex = (int)TrackedJoint;
            if (manager.IsUserDetected())
            {
                uint userId = manager.GetPlayer1ID();

                if (manager.IsJointTracked(userId, iJointIndex))
                {
                    
                    if (isBeingHeld)
                    {
                        print("ajsdfkjaslkdfjaöklsdjfaöksldjfaöksdjfaö");
                        Vector3 posJoint = manager.GetRawSkeletonJointPos(userId, iJointIndex);
                        gameObject.transform.position = posJoint;
                    }
                    
                }
            }
        }
          
       
            
        
    }

   

  

    void OnTriggerEnter2D(Collider2D col)
    {
        print("Ta");
        //Check to see if the tag on the collider is equal to Enemy
       

            print("Is triggered");
            isBeingHeld = true;
            
            gameObject.GetComponent<AudioSource>().Play();

        if (col.gameObject.CompareTag("basket"))
        {
            isBeingHeld=!isBeingHeld;
            Debug.Log("Triggered by basket");
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

}
