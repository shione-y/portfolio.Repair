using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//解体を行う処理
//修理されている状態のオブジェクトにつける
public class Object_Demolish : ObjectCategory
{
    //相方
    public GameObject difference;
    //相方(object)
    [NonSerialized]
    public GameObject _difference = null;

    void Start()
    {
        //自身の解体修理のステータスを変更する
        overhaulState = ObjectCategory.State.Demolish;

        //Debug.Log(difference.name);
        if (_difference == null)
        {
            //差分オブジェクトを先に生成して、SetActive(false)にしておく
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
        //ゲームマネジャーに「このオブジェクト」が「解体した」旨を伝える
        GC.Demolish(this.gameObject);

        //　相方を表示する
        _difference.SetActive(true);

        // 佐渡島追加 -----------------------------------------------------------------------------------------------------
        // 位置・向きを合わせる
        _difference.transform.position = this.transform.position;
        _difference.transform.rotation = this.transform.rotation;

        // ----------------------------------------------------------------------------------------------------------------

        //GimmickConditionのリストを書き換える
        //添え字
        int num = GC.GetOwnPoint(this.gameObject);
        //書き換え
        GC.SetObject(num, _difference);

        //　自身を非表示にする
        this.gameObject.SetActive(false);
    }

}
