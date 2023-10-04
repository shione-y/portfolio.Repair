using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ベルトコンベアの動き（仮）
public class beltConveyor : MonoBehaviour
{
    [NonSerialized]
    public GimmickConditions GC;

    [Tooltip("対応するレバー")]
    [SerializeField]
    private GameObject _handle;
    [NonSerialized]
    public int _handlePoint;

    //サウンド
    AudioSource _movingSound;
    //サウンドがプレイ中かどうか
    bool _playSound = false;

    void Awake()
    {
        GC = GameObject.Find("GimmickCondition").GetComponent<GimmickConditions>();
        //対応するハンドルのGimmickConditionのデータ位置を取得
        _handlePoint = GC.GetOwnPoint(_handle);

        _movingSound = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(GC.GetConditionUsing(_handlePoint) && GC.GetConditionOverHaul(_handlePoint))
        {
            if (!_playSound)
            {
                _movingSound.Play();
                _playSound = true;
            }
        }
        else
        {
            if (_playSound)
            {
                _movingSound.Stop();
                _playSound = false;
            }
        }
    }
}
