using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator Animator;
    public Shoot Shoot;
    public GameObject FireBall;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TriggerAttackAnimation();
        }
    }

    private const string ATTACK_ANIMATION_NAME = "Attack";

    private void Awake()
    {
        InitializeComponents();
    }

    private void Update()
    {
        
    }

    private void InitializeComponents()
    {
        if (Animator == null)
        {
            Animator = GetComponent<Animator>();
        }
    }
    

    private void TriggerAttackAnimation()
    {
        if (Animator == null)
        {
            return;
        }
        
        // Manually plays the attack animation (no blending/transitions)
        Animator.Play(ATTACK_ANIMATION_NAME); 
    }

}
