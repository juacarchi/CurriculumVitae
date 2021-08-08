using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInfo : MonoBehaviour
{
    public InfoCV infoCV;

    public void ShowMessage()
    {
        Debug.Log(infoCV.name);
    }
}
