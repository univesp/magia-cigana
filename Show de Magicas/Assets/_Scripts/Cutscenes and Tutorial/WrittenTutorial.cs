using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WrittenTutorial : MonoBehaviour
{
    [SerializeField] private Image _tutorialImage;
    [SerializeField] private Sprite[] _tutorialSprites;

    [SerializeField] private TextMeshProUGUI _textMesh;
    [TextArea]
    [SerializeField] private string[] _tutorialTexts;
    private int _index;

    [SerializeField] private GameObject _nextArrow;
    [SerializeField] private GameObject _previousArrow;

    private void OnEnable()
    {
        _index = 0;
        _tutorialImage.sprite = _tutorialSprites[_index];
        _textMesh.text = _tutorialTexts[_index];
        _nextArrow.SetActive(true);
        _previousArrow.SetActive(false);
    }

    public void NavigateTutorial(int direction)
    {
        _index += direction;
        if(_index == _tutorialSprites.Length - 1)
        {
            _nextArrow.SetActive(false);
        }
        if(_index == 0)
        {
            _previousArrow.SetActive(false);
        }

        _tutorialImage.sprite = _tutorialSprites[_index];
        _textMesh.text = _tutorialTexts[_index];
    }
}
