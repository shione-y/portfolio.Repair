using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Tutorial_3    ��̂��ꂽ��|���
public class Fence_Tutorial3 : MonoBehaviour
{
    GimmickConditions GC;

    //�A�j���[�^�[
    Animator animator;
    //�{���g
    public GameObject bolt;
    //GimmickCondition�@�́@���X�g�̓Y����
    private int _boltPoint = 0;

    //�A�j���[�^�[�̃g���K�[�ɂăA�j���[�V�������Đ�����
    private void FenceAnimation()
    {
        if (GC.GetConditionOverHaul(_boltPoint) == false)
        {
            animator.SetBool("bolt_dismantling", true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GC = GameObject.Find("GimmickCondition").GetComponent<GimmickConditions>();

        _boltPoint = GC.GetOwnPoint(bolt);
        bolt = GC.GetGameObject(_boltPoint);

        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FenceAnimation();
    }
}
