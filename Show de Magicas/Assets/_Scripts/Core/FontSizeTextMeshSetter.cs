using UnityEngine;
using TMPro;

public class FontSizeTextMeshSetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        //Inicializa com o último tamanho definido nas opções
        _text.fontSize = PlayerPrefs.GetFloat("font_size", 60f);

        //Salvar o método de atualizar o tamanho no delegate
        FontSizeChanger.Instance.SizeChangeDelegate += UpdateSize;
    }

    private void OnDisable()
    {
        //Remove o método de atualizar o tamanho no delegate
        FontSizeChanger.Instance.SizeChangeDelegate -= UpdateSize;
    }

    private void UpdateSize()
    {
        _text.fontSize = PlayerPrefs.GetFloat("font_size", 60f);
    }
}
