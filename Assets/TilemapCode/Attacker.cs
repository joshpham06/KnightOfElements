using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public Animator Animator;
    public KeyboardInput KeyboardInput;
    public GamepadInput GamepadInput;
    public Shoot Shoot;
    public Sounds Sounds;
    public PlayerInfo PlayerInfo;
    public Enemy enemy;
    private bool isTouching; 

    public void OnTriggerEnter2D(Collider2D other)
    {
        isTouching = true;
        
        if (other.gameObject.tag == "Health")
        {
            PlayerInfo.AddHealth(25);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Gem")
        {
            PlayerInfo.AddScore(100);
            Destroy(other.gameObject);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        isTouching = false;
    }

    private const string ATTACK_ANIMATION_NAME = "Attack";

    private void Awake()
    {
        InitializeComponents();
    }

    private void Update()
    {
        if (WasAttackButtonPressed())
        {
            TriggerAttackAnimation();
            
            Shoot.FireProjectile();
        }
    }

    private void InitializeComponents()
    {
        if (Animator == null)
        {
            Animator = GetComponent<Animator>();
        }
        
        if (KeyboardInput == null)
        {
            KeyboardInput = GetComponent<KeyboardInput>();
        }
        
        if (GamepadInput == null)
        {
            GamepadInput = GetComponent<GamepadInput>();
        }
    }

    private bool WasAttackButtonPressed()
    {
        bool keyboardPressed = IsKeyboardAttackPressed();
        bool gamepadPressed = IsGamepadAttackPressed();
        
        return keyboardPressed || gamepadPressed;
    }

    private bool IsKeyboardAttackPressed()
    {
        if (KeyboardInput == null)
        {
            return false;
        }
        
        return KeyboardInput.WasAttackButtonPressed();
    }

    private bool IsGamepadAttackPressed()
    {
        if (GamepadInput == null)
        {
            return false;
        }
        
        return GamepadInput.WasAttackButtonPressed();
    }

    private void TriggerAttackAnimation()
    {
        if (Animator == null)
        {
            return;
        }

        //sounds.PlaySwordAttack(); 
        
        // Manually plays the attack animation (no blending/transitions)
        Animator.Play(ATTACK_ANIMATION_NAME);
        if (isTouching)
        {
            DealDamage();
        }
    }
    
    private void DealDamage()
    {
        enemy.LoseHealth(PlayerInfo.GetAttackDmg());
    }

    private void TriggerProjectileAnimation()
    {
        // add projectile attack animation here
    }
}