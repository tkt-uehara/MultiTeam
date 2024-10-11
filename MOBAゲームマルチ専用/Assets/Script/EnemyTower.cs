using UnityEngine;

public class EnemyTower : MonoBehaviour
{
    public float attackRange = 5f;
    public float attackCooldown = 2f;
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public LineRenderer lineRenderer;
    private float nextAttackTime = 0f;
    private GameObject currentTarget;

    private void Update()
    {
        if (currentTarget == null || Vector3.Distance(transform.position, currentTarget.transform.position) > attackRange)
        {
            FindNewTarget();
        }

        UpdateLineToCurrentTarget();

        if (Time.time >= nextAttackTime)
        {
            AttackCurrentTarget();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    private void FindNewTarget()
    {
        GameObject[] minions = GameObject.FindGameObjectsWithTag("AllyMinion");
        float closestDistance = float.MaxValue;

        foreach (GameObject minion in minions)
        {
            float distance = Vector3.Distance(transform.position, minion.transform.position);
            if (distance <= attackRange &&  distance < closestDistance)
            {
                closestDistance = distance;
                currentTarget = minion;
            }
        }
    }

    private void UpdateLineToCurrentTarget()
    {
        if (currentTarget != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, spawnPoint.position);
            lineRenderer.SetPosition(1, currentTarget.transform.position);
;       }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    private void AttackCurrentTarget()
    {
        if (currentTarget != null)
        {
            GameObject projectileGO = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
            Projectile projectile = projectileGO.GetComponent<Projectile>();
            projectile.Seek(currentTarget.transform);
        }
    }
}
