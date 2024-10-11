using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


 
public class HommingMissile_Tama : MonoBehaviour
{
    public float speed;
    private GameObject[] targets;
    public NavMeshAgent player;
    public GameObject target;
    private bool isSwitch = false;
    public float stopDistance;
    float dis;
 
    private GameObject closeEnemy;
 
    private void Start()
    {
        // タグを使って画面上の全ての敵の情報を取得
        targets = GameObject.FindGameObjectsWithTag("player");
        target = serchTag(gameObject, "player");
 
        // 「初期値」の設定
        float closeDist = 1000;
 
        foreach (GameObject t in targets)
        {
            // コンソール画面での確認用コード
            print(Vector3.Distance(transform.position, t.transform.position));
 
            // このオブジェクト（砲弾）と敵までの距離を計測
            float tDist = Vector3.Distance(transform.position, t.transform.position);
 
            // もしも「初期値」よりも「計測した敵までの距離」の方が近いならば、
            if(closeDist > tDist)
            {
                // 「closeDist」を「tDist（その敵までの距離）」に置き換える。
                // これを繰り返すことで、一番近い敵を見つけ出すことができる。
                closeDist = tDist;
 
                // 一番近い敵の情報をcloseEnemyという変数に格納する（★）
                closeEnemy = t;
            }
        }
 
        // 砲弾が生成されて0.5秒後に、一番近い敵に向かって移動を開始する。
        if (dis <= stopDistance) 
        {
            Invoke("SwitchOn", 0.5f);
        }
        
    }
 
    void Update()
    {
        

        Vector3 targetPos = target.transform.position;
        Vector3 playerPos = player.transform.position;
        float dis = Vector3.Distance(targetPos, playerPos);

        
        if(isSwitch && targets.Length > 0)
        {
            float step = speed * Time.deltaTime;
 
            // ★で得られたcloseEnemyを目的地として設定する。
            transform.position = Vector3.MoveTowards(transform.position, closeEnemy.transform.position, step);
        }
    }
 
    void SwitchOn()
    {
        isSwitch = true;
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

    private void OnCollisionEnter(Collision collision) //ぶつかったら消える命令文開始
    {
        if (collision.gameObject.CompareTag("player"))//さっきつけたTagutukeruというタグがあるオブジェクト限定で～という条件の下
        {
        Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }
    }
}