using UnityEngine;

public interface IHandler
{
    void HandleCollision(Collider2D other);
    void SetNext(IHandler nextHandler);
}