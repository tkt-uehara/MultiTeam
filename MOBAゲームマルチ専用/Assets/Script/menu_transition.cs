using UnityEngine;
using UnityEngine.SceneManagement;

public class transition : MonoBehaviour
{
    [SerializeField] GameObject endPanel;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("押した");

            if (endPanel.activeSelf == false)
            {

                endPanel.SetActive(true);
            }
            else
            {
                
                endPanel.SetActive(false);
            }
        }
    }

    public void Selecttransition(){
        
        SceneManager.LoadScene("SelectChara");
    }

    public void EndGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
        #else
            Application.Quit();//ゲームプレイ終了
        #endif
    }
}
