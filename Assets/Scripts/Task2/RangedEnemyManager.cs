using UnityEngine;

public class RangedEnemyManager : EnemyManager
{
    [Header("Ranged Settings")]
    public float preferredDistance = 5f;
    public float shootingCooldown = 2f;
    public GameObject projectilePrefab; 
    public Transform firePoint;

    private bool canShoot = true;
    private float shootTimer;

    protected override void Update()
    {
        base.Update();

        if (playerDetected)
        {
            MaintainDistance();

            if (canShoot)
            {
                ShootProjectile();
            }
        }
        else
        {
            Patrol();
        }
        HandleShootCooldown();
    }

    private void MaintainDistance()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        float direction = 0f;

        if (distanceToPlayer > preferredDistance + 0.5f)
        {
            if (player.position.x > transform.position.x) direction = 1f;
            else direction = -1f;
        }
        else if (distanceToPlayer < preferredDistance - 0.5f)
        {
            if (player.position.x > transform.position.x) direction = -1f;
            else direction = 1f;
        }

        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }

    private void ShootProjectile()
    {
        Debug.Log("Ranged Enemy fired a shot!");
        if (projectilePrefab != null && firePoint != null)
        {
            Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        }
        
        canShoot = false;
        shootTimer = shootingCooldown;
    }

    private void HandleShootCooldown()
    {
        if (!canShoot)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f) canShoot = true;
        }
    }

    protected override void ChasePlayer()
    {
        
    }
    
}