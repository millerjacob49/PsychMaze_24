using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTrigger : MonoBehaviour
{
    public Timer Timer;
    GameObject sceneManagerObject;                      //***********************************
    GameObject infoManagerObject;
    MySceneManager sceneManagerScript;
    InfoManager myInfoManagerScript;
    TimeOutRetriever timeOutScript;
    float timeOut;
    // Start is called before the first frame update
    void Start()
    {
        Timer = GetComponent<Timer>();
        Timer.setStartTime();

        if (sceneManagerObject == null)
        {
            sceneManagerObject = GameObject.Find("MySceneManager");
            sceneManagerScript = sceneManagerObject.GetComponent<MySceneManager>();
            timeOutScript = sceneManagerObject.GetComponent<TimeOutRetriever>();
            timeOut = timeOutScript.GetTimeOutValue();
        }

        if (infoManagerObject == null)
        {
            infoManagerObject = GameObject.Find("MySceneManager");
            myInfoManagerScript = infoManagerObject.GetComponent<InfoManager>();
        }
    }

    void FixedUpdate()
    {
        if (sceneManagerScript.ready == true)
        {
            Timer.setEndTime();
            Debug.Log("Timer: " + (timeOut - Timer.getTotalTime()));
            if (((timeOut - Timer.getTotalTime()) <= 0))
            {
                
                HandleCollision();
                sceneManagerScript.timeExpired = true;
                sceneManagerScript.ready = false;
            }
        }
    }

    void OnTriggerEnter(Collider other) //seems to call twice upon collision but timer is accurate.
    {
        Debug.Log("Final: ");
        HandleCollision();

    }

    void HandleCollision()
    {
        Timer.setEndTime();
        Debug.Log(Timer.getTotalTime());
        Debug.Log("Resetting GameScape");
        myInfoManagerScript.ManageCollision();
        sceneManagerScript.ManageCollision();
    }

}
