using System.Collections;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    private float speed = 3.0f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            animator.SetBool("WalkBool",true);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            animator.SetBool("WalkBool", true);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
            animator.SetBool("WalkBool", true);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
            animator.SetBool("WalkBool", true);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("WalkBool", false);
        }

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
            animator.SetTrigger("eAttack");
        }
    }
}
