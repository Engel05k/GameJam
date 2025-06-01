using System.Collections.Generic;
using UnityEngine.Events;

[System.Serializable]
public class MusicManager
{
    public string name;
    public List<int> sequence;
    public UnityEvent onSequenceComplete;
}