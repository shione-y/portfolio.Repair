using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//�@Transform�𒼐ڏ���������h�A�̊J����
//�@��X���₷���悤�ɏ��������邩���H
public class Door : MonoBehaviour
{
    GimmickConditions GC;

    //�A�j���[�^�[
    Animator animator;

    //�z�d��
    public GameObject basis = null;
    //GimmckCondition�@�̃��X�g�̓Y����
    private int _basisPoint = 0;

    void Start()
    {
        GC = GameObject.Find("GimmickCondition").GetComponent<GimmickConditions>();
        animator = this.GetComponent<Animator>();

        //�z�d�Ղ̃��X�g�ʒu���擾
        _basisPoint = GC.GetOwnPoint(basis);
        basis = GC.GetGameObject(basis);
    }

    void Update()
    {
        DoorAnimation();
    }

    //�A�j���[�^�[�̃g���K�[�ɂăA�j���[�V�������Đ�����
    private void DoorAnimation()
    {
        if(GC.GetConditionOverHaul(_basisPoint) == true)
        {
            animator.SetBool("basis_repair", true);
        }
    }
}
