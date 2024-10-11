using UnityEngine;
using UnityEngine.AI;

public class MinionAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform currentTarget;
    public string enemyMinionTag = "EnemyMinion";
    public string turretTag = "Turret";
    public float stopDistance = 2.0f;
    public float aggroRange = 5.0f;
    public float targetSwitchInterval = 2.0f;

    private float timeSinceLastTargetSwitch = 0.0f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        FindAndSetTarget();
    }

    private void Update()
    {
        timeSinceLastTargetSwitch += Time.deltaTime;

        if (timeSinceLastTargetSwitch >= targetSwitchInterval)
        {
            ChecckAndSwitchTargets();
            timeSinceLastTargetSwitch = 0.0f;
        }

        if (currentTarget != null)
        {
            Vector3 directionToTarget = currentTarget.position - transform.position;

            Vector3 stoppingPosition = currentTarget.position - directionToTarget.normalized * stopDistance;

            agent.SetDestination(stoppingPosition);
        }
    }

    private void ChecckAndSwitchTargets()
    {
        GameObject[] enemyMinions = GameObject.FindGameObjectsWithTag(enemyMinionTag);
        Transform closestEnemyMinion = GetClosestObjectInRadius(enemyMinions, aggroRange);

        if (closestEnemyMinion != null)
        {
            currentTarget = closestEnemyMinion;
        }
        else
        {
            GameObject[] turrets = GameObject.FindGameObjectsWithTag(turretTag);
            currentTarget = GetClosestObject(turrets);
        }
    }

    private Transform GetClosestObject(GameObject[] objects)
    {
        float closestDistance = Mathf.Infinity;
        Transform closestObject = null;
        Vector3 currentPosition = transform.position;

        foreach (GameObject obj in objects)
        {
            float distance = Vector3.Distance(currentPosition, obj.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = obj.transform;
            }
        }
        return closestObject;
    }

    private Transform GetClosestObjectInRadius(GameObject[] objects, float radius)
    {
        float closestDistance = Mathf.Infinity;
        Transform closestObject = null;
        Vector3 currentPosition = transform.position;

        foreach (GameObject obj in objects)
        {
            float distance = Vector3.Distance(currentPosition, obj.transform.position);

            if (distance < closestDistance && distance <= radius)
            {
                closestDistance = distance;
                closestObject = obj.transform;
            }
        }
        return closestObject;
    }
    private void FindAndSetTarget()
    {
        GameObject[] enemyMinions = GameObject.FindGameObjectsWithTag(enemyMinionTag);

        Transform closestEnemyMinion = GetClosestObjectInRadius(enemyMinions, aggroRange);

        if (closestEnemyMinion != null)
        {
            currentTarget = closestEnemyMinion;
        }
        else
        {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag(turretTag);
        currentTarget = GetClosestObject(turrets);
        }
    }
}



    
    