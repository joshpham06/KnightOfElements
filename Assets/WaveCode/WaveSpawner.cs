using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaveSpawner : MonoBehaviour
{
    public GameObject Player;
    public GameObject SafeRadius;
    public Tilemap Tilemap;
    private GameObject Prefab;

    public int SpawnedThisWave;

    private bool IsActive = false;
    private bool IsSpawning = false;
    private Coroutine SpawnRoutine;
    private int TotalToSpawn;
    private float MinInterval;
    private float MaxInterval;

    public void StartWave(GameObject prefab, int enemyCount, float waveDuration, float variance = 0.8f)
    {
        Prefab = prefab;
        TotalToSpawn = enemyCount;
        SpawnedThisWave = 0;

        float averageInterval = waveDuration / enemyCount;
        MinInterval = averageInterval - variance;
        MaxInterval = averageInterval + variance;

        IsActive = true;

        if (SpawnRoutine != null)
            StopCoroutine(SpawnRoutine);

        SpawnRoutine = StartCoroutine(SpawnLoop());
    }

    public void StopWave()
    {
        IsActive = false;
        if (SpawnRoutine != null)
            StopCoroutine(SpawnRoutine);
    }

    private IEnumerator SpawnLoop()
    {
        IsSpawning = true;

        while (IsActive && SpawnedThisWave < TotalToSpawn)
        {
            float waitTime = Random.Range(MinInterval, MaxInterval);
            yield return new WaitForSeconds(waitTime);

            Vector3 pos = RandomLocationOutsideSafeRadius();
            Instantiate(Prefab, pos, Quaternion.identity);

            SpawnedThisWave++;
        }

        IsSpawning = false;
    }

    private Vector3 RandomLocationOutsideSafeRadius()
    {
        CircleCollider2D safeCircle = SafeRadius.GetComponent<CircleCollider2D>();
        safeCircle.isTrigger = true;
        float safeRadius = safeCircle.radius * SafeRadius.transform.localScale.x;
        Vector2 center = safeCircle.transform.position;

        Vector3 bottomLeft = GetBottomLeft();
        Vector3 topRight = GetTopRight();

        CapsuleCollider2D enemyCollider = Prefab.GetComponent<CapsuleCollider2D>();

        Vector3 randomPos = Vector3.zero;
        int attempts = 0;
        int maxAttempts = 100;

        while (attempts < maxAttempts)
        {
            float x = Random.Range(bottomLeft.x, topRight.x);
            float y = Random.Range(bottomLeft.y, topRight.y);
            randomPos = new Vector3(x, y, 0);

            bool outsideSafeRadius = Vector2.Distance(randomPos, center) >= safeRadius;

            bool noCollision = true;
            if (enemyCollider != null)
            {
                Vector2 size = enemyCollider.size;
                Vector2 pointA = (Vector2)randomPos - size / 2;
                Vector2 pointB = (Vector2)randomPos + size / 2;
                noCollision = Physics2D.OverlapArea(pointA, pointB) == null;
            }

            if (outsideSafeRadius && noCollision)
                return randomPos;

            attempts++;
        }

        return center + new Vector2(safeRadius + 0.5f, 0);
    }

    private Vector3 GetBottomLeft()
    {
        BoundsInt bounds = Tilemap.cellBounds;
        return Tilemap.CellToWorld(bounds.min);
    }

    private Vector3 GetTopRight()
    {
        BoundsInt bounds = Tilemap.cellBounds;
        return Tilemap.CellToWorld(bounds.max);
    }
}