using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//クリア条件を管理する親スクリプト
//主ギミック関係のオブジェクトのやり取りを行いたい

public class GimmickConditions : MonoBehaviour
{
    //ギミックオブジェクトリスト
    //渡したい情報
    [Tooltip("ステージ内で使用されるギミックをすべて格納する")]
    [SerializeField]
    private List<GameObject> _Gimmick = new List<GameObject>();
    //解体修理の状態を取得(解体されている状態(修理可能)：false  修理されている状態(解体可能)：true)
    private List<bool> _overhaulGimmick = new List<bool>();
    //使用したかどうか
    private List<bool> _usingGimmick = new List<bool>();


    public
    // Start is called before the first frame update
    void Start()
    {
        //最初の段階での解体修理状況をbool値に直す
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

    //解体
    public void Demolish(GameObject _object)
    {
        int num = GetOwnPoint(_object);
        _overhaulGimmick[num] = false;
    }

    //修理
    public void Repair(GameObject _object)
    {
        int num = GetOwnPoint(_object);
        _overhaulGimmick[num] = true;

    }

    //使用
    public void Using(GameObject _object)
    {
        int num = GetOwnPoint(_object);
        //on/offを切り替える
        _usingGimmick[num] = !_usingGimmick[num];

    }

    //リストから自身の場所を探す
    public int GetOwnPoint(GameObject _object)
    {
        //自身の添え字を格納
        int _placeNum = 0;
        _placeNum = _Gimmick.IndexOf(_object);
        if(_placeNum == -1)
        {
            Debug.Log("ERROR");
        }
        return _placeNum;
    }

    //リスト（オブジェクト）を入れ替える
    public void SetObject(int i, GameObject _object)
    {
        _Gimmick[i] = _object;
    }

    //オブジェクトの参照
    public GameObject GetGameObject(GameObject _object)
    {
        int num = GetOwnPoint(_object);
        return _Gimmick[num];
    }

    //リストを参照(解体修理)
    public bool GetConditionOverHaul(GameObject _object)
    {
        int num = GetOwnPoint(_object);
        return _overhaulGimmick[num];
    }

    //リストを参照（使用）
    public bool GetConditionUsing(GameObject _object)
    {
        int num = GetOwnPoint(_object);
        return _usingGimmick[num];
    }

    //リスト参照の添え字版
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
