using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Header("Sound BackGround")] 
    [SerializeField] private AudioSource _audioBackgorund;
    [SerializeField] private List<DictionSound> _soundBackgrounds = new();
    [Header("Sound Sound SFX")]
    [SerializeField] private AudioSource _audioSFX;
    [SerializeField] private List<DictionSound> _soundsSFXs = new();


    private void Start()
    {
        PlayAudioBackGround(Sound.background);
    }


    public void ToggleSoundBackGround()
    {
        if (_audioBackgorund.isPlaying)
        {
            _audioBackgorund.Stop();
            return;
        }
        _audioBackgorund.Play();
    }

    public void ToggleSoundSFX()
    {
        bool checkEnable = _audioSFX.enabled;
        _audioSFX.enabled = !checkEnable;
    }


    public void PlayAudioSFX(Sound name)
    {
        var audioclip = _soundsSFXs.FirstOrDefault(x => x.nameSound == name);
        if(audioclip == null) return;
        _audioSFX.PlayOneShot(audioclip.audiosource);
    }

    public void PlayAudioBackGround(Sound name)
    {
        // var audioclip = _soundsSFXs.FirstOrDefault(x => x.nameSound == name);
        // if(audioclip == null) return;
        // _audioSFX.clip = audioclip.audiosource;
         _audioSFX.Play();
        
    }
    
}

[Serializable]
public class DictionSound
{
    public Sound nameSound;
    public AudioClip audiosource;
}
