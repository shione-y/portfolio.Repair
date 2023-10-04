using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BeltConveyor_Belt : MonoBehaviour
{
    //�e����GimmickCondition���Q�Ƃ��Ă���X�N���v�g�����
    beltConveyor _beltConbeyor;


    public float TargetDriveSpeed = 1.0f;
    [SerializeField]
    private float _forcePower = 100f;

    private List<Rigidbody> _rbs = new List<Rigidbody>();

    Vector3 DriveDirection;



    private void Start()
    {
        _beltConbeyor = transform.parent.gameObject.GetComponent<beltConveyor>();
        DriveDirection = -transform.forward;
    }

    private void FixedUpdate()
    {
        if (_beltConbeyor.GC.GetConditionUsing(_beltConbeyor._handlePoint))
        {
            foreach (var rb in _rbs)
            {
                //���̂̈ړ����x�̃x���g�R���x�A�����̐������������o��
                var objectSpeed = Vector3.Dot(rb.velocity, DriveDirection);

                //�ڕW�l�ȉ��Ȃ��������
                if (objectSpeed < Mathf.Abs(TargetDriveSpeed))//��Βl
                {
                    rb.AddForce(DriveDirection * _forcePower, ForceMode.Acceleration);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        var rb = collision.gameObject.GetComponent<Rigidbody>();
        _rbs.Add(rb);
    }

    void OnCollisionExit(Collision collision)
    {
        var rb = collision.gameObject.GetComponent<Rigidbody>();
        _rbs.Remove(rb);
    }
}
