using System.Collections;
using UnityEngine;

public class Skip : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationActions _animationActions;

    private bool _wantSkip;
    private float _timer;

    private void Update()
    {
        if(_wantSkip)
        {
            _timer += Time.deltaTime;
            if(_timer >= 2.0f)
            {
                StartCoroutine(Unskip());
            }
        }
    }

    public void SkipScene()
    {
        if (!_wantSkip)
        {
            _animator.Play("skip_exit");
            _wantSkip = true;
        }
        else
        {
            _wantSkip = false;
            _animationActions.StartAnimation();
        }
    }

    private IEnumerator Unskip()
    {
        _animator.Play("skip_enter");

        yield return new WaitForSeconds(0.5f);

        _wantSkip = false;
        _timer = 0;
    }
}