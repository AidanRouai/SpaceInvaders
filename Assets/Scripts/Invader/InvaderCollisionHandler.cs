using UnityEngine;

public class InvaderCollisionHandler : IHandler
{
    private IHandler nextHandler;
    private System.Action killed;
    private Invader invader;
    public InvaderCollisionHandler(System.Action killedAction)
    {
        this.killed = killedAction;
    }

    public void HandleCollision(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            killed?.Invoke();
            invader.gameObject.SetActive(false);
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