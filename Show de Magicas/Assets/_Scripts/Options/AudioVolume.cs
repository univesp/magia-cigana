using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer _masterMixer;

    [Space]
    [Header("BGM")]
    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private float _bgmMinValue;
    [SerializeField] private float _bgmMaxValue;

    [Space]
    [Header("SFX")]
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private float _sfxMinValue;
    [SerializeField] private float _sfxMaxValue;

    private void Start()
    {
        StartSliders();
        VolumeBGM();
        VolumeSFX();
    }

    //Inicializa os valores mínimos e máximos dos sliders e os coloca no valor definido
    private void StartSliders()
    {
        _bgmSlider.minValue = _bgmMinValue;
        _bgmSlider.maxValue = _bgmMaxValue;
        _bgmSlider.value = PlayerPrefs.GetFloat("BGM", 0f);

        _sfxSlider.minValue = _sfxMinValue;
        _sfxSlider.maxValue = _sfxMaxValue;
        _sfxSlider.value = PlayerPrefs.GetFloat("SFX", 0f);
    }

    public void VolumeBGM()
    {
        _masterMixer.SetFloat("BGM", _bgmSlider.value);
        PlayerPrefs.SetFloat("BGM", _bgmSlider.value);
    }

    public void VolumeSFX()
    {
        _masterMixer.SetFloat("SFX", _sfxSlider.value);
        PlayerPrefs.SetFloat("SFX", _sfxSlider.value);
    }
}