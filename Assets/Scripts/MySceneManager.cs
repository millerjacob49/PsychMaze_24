
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[System.Serializable]
public class MySceneManager : MonoBehaviour
{
    public MySceneManager Instance;
    public int curTrialCount = 0;
    public int maxTrialCount = 10;
    public float maxTrialTime;  //this is a timeout value.
    string curTrialType = "practice"; //this will either be "practice"(default) or "experiment"
    Scene gameScene;
    public bool ready;
    MapHandler mapHandler;
    public bool timeExpired = false;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        maxTrialTime = GetComponent<TimeOutRetriever>().GetTimeOutValue();
        maxTrialCount = GetComponent<TrialNumberRetriever>().GetMaxTrialCount();
        
    }

    void Start ()
    {
        maxTrialCount = GetComponent<TrialNumberRetriever>().GetMaxTrialCount();
    }

    public void ManageCollision()
    {
        if (IsEndOfSession())
        {
            LoadDebriefScene();
        }
        else
        {
            IncrementTrialCount();      //This only increments if "practice" run
            LoadBriefOnCollision();
            Debug.Log(curTrialCount);
        }
    }

    public void LoadMainBriefScene()
    {
        SceneManager.LoadSceneAsync("briefTest");
    }

    public void LoadGameScene()
    {
        //GetTrialType() -- "practice" or "experiment" .... separate game scenes for practice/experiment?
        gameScene = SceneManager.GetSceneByName("game");
        if (gameScene.isLoaded)
        {
            Debug.Log("Game scene already loaded. Action cancelled.");

        }
        else
        {
            var scene = SceneManager.LoadSceneAsync("game");
            ready = true;
            timeExpired = false;
        }
    }

    public void LoadBriefOnCollision()
    {
        FlipTrialType();
        if(curTrialType == "practice")
        {
            SceneManager.LoadSceneAsync("briefTest");       //We'll want to create a separate brief scene for this. (PRACTICE RUN)
            Debug.Log(curTrialType);
        }
        else
        {
            SceneManager.LoadSceneAsync("brief_pre_experimental");       //We'll want to create a separate brief scene for this. (EXPERIMENT RUN)
            Debug.Log(curTrialType);
        }

    }

    public void LoadDebriefScene()
    {
        SceneManager.LoadSceneAsync("debrief");
    }

    public void FlipTrialType()
    {
        if(curTrialType == "practice")
        {
            curTrialType = "experiment";
        }
        else
        {
            curTrialType = "practice";
        }
    }

    public string GetCurTrialType()
    {
        return curTrialType;
    }

    public int GetCurTrialNumber()
    {
        return curTrialCount;
    }

    public void IncrementTrialCount()
    {
        if (curTrialType == "practice")
        {
            curTrialCount += 1;
            Debug.Log("TrialCount Incremented");
        }
    }

    public bool IsEndOfSession()
    {
        if ((curTrialCount >= maxTrialCount) && (curTrialType == "experiment"))
        {
            Debug.Log("Ending and moving to debrief scene");
            Debug.Log(curTrialCount + ">=" + maxTrialCount);
            return true;
            
        }
        else
        {
            return false;
        }
    }

    public bool IsGameSceneLoaded()
    {
        gameScene = SceneManager.GetSceneByName("game");
        if (gameScene.isLoaded)
        {
            return true;

        }
        else
        {
            return false;
        }
    }

    public bool IsMenuSceneLoaded()
    {
        Scene menuScene = SceneManager.GetSceneByName("menu");
        if (menuScene.isLoaded)
        {
            return true;

        }
        else
        {
            return false;
        }
    }

  


}
