using UnityEngine;

public class ScoutManager : EnemyManager
{
    [Header("Scout Settings")]
    public Transform[] scanPoints;
    public float rotationSpeed = 25f;
    public float alertDuration;
    public float fieldOfView = 45f;
    private int currentPointIndex = 0;

    protected override void Update()
    {
        DetectPlayer();

        if (!playerDetected)
        {
            ScanArea();
        }
        else
        {
            RaiseGlobalAlert();
        }
    }

    protected override void DetectPlayer()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if(distance <= detectionRange)
        {
            Vector2 directionToPlayer = (player.position - transform.position).normalized;
            float angle = Vector2.Angle(transform.right, directionToPlayer);

            if (angle <= fieldOfView / 2f)
            {
                playerDetected = true;
                return;
            }
        }
        playerDetected = false; 
    }

    private void ScanArea()
    {
        if (scanPoints.Length == 0) return;

        RotateTowardsPoint();

        Vector3 directionToPoint = scanPoints[currentPointIndex].position - transform.position;
        float angleToTarget = Mathf.Atan2(directionToPoint.y, directionToPoint.x) * Mathf.Rad2Deg;
        float currentAngle = transform.eulerAngles.z;

        if (Mathf.Abs(Mathf.DeltaAngle(currentAngle, angleToTarget)) < 1f)
        {
            currentPointIndex = (currentPointIndex + 1) % scanPoints.Length;
        }
    }

    private void RotateTowardsPoint()
    {
        Vector3 directionToPoint = scanPoints[currentPointIndex].position - transform.position;
        float targetAngle = Mathf.Atan2(directionToPoint.y, directionToPoint.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void RaiseGlobalAlert()
    {
        Debug.Log("CAMERA SPOTTED PLAYER!s");
        AlertNearbyEnemies();
    }

    public override void ReceiveAlert(Vector3 playerPosition)
    {

    }
}