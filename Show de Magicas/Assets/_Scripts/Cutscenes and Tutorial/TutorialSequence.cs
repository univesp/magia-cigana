using UnityEngine;
using UnityEngine.Events;

public class TutorialSequence : MonoBehaviour
{
    [Header("Tutorial Data")]
    [SerializeField] private TutorialLines[] _tutorialData;
    [SerializeField] private UnityEvent[] _actions;
    private int _index;

    [Header("Dialogue Actions")]
    [SerializeField] private DialogueActions _dialogueActions;

    private void Start()
    {
        Invoke("NextTutorialDialogue", 1.5f);
    }

    private void NextTutorialDialogue()
    {
        _dialogueActions.StartNewDialogue(_tutorialData[_index].Lines, _actions[_index]);
        _index++;
    }

    public void CallNextDialogue(float delay)
    {
        Invoke("NextTutorialDialogue", delay);
    }
}

[System.Serializable]
public class TutorialLines
{
    [TextArea]
    public string[] Lines;    
}