using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOutDisplay : MonoBehaviour
{
    GameObject sceneMgmtObject;
    MySceneManager sceneMgmt;
    public GameObject myText;
    // Start is called before the first frame update
    void Start()
    {
        sceneMgmtObject = GameObject.Find("MySceneManager");
        sceneMgmt = sceneMgmtObject.GetComponent<MySceneManager>();

        if (sceneMgmt.timeExpired)
        {
            myText.SetActive(true);
        }
        else
        {
            myText.SetActive(false);
        }
    }

    
}
