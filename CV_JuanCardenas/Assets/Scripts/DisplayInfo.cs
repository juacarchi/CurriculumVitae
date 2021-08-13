using UnityEngine;
using UnityEngine.UI;
public class DisplayInfo : MonoBehaviour
{
    public static DisplayInfo instance;
    public GameObject panelDP;
    public GameObject panelFO;
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
    public void ShowMessage(string panel)
    {
        if (panel == "DP")
        {
            panelDP.SetActive(true);
            UIManager.instance.SetPanelActive(panelDP);
        }
        else if(panel == "FO")
        {
            panelFO.SetActive(true);
            UIManager.instance.SetPanelActive(panelFO);
        }
        
        var foundTexts = Resources.FindObjectsOfTypeAll<LanguageText>();
        foreach (var item in foundTexts)
        {
            if (item.enabled)
            {
                item.SetText(GameManager.instance.GetLanguage());
            }

        }
    }
}
