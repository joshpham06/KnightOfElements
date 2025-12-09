using System;
using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator Animator;
    public Shoot Shoot;
    public GameObject FireBall;
    public Sounds Sounds;
    public GameObject currentObject;
    private bool isAttacking = false;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(TriggerAttackAnimation());
        }
    }

    private const string ATTACK_ANIMATION_NAME = "Attack";

    private void Awake()
    {
        InitializeComponents();
        currentObject = this.gameObject;
        //Sounds = GameObject.FindGameObjectWithTag("Sounds");
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
    

    IEnumerator TriggerAttackAnimation()
    {

        if (isAttacking)
        {
            yield break;
        }
        
        isAttacking =  true;
        
        if (currentObject.gameObject.tag == "Golem")
        {
            Sounds.PlayGolemAttack();
        }
        if (currentObject.gameObject.tag == "TentacleHead")
        {
            Sounds.PlayTentacleAttack();
        }
        if (currentObject.gameObject.tag == "Wolf")
        {
            Sounds.PlayWolfAttack();
        }
        // Manually plays the attack animation (no blending/transitions)
        Animator.Play(ATTACK_ANIMATION_NAME);
        
        isAttacking = false;
        
        yield return new WaitForSeconds(3f);
    }
    

}
