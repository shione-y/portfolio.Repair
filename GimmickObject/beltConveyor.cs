using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�x���g�R���x�A�̓����i���j
public class beltConveyor : MonoBehaviour
{
    [NonSerialized]
    public GimmickConditions GC;

    [Tooltip("�Ή����郌�o�[")]
    [SerializeField]
    private GameObject _handle;
    [NonSerialized]
    public int _handlePoint;

    //�T�E���h
    AudioSource _movingSound;
    //�T�E���h���v���C�����ǂ���
    bool _playSound = false;

    void Awake()
    {
        GC = GameObject.Find("GimmickCondition").GetComponent<GimmickConditions>();
        //�Ή�����n���h����GimmickCondition�̃f�[�^�ʒu���擾
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
