using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] tuberias;
    public static GameManager instance;
    int actualTuberia;
    int language; // 0 Españo ; 1 ingles;
    bool canMove;

    

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

    public void ActiveTuberia()
    {
        actualTuberia++;
        Vector2 posTuberiaSiguiente = tuberias[actualTuberia].transform.position;
        player.transform.position = posTuberiaSiguiente;
        actualTuberia++;
    }
    public bool GetCanMove()
    {
        return canMove;
    }
    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
    }
}
