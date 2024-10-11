// 参考のために、マウスポインターをオブジェクトに重ねた時の処理の実装例

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InteractiveObject: MonoBehaviour, IPointerExitHandler
{

    [SerializeField] GameObject endPanel;
    // ポインターがオブジェクトの領域から出た時に呼び出される処理
    public Action<InteractiveObject, PointerEventData> OnPointerExitAction;

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("外");
        if (endPanel.activeSelf == true)
        {
            if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1))
            {
                Debug.Log("押された");
                endPanel.SetActive(false);
            }

        }

        OnPointerExitAction?.Invoke(this, eventData);
    }

    public void ResetAllActions()// すべてのイベントアクションを空にする。
    {

        OnPointerExitAction = null;
    }
}