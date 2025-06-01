using System.Collections.Generic;
using System;
using UnityEngine;

public class DialogueData1 : MonoBehaviour
{
    [Serializable]
    public class DialogueDay
    {
        public int dia;
        public List<DialogueScene> scene;
    }

    [Serializable]
    public class DialogueScene
    {
        public int scene;
        [TextArea(3, 10)]
        public string text;
    }
}
