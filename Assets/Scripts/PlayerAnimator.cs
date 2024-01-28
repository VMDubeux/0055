using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] public Animator _animator;

    [Header("Settings")]
    [SerializeField] private float _moveSpeedMultiplier;

    void Start()
    {

    }

    void Update()
    {

    }

    public void ManageAnimations(Vector3 moveVector)
    {
        if (moveVector.magnitude > 0)
        {
            _animator.SetFloat("moveSpeed", moveVector.magnitude * _moveSpeedMultiplier);
            PlayRunAnimation();

            _animator.transform.forward = moveVector.normalized;
        }
        else
        {
            
            PlayIdleAnimation();
        }
    }

    /*public void ManageShootAnimation(Vector3 moveVector)
    {
        if (moveVector.magnitude > 0)
        {
            _animator.SetBool("isShooting", true);
            PlayShootAnimation();

            
        }
        else
        {
            _animator.SetBool("isShooting", false);
        }
    }*/

    private void PlayRunAnimation()
    {
        
        _animator.Play("Run");
    }

    private void PlayIdleAnimation()
    {
        _animator.Play("Idle");
    }

    private void PlayShootAnimation()
    {
        _animator.Play("Shoot");
    }

    public void PlayShootingAnimation()
    {
        _animator.SetLayerWeight(1, 1);
    }

    public void StopShootingAnimation()
    {
        
        _animator.SetLayerWeight(1, 0);
    }
}