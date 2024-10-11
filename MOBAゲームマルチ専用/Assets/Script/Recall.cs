using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recall : MonoBehaviour
{
    private PlayerController playScript;  // PlayScriptのインスタンスを取得
    bool isStopped = false;  // 内部でのフラグ管理
    [SerializeField] public GameObject recallObject;  // ターゲットオブジェクトをインスペクタで設定

    void Start()
    {
        playScript = GetComponent<PlayerController>();

    }
    void Update()
    {
        if (playScript == null) return;  // playScriptが設定されていない場合、処理をスキップ

        // Zキー（停止）を押した場合
        if (Input.GetKeyDown(KeyCode.Z) && !isStopped)
        {
            StartCoroutine(StopAndTeleport());
        }
    }

    private IEnumerator StopAndTeleport()
    {
        isStopped = true;  // 停止中フラグをセット
        playScript.isStopped = true;  // PlayScriptの移動を停止

        Debug.Log("プレイヤー停止");

        // 3秒間待機
        yield return new WaitForSeconds(3);

        if (recallObject != null)
        {
            // ターゲットオブジェクトの位置に瞬間移動
            transform.position = recallObject.transform.position;
        }

        Debug.Log("瞬間移動完了");

        // 移動の再開
        playScript.isStopped = false;
        isStopped = false;  // 停止中フラグをリセット
    }
}
