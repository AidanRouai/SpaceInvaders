using UnityEngine;

public class BulletProjectile : MonoBehaviour, IProjectile
{
    public Vector3 direction;
    public float speed;
    public event System.Action Destroyed;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnCollision(other);
    }

    public void OnCollision(Collider2D other)
    {
        Destroyed?.Invoke();
        Destroy(this.gameObject);
    }
}