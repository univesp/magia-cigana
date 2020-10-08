using UnityEngine;
using UnityEngine.Events;

public class Feedback : MonoBehaviour
{
    [SerializeField] private FeedbackLines[] _feedbackDialogue;
    [SerializeField] private UnityEvent[] _actions;
    [SerializeField] private DialogueActions _dialogueActions;

    private void Start()
    {
        FeedbackResults();
    }

    private void FeedbackResults()
    {
        Debug.Log(PlayerPrefs.GetInt("wins"));
        switch(PlayerPrefs.GetInt("wins"))
        {
            case 0:
                _dialogueActions.StartNewDialogue(_feedbackDialogue[0].Lines, _actions[0]);
                break;

            case 3:
                _dialogueActions.StartNewDialogue(_feedbackDialogue[2].Lines, _actions[2]);
                break;

            default:
                _feedbackDialogue[1].Lines[0] = _feedbackDialogue[1].Lines[0].Replace("[RESULTADO]", PlayerPrefs.GetInt("wins").ToString());
                _dialogueActions.StartNewDialogue(_feedbackDialogue[1].Lines, _actions[1]);
                break;
        }        
    }
}

[System.Serializable]
public class FeedbackLines
{
    [TextArea]
    public string[] Lines;
}