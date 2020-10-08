using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSounds : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    [SerializeField] private AudioClip _mouseOver;
    [SerializeField] private AudioClip _mouseClick;

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioPlayer.Instance.PlaySFX(_mouseOver);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AudioPlayer.Instance.PlaySFX(_mouseClick);
    }
}
