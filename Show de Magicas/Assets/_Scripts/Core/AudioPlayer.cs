using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _bgmAudio;
    [SerializeField] private AudioSource _sfxAudio;

    public static AudioPlayer Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayBGM(AudioClip musicAudioClip)
    {
        _bgmAudio.clip = musicAudioClip;
        _bgmAudio.Play();
    }

    public void StopBGM()
    {
        _bgmAudio.Stop();
    }

    public void PlaySFX(AudioClip soundEffectAudioClip)
    {
        _sfxAudio.PlayOneShot(soundEffectAudioClip);
    }

    public void StopSFX()
    {
        _sfxAudio.Stop();
    }
}