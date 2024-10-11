using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ememyminion : MonoBehaviour {

    private Animator animator = null;

    public int DMG=0;
    public GameObject enemy;
    public NavMeshAgent player;
    private GameObject target;
    private GameObject target2;
    private GameObject[] targets1;
    private GameObject[] targets2;
    private GameObject[] targets3;
    private GameObject[] Tama;
    public float stopDistance;
    private float dis;
    private NavMeshAgent agent;


    //最大HPと現在のHP。
    int maxHp = 100;
    int Hp;
    //Slider
    public Slider slider;
    

    
    

    void Start () {

        animator = GetComponent<Animator>();

        player  = gameObject.GetComponent<NavMeshAgent>();
        target = serchTag(gameObject, "PlayerMinion");
        
        //Sliderを最大にする。
        slider.value = 100;
        //HPを最大HPと同じ値に。
        Hp = maxHp;
        
        Vector3 targetPos = target.transform.position;
        Vector3 playerPos = player.transform.position;
        float dis = Vector3.Distance(targetPos, playerPos);



        agent = GetComponent<NavMeshAgent>();
        //nextGoal();
    }


    void nextGoal(){
        var randomPos = new Vector3(Random.Range(0,10),0,Random.Range(0,10));
        agent.destination = randomPos;
    }

    void Update () {
        
        targets1 = GameObject.FindGameObjectsWithTag("PlayerMinion");
        targets2 = GameObject.FindGameObjectsWithTag("PlayerTower");
        targets3 = GameObject.FindGameObjectsWithTag("PlayerTurret");
        
 
        //"Turret"
        if (target != null && targets1.Length >= 0 && targets2.Length >= 0 &&targets3.Length >= 0) //target2 != null && dis != stopDistance
        {
            //Debug.Log("もずく");
            animator.SetBool("WalkBool",true);

            player.destination  = target.transform.position;
            Vector3 targetPos = target.transform.position;
            Vector3 playerPos = player.transform.position;
            float dis = Vector3.Distance(targetPos, playerPos);
            Tama = GameObject.FindGameObjectsWithTag("Minion_Tama");
            if(Tama.Length == 0 && dis <= stopDistance)
            {
            Instantiate(enemy,this.transform.position,Quaternion.identity);
            Debug.Log(transform.position);
            }
            //Debug.Log(dis);
        }
        else if(target == null && targets1.Length != 0)
        {
            Debug.Log("さだがる");
            target = serchTag(gameObject, "PlayerMinion");  
            
            Vector3 targetPos = target.transform.position;
            Vector3 playerPos = player.transform.position;
            float dis = Vector3.Distance(targetPos, playerPos);
        }
        else if(target == null && targets1.Length == 0 && targets2.Length != 0)
        {
            Debug.Log("くるみ");
            target = serchTag(gameObject, "PlayerTower");  
            
            Vector3 targetPos = target.transform.position;
            Vector3 playerPos = player.transform.position;
            float dis = Vector3.Distance(targetPos, playerPos);
        }
        else if(target == null && targets1.Length == 0 && targets2.Length == 0 &&targets3.Length != 0)
        {
            Debug.Log("もみじ");
            target = serchTag(gameObject, "PlayerTurret");  
            
            Vector3 targetPos = target.transform.position;
            Vector3 playerPos = player.transform.position;
            float dis = Vector3.Distance(targetPos, playerPos);
        }
        else if(target == null && targets1.Length == 0 && targets2.Length == 0 && targets3.Length == 0)
        {
            Debug.Log("ビー玉");
            nextGoal();
        }
        
       
    }
    //指定されたタグの中で最も近いものを取得
    GameObject serchTag(GameObject nowObj,string tagname){
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in  GameObject.FindGameObjectsWithTag(tagname)){
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
        if (collision.gameObject.CompareTag("Tama"))
        {
        //Destroy(gameObject);//このゲームオブジェクトを消滅させる

        //HPから1を引く
            Hp = Hp - DMG;

            //HPをSliderに反映。
            slider.value = (float)Hp;
        }
        if(Hp <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    
}