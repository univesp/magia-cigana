using UnityEngine;

public class FontSizeChanger : MonoBehaviour
{
    public static FontSizeChanger Instance;

    public delegate void OnSizeChange();
    public OnSizeChange SizeChangeDelegate;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeSize()
    {
        SizeChangeDelegate?.Invoke();
    }
}