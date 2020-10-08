using System.Collections;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    [SerializeField] private CardOperations _cardOperations;

    [Header("All Cards Screen")]
    [SerializeField] private GameObject _allCardsScreen;
    [SerializeField] private GameObject _allCardsChooseCard;
    [SerializeField] private GameObject _allCardsComputerTurn;
    [SerializeField] private GameObject _allCardsRevealCard;

    [Header("Grouped Cards Screen")]
    [SerializeField] private GameObject _groupedCardsScreen;
    [SerializeField] private GameObject _groupedCardsComputerTurn;

    [Header("Dialogue")]
    [SerializeField] private GameplaySequence _gameplaySequence;

    [SerializeField] private bool playLater;

    [SerializeField] private bool _isPlayerTurn = true;

    private void Start()
    {
        if (!playLater)
        {
            OpenChooseCardScreen(0);
        }
    }

    public void SetPlayerTurn(bool currentState)
    {
        _isPlayerTurn = currentState;
    }

    public void OpenChooseCardScreen(float delay)
    {
        StartCoroutine(ChooseCardSequence(delay));
    }

    private IEnumerator ChooseCardSequence(float delay)
    {
        _cardOperations.RestarToggles();

        yield return new WaitForSeconds(delay);

        _allCardsScreen.SetActive(true);
        _allCardsChooseCard.SetActive(true);
        _allCardsComputerTurn.SetActive(false);
        _allCardsRevealCard.SetActive(false);

        _groupedCardsScreen.SetActive(false);
    }

    public void OpenGroupedCardsScreen()
    {
        StartCoroutine(OpenGroupedCardsSequece());
    }

    private IEnumerator OpenGroupedCardsSequece()
    {
        yield return new WaitForSeconds(1.5f);
        _allCardsScreen.SetActive(false);

        _groupedCardsScreen.SetActive(true);

        if (_isPlayerTurn)
        {
            _groupedCardsComputerTurn.SetActive(true);            
        }
        else
        {
            _groupedCardsComputerTurn.SetActive(false);
        }
    }

    public void ComputerPickCard()
    {
        _cardOperations.ComputerPickCard();
    }

    public void TutorialOpenGroupedCardsScreen()
    {
        StartCoroutine(TutorialGroupedCardsSequence());
    }

    private IEnumerator TutorialGroupedCardsSequence()
    {
        yield return new WaitForSeconds(1.5f);
        _allCardsScreen.SetActive(false);

        _groupedCardsScreen.SetActive(true);
        _groupedCardsComputerTurn.SetActive(true);

        _cardOperations.TutorialComputerPickCard();
    }

    public void PostGroupedScreen()
    {
        if(_isPlayerTurn)
        {
            _allCardsComputerTurn.SetActive(false);
            _allCardsScreen.SetActive(true);           
            _allCardsChooseCard.SetActive(false);

            _groupedCardsScreen.SetActive(false);
        }
        else
        {
            _cardOperations.ComputerGuessCard();
            OpenRevealCardScreen();
        }
    }

    public void OpenRevealCardScreen()
    {
        StartCoroutine(RevealSequece());
    }

    private IEnumerator RevealSequece()
    {
        yield return new WaitForSeconds(1.0f);
        _allCardsComputerTurn.SetActive(false);
        _allCardsScreen.SetActive(false);
        _allCardsChooseCard.SetActive(false);
        _groupedCardsScreen.SetActive(false);
        _allCardsRevealCard.SetActive(true);
    }

    public void PlayerGuessCard(int cardIndex)
    {
        bool correctSelection = _cardOperations.PlayerGuessCard(cardIndex);

        if(correctSelection)
        {
            _gameplaySequence.RightCard();
        }
        else
        {
            _gameplaySequence.WrongCard();
        }
    }
}