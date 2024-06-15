using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private GameObject alertLinePrefab;
    [SerializeField]
    private GameObject StonePrefab;
    [SerializeField]
    private float minSpawnTime = 1.0f;
    [SerializeField]
    private float maxSpawnTime = 4.0f;
    
    private void Awake()
    {
        StartCoroutine("SpawnStone");
    }

    private IEnumerator SpawnStone()
    {
        while ( true )
        {
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            GameObject alertLineClone = Instantiate(alertLinePrefab, new Vector3(positionX, 0, 0), Quaternion.identity);

            yield return new WaitForSeconds(1.0f);
            Destroy(alertLineClone);

            Vector3 StonePosition = new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0);
            Instantiate(StonePrefab, StonePosition, Quaternion.identity);

            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
