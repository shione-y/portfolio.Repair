using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�N���A�������Ǘ�����e�X�N���v�g
//��M�~�b�N�֌W�̃I�u�W�F�N�g�̂������s������

public class GimmickConditions : MonoBehaviour
{
    //�M�~�b�N�I�u�W�F�N�g���X�g
    //�n���������
    [Tooltip("�X�e�[�W���Ŏg�p�����M�~�b�N�����ׂĊi�[����")]
    [SerializeField]
    private List<GameObject> _Gimmick = new List<GameObject>();
    //��̏C���̏�Ԃ��擾(��̂���Ă�����(�C���\)�Ffalse  �C������Ă�����(��̉\)�Ftrue)
    private List<bool> _overhaulGimmick = new List<bool>();
    //�g�p�������ǂ���
    private List<bool> _usingGimmick = new List<bool>();


    public
    // Start is called before the first frame update
    void Start()
    {
        //�ŏ��̒i�K�ł̉�̏C���󋵂�bool�l�ɒ���
        for (int i = 0; i < _Gimmick.Count; i++)
        {
            if (_Gimmick[i].GetComponent<ObjectCategory>().overhaulState == ObjectCategory.State.Demolish)
            {
                _overhaulGimmick.Add(true);
            }
            else { _overhaulGimmick.Add(false); }

            _usingGimmick.Add(false);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //���
    public void Demolish(GameObject _object)
    {
        int num = GetOwnPoint(_object);
        _overhaulGimmick[num] = false;
    }

    //�C��
    public void Repair(GameObject _object)
    {
        int num = GetOwnPoint(_object);
        _overhaulGimmick[num] = true;

    }

    //�g�p
    public void Using(GameObject _object)
    {
        int num = GetOwnPoint(_object);
        //on/off��؂�ւ���
        _usingGimmick[num] = !_usingGimmick[num];

    }

    //���X�g���玩�g�̏ꏊ��T��
    public int GetOwnPoint(GameObject _object)
    {
        //���g�̓Y�������i�[
        int _placeNum = 0;
        _placeNum = _Gimmick.IndexOf(_object);
        if(_placeNum == -1)
        {
            Debug.Log("ERROR");
        }
        return _placeNum;
    }

    //���X�g�i�I�u�W�F�N�g�j�����ւ���
    public void SetObject(int i, GameObject _object)
    {
        _Gimmick[i] = _object;
    }

    //�I�u�W�F�N�g�̎Q��
    public GameObject GetGameObject(GameObject _object)
    {
        int num = GetOwnPoint(_object);
        return _Gimmick[num];
    }

    //���X�g���Q��(��̏C��)
    public bool GetConditionOverHaul(GameObject _object)
    {
        int num = GetOwnPoint(_object);
        return _overhaulGimmick[num];
    }

    //���X�g���Q�Ɓi�g�p�j
    public bool GetConditionUsing(GameObject _object)
    {
        int num = GetOwnPoint(_object);
        return _usingGimmick[num];
    }

    //���X�g�Q�Ƃ̓Y������
    public GameObject GetGameObject(int num)
    {
        return _Gimmick[num];
    }

    public bool GetConditionOverHaul(int num)
    {
        return _overhaulGimmick[num];
    }

    public bool GetConditionUsing(int num)
    {
        return _usingGimmick[num];
    }
}
