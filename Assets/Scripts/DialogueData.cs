using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueScene
{
    public int scene;
    [TextArea(3, 6)]
    public string text;
}

[System.Serializable]
public class DialogueDay
{
    public int dia;
    public List<DialogueScene> scene;
}

