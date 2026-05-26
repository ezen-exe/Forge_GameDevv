    using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    protected Rigidbody2D rb;
    public float moveSpeed = 3f;
    [Header("Patrol Settings")]
    public Transform ptA;
    public Transform ptB;
    private Transform currentTarget;
    
    [Header("Detection")]
    public float detectionRange;
    public LayerMask playerLayer;

    [Header("References")]
    public Transform player;

    protected bool playerDetected;
    protected bool isAlerted;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentTarget = ptA;
    }

    protected virtual void Update()
    {
        DetectPlayer();

        if (playerDetected)
        {
            AlertNearbyEnemies();
        }
    }

    protected virtual void DetectPlayer()
    {
        float distance = Vector2.Distance(transform.position, player.position);

    if (distance <= detectionRange)
    {
        playerDetected = true;
    }
    else if (!isAlerted)
    {
        playerDetected = false;
    }
    }

    protected virtual void AlertNearbyEnemies()
{
    EnemyManager[] allEnemies = FindObjectsOfType<EnemyManager>();
    
    foreach (EnemyManager enemy in allEnemies)
    {
        if (enemy != this)
        {
            enemy.ReceiveAlert(player.position);
        }
    }
}

    public virtual void ReceiveAlert(Vector3 playerPosition)
    {
        playerDetected = true;
        isAlerted = true;
    }

    protected virtual void Patrol()
{
    float direction = 0f;
    if (currentTarget.position.x > transform.position.x) direction = 1f;
    else if (currentTarget.position.x < transform.position.x) direction = -1f;

    rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);

    if (Mathf.Abs(transform.position.x - currentTarget.position.x) < 0.2f)
    {
        if (currentTarget == ptA) currentTarget = ptB;
        else currentTarget = ptA;
    }
}

    protected virtual void ChasePlayer()
    {
        float direction = 0f;
        if (player.position.x > transform.position.x) direction = 1f;
        else if (player.position.x < transform.position.x) direction = -1f;

        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }

    protected virtual void ReturnToPatrol()
    {
    
    }
}