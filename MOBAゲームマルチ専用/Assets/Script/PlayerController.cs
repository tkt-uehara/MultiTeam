using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private CustomActions input;
    public NavMeshAgent agent;
    public Animator anim;

    // リコールシステム
    public bool isStopped = false;

    //キャラ移動変数
    float motionSmoothTime = 0.1f;
    public float rotateSpeedMovement = 0.05f;
    private float rotateVelocity;

    //クリックした敵オブジェクトを追いかける
    [Header("Enemy Targeting")]
    [Tooltip("クリックしたオブジェクト")] public GameObject targetObj;//クリックオブジェクト
    private HighlightManager hmScript;

    //移動ピン
    [Header("ClickEffect")]
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;

    //コンポーネント
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        input = new CustomActions();

        AssignInputs();
    }

    //開始
    void Start()
    {
        hmScript = GetComponent<HighlightManager>();
        targetObj = null;
        // Debug.Log("start");
    }

    //更新
    void Update()
    {
        Animation();
    }

    void LateUpdate()
    {

    }

    //クリック入力検知
    void AssignInputs()
    {
        input.Main.Move.performed += ctx => ClickToMove();
    }

    public void ClickToMove()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            if (hit.collider.tag == "Ground")//地面
            {
                MOVEandROTATE(hit.point);
                agent.stoppingDistance = 0;

                if (targetObj != null)
                {
                    targetObj = null;
                    // hmScript.DeselectedHighlight();//アウトライン
                }
            }
            else if (hit.collider.CompareTag("Enemy"))//敵
            {
                targetObj = hit.collider.gameObject;//オブジェクト代入
                Debug.Log("エネミーをクリック");
                agent.stoppingDistance = 2;
                MOVEandROTATE(hit.point);
                // hmScript.SelectedHighlight();//アウトライン
            }
            else if (hit.collider.CompareTag("Tower"))//タワー
            {
                agent.stoppingDistance = 10f;
                Debug.Log("ディスタンス変更" + agent.stoppingDistance);
                targetObj = hit.collider.gameObject;//オブジェクト代入
                Debug.Log("エネミータワーをクリック");
                MOVEandROTATE(hit.point);
                // hmScript.SelectedHighlight();//アウトライン
            }
        }

        if (targetObj != null || Vector3.Distance(transform.position, targetObj.transform.position) < agent.stoppingDistance)
        {
            agent.SetDestination(targetObj.transform.position);
        }
    }

    //MOVEandROTATE
    public void MOVEandROTATE(Vector3 position)
    {
        agent.destination = position;

        if (clickEffect != null)
        {
            Instantiate(clickEffect, position += new Vector3(0, 0.1f, 0), clickEffect.transform.rotation);
        }

        //キャラクターの向き
        Quaternion rotationToLookAt = Quaternion.LookRotation(position - transform.position);
        float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y,
            ref rotateVelocity, rotateSpeedMovement * (Time.deltaTime * 5));

        transform.eulerAngles = new Vector3(0, rotationY, 0);
    }


    public void Animation()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("Speed", speed, motionSmoothTime, Time.deltaTime);
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }
}
