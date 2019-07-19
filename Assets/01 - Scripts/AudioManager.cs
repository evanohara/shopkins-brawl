using System;
using UnityEngine;

[System.Serializable]
public class AudioManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private AudioSource _soundSource;
    [SerializeField]
    private AudioSource _musicSource1;
    [SerializeField]
    private AudioSource _musicSource2;
#pragma warning restore 0649

    public bool MusicEnabled { get; set; } = true;
    public bool SoundEnabled { get; set; } = true;
    private AudioLibrary audioLibrary;

    private AudioSource currentMusicSource;

    public static AudioManager instance = null;

    public AudioLibrary AudioLibrary { get => audioLibrary; set => audioLibrary = value; }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        if (currentMusicSource == null)
            currentMusicSource = _musicSource1;

        if (AudioLibrary == null)
        {
            AudioLibrary = GetComponent<AudioLibrary>();
        }
    }

    public void ToggleMusic()
    {
        if (MusicEnabled)
        {
            _musicSource1.volume = 0f;
            _musicSource2.volume = 0f;
        }
        else
        {
            _musicSource1.volume = 1f;
            _musicSource2.volume = 1f;
        }
        MusicEnabled = !MusicEnabled;
    }

    public void ToggleSound()
    {
        if (SoundEnabled)
            _soundSource.volume = 0f;
        else
            _soundSource.volume = 1f;
        SoundEnabled = !SoundEnabled;
    }

    public void Play(AudioClip clip)
    {
        _soundSource.PlayOneShot(clip);
    }

    public void PlayFromLibrary(AudioLibrary.SoundTag tag)
    {
        if (AudioLibrary == null) Debug.Log("yea its null");
        Play(AudioLibrary.GetClip(tag));
    }

    public void PauseMusic()
    {
        currentMusicSource.Pause();
    }

    public void ResumeMusic()
    {
        currentMusicSource.Play();
    }

    public void PlayMusicWithLead(AudioClip lead, AudioClip mainLoop)
    {
        if (currentMusicSource == _musicSource1)
        {
            Debug.Log(name + ": Current Source is 1, loading lead into 2.");
            _musicSource2.clip = lead;
            _musicSource1.clip = mainLoop;
            StitchAudio(_musicSource2, _musicSource1);
        }
        else
        {
            Debug.Log(name + ": Current Source is 2, loading lead into 1.");
            _musicSource1.clip = lead;
            _musicSource2.clip = mainLoop;
            StitchAudio(_musicSource1, _musicSource2);
        }
    }

    internal void StitchAudio(AudioSource leadSource, AudioSource mainSource)
    {
        double leadDuration = CalculateClipDuration(leadSource);
        leadSource.PlayScheduled(AudioSettings.dspTime + 0.1);
        mainSource.PlayScheduled(AudioSettings.dspTime + 0.1 + CalculateClipDuration(leadSource));
        mainSource.loop = true;
    }

    internal double CalculateClipDuration(AudioSource source)
    {
        return (double)source.clip.samples / source.clip.frequency;
    }

}
