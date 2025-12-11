using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Serializable class so you can edit waves in the inspector
[System.Serializable]
public class Wave
{
    public string Name;
    public GameObject EnemyPrefab;
    public int EnemyCount;
    public float WaveDuration;
    public float SpawnVariance = 0.8f;
}

public class WaveManager : MonoBehaviour
{
    public WaveSpawner Spawner;
    public List<Wave> Waves;
    public float TimeBetweenWaves = 5f;

    private int currentWaveIndex = 0;

    void Start()
    {
        if (Waves.Count > 0)
            StartCoroutine(RunWaves());
    }

    private IEnumerator RunWaves()
    {
        while (currentWaveIndex < Waves.Count)
        {
            Wave wave = Waves[currentWaveIndex];
            
            //Starting Wave

            Spawner.StartWave(wave.EnemyPrefab, wave.EnemyCount, wave.WaveDuration, wave.SpawnVariance);

            yield return new WaitUntil(() =>
                Spawner.SpawnedThisWave >= wave.EnemyCount &&
                GameObject.FindGameObjectsWithTag(wave.EnemyPrefab.tag).Length == 0
            );

            // Wave Completed
            
            currentWaveIndex++;

            yield return new WaitForSeconds(TimeBetweenWaves);
        }

        // Add Waves Completed
    }
}