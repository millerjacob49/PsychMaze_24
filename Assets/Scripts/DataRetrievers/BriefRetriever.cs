using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class BriefRetriever : MonoBehaviour
{

    string briefText;
    public string fileName = Application.streamingAssetsPath + "/Input/BriefText.txt";
    public TextMeshProUGUI BriefTextObject;

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(fileName))
        {
            BriefTextObject.text = File.ReadAllText(fileName);
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
