using UnityEngine;

public class OptionsSignal : MonoBehaviour
{
    public bool InOptions;
    public static OptionsSignal Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SetInOptions(bool currentState)
    {
        InOptions = currentState;
    }
}