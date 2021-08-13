using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New PersonalData", menuName = "PersonalData")]

public class PersonalData : ScriptableObject
{
    public string idioma;
    public string title;
    [TextArea]
    public string textContact;
    [TextArea]
    public string textContact2;
    [TextArea]
    public string personalCompetences;
    [TextArea]
    public string personalCompetences2;
    [TextArea]
    public string textSpain;
    [TextArea]
    public string textEnglish;
    [TextArea]
    public string textOthers;
}
