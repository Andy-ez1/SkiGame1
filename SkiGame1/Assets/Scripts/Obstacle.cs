using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public delegate void OnHitAction();
    public static event OnHitAction OnObstacleHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
            OnObstacleHit.Invoke();
    }
}