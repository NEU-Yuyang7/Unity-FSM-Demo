using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Patrol,
        Chase
    }
    public EnemyState currentState = EnemyState.Idle;
    public float moveSpeed = 3f;
    public float chaseSpeed = 4.5f;

    public Transform player;
    public float sightRange = 8f;   // Player detection distance

    public Transform[] waypoints;
    public float waypointReachThreshold = 0.3f;
    private int currentWaypointIndex = 0;

    public float idleTime = 2f;
    private float idleTimer = 0f;

    private void Start()
    {
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.transform;
        }

        ChangeState(currentState);
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                IdleUpdate();
                break;

            case EnemyState.Patrol:
                PatrolUpdate();
                break;

            case EnemyState.Chase:
                ChaseUpdate();
                break;
        }
    }

    void ChangeState(EnemyState newState)
    {
        if (newState == EnemyState.Idle)
            idleTimer = 0f;

        currentState = newState;
    }

    void IdleUpdate()
    {
        idleTimer += Time.deltaTime;

        if (IsPlayerInSight())
        {
            ChangeState(EnemyState.Chase);
            return;
        }

        if (idleTimer >= idleTime && waypoints != null && waypoints.Length > 0)
        {
            ChangeState(EnemyState.Patrol);
        }
    }

    void PatrolUpdate()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            ChangeState(EnemyState.Idle);
            return;
        }

        Transform target = waypoints[currentWaypointIndex];
        MoveTowards(target.position, moveSpeed);

        float dist = Vector3.Distance(transform.position, target.position);
        if (dist <= waypointReachThreshold)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        if (IsPlayerInSight())
        {
            ChangeState(EnemyState.Chase);
        }
    }

    void ChaseUpdate()
    {
        if (player == null)
        {
            ChangeState(EnemyState.Idle);
            return;
        }

        float distToPlayer = Vector3.Distance(transform.position, player.position);

        // If the player leaves detection range → return to Idle
        if (distToPlayer > sightRange * 1.5f)
        {
            ChangeState(EnemyState.Idle);
            return;
        }

        MoveTowards(player.position, chaseSpeed);
    }

    bool IsPlayerInSight()
    {
        if (player == null) return false;

        float dist = Vector3.Distance(transform.position, player.position);
        return dist <= sightRange;
    }

    void MoveTowards(Vector3 targetPos, float speed)
    {
        Vector3 dir = targetPos - transform.position;
        dir.y = 0f;
        if (dir.sqrMagnitude < 0.0001f) return;

        dir = dir.normalized;
        transform.Translate(dir * speed * Time.deltaTime, Space.World);
    }

}
