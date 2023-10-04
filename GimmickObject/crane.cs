using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�N���[���������X�N���v�g
//�N���[���{�̂ɂ��āAcable�ϐ��ɊY������P�[�u���������i�[����

//���_�F�P�[�u���̐�̓S�����̃X�P�[���܂ŕω�������̂ł͂Ȃ����H
public class crane : MonoBehaviour
{
    //GimmickCondition test
    //���ۂ�GimmickCondition�N���X�̃��X�g�̒l������悤�ɂ���
    public bool GimmickCondition = false;

    //�R
    [Tooltip("�P�[�u��")]
    public GameObject cable;
    [Tooltip("�P�[�u�����ǂ��܂ŐL�΂����i�X�P�[���j")]
    public float scaleNum;
    // ------------------------------------------------------------
    [Tooltip("��[�̉ו�")]
    public Transform load;

    //�P�[�u���̐�[
    public Vector3 _cableTip;
    // -------------------------------------------------------------

    //�P�[�u���̃X�P�[��
    private Vector3 _scale;
    private Vector3 _position;
    private float num = 0.0f;

    void Start()
    {
        //GimmickCondition�̒T��
        _position = cable.GetComponent<Transform>().position;
        _scale = cable.GetComponent<Transform>().localScale;
        // ------------------------------------------------------
        _cableTip = cable.GetComponentInChildren<Transform>().position;
        Debug.Log(_cableTip);

    }

    void Update()
    {
        if (GimmickCondition == true)
        {
            if (cable.transform.localScale.y <= scaleNum)
            {
                //�N���[���̂Ђ��̕�����L�΂�
                num = 0.5f * Time.deltaTime;
                _scale.y += num;
                cable.transform.localScale = _scale;
                //�N���[���̎x�_�����̈ʒu�����炳�Ȃ��悤�Ɉړ�������
                _position.y -= num;
                cable.transform.position = _position;
                //��[�̉ו���position���ړ������� ------------------------------------
                load.position = new Vector3(_cableTip.x, _cableTip.y, _cableTip.z);
            }
        }
        else if(GimmickCondition == false && cable.transform.localScale.y >= 1)
        {
            BackCable();
        }
    }

    //�N���[���̃P�[�u���������߂��i�g�����킩��Ȃ����Ǎ���Ă݂��j
    void BackCable()
    {
        //�N���[���̂Ђ��̕�����L�΂�
        num = 0.5f * Time.deltaTime;
        _scale.y -= num;
        cable.transform.localScale = _scale;
        //�N���[���̎x�_�����̈ʒu�����炳�Ȃ��悤�Ɉړ�������
        _position.y += num;
        cable.transform.position = _position;
        //��[�̉ו���position���ړ������� ---------------------------------
        load.position = new Vector3(_cableTip.x, _cableTip.y, _cableTip.z);

    }
}
