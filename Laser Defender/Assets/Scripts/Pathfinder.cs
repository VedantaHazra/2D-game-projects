using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
   WaveConfigSO waveConfig;
   List<Transform> wavepoints;
   int wavepointIndex= 0;

   void Awake() {
     enemySpawner = FindObjectOfType<EnemySpawner>();
   }
    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        wavepoints = waveConfig.GetWayPoint();
        transform.position = wavepoints[wavepointIndex].position;
        
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(wavepointIndex<wavepoints.Count)
        {
            Vector3 targetPosition = wavepoints[wavepointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                wavepointIndex++;
            }
        }
            else{
                Destroy(gameObject);
            }

        
    }
}
