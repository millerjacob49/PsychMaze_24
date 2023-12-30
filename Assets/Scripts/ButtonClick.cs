using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{

    public Button startButton;
    public GameObject sceneManagerObject;
    public MySceneManager mySceneScript;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick); 
        mySceneScript = sceneManagerObject.GetComponent<MySceneManager>();


    }

    void TaskOnClick()              //this function will ALWAYS load the brief
    {
        Debug.Log("Button Clicked");
        mySceneScript.LoadMainBriefScene();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
