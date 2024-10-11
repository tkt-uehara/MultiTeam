using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneKIRIKAE : MonoBehaviour
{
    public Button myButton;
    public string MainGameScene;

    //GameObject型の変数aを宣言　好きなゲームオブジェクトをアタッチ
    [SerializeField] private GameObject CreateSession;
    [SerializeField] private GameObject JoinSessionByCode;
    [SerializeField] private GameObject QuickJoinSession;
    [SerializeField] private GameObject LeaveSession;
    [SerializeField] private GameObject ShowSessionCode;
    [SerializeField] private GameObject SessionPlayerList;
    [SerializeField] private GameObject SessionList;
    //[SerializeField] private GameObject TextChat;
    [SerializeField] private GameObject GameStart;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myButton.onClick.AddListener(ChangeScene);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("MainGameScene",LoadSceneMode.Additive);
        CreateSession.SetActive(false);
        JoinSessionByCode.SetActive(false);
        QuickJoinSession.SetActive(false);
        LeaveSession.SetActive(false);
        ShowSessionCode.SetActive(false);
        SessionPlayerList.SetActive(false);
        SessionList.SetActive(false);
        //TextChat.SetActive(false);
        GameStart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
