using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createclick : MonoBehaviour
{


    public GameObject Box;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            Instantiate(Box,this.transform.position + transform.forward * 5,Quaternion.identity);
        }
    }
}
