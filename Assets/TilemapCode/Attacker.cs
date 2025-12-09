using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public Animator Animator;
    public KeyboardInput KeyboardInput;
    public GamepadInput GamepadInput;
    public Shoot Shoot;
    public GameObject FireBall;
    public Sounds Sounds;
    public PlayerInfo PlayerInfo;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Health")
        {
            PlayerInfo.addHealth(25);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Gem")
        {
            PlayerInfo.addScore(100);
            Destroy(other.gameObject);
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

            Shoot.ShootBall(10f, FireBall);
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

        Sounds.PlaySwordAttack(); 
        
        // Manually plays the attack animation (no blending/transitions)
        Animator.Play(ATTACK_ANIMATION_NAME); 
    }

    private void TriggerProjectileAnimation()
    {
        // add projectile attack animation here
    }
}