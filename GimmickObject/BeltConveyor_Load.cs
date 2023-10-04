using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ベルトコンベア上に流す物体の移動処理

public class BeltConveyor_Load : MonoBehaviour
{
    //親からGimmickConditionを参照しているスクリプトを取る
    beltConveyor _beltConbeyor;

    [SerializeField]
    private GameObject _load;

    public float timeOut = 3.0f;

    //コルーチンそのもの
    IEnumerator _enumerator = null;

    //コルーチンが再生されているかどうか
    private bool playCoroutine;

    void Start()
    {
        _beltConbeyor = transform.parent.gameObject.GetComponent<beltConveyor>();
        _enumerator = FuncCoroutine();
    }

    void Update()
    {
        //使用中じゃない かつ　コルーチンが再生中　のときコルーチンを止める
        if (!_beltConbeyor.GC.GetConditionUsing(_beltConbeyor._handlePoint) && playCoroutine)
        {
            Debug.Log("ベルトコンベアー　停止");
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
