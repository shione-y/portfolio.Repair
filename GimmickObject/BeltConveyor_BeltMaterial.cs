using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltConveyor_BeltMaterial : MonoBehaviour
{
    //�e����GimmickCondition���Q�Ƃ��Ă���X�N���v�g�����
    beltConveyor _beltConbeyor;

    //���g�̃}�e���A��
    public Material _material;
    //�ړ��l
    public float moveStep = 0.1f;
    Vector2 _texVector;

    void Start()
    {
        _beltConbeyor = transform.parent.gameObject.GetComponent<beltConveyor>();
        //_material = this.GetComponent<Material>();
    }

    void Update()
    {
        //�Ή����郌�o�[���g�p���̊ԁ@�}�e���A�����|�����Ɉړ�������
        if (_beltConbeyor.GC.GetConditionUsing(_beltConbeyor._handlePoint))
        {
            //���݂̒l���擾
            _texVector = _material.mainTextureOffset;
            //�V�����l�̐���
            _texVector.y -= moveStep * Time.deltaTime;
            _material.mainTextureOffset = _texVector;
        }
    }
}
