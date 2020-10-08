using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogueActions : MonoBehaviour
{    
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private Animator _animator;

    [Space]

    private string[] _lines;
    private int _textIndex;
    private int _totalVisibleCharacters;
    private bool _isPrintingText;
    private bool _finishedDialogue;

    private IEnumerator _letterByLetterCoroutine;

    private UnityEvent _actions;

    private void Start()
    {
        _letterByLetterCoroutine = LetterByLetter();
    }

    public void StartNewDialogue(string[] newLines, UnityEvent newActions)
    {
        _animator.gameObject.SetActive(true);
        _lines = newLines;
        _actions = newActions;
        _textIndex = 0;
        _finishedDialogue = false;
        TextClickAction();
    }

    public void TextClickAction()
    {
        if (_isPrintingText)
        {
            //Para a coroutine de mostrar o texto, mostra o texto todo e avisa que parou de imprimir
            StopCoroutine(_letterByLetterCoroutine);
            _textMesh.maxVisibleCharacters = _totalVisibleCharacters;
            _isPrintingText = false;

            //Sai dessa função
            return;
        }

        if (!_finishedDialogue)
        {
            //Chama o próximo texto
            CallNextText();
        }
    }

    private void CallNextText()
    {
        if (_textIndex < _lines.Length)
        {
            _textMesh.text = _lines[_textIndex];
            _textIndex++;

            //StartCoroutine(_letterByLetterCoroutine);
        }
        else
        {
            //Avisa que esse diálogo acabou
            _finishedDialogue = true;
            //Executa após o texto terminar
            StartCoroutine(EndDialogue());
        }
    }

    private IEnumerator LetterByLetter()
    {
        //Avisa que o texto está sendo impresso na tela
        _isPrintingText = true;

        //Espera o fim do frame para pegar a quantidade certa de palavras na frase
        yield return new WaitForEndOfFrame();

        /*//Pega a quantidade total de caracteres do texto
        _totalVisibleCharacters = _textMesh.textInfo.characterCount;

        //Espera o tempo para tornar visível letra por letra
        for (int i = 0; i <= _totalVisibleCharacters; i++)
        {
            _textMesh.maxVisibleCharacters = i;
            yield return new WaitForSeconds(0.01f);
        }
        */
        //Avisa que terminou de imprimir o texto na tela
        _isPrintingText = false;
    }

    private IEnumerator EndDialogue()
    {
        _animator.Play("dialogue_exit");
        yield return new WaitForSeconds(1.0f);
        //Executa a ação depois da animação
        _actions.Invoke();
        //Deixa a janela do diálogo invisível
        _animator.gameObject.SetActive(false);
    }
}