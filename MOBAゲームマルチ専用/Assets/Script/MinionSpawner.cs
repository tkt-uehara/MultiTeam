using UnityEngine;
using System.Collections;
public class MinionSpawner : MonoBehaviour
{
     public float minionMoveSpeed;
    public float superMinionMoveSpeed;

    public GameObject minionPrefab;
    public GameObject SuperMinionPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 20.0f;
    public int minionsPerWave = 6;
    public int wavesUntilSuperMinion = 3;
    private int waveCount = 0;

    public float delayBetweenMinions;

    private void Start()
    {
        StartCoroutine(SpawnMinions());
        
    }

    private IEnumerator SpawnMinions()
    {
        
        while (true)
        {
            waveCount++;

            if (waveCount % wavesUntilSuperMinion == 0)
            {
                for (int i = 0; i < minionsPerWave - 1; i++)
                {
                    SpawnRegularMinion();
                    yield return new WaitForSeconds(delayBetweenMinions);
                }

                SpawnRegularMinion();
                yield return new WaitForSeconds(delayBetweenMinions);

                SpawnSuperMinion();
                yield return new WaitForSeconds(spawnInterval - delayBetweenMinions * (minionsPerWave - 1) - delayBetweenMinions);
            }
            else
            {
                for(int i = 0; i < minionsPerWave; i++)
                {
                    SpawnRegularMinion();
                    yield return new WaitForSeconds(delayBetweenMinions);
                }
                yield return new WaitForSeconds(spawnInterval - delayBetweenMinions * minionsPerWave);
            }
        }
    }

    private void SpawnRegularMinion()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject minion = Instantiate(minionPrefab, spawnPoint.position, spawnPoint.rotation);

        UnityEngine.AI.NavMeshAgent minionAgent = minion.GetComponent<UnityEngine.AI.NavMeshAgent>();
        minionAgent.speed = minionMoveSpeed;
    }

    private void SpawnSuperMinion()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject superMinion = Instantiate(minionPrefab, spawnPoint.position, spawnPoint.rotation);
        
        UnityEngine.AI.NavMeshAgent superMinionAgent = superMinion.GetComponent<UnityEngine.AI.NavMeshAgent>();
        superMinionAgent.speed = superMinionMoveSpeed;
    }
}




