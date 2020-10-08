using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DelayedActions : MonoBehaviour
{
    private float _delayTime;
    [SerializeField] private UnityEvent _actions;

    public void ExecuteActions(float delay)
    {
        StartCoroutine(Execute(delay));
    }

    private IEnumerator Execute(float delay)
    {
        yield return new WaitForSeconds(delay);
        _actions.Invoke();
    }
}
