using UnityEngine;

public class Attacker : MonoBehaviour
{
    public Animator Animator;
    public KeyboardInput KeyboardInput;
    public GamepadInput GamepadInput;
    public Shoot Shoot;
    public GameObject FireBall;

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
        
        // Manually plays the attack animation (no blending/transitions)
        Animator.Play(ATTACK_ANIMATION_NAME); 
    }

    private void TriggerProjectileAnimation()
    {
        // add projectile attack animation here
    }
}