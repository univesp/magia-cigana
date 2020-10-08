using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameplaySequence : MonoBehaviour
{
    [Header("Tutorial Data")]
    [SerializeField] private GameplayLines[] _gameplayData;
    [SerializeField] private UnityEvent[] _actions;
    //0 - Escolha das cartas | 1 - Escolha dos grupos | 2 - Acerto | 3 - Erro

    [Header("Dialogue Actions")]
    [SerializeField] private DialogueActions _dialogueActions;

    [Header("Round Controller")]
    [SerializeField] private RoundController _roundController;

    [Header("Final Action")]
    [SerializeField] private AnimationActions _rightAnimationActions;
    [SerializeField] private AnimationActions _wrongAnimationActions;
    private bool _goodEnding;

    [Header("SFX")]
    [SerializeField] private AudioClip _rightSound;
    [SerializeField] private AudioClip _wrongSound;

    [Header("Avatar")]
    [SerializeField] private Image _avatarImage;
    [SerializeField] private Sprite[] _avatarSprites;

    private int _wins;

    [SerializeField] private bool _infiniteMode;
    private int _roundCount;

    [SerializeField] private bool _playInStart;

    private void Start()
    {
        if(_playInStart)
        {
            ChooseCardsDialogue();
        }
        _wins = 0;
        PlayerPrefs.SetInt("wins", _wins);
    }

    public void ChooseCardsDialogue()
    {
        StartCoroutine(CallDialogue(0));
    }    

    public void ChooseGroupsDialogue()
    {
        StartCoroutine(CallDialogue(1));
    }

    public void ChooseFinalCardDialogue()
    {
        StartCoroutine(CallDialogue(5));
    }

    public void RightCard()
    {
        _wins++;
        PlayerPrefs.SetInt("wins", _wins);

        _goodEnding = true;

        StartCoroutine(Results(2, _rightSound));
    }

    public void WrongCard()
    {
        StartCoroutine(Results(3, _wrongSound));
    }

    public void TutorialRoundEnd()
    {
        StartCoroutine(CallDialogue(4));
    }

    private IEnumerator CallDialogue(int dialogueIndex)
    {
        yield return new WaitForSeconds(1.0f);
        _dialogueActions.StartNewDialogue(_gameplayData[dialogueIndex].Lines, _actions[dialogueIndex]);
    }

    private IEnumerator Results(int dialogueIndex, AudioClip sound)
    {
        AudioPlayer.Instance.PlaySFX(sound);
        yield return new WaitForSeconds(2.0f);        
        _dialogueActions.StartNewDialogue(_gameplayData[dialogueIndex].Lines, _actions[dialogueIndex]);
    }

    public void NextRound()
    {
        if(_infiniteMode)
        {
            StartCoroutine(NextRoundSequence());
        }
        else
        {
            _roundCount++;            

            if(_roundCount >= 3)
            {
                if (_goodEnding)
                {
                    _rightAnimationActions.StartAnimation();
                }
                else
                {
                    _wrongAnimationActions.StartAnimation();
                }
            }
            else
            {
                StartCoroutine(NextRoundSequence());
            }
        }
    }    

    public IEnumerator NextRoundSequence()
    {
        if (_infiniteMode)
        {
            _roundController.OpenChooseCardScreen(1.0f);
            yield return new WaitForSeconds(2.0f);
            _dialogueActions.StartNewDialogue(_gameplayData[0].Lines, _actions[0]);
            _avatarImage.sprite = _avatarSprites[Random.Range(0, 3)];
        }
        else
        {            
            _roundController.OpenChooseCardScreen(1.0f);
            yield return new WaitForSeconds(2.0f);
            _avatarImage.sprite = _avatarSprites[_roundCount];
            _dialogueActions.StartNewDialogue(_gameplayData[0].Lines, _actions[0]);
        }
    }

    public void InfiniteModeOn(bool currentStatus)
    {
        _infiniteMode = currentStatus;
        _roundCount = 0;
    }
}

[System.Serializable]
public class GameplayLines
{
    [TextArea]
    public string[] Lines;
}