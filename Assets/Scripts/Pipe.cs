using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private float despawnX = -10f;
    [SerializeField] private int scoreValue = 1;

    private bool hasScored;

    private void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x <= despawnX)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasScored || !other.CompareTag("Player"))
        {
            return;
        }

        hasScored = true;
        GameManager.Instance.AddScore(scoreValue);
    }
}
