using UnityEngine;
using UnityEngine.UI;

public class ScrollFix : MonoBehaviour
{
    [SerializeField] private Scrollbar sb;

    private void Start()
    {
        sb.value = 1;
        sb.size = 0;
    }

    public void ForceSize()
    {
        sb.size = 0;
    }
}