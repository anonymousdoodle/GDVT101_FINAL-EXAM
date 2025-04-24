using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 3f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingToTarget = true;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + new Vector3(0, 0, moveDistance);
    }

    void Update()
    {
        Vector3 direction = (movingToTarget ? targetPos : startPos) - transform.position;
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

        
        if (direction.magnitude < 0.1f)
        {
            movingToTarget = !movingToTarget;
        }
    }
}
