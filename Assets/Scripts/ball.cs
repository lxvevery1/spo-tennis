using Mirror;
using UnityEngine;
public class ball : NetworkBehaviour
{
    public Vector2 PosBall;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField, SyncVar] public float speed = 3f;
    [SerializeField] public int ScorePlayer1, ScorePlayer2;
    private float BallBorder = 12f;
    private float MaxSpeed = 10f;
    float x, y;
    public Vector2 startPosition;

    public override void OnStartServer()
    {
        base.OnStartServer();

        rb.velocity = Vector2.right * speed;
    }
    
    private void Start()
    {
        _Reset();
        startPosition = transform.position;
    }

    void Update()
    {
        SpeedLimit();
        Score();
        PosBall = transform.position;
    }
    private void Launch()
    {
        x = Random.Range(-1, 0) == 0 ? -1 : 1;
        y = Random.Range(-1, 0) == 0 ? -1 : 1;
        rb.velocity = (new Vector2(speed * x, speed * y));
    }
    private void SpeedLimit()
    {
        if (rb.velocity.magnitude > MaxSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
        }
    }
    private void Score() // –естарт игры при вылете м€ча за рамки
    {
        if (PosBall.x < -BallBorder)
        {
            ScorePlayer2 += 1;
            _Reset();
        }

        if (PosBall.x > BallBorder)
        {
            ScorePlayer1 += 1;
            _Reset();
        }
    }
    private void _Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        Launch();
    }
    
    float HitFactor(Vector2 ballpos, Vector2 diskpos, float diskHeight)
    {
        return ((ballpos.y - diskpos.y) / diskHeight);
    }
    [ServerCallback]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<player1behaviour>())
        {
            float y = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);

            float x = collision.relativeVelocity.x > 0 ? 1 : -1;

            Vector2 dir = new Vector2(x, y).normalized;

            rb.velocity = dir * speed;
        }
    }
}