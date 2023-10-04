using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorSound : MonoBehaviour
{
    //EventSystem
    //[SerializeField]
    //private EventSystem _event;
    //AudioSorce
    [SerializeField]
    private AudioSource _audio;

    //選択中のGameObject
    private GameObject _th = null; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //選択していたオブジェクトが変わったとき
        if (_th != EventSystem.current.currentSelectedGameObject)
        {
            _th = EventSystem.current.currentSelectedGameObject;
            //音を鳴らす処理;
            _audio.Play();
        }
    }
}
