using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }
}
