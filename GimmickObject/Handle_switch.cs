using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle_switch : MonoBehaviour
{
    GimmickConditions GC;
    private int _handlePoint;

    Animator _animator;

    //������Ԃ�ON�̏�Ԃɂ��邩�ǂ���
    [Tooltip("�Q�[���X�^�[�g���@ON/OFF")]
    public bool handle_OnOff = true;

    //�n���h������
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

        //������ON/OFF���n���h���̊p�x�ɔ��f����
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
        //�g�p��
        if (GC.GetConditionUsing(_handlePoint))
        {
            //�A�j���[�^�[�̃p�����[�^�[���l���m�F����
            if (_animator.GetBool("handle_using") == false)
            {
                _animator.SetBool("handle_using", true);
            }
        }
        else
        //���g�p
        //false�̂Ƃ�
        {
            //�A�j���[�^�[�̃p�����[�^�[���l���m�F����
            if (_animator.GetBool("handle_using") == true)
            {
                _animator.SetBool("handle_using", false);
            }

        }
    }
}
