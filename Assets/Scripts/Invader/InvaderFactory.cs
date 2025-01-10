using UnityEngine;
using UnityEngine.SceneManagement;

public class InvaderFactory : MonoBehaviour
{
    public Invader[] prefabs;
    public int rows = 5;
    public int columns = 11;
    public AnimationCurve speed;
    public Projectile missilePrefab;
    public int amountKilled { get; private set; }
    public int totalInvaderDeaths => this.rows * this.columns;
    public float percentKilled => (float)this.amountKilled / (float)this.totalInvaderDeaths;
    public float amountAlive => this.totalInvaderDeaths - (float)this.amountKilled;
    private Vector3 direction = Vector2.right;
    public float missileAttackRate = 1.0f;

    private void Awake()
    {
        CreateInvaders();
    }

    private void Start()
    {
        InvokeRepeating(nameof(MissileAttack), this.missileAttackRate, this.missileAttackRate);
    }

    private void Update()
    {
        MoveInvaders();
    }

    private void CreateInvaders()
    {
        for (int row = 0; row < this.rows; row++)
        {
            float width = 2.0f * (this.columns - 1);
            float height = 2.0f * (this.rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);
            for (int col = 0; col < this.columns; col++)
            {
                Invader invader = Instantiate(this.prefabs[row], this.transform);
                invader.Killed += InvaderKilled;
                Vector3 position = rowPosition;
                position.x += col * 2.0f;
                invader.transform.localPosition = position;
            }
        }
    }

    private void MoveInvaders()
    {
        this.transform.position += direction * this.speed.Evaluate(this.percentKilled) * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (direction == Vector3.right && invader.position.x >= rightEdge.x - 1.0f)
            {
                AdvanceRow();
            }
            else if (direction == Vector3.left && invader.position.x <= leftEdge.x + 1.0f)
            {
                AdvanceRow();
            }
        }
    }

    private void AdvanceRow()
    {
        direction.x *= -1.0f;
        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;
    }

    public void MissileAttack()
    {
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy) { continue; }

            if (Random.value < (1.0f / (float)this.amountAlive))
            {
                Instantiate(this.missilePrefab, invader.position, Quaternion.identity);
                break;
            }
        }
    }

    private void InvaderKilled()
    {
        amountKilled++;

        if (this.amountKilled >= this.totalInvaderDeaths)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}