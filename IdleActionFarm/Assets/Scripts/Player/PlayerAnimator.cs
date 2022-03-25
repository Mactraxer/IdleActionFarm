using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{

    //===== Clips name =====
    private const string RUN = "Run";

    //===== Blend trees paramets =====
    private const string SPEED = "Speed";

    //===== Blend trees name =====
    private const string RUN_BLEND_TREE = "Run Blend Tree";
    private const string HARVEST_BLEND_TREE = "Harvest Blend Tree";

    private Animator _animator;

    public Action OnAnimatedHarvesting;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void AninateRun()
    {
        _animator.Play(RUN);
    }

    public void AnimateIdle()
    {
        _animator.Play(RUN_BLEND_TREE);
    }

    public void AnimateHarvesting()
    {
        _animator.Play(HARVEST_BLEND_TREE);
    }

    public void AnimateMove(float speed)
    {
        _animator.SetFloat(SPEED, speed);
    }

}
