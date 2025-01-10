using UnityEngine;

public interface IInvader
{
    void Animate();
    void OnHit();
    event System.Action Killed;
}