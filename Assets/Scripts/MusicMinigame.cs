using System.Collections.Generic;
using Unity.VisualScripting;

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

    private LogicaNotas[] notasPantalla;

    private void Start()
    {

        audioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        notasPantalla = FindObjectsOfType<LogicaNotas>();

        if (Input.GetKeyDown(key0))
        {
            PlayNote(0);
            CheckNote();
        }
        if (Input.GetKeyDown(key1))
        {
            PlayNote(1);
            CheckNote();
        }
        if (Input.GetKeyDown(key2))
        {
            PlayNote(2);
            CheckNote();
        }
        if (Input.GetKeyDown(key3))
        {
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
    private void CheckPresion(int idNota)
    {
        foreach(var nota in notasPantalla)
        {
            Debug.Log("Nota Acertada");
            PlayNote(idNota);
            Destroy(nota.gameObject);
            return;
        }
        Debug.Log("Fallaste nota");
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


