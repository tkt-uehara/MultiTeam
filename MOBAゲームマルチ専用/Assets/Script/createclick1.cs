using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createclick1 : MonoBehaviour
{
    // 自身のTransform
    [SerializeField] private Transform _self;
    
    // ターゲットのTransform
    [SerializeField] private Transform _target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    private IEnumerator BotGene()
    {   
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
         _self.LookAt(_target);
        StartCoroutine(BotGene());
    }
}
