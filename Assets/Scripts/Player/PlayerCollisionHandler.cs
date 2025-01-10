using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : IHandler
{
    private IHandler nextHandler;

    public void HandleCollision(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader") ||
            other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            nextHandler?.HandleCollision(other);
        }
    }

    public void SetNext(IHandler nextHandler)
    {
        this.nextHandler = nextHandler;
    }
}