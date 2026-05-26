using UnityEngine;

public class MeleeEnemyManager : EnemyManager
{
    
    [Header("Melee Settings")]
    public float attackRange;
    public float attackCooldown;

    private float attackTimer;

    private bool canAttack = true;

    protected override void Update()
    {
        base.Update();

        if (playerDetected)
        {
            ChasePlayer();

            if (Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                PerformAttack();
            }
        }
        else
        {
            Patrol();
        }
        HandleAttackCooldown();
    }

    private void PerformAttack()
    {
        rb.linearVelocity = new Vector2(0f,rb.linearVelocity.y);

        Debug.Log("Attack!");

        canAttack = false;

        attackTimer = attackCooldown;
    }

    private void HandleAttackCooldown()
    {
        if (!canAttack)
        {
            attackTimer -= Time.deltaTime;

            if(attackTimer <= 0f)
            {
                canAttack = true;
            }
        }
    }
    
}
