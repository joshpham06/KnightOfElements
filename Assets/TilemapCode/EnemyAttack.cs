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
    public PlayerInfo PlayerInfo;
    public Enemy Enemy; 
    private bool isAttacking = false;
    private bool isTouchingPlayer = false;
    private bool damageTimer = false; 
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        
        if (other.gameObject.tag == "Player")
        {
            isTouchingPlayer = true;
            StartCoroutine(TriggerAttackAnimation());
            
        }
        
    }

    

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = false;
        }
    }


    private const string ATTACK_ANIMATION_NAME = "Attack";

    private void Awake()
    {
        InitializeComponents();
        currentObject = this.gameObject;
        PlayerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
        Enemy = GetComponent<Enemy>(); 
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
        StartCoroutine(CallDealDamage());
        
        
        yield return new WaitForSeconds(1.85f);
        
        isAttacking = false;
    }

    IEnumerator CallDealDamage()
    {


        if (damageTimer)
        {
            yield break;
        } 
        damageTimer = true;

        
        
        yield return new WaitForSeconds(.5f);
        
        if (isTouchingPlayer)
        {
            DealDamage();
        }
        damageTimer = false; 

        
    }
    
    
    
    private void DealDamage()
    {
        PlayerInfo.LoseHealth(Enemy.damage);
    }
    

}
