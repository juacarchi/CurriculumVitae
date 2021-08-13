using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLanguage : MonoBehaviour
{
    [SerializeField] bool spanish;
    [SerializeField] bool english;
    public void SetLanguage()
    {
        if (spanish)
        {
            GameManager.instance.SetLanguage(0);
        }
        else if (english)
        {
            GameManager.instance.SetLanguage(1);
        }
    }
}
