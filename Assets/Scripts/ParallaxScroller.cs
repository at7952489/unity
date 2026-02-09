using UnityEngine;

public class ParallaxScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.5f;
    [SerializeField] private float resetX = -10f;
    [SerializeField] private float startX = 10f;

    private void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        if (transform.position.x <= resetX)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = startX;
            transform.position = newPosition;
        }
    }
}
