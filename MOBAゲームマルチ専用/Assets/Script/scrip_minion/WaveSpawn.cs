using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    public GameObject[] bots;

    private int waveNum = 4;
    private int botNum = 0;
    private int c = 0;
    

    

    private IEnumerator BotGene()
    {
        while(true)
        {
            //yield return new WaitForSeconds(5f);
            if(c % 3 != 0 || c == 0)
            {
                for (int j = 0; j < waveNum; j++)
                {
                    Instantiate(bots[botNum], transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(1f);
                }
            }
            

            //waveNum += 1;

            // 改良（ランダム化のテクニック）
            //int rnd = Random.Range(1, 10);
            else if(c % 3 == 0 && c != 0)
            {
                Instantiate(bots[0], transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1f);
                Instantiate(bots[0], transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1f);
                Instantiate(bots[0], transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1f);
                Instantiate(bots[1], transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                botNum = 0;
            }
            c++;

            yield return new WaitForSeconds(5f);
        }
    }
    
    
    void Start()
    {
        StartCoroutine(BotGene());
    }
}