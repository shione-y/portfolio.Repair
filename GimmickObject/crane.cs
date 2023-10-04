using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//クレーンを下すスクリプト
//クレーン本体につけて、cable変数に該当するケーブル部分を格納する

//問題点：ケーブルの先の鉄骨等のスケールまで変化があるのではないか？
public class crane : MonoBehaviour
{
    //GimmickCondition test
    //実際はGimmickConditionクラスのリストの値を見るようにする
    public bool GimmickCondition = false;

    //紐
    [Tooltip("ケーブル")]
    public GameObject cable;
    [Tooltip("ケーブルをどこまで伸ばすか（スケール）")]
    public float scaleNum;
    // ------------------------------------------------------------
    [Tooltip("先端の荷物")]
    public Transform load;

    //ケーブルの先端
    public Vector3 _cableTip;
    // -------------------------------------------------------------

    //ケーブルのスケール
    private Vector3 _scale;
    private Vector3 _position;
    private float num = 0.0f;

    void Start()
    {
        //GimmickConditionの探索
        _position = cable.GetComponent<Transform>().position;
        _scale = cable.GetComponent<Transform>().localScale;
        // ------------------------------------------------------
        _cableTip = cable.GetComponentInChildren<Transform>().position;
        Debug.Log(_cableTip);

    }

    void Update()
    {
        if (GimmickCondition == true)
        {
            if (cable.transform.localScale.y <= scaleNum)
            {
                //クレーンのひもの部分を伸ばす
                num = 0.5f * Time.deltaTime;
                _scale.y += num;
                cable.transform.localScale = _scale;
                //クレーンの支点部分の位置をずらさないように移動させる
                _position.y -= num;
                cable.transform.position = _position;
                //先端の荷物のpositionを移動させる ------------------------------------
                load.position = new Vector3(_cableTip.x, _cableTip.y, _cableTip.z);
            }
        }
        else if(GimmickCondition == false && cable.transform.localScale.y >= 1)
        {
            BackCable();
        }
    }

    //クレーンのケーブルを巻き戻す（使うかわかんないけど作ってみた）
    void BackCable()
    {
        //クレーンのひもの部分を伸ばす
        num = 0.5f * Time.deltaTime;
        _scale.y -= num;
        cable.transform.localScale = _scale;
        //クレーンの支点部分の位置をずらさないように移動させる
        _position.y += num;
        cable.transform.position = _position;
        //先端の荷物のpositionを移動させる ---------------------------------
        load.position = new Vector3(_cableTip.x, _cableTip.y, _cableTip.z);

    }
}
