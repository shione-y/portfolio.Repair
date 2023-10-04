using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle_switch : MonoBehaviour
{
    GimmickConditions GC;
    private int _handlePoint;

    Animator _animator;

    //初期状態をONの状態にするかどうか
    [Tooltip("ゲームスタート時　ON/OFF")]
    public bool handle_OnOff = true;

    //ハンドル部分
    //private Transform _handle;
    //private Vector3 _handleAngles;

    // Start is called before the first frame update
    void Start()
    {
        GC = GameObject.Find("GimmickCondition").GetComponent<GimmickConditions>();
        _handlePoint = GC.GetOwnPoint(this.gameObject);
        _animator = GetComponent<Animator>();

        if (handle_OnOff)
        {
            GC.Using(this.gameObject);
        }

        /*
        _handle = transform.Find("handle");
        _handleAngles = _handle.eulerAngles;

        //初期のON/OFFをハンドルの角度に反映する
        Debug.Log(_handleAngles.x);
        if(handle_OnOff == true)
        {
            _handleAngles.x = -45;
            _handle.transform.eulerAngles = new Vector3(-45, 0, 0);
        }
        else
        {
            _handleAngles.x = 45;
            _handle.transform.eulerAngles = new Vector3(-45, 0, 0);
        }
        //_handle.transform.eulerAngles = _handleAngles;
        Debug.Log(_handle.eulerAngles);
        */
    }

    // Update is called once per frame
    void Update()
    {
        //使用中
        if (GC.GetConditionUsing(_handlePoint))
        {
            //アニメーターのパラメーターが値を確認する
            if (_animator.GetBool("handle_using") == false)
            {
                _animator.SetBool("handle_using", true);
            }
        }
        else
        //未使用
        //falseのとき
        {
            //アニメーターのパラメーターが値を確認する
            if (_animator.GetBool("handle_using") == true)
            {
                _animator.SetBool("handle_using", false);
            }

        }
    }
}
