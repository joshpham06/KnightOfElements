using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public Animator Animator;
    public KeyboardInput KeyboardInput;
    public GamepadInput GamepadInput;
    public Shoot Shoot;
    public GameObject FireBall;
    public GameObject AirBall;
    public GameObject LightningBall;
    public GameObject WaterBall;
    public GameObject EarthBall;
    public Sounds Sounds;
    public PlayerInfo PlayerInfo;
    public Enemy enemy;
    public ElementUI ElementUI;
    private bool isTouching; 

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        
        
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
        
        if (other.CompareTag("Golem"))
        {
            isTouching = true;
            enemy = other.GetComponent<Enemy>();
            print("Golem");
            
        }
        if (other.CompareTag("Wolf"))
        {
            isTouching = true;
            enemy = other.GetComponent<Enemy>();
            print("Wolf");
        }
        if (other.CompareTag("TentacleHead"))
        {
            isTouching = true;
            enemy = other.GetComponent<Enemy>();
            print("TentacleHead");
        } 
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Golem"))
        {
            isTouching = false;
            enemy = null; 
            
        }
        if (other.CompareTag("Wolf"))
        {
            isTouching = false;
            enemy = null; 
            
        }
        if (other.CompareTag("TentacleHead"))
        {
            isTouching = false;
            enemy = null; 
            
        } 
        
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
            
        }

        if (WasProjectileButtonPressed())
        {
            if (ElementUI.getCurrentElementIndex() == 0)
            {
                Shoot.ShootBall(10f, FireBall); 
            }
            if (ElementUI.getCurrentElementIndex() == 1)
            {
                Shoot.ShootBall(10f, LightningBall); 
            }
            if (ElementUI.getCurrentElementIndex() == 2)
            {
                Shoot.ShootBall(10f, EarthBall); 
            }
            if (ElementUI.getCurrentElementIndex() == 3)
            {
                Shoot.ShootBall(10f, AirBall); 
            }
            if (ElementUI.getCurrentElementIndex() == 4)
            {
                Shoot.ShootBall(10f, WaterBall); 
            }
            
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
    
    private bool WasProjectileButtonPressed()
    {
        bool keyboardPressed = IsKeyboardProjectilePressed();
        bool gamepadPressed = IsGamepadProjectilePressed();
        
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
    
    private bool IsKeyboardProjectilePressed()
    {
        if (KeyboardInput == null)
        {
            return false;
        }
        
        return KeyboardInput.WasProjectileButtonPressed();
    }

    private bool IsGamepadAttackPressed()
    {
        if (GamepadInput == null)
        {
            return false;
        }
        
        return GamepadInput.WasAttackButtonPressed();
    }
    
    private bool IsGamepadProjectilePressed()
    {
        if (GamepadInput == null)
        {
            return false;
        }
        
        return GamepadInput.WasProjectileButtonPressed();
    }

    private void TriggerAttackAnimation()
    {
        if (Animator == null)
        {
            return;
        }

        Sounds.PlaySwordAttack(); 
        
        // Manually plays the attack animation (no blending/transitions)
        Animator.Play(ATTACK_ANIMATION_NAME);
        if (isTouching && enemy != null)
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