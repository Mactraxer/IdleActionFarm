    using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Timer))]
public class ResourcePackAnimator : MonoBehaviour
{
    private const string DROP_CLIP_NAME = "ResourcePackDrop";
    private const string IDLE_CLIP_NAME = "ResourcePackIdle";

    private Animator _animator;
    private Timer _timer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _timer = GetComponent<Timer>();

        _animator.Play(DROP_CLIP_NAME);
        _timer.OnTimeout += Timeout;
        _timer.StartTimer(1f);
    }

    private void OnDisable()
    {
        _timer.OnTimeout -= Timeout;
    }

    private void Timeout()
    {
        _animator.Play(IDLE_CLIP_NAME);
    }

}
