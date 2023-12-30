using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class InfoManager : MonoBehaviour
{
    public GameObject player;
    public string sessionFileNamePos;
    public string sessionFileNameTime;
    public string IDText;
    string mapSelection = "FullMap";
    public List<float> xPos;
    public List<float> yPos;
    public List<int> timeInterval;
    int fixedIncrement = 0;
    MySceneManager sceneMgmt;
    public GameObject timerRefObject;
    

    // Start is called before the first frame update
    void Start()
    {
        sceneMgmt = GetComponent<MySceneManager>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(sceneMgmt.IsGameSceneLoaded() && timerRefObject == null)
        {
            timerRefObject = GameObject.Find("Plane_EndTrigger");       //this will constantly pull errors until the gamescene loads
            Debug.Log("Reference found.");
        }
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            player = GameObject.Find("PlayerCapsule");
        }
        else if (sceneMgmt.IsGameSceneLoaded())                 //Fixed timer related to position tracking
        { 
            if ((fixedIncrement % 25 == 0) || ((fixedIncrement == 0) || (fixedIncrement % 100 == 0)))
            {
                StorePositionData();        //simply adds xy_pos to lists
                //LogPositionData();
            }
        fixedIncrement += 1;
        }

    }

    public void ManageCollision()
    {
        WritePositionData();
        WriteTimeData();
        ResetPositionData();
    }

    public void SetDropDownSelection(int index)
    {
        switch (index)
        {
            case 0: mapSelection = "FullMap"; break;
            case 1: mapSelection = "MiniMap"; break;
            case 2: mapSelection = "NoMap"; break;
        }

        Debug.Log(mapSelection);
    }

    public string GetDropDownSelection()
    {
        return mapSelection;
    }

    public void GatherFileData(string subjectid)
    {
        IDText = subjectid;
        Debug.Log(IDText+ ", " + mapSelection);
        
    }

    public void CreateTimeFile()
    {
        //pull subject ID from textbox
        sessionFileNameTime = "../PsychMaze_V2.0/Assets/AuxFiles/Output/" + IDText + mapSelection + "_TIME.csv";
        //sessionFileNameTime = Application.persistentDataPath + sessionFileNameTime + ".csv";
        File.AppendAllText(sessionFileNameTime, "Header \n" + ", Condition: ," + /**/ mapSelection /**/ + "\n" + ",SubjectNumber: " + IDText + "\n" + ",Time Started: " + System.DateTime.Now.ToString("MM-dd_HH-mm-ss") + "\n");
        File.AppendAllText(sessionFileNameTime, "***** \n");
        string settingsData = "Trial, P/A, Time" + "\n";
        File.AppendAllText(sessionFileNameTime, settingsData);
        Debug.Log("created file");

    }

    public void WriteTimeData()
    {
        int trialNumber = sceneMgmt.GetCurTrialNumber();
        string trialType = sceneMgmt.GetCurTrialType();

        if (trialType == "practice")             //increment number if practice to compensate for other calculations
        {
            trialNumber += 1;
        }

        File.AppendAllText(sessionFileNameTime, trialNumber + ", " + trialType + ", " + timerRefObject.GetComponent<Timer>().getTotalTime() + "\n");
    }

    public void CreatePositionFile()
    {
        sessionFileNamePos = "../PsychMaze_V2.0/Assets/AuxFiles/Output/" + IDText + mapSelection + "_POS.csv";
        File.AppendAllText(sessionFileNamePos, "Header \n" + ", Condition: ," + /**/ mapSelection /**/ + "\n" + ",SubjectNumber: " + IDText + "\n" + ",Time Started: " + System.DateTime.Now.ToString("MM-dd_HH-mm-ss") + "\n");
        File.AppendAllText(sessionFileNamePos, "***** \n");
    }

    public void LogPositionData()
    {
        Debug.Log("InfoManager dumping position data");
        Debug.Log(player.transform.position.x);
    }

    public void StorePositionData()
    {
        timeInterval.Add((fixedIncrement * 20));
        xPos.Add(player.transform.position.x);
        yPos.Add(player.transform.position.z);

        //will want to dump these once plane trigger
    }

    public void WritePositionData()
    {
        int trialNumber = sceneMgmt.GetCurTrialNumber();
        string trialType = sceneMgmt.GetCurTrialType();
        if(trialType == "practice")             //increment number if practice to compensate for other calculations
        {
            trialNumber += 1;
        }

        for (int i = 0; i < timeInterval.Count; i++)
        {
            File.AppendAllText(sessionFileNamePos, trialNumber + ", " + trialType + ", " + timeInterval[i] + "," + xPos[i] + "," + yPos[i] + "\n");
        }

    }

    public void ResetPositionData()
    {
        fixedIncrement = 0;
        timeInterval.Clear();
        xPos.Clear();
        yPos.Clear();
    }


}
