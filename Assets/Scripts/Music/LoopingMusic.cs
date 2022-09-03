using UnityEngine;
using NSMB.Utils;
using ExitGames.Client.Photon;

public class LoopingMusic : MonoBehaviour {

    private bool _fastMusic;
    public bool FastMusic {
        set {
           if (_fastMusic ^ value) {
                audioSource.time *= value ? 0.8f : 1.25f;
                bool spec = true;
                if (!spec)
                    audioSource.clip = value && currentSong.fastClip ? currentSong.fastClip : currentSong.clip;
                else
                    audioSource.clip = value && currentSong.fastClip ? currentSong.spectFastClip : currentSong.spectClip;
                
                audioSource.Play();

                if (currentSong.loopEndSample != -1 && audioSource.time >= currentSong.loopEndSample)
                    audioSource.time = currentSong.loopStartSample + (audioSource.time - currentSong.loopEndSample);
            }

            _fastMusic = value;
        }
        get => _fastMusic && currentSong.fastClip;
    }

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private MusicData currentSong;

    public void Start() {
        if (currentSong)
            Play(currentSong);
    }

    public void Play(MusicData song) {
        currentSong = song;
        audioSource.loop = true;
        audioSource.clip = _fastMusic && song.fastClip ? song.fastClip : song.clip;
        audioSource.time = 0;
        audioSource.Play();
    }
    public void Stop() {
        audioSource.Stop();
    }

    public void Update() {
        if (!audioSource.isPlaying)
            return;

        float end = currentSong.loopEndSample * (FastMusic ? 0.8f : 1f);
        if (currentSong.loopEndSample != -1 && audioSource.time >= end)
            audioSource.time = (currentSong.loopStartSample * (FastMusic ? 0.8f : 1f)) + (audioSource.time - end);
    }
}