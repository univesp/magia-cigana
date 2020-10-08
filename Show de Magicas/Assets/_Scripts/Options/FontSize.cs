using UnityEngine;
using UnityEngine.UI;

public class FontSize : MonoBehaviour
{
    [SerializeField] private Slider _fontSlider;
    [SerializeField] private float _fontSliderMinValue;
    [SerializeField] private float _fontSliderMaxValue;

    private void Start()
    {
        StartSlider();
    }

    //Inicializa o valor mínimo e máximo do slider e o coloca no valor definido
    private void StartSlider()
    {
        _fontSlider.value = PlayerPrefs.GetFloat("font_size", 60f);

        _fontSlider.minValue = _fontSliderMinValue;
        _fontSlider.maxValue = _fontSliderMaxValue;
    }

    public void ChangeFontSize()
    {
        //Muda o tamanho das fontes visíveis
        FontSizeChanger.Instance.ChangeSize();

        //Atualiza o PlayerPrefs com o valor atual
        PlayerPrefs.SetFloat("font_size", _fontSlider.value);        
    }
}