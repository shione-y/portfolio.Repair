using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//�Y���|�b�v�A�b�v�̕\����\�����s��

public class Popup_displaySwitching : MonoBehaviour
{
    //�Y���|�b�v�A�b�v
    [SerializeField]
    private GameObject _popup;

    //ButtonSelect
    EventSystem eventSystem;
    private void Start()
    {
        //�R���|�[�l���g�擾
        eventSystem = GameObject.FindObjectOfType<EventSystem>();
    }

    //�\��
    public void Activate()
    {
        _popup.SetActive(true);
    }

    //��\��
    public void Inactivate()
    {
        _popup.SetActive(false);
        //���ݑI������Ă���Q�[���I�u�W�F�N�g��null�ɂ���
        eventSystem.SetSelectedGameObject(null);
    }
}
