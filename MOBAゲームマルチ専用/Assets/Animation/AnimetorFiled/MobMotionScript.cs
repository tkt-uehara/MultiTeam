using System.Collections;
using UnityEngine;

public class MobMotionScript: MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            animator.SetTrigger("qAttack");
        }

        if (Input.GetKeyDown("w"))
        {
            animator.SetTrigger("wAttack");
        }

        if (Input.GetKeyDown("e"))
        {
            animator.SetTrigger("eDie");
        }
    }
}