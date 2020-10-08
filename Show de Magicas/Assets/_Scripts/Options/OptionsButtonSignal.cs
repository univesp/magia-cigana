using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsButtonSignal : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool IsIn;
    public static OptionsButtonSignal Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsIn = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsIn = false;
    }
}
