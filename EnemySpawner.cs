using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private int maxEnemyCount = 100; //stage maximum enemy
    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        int currentEnemyCount = 0;
        
        while ( true )
        {
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            Instantiate(enemyPrefab, new Vector3(positionX, stageData.LimitMax.y-13.0f, 0.0f), Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
