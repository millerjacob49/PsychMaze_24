using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class DebriefRetriever : MonoBehaviour
{

    public string fileName = Application.streamingAssetsPath + "/Input/DebriefText.txt";
    public TextMeshProUGUI DebriefTextObject;

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(fileName))
        {
            DebriefTextObject.text = File.ReadAllText(fileName);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
