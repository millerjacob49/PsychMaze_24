using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public float startTime = 0f;
    public float endTime = 0f;
    public TextMeshProUGUI myText;

    // Start is called before the first frame update
    void Start()
    {
        setStartTime();
    }

    // Update is called once per frame - FixedUpdate functions differently
    void FixedUpdate()
    {
        float tempEndTime = Time.time;
        //Debug.Log(tempEndTime - getStartTime());
        if (myText != null)
        {
            myText.text = (tempEndTime - startTime).ToString();

        }
    }

    public void test()
    {
        Debug.Log("Timer test is being properly called.");
    }

    public float setStartTime()
    {
        startTime = Time.time;
        return startTime;
    }

    public float setEndTime()
    {
        endTime = Time.time;
        return endTime;
    }

    public float getStartTime()
    {
        return startTime;
    }

    public float getEndTime()
    {

        return endTime;
    }

    public float getTotalTime()
    {
        return endTime-startTime;
    }

    public void resetAllTime()
    {
        startTime = 0;
        endTime = 0;
    }


}
