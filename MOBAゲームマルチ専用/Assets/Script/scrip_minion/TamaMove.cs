using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TamaMove : MonoBehaviour {

 
    public NavMeshAgent player;
    private GameObject target;
    private GameObject[] targets1;
    private GameObject[] targets2;
    private GameObject[] targets3;
    //public float stopDistance;
    //float dis;
    

    
    

    void Start () {
        player  = gameObject.GetComponent<NavMeshAgent>();
        target = serchTag(gameObject, "PlayerMinion");
    }

    void Update () {

        targets1 = GameObject.FindGameObjectsWithTag("PlayerMinion");
        targets2 = GameObject.FindGameObjectsWithTag("PlayerTower");
        targets3 = GameObject.FindGameObjectsWithTag("PlayerTurret");
        //Vector3 playerPos = player.transform.position;
        //Vector3 targetPos = target.transform.position;
        //float dis = Vector3.Distance(targetPos, playerPos);
        
    
        
        if (target != null && targets1.Length >= 0 && targets2.Length >= 0 &&targets3.Length >= 0) 
        {
            Debug.Log("1234578");
            player.destination  = target.transform.position;
        }
        else if(target == null && targets1.Length != 0)
        {
            target = serchTag(gameObject, "PlayerMinion");
        }
        else if(target == null && targets1.Length == 0 && targets2.Length != 0 )
        {
            target = serchTag(gameObject, "PlayerTower");
        }
        else if(target == null && targets1.Length == 0 && targets2.Length == 0 &&targets3.Length != 0)
        {
            target = serchTag(gameObject, "PlayerTurret");  
        }
        
       
    }
    //指定されたタグの中で最も近いものを取得
    GameObject serchTag(GameObject nowObj,string tagName){
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in  GameObject.FindGameObjectsWithTag(tagName)){
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                player.velocity = Vector3.zero;
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
                
            }

        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("PlayerMinion") || collision.gameObject.CompareTag("PlayerTower") ||collision.gameObject.CompareTag("PlayerTurret"))
        {
        Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }
    }
}