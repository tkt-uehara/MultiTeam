using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectSelector : MonoBehaviour
{
    public GameObject[] objects;  // 選択対象のオブジェクトを保持する配列
    private int selectedCharacterIndex = -1;  // 選択されたキャラクターのインデックスを保持

    void Start()
    {
        // 全てのオブジェクトを非アクティブにする
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }

    // 特定のオブジェクトを選択して表示
    public void SelectObject(int index)
    {
        // 全てのオブジェクトを非アクティブにする
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }

        // 指定されたインデックスのオブジェクトをアクティブにする
        if (index >= 0 && index < objects.Length)
        {
            objects[index].SetActive(true);
            selectedCharacterIndex = index;  // 選択されたキャラクターのインデックスを保存
        }
        else
        {
            Debug.LogWarning("指定されたインデックスが範囲外です。");
        }
    }

    // 決定ボタンが押されたときにシーンを切り替える
    public void ConfirmSelection()
    {
        if (selectedCharacterIndex != -1)
        {
            // 選択されたキャラクターのインデックスをPlayerPrefsに保存
            PlayerPrefs.SetInt("SelectedCharacterIndex", selectedCharacterIndex);

            // 新しいシーンに移動
            SceneManager.LoadScene("MainGameScene clone 1");
        }
        else
        {
            Debug.LogWarning("キャラクターが選択されていません。");
        }
    }
}
