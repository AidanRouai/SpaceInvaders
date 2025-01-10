using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Projectile bulletPrefab;
    private bool bulletActive;

    public void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!bulletActive)
        {
            Projectile projectile = Instantiate(this.bulletPrefab, this.transform.position, Quaternion.identity);
            projectile.destroyed += BulletDestroyed;
            bulletActive = true;
        }
    }

    private void BulletDestroyed()
    {
        bulletActive = false;
    }
}