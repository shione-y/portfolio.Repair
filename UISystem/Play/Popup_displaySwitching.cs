using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//該当ポップアップの表示非表示を行う

public class Popup_displaySwitching : MonoBehaviour
{
    //該当ポップアップ
    [SerializeField]
    private GameObject _popup;

    //ButtonSelect
    EventSystem eventSystem;
    private void Start()
    {
        //コンポーネント取得
        eventSystem = GameObject.FindObjectOfType<EventSystem>();
    }

    //表示
    public void Activate()
    {
        _popup.SetActive(true);
    }

    //非表示
    public void Inactivate()
    {
        _popup.SetActive(false);
        //現在選択されているゲームオブジェクトをnullにする
        eventSystem.SetSelectedGameObject(null);
    }
}
