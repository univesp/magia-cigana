using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardOperations : MonoBehaviour
{
    private NumberOperations numberOperations;

    [SerializeField] private Toggle[] _cardToggles;

    [SerializeField] private Image _cardImage;
    [SerializeField] private Sprite[] _cardSprites;

    private int _cardPicked;

    private void Awake()
    {
        numberOperations = new NumberOperations();
    }

    #region Computer Turn
    public void ComputerGuessCard()
    {
        //Inicializa a string que vai guardar o número binário
        string binaryNumber = "";

        //Passa por todos os cards que o jogador selecionou para formar o número binário
        for(int i = 0; i < _cardToggles.Length; i++)
        {
            if (_cardToggles[i].isOn)
            {
                binaryNumber += "1";
            }
            else
            {
                binaryNumber += "0";
            }
        }

        //Converte o número binário em decimal para pegar o índice da carta escolhida
        int cardResult = numberOperations.BinaryToDecimal(binaryNumber);

        //Exibe o card correto
        _cardImage.sprite = _cardSprites[cardResult];
    }
    #endregion

    #region Player Turn
    public void ComputerPickCard()
    {
        //Seleciona um card aleatório
        _cardPicked = Random.Range(0, 16);

        //Pega os dígitos individuais do número binário desse card
        Stack<int> binaryDigits = numberOperations.SplitDigits(numberOperations.DecimalToBinary(_cardPicked));

        //Seleciona os cards de acordo com o número binário
        for (int i = _cardToggles.Length - 1; i >= 0; i--)
        {
            if(binaryDigits.Pop() == 0)
            {
                _cardToggles[i].isOn = false;
            }
            else
            {
                _cardToggles[i].isOn = true;
            }            
        }
    }

    public void TutorialComputerPickCard()
    {
        _cardPicked = 6;
    }

    public bool PlayerGuessCard(int cardIndex)
    {
        //Exibe o card escolhido
        _cardImage.sprite = _cardSprites[cardIndex];

        if (cardIndex == _cardPicked)
        {
            return true;
        }
        else
        {
            return false;
        }        
    }
    #endregion

    public void RestarToggles()
    {
        for(int i = 0; i < _cardToggles.Length; i++)
        {
            _cardToggles[i].isOn = false;
        }
    }
}