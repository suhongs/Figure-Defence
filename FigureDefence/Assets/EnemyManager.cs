using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float speed = 10.0f;

    private Transform target;
    private int wavePointIndex = 0;

    private void Start()
    {
        target = Waypoints.wayPoints[wavePointIndex];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            getNextWayPoint();
        }
    }

    private void getNextWayPoint()
    {

        if (++wavePointIndex == Waypoints.wayPoints.Length)
        {
            Destroy(gameObject);
            return;
        }
        target = Waypoints.wayPoints[wavePointIndex];
    }
}
