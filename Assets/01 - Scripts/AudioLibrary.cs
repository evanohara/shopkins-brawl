//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLibrary : MonoBehaviour
{
    public List<AudioClip> _generalSFX;
    public List<AudioClip> _music;

    public AudioClip GetClip(SoundTag sound)
    {
        return _generalSFX[(int)sound];
    }
    public AudioClip GetClip(MusicTag sound)
    {
        return _generalSFX[(int)sound];
    }
    public enum SoundTag { Hit, Select, MenuMove, Buzz }
    public enum MusicTag { ChefClubIntro, ChefClubMain }

}
