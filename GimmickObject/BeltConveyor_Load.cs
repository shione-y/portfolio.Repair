using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�x���g�R���x�A��ɗ������̂̈ړ�����

public class BeltConveyor_Load : MonoBehaviour
{
    //�e����GimmickCondition���Q�Ƃ��Ă���X�N���v�g�����
    beltConveyor _beltConbeyor;

    [SerializeField]
    private GameObject _load;

    public float timeOut = 3.0f;

    //�R���[�`�����̂���
    IEnumerator _enumerator = null;

    //�R���[�`�����Đ�����Ă��邩�ǂ���
    private bool playCoroutine;

    void Start()
    {
        _beltConbeyor = transform.parent.gameObject.GetComponent<beltConveyor>();
        _enumerator = FuncCoroutine();
    }

    void Update()
    {
        //�g�p������Ȃ� ���@�R���[�`�����Đ����@�̂Ƃ��R���[�`�����~�߂�
        if (!_beltConbeyor.GC.GetConditionUsing(_beltConbeyor._handlePoint) && playCoroutine)
        {
            Debug.Log("�x���g�R���x�A�[�@��~");
            StopCoroutine(_enumerator);
            playCoroutine = false;
        }
        else if(_beltConbeyor.GC.GetConditionUsing(_beltConbeyor._handlePoint) && !playCoroutine)
        {
            StartCoroutine(_enumerator);
            playCoroutine = true;
        }
    }

    IEnumerator FuncCoroutine()
    {
        while (true)
        {
            var load_i = GameObject.Instantiate(_load, transform.position, Quaternion.identity) as GameObject;
            yield return new WaitForSeconds(timeOut);
        }
    }
}
