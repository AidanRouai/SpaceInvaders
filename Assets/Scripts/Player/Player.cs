using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;
    private IHandler collisionHandler;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
        collisionHandler = new PlayerCollisionHandler();
    }

    private void Update()
    {
        playerMovement.HandleMovement();
        playerAttack.HandleShooting();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        collisionHandler.HandleCollision(other);
    }
}