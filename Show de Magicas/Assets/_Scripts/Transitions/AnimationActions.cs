using System.Collections;
using UnityEngine;
using UnityEngine.Events;

//Toca uma animação e executa ações após ou durante a animação
public class AnimationActions : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator _animator;
    [SerializeField] private string _animationName;

    [Header("Wait Time")]
    [SerializeField] private float _hasteTime;

    [Header("Events")]
    [SerializeField] private UnityEvent _actions;
    public void StartAnimation()
    {
        StartCoroutine(ExecuteActions());
    }

    private IEnumerator ExecuteActions()
    {
        if (_animator != null)
        {
            _animator.Play(_animationName);
        

        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length - _hasteTime);
        }

        _actions.Invoke();
    }
}