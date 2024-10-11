using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject[] characters;  // シーン内で動かすキャラクターの配列
    private GameObject activeCharacter;  // 選択されたアクティブなキャラクター

    void Start()
    {
        // 選択されたキャラクターのインデックスをPlayerPrefsから取得
        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacterIndex", -1);

        if (selectedCharacterIndex != -1 && selectedCharacterIndex < characters.Length)
        {
            // 全てのキャラクターを非アクティブにする
            foreach (GameObject character in characters)
            {
                character.SetActive(false);
            }

            // 選択されたキャラクターをアクティブにする
            activeCharacter = characters[selectedCharacterIndex];
            activeCharacter.SetActive(true);
        }
        else
        {
            Debug.LogError("選択されたキャラクターが見つかりません。");
        }
    }
}
