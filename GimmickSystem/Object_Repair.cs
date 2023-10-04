using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�@�C�����s������
//�@��̂���Ă���I�u�W�F�N�g�ɂ���
public class Object_Repair : ObjectCategory
{

    //����(purehabu)
    public GameObject difference;
    //����(object)
    [NonSerialized]
    public GameObject _difference = null;

    void Start()
    {
        //���g�̉�̏C���̃X�e�[�^�X��ύX����
        overhaulState = ObjectCategory.State.Repair;

        //Debug.Log(difference.name);
        if (_difference == null)
        {
            //Debug.Log(difference.name + "�Ɠ������O�̃I�u�W�F�N�g�͂Ȃ�����");
            //�����I�u�W�F�N�g���ɐ������āASetActive(false)�ɂ��Ă���
            _difference = Instantiate(difference, this.transform.position, Quaternion.identity);
            _difference.GetComponent<Object_Demolish>()._difference = this.gameObject;
        }
        _difference.SetActive(false);
    }

    void Update()
    {

    }

    // �C��
    public override void Repair()
    {
        //Debug.Log("�C��");
        //�Q�[���}�l�W���[�Ɂu���̃I�u�W�F�N�g�v���u�C�������v�|��`����
        GC.Repair(this.gameObject);

        //�@������\������
        _difference.SetActive(true);

        // ���n���ǉ� -----------------------------------------------------------------------------------------------------
        // �ʒu�E���������킹��
        _difference.transform.position = this.transform.position;
        _difference.transform.rotation = this.transform.rotation;
        // ----------------------------------------------------------------------------------------------------------------

        //GimmickCondition�̃��X�g������������
        //�Y����
        int num = GC.GetOwnPoint(this.gameObject);
        //��������
        GC.SetObject(num, _difference);


        //�@���g���\���ɂ���
        this.gameObject.SetActive(false);
    }

    //�C���Ɏg�����i�̎�ނ������Ă��邩�̔���
    public override bool GetRightRepairPats(Transform mono)
    {
        // ����A���Ă���̂��{���g�F�C���Ɏg�����̂Ƃ��Đ��������̂����Ȃ����߁A�s�v�H
        // ���ɑ��������p�Ɉꉞ�c���Ă��������ǂ�����
        if (mono == null) { return false; }

        return mono.CompareTag("Bolt");
    }


}
