using UnityEngine;

public class Invader : MonoBehaviour, IInvader
{
    public Sprite[] animationSprites;
    public float animationTime = 1.0f;
    private SpriteRenderer spriteRenderer;
    private int animationFrame;
    public event System.Action Killed;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(Animate), this.animationTime, this.animationTime);
    }

    public void Animate()
    {
        animationFrame++;

        if (animationFrame >= this.animationSprites.Length)
        {
            animationFrame = 0;
        }

        spriteRenderer.sprite = this.animationSprites[animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            OnHit();
        }
    }

    public void OnHit()
    {
        Killed?.Invoke();
        this.gameObject.SetActive(false);
    }
}