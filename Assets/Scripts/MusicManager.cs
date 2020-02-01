using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public AudioClip musicPlay;
    public AudioClip musicWin;
    public AudioClip musicLose;
    [Inject] private EventManager _eventManager;

    // Start is called before the first frame update
    void Start()
    {
        _eventManager.OnWin += PlayMusicWin;
        _eventManager.OnDefeat += PlayMusicLose;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PlayMusicWin()
    {
        audioSource.clip = musicWin;
        audioSource.Play();
    }
    void PlayMusicLose()
    {
        audioSource.clip = musicLose;
        audioSource.Play();
    }
}
