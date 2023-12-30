using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TimeOutRetriever : MonoBehaviour
{
    float timeOutValue = 0;
    public string fileName = Application.streamingAssetsPath + "/Input/TimeOutValue.txt";
    // Start is called before the first frame update
    void Awake()
    {
        if (File.Exists(fileName))
        {
            string text = File.ReadAllText(fileName);
            if (float.TryParse(text, out float value))
            {
                timeOutValue = value;
            }
        }
        Debug.Log("TimeOutValue = " + timeOutValue);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GetTimeOutValue()
    {
        return timeOutValue;
    }
}
