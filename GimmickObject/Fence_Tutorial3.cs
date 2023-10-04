using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Tutorial_3    解体されたら倒れる
public class Fence_Tutorial3 : MonoBehaviour
{
    GimmickConditions GC;

    //アニメーター
    Animator animator;
    //ボルト
    public GameObject bolt;
    //GimmickCondition　の　リストの添え字
    private int _boltPoint = 0;

    //アニメーターのトリガーにてアニメーションを再生する
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
