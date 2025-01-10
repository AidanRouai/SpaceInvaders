public interface IProjectile
{
    void Move();
    void OnCollision(UnityEngine.Collider2D other);
    event System.Action Destroyed;
}