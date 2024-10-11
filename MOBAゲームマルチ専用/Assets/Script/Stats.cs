using UnityEngine;

public class Stats : MonoBehaviour
{
    public float health = 100;
    public float damage = 0;
    public float attackSpeed = 0;
    
    //被ダメージ
    public void TakeDamage(GameObject target, float damage)
    {
        target.GetComponent<Stats>().health -= damage;
        Debug.Log(target + "に" + damage + "ダメージ");

        if(target.GetComponent<Stats>().health <= 0)
        {
            //HP0で消滅
            Destroy(target.gameObject);
        }
    }
}
