using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "newWaveConfig", menuName = "WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefab;
   [SerializeField] Transform pathPrefab;
   [SerializeField] float moveSpeed = 5f;

   [SerializeField] float timeBetweenEnemySpawn = 1f;
   [SerializeField] float spawnTimeVariance = 0.5f;
   [SerializeField] float minimumSpawnTime = 0.2f;


   public int GetEnemyCount()
   {
    return enemyPrefab.Count;
   }
   public GameObject GetEnemyPrefab(int index)
   {
    return enemyPrefab[index];
   }

   public Transform GetStartingWaypoint()
   {
    return pathPrefab.GetChild(0);
   }

   public List<Transform> GetWayPoint()
   {
    List<Transform> waypoints = new List<Transform>();
    foreach(Transform child in pathPrefab)
    {
        waypoints.Add(child);
    }
    return waypoints;
   }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawn-spawnTimeVariance, timeBetweenEnemySpawn+spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
