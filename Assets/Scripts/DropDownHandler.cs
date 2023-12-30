using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownHandler : MonoBehaviour
{
    string selection = "FullMap";
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void OnValueChanged(int index)
    {
        switch (index)
        {
            case 0:  selection = "FullMap"; break;
            case 1:  selection = "MiniMap"; break;
            case 2: selection = "NoMap"; break;
        }

        Debug.Log(selection);
    }

    public string GetDropDownSelection()
    {
        return selection;   
    }

    
}
