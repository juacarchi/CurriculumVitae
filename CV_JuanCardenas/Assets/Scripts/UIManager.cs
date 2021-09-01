using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public SpriteRenderer btn_english;
    public SpriteRenderer btn_spanish;

    GameObject panelActive;
    public static UIManager instance;
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
    public void SetPanelActive(GameObject panelActive)
    {
        this.panelActive = panelActive;
    }
 public void ClosePanel()
    {
        panelActive.SetActive(false);
        GameManager.instance.SetCanMove(true);
    }
}
