using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Pipe pipePrefab;
    [SerializeField] private float spawnInterval = 1.6f;
    [SerializeField] private float minHeight = -1.5f;
    [SerializeField] private float maxHeight = 2.2f;

    private float nextSpawnTime;

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnPipe();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnPipe()
    {
        if (pipePrefab == null)
        {
            return;
        }

        float yPosition = Random.Range(minHeight, maxHeight);
        Vector3 spawnPosition = new Vector3(transform.position.x, yPosition, transform.position.z);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
}
