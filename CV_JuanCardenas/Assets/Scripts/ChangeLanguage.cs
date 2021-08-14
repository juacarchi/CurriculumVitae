using UnityEngine;

public class ChangeLanguage : MonoBehaviour
{
    [SerializeField] bool spanish;
    [SerializeField] bool english;
    public void SetLanguage()
    {
        if (spanish)
        {
            if (GameManager.instance.GetLanguage() != 0)
            {
                GameManager.instance.SetLanguage(0);
                Sprite spriteSpanish = UIManager.instance.btn_spanish.sprite;
                Sprite spriteEnglish = UIManager.instance.btn_english.sprite;
                UIManager.instance.btn_spanish.sprite = spriteEnglish;
                UIManager.instance.btn_english.sprite = spriteSpanish;
            }


        }
        else if (english)
        {
            if (GameManager.instance.GetLanguage() != 1)
            {
                GameManager.instance.SetLanguage(1);
                Sprite spriteSpanish = UIManager.instance.btn_spanish.sprite;
                Sprite spriteEnglish = UIManager.instance.btn_english.sprite;
                UIManager.instance.btn_spanish.sprite = spriteEnglish;
                UIManager.instance.btn_english.sprite = spriteSpanish;
            }
                
        }
    }
}
