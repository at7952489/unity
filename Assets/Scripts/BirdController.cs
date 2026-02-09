using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdController : MonoBehaviour
{
    [Header("Flight")]
    [SerializeField] private float flapForce = 5.5f;
    [SerializeField] private float maxUpwardVelocity = 7f;

    [Header("Rotation")]
    [SerializeField] private float tiltUpAngle = 25f;
    [SerializeField] private float tiltDownAngle = -60f;
    [SerializeField] private float tiltSpeed = 5f;

    private Rigidbody2D body;
    private bool isAlive = true;

    public bool IsAlive => isAlive;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isAlive)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }

        ApplyTilt();
    }

    public void Flap()
    {
        body.velocity = new Vector2(body.velocity.x, Mathf.Min(0f, body.velocity.y));
        body.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);
        body.velocity = new Vector2(body.velocity.x, Mathf.Min(body.velocity.y, maxUpwardVelocity));
    }

    private void ApplyTilt()
    {
        float targetAngle = Mathf.Lerp(tiltDownAngle, tiltUpAngle, Mathf.InverseLerp(-maxUpwardVelocity, maxUpwardVelocity, body.velocity.y));
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, targetAngle), tiltSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isAlive)
        {
            return;
        }

        isAlive = false;
        GameManager.Instance.OnPlayerDeath();
    }
}
