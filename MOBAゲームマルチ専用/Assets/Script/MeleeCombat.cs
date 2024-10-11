using System.Collections;
using UnityEditor.Analytics;
using UnityEngine;

[RequireComponent(typeof(PlayerController)), RequireComponent(typeof(Stats))]
public class MeleeCombat : MonoBehaviour
{
    private PlayerController Controller_P;
    private Stats stats;
    private Animator anim;

    [Tooltip("クリックオブジェクト格納"),Header("Target")]
    private GameObject MeleeTarget;//PlayerControllerのクリックしたオブジェクトが代入される

    [Header("Melee Attack Variables")]
    public bool performMeleeAttack = true;
    private float attackInterval;
    private float nextAttackTime = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Controller_P = GetComponent<PlayerController>();
        stats = GetComponent<Stats>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        attackInterval = stats.attackSpeed / ((500 + stats.attackSpeed) * 0.01f);

        MeleeTarget = Controller_P.targetObj;//クリックオブジェクト参照

        if(MeleeTarget != null && performMeleeAttack && Time.time > nextAttackTime)
        {
            if(Vector3.Distance(transform.position, MeleeTarget.transform.position) < Controller_P.agent.stoppingDistance)
            {
                StartCoroutine(MeleeAttackInterval(MeleeTarget));
            }
        }
    }

    private IEnumerator MeleeAttackInterval(GameObject target)
    {
        performMeleeAttack = false;

        anim.SetBool("isAttacking", true);

        yield return new WaitForSeconds(attackInterval);

        //敵がまだいた場合
        if(target != null)
        {
            anim.SetBool("isAttacking", false);
            performMeleeAttack = true;
        }
    }

    //アニメーションを呼ぶ
    private void MeleeAttack()
    {
        Debug.Log("anim");
        
        stats.TakeDamage(MeleeTarget, stats.damage);

        //次の攻撃時間設定
        nextAttackTime = Time.time * attackInterval;
        performMeleeAttack = true;

        //ストップ
        anim.SetBool("isAttacking", false);
    }
}
