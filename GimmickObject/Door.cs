using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//　Transformを直接書き換えるドアの開閉動作
//　後々見やすいように書き換えるかも？
public class Door : MonoBehaviour
{
    GimmickConditions GC;

    //アニメーター
    Animator animator;

    //配電盤
    public GameObject basis = null;
    //GimmckCondition　のリストの添え字
    private int _basisPoint = 0;

    void Start()
    {
        GC = GameObject.Find("GimmickCondition").GetComponent<GimmickConditions>();
        animator = this.GetComponent<Animator>();

        //配電盤のリスト位置を取得
        _basisPoint = GC.GetOwnPoint(basis);
        basis = GC.GetGameObject(basis);
    }

    void Update()
    {
        DoorAnimation();
    }

    //アニメーターのトリガーにてアニメーションを再生する
    private void DoorAnimation()
    {
        if(GC.GetConditionOverHaul(_basisPoint) == true)
        {
            animator.SetBool("basis_repair", true);
        }
    }
}
