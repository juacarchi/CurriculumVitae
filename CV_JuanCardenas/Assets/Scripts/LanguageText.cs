using UnityEngine;
using UnityEngine.UI;
public class LanguageText : MonoBehaviour
{
    [TextArea] public string spanishText;
    [TextArea] public string englishText;
    string[] arrayText;
    private void Awake()
    {
        arrayText = new string[2];
        arrayText[0] = spanishText;
        arrayText[1] = englishText;
    }
    private void Start()
    {
        SetText(GameManager.instance.GetLanguage());
        if (this.GetComponent<TextMesh>() != null)
        {
            SetTextMesh(GameManager.instance.GetLanguage());
        }
        
    }
    public void SetText(int i)
    {
        if (this.gameObject == isActiveAndEnabled)
        {
            if (GetComponent<Text>() != null)
            {
                Text originalText = this.GetComponent<Text>();
                originalText.text = arrayText[i];
            }
            
        }
    }
    public void SetTextMesh(int i)
    {
        if (this.gameObject == isActiveAndEnabled)
        {
            TextMesh originalText = this.GetComponent<TextMesh>();
            originalText.text = arrayText[i];
        }
    }

}
