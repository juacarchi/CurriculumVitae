using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int language; // 0 Españo ; 1 ingles;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetLanguage(int language)
    {
        this.language = language;
        var foundTexts = Resources.FindObjectsOfTypeAll<LanguageText>();
        foreach (var item in foundTexts)
        {
            if (item.enabled)
            {
                item.SetTextMesh(language);
            }

        }
    }
    public int GetLanguage()
    {
        return language;
    }

}
