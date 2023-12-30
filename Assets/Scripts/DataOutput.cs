using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataOutput : MonoBehaviour
{
    string sessionName = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateLogFile(string subjectID)
    {
        //SettingsMenu settings = GetComponent<SettingsMenu>();
        //TrialManager trialManager = GetComponent<TrialManager>();
        sessionName = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"); //This will be named by subject ID instead
        //sessionName = Application.persistentDataPath + sessionName + ".csv";    //Can I find a better place to write to?
        sessionName = "../PsychMaze Project/Assets/AuxFiles/Output/" + sessionName + ".csv";
    }

    public bool CheckFile(string subjectID)
    {
        //DropDownManager DDMaps = DDMapMgmt.GetComponent<DropDownManager>();
        //miniMapSet = DDMaps.MapValue;

        sessionName = subjectID + "." + /*MiniMapConvert(miniMapSet) +*/ ".csv";

        if (File.Exists(sessionName))
        {
            return true;
        }
        else
        {
            //SubjectInputID = subjectID;
            return false;
        }

    }
}
