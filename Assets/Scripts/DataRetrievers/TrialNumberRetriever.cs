using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TrialNumberRetriever : MonoBehaviour
{

    int maxTrialCount = 0;
    public string fileName = Application.streamingAssetsPath + "/Input/MaxTrialCount.txt";
    // Start is called before the first frame update
    void Awake ()
    {
        if (File.Exists(fileName))
        {
            string text = File.ReadAllText(fileName);
            if(int.TryParse(text, out int value))
            {
                maxTrialCount = value;
            }
        }
        Debug.Log("MaxTrialCount = " + maxTrialCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetMaxTrialCount()
    {
        return maxTrialCount;
    }

}
