using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Vector2 speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] protected int _value = 10;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = speed * Time.fixedDeltaTime;
        _rb.rotation += rotationSpeed * Time.fixedDeltaTime;
    }
    
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
