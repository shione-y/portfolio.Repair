using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//　修理を行う処理
//　解体されているオブジェクトにつける
public class Object_Repair : ObjectCategory
{

    //相方(purehabu)
    public GameObject difference;
    //相方(object)
    [NonSerialized]
    public GameObject _difference = null;

    void Start()
    {
        //自身の解体修理のステータスを変更する
        overhaulState = ObjectCategory.State.Repair;

        //Debug.Log(difference.name);
        if (_difference == null)
        {
            //Debug.Log(difference.name + "と同じ名前のオブジェクトはなかった");
            //差分オブジェクトを先に生成して、SetActive(false)にしておく
            _difference = Instantiate(difference, this.transform.position, Quaternion.identity);
            _difference.GetComponent<Object_Demolish>()._difference = this.gameObject;
        }
        _difference.SetActive(false);
    }

    void Update()
    {

    }

    // 修理
    public override void Repair()
    {
        //Debug.Log("修理");
        //ゲームマネジャーに「このオブジェクト」が「修理した」旨を伝える
        GC.Repair(this.gameObject);

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

    //修理に使う部品の種類が合っているかの判定
    public override bool GetRightRepairPats(Transform mono)
    {
        // 現状、持てるものがボルト：修理に使うものとして正しいものしかないため、不要？
        // 他に増えた時用に一応残しておく方が良いかも
        if (mono == null) { return false; }

        return mono.CompareTag("Bolt");
    }


}
