using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private BallStarter _ballStarter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ball ball))
        {
            _health.DoDamage();
            _ballStarter.ResetBall();
        }       
    }
}
