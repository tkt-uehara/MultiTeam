using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameset : MonoBehaviour
{

    public GameObject canvas;
    public GameObject particle;
    public ParticleSystem particle1;


    void Start()
    {
        canvas.SetActive(false);
        particle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            canvas.SetActive(true);
        }
        if(canvas.activeSelf != false)
        {
            Debug.Log("スズメ") ;
            particle.SetActive(true);
            //particle1.Play();//再生
            //SceneManager.LoadScene("Test_scenes");
            StartCoroutine(DelayCoroutine());
        }
        
        
    }
    private IEnumerator DelayCoroutine()
    {
        // 3秒間待つ
        yield return new WaitForSeconds(9);
        SceneManager.LoadScene("Test_scenes");
    }
    
        
}