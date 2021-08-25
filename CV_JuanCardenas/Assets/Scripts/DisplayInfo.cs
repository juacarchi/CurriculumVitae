using UnityEngine;
using UnityEngine.UI;
public class DisplayInfo : MonoBehaviour
{
    public static DisplayInfo instance;
    public GameObject panelDP;
    public GameObject panelFO;
    public GameObject panelCO;
    public GameObject panelEX;
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
        else if (panel == "CO")
        {
            panelCO.SetActive(true);
            UIManager.instance.SetPanelActive(panelCO);
        }
        else if (panel == "EX")
        {
            panelEX.SetActive(true);
            UIManager.instance.SetPanelActive(panelEX);
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
