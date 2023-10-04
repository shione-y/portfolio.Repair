using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//��̂��s������
//�C������Ă����Ԃ̃I�u�W�F�N�g�ɂ���
public class Object_Demolish : ObjectCategory
{
    //����
    public GameObject difference;
    //����(object)
    [NonSerialized]
    public GameObject _difference = null;

    void Start()
    {
        //���g�̉�̏C���̃X�e�[�^�X��ύX����
        overhaulState = ObjectCategory.State.Demolish;

        //Debug.Log(difference.name);
        if (_difference == null)
        {
            //�����I�u�W�F�N�g���ɐ������āASetActive(false)�ɂ��Ă���
            _difference = Instantiate(difference, this.transform.position, Quaternion.identity);
            _difference.GetComponent<Object_Repair>()._difference = this.gameObject;
        }
        _difference.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Dismatle()
    {
        //�Q�[���}�l�W���[�Ɂu���̃I�u�W�F�N�g�v���u��̂����v�|��`����
        GC.Demolish(this.gameObject);

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

}
