using UnityEngine;
using Pathfinding;

public class EnemySpriteAnimator : MonoBehaviour
{
    public AIPath AIPath; 
    public Animator Animator;
    public SpriteRenderer SpriteRenderer;

    private void Awake()
    {
        if (AIPath == null)
            AIPath = GetComponent<AIPath>();

        if (Animator == null)
            Animator = GetComponentInChildren<Animator>();

        if (SpriteRenderer == null)
            SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 velocity = AIPath.desiredVelocity;

        HandleAnimation(velocity);
        HandleFlipping(velocity);
    }

    private void HandleAnimation(Vector2 velocity)
    {
        bool isMoving = velocity.sqrMagnitude > 0.05f;
        Animator.SetBool("IsWalking", isMoving);
    }

    private void HandleFlipping(Vector2 velocity)
    {
        if (velocity.x > 0.01f)
            SpriteRenderer.flipX = false;
        else if (velocity.x < -0.01f)
            SpriteRenderer.flipX = true;
    }
}