using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltConveyor_BeltMaterial : MonoBehaviour
{
    //親からGimmickConditionを参照しているスクリプトを取る
    beltConveyor _beltConbeyor;

    //自身のマテリアル
    public Material _material;
    //移動値
    public float moveStep = 0.1f;
    Vector2 _texVector;

    void Start()
    {
        _beltConbeyor = transform.parent.gameObject.GetComponent<beltConveyor>();
        //_material = this.GetComponent<Material>();
    }

    void Update()
    {
        //対応するレバーが使用中の間　マテリアルを－方向に移動させる
        if (_beltConbeyor.GC.GetConditionUsing(_beltConbeyor._handlePoint))
        {
            //現在の値を取得
            _texVector = _material.mainTextureOffset;
            //新しい値の制定
            _texVector.y -= moveStep * Time.deltaTime;
            _material.mainTextureOffset = _texVector;
        }
    }
}
