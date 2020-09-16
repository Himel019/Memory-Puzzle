using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMusicController : MonoBehaviour
{
    private PuzzleGameSaver puzzleGameSaver;
    private AudioSource audioSource;

    private float musicVolume;

    void Awake() {
        puzzleGameSaver = GameObject.Find("Puzzle Game Saver").GetComponent<PuzzleGameSaver>();
        GetAudioSource();
    }

    // Start is called before the first frame update
    void Start()
    {
        musicVolume = puzzleGameSaver.musicVolume;
        PlayOrTurnOnMusic(musicVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetAudioSource() {
        audioSource = GetComponent<AudioSource>();
    }

    public void SetMusicVolume(float volume) {
        PlayOrTurnOnMusic(volume);
    }

    private void PlayOrTurnOnMusic(float volume) {
        musicVolume = volume;
        audioSource.volume = musicVolume;

        if(audioSource.volume > 0) {
            if(!audioSource.isPlaying) {
                audioSource.Play();
            }

            puzzleGameSaver.musicVolume = musicVolume;
            puzzleGameSaver.SaveGameData();
        } else if(audioSource.volume == 0) {
            if(audioSource.isPlaying) {
                audioSource.Stop();
            }

            puzzleGameSaver.musicVolume = musicVolume;
            puzzleGameSaver.SaveGameData();
        }
    }

    public float GetMusicVolume() {
        return this.musicVolume;
    }
}
