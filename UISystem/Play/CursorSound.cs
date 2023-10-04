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

    //�I�𒆂�GameObject
    private GameObject _th = null; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�I�����Ă����I�u�W�F�N�g���ς�����Ƃ�
        if (_th != EventSystem.current.currentSelectedGameObject)
        {
            _th = EventSystem.current.currentSelectedGameObject;
            //����炷����;
            _audio.Play();
        }
    }
}
