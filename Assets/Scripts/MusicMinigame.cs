using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class MusicMinigame : MonoBehaviour
{

    [Header("Key Bindings")]
    [SerializeField] private KeyCode key0 = KeyCode.W;
    [SerializeField] private KeyCode key1 = KeyCode.A;
    [SerializeField] private KeyCode key2 = KeyCode.S;
    [SerializeField] private KeyCode key3 = KeyCode.D;

    [Header("SoundEffects")]
    [SerializeField] private AudioClip[] sounds;
    private AudioSource audioSource;

    [Header("Songs")]
    [SerializeField] List<MusicManager> allSongs = new List<MusicManager>();
    private List<int> sequence = new List<int>();
    [SerializeField] private int maxAmountKeys = 5;

    private void Start()
    {

        audioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(key0))
        {
            Debug.Log("Key 0 pressed");
            PlayNote(0);
            CheckNote();
        }
        if (Input.GetKeyDown(key1))
        {
            Debug.Log("Key 1 pressed");
            PlayNote(1);
            CheckNote();
        }
        if (Input.GetKeyDown(key2))
        {
            Debug.Log("Key 2 pressed");
            PlayNote(2);
            CheckNote();
        }
        if (Input.GetKeyDown(key3))
        {
            Debug.Log("Key 3 pressed");
            PlayNote(3);
            CheckNote();
        }
    }

    private void PlayNote(int note)
    {

        if (note < 0 || note >= sounds.Length) 
        {
            return;
        }
    
        audioSource.PlayOneShot(sounds[note]);
        sequence.Add(note);


    }

    private void CheckNote()
    {

        if (sequence.Count > maxAmountKeys)
        {
            sequence.RemoveAt(0);
        }

        foreach (var song in allSongs)
        {
            if (CheckSequence(song.sequence))
            {
                Debug.Log("Tocaste la canción: " + song.name);
                song.onSequenceComplete.Invoke();
                sequence.Clear();
                break;
            }
        }

    }

    private bool CheckSequence(List<int> sequenceToCheck)
    {
        if (sequence.Count != sequenceToCheck.Count)
        {
            return false;
        }
        for (int i = 0; i < sequence.Count; i++)
        {
            if (sequence[i] != sequenceToCheck[i])
            {
                return false;
            }
        }
        return true;
    }
}


