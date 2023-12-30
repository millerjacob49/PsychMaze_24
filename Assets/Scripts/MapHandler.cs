using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHandler : MonoBehaviour
{
    GameObject sceneMgmtObject;
    InfoManager infoMgmt;
    MySceneManager sceneMgmt;
    string curTrialType;
    string dropDownSelection;
    GameObject miniMap;
    GameObject fullMap;
    // Start is called before the first frame update
    void Start()
    {
        sceneMgmtObject = GameObject.Find("MySceneManager");
        sceneMgmt = sceneMgmtObject.GetComponent<MySceneManager>();
        infoMgmt = sceneMgmt.GetComponent<InfoManager>();

        miniMap = GameObject.Find("MiniMapImage");
        fullMap = GameObject.Find("FullMapImage");
        HandleMaps();
    }

    public void HandleMaps()
    {
        dropDownSelection = infoMgmt.GetDropDownSelection();
        curTrialType = sceneMgmt.GetCurTrialType();

        miniMap.SetActive(false);
        fullMap.SetActive(false);

        if (curTrialType == "experiment")
        {

        }
        else if (dropDownSelection == "NoMap")
        {

        }
        else if (dropDownSelection == "MiniMap")
        {
            miniMap.SetActive(true);

        }
        else
        {
            fullMap.SetActive(true);
        }
    }
}
