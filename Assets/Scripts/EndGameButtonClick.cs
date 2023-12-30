using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameButtonClick : MonoBehaviour
{

    public Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);


    }

    void TaskOnClick()              //this function will ALWAYS load the brief
    {
        Debug.Log("Application.Quit()");
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {

    }
}