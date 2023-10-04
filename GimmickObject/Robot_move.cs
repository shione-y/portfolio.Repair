using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

//徘徊ロボットの動き
//https://gist.github.com/tsubaki/301d163cab865ad8fa17
//https://qiita.com/guru_taka/items/b59aa55643c77cc5aa6e

//ロボットはアニメーションを使っているわけではないので、スクリプト内でサウンドの調節も行う
public class Robot_move : MonoBehaviour {
  GameObject gimmickCondition;
  GimmickConditions GC;

  //移動を行うかどうか
  [Tooltip("徘徊ロボの移動を許可する")]
  public bool CanMoving;

  //目標地点
  private Transform _targetobject;
  //上記のtargetobjectの子要素をリストに格納する
  public List<Transform> _nextPoint = new List<Transform>();
  //目標地点の数
  private int _listNum = 0;
  //目標地点の添え字
  private int _pointNum = 0;
  private NavMeshAgent _nav;

  void Start() {
    //GimmickConditionの取得
    gimmickCondition = GameObject.Find("GimmickCondition");
    GC = gimmickCondition.GetComponent<GimmickConditions>();

    //ターゲットオブジェクトがまとめられているオブジェクトの探索と取得
    _targetobject = GameObject.Find("robot_targetPoints").transform;
    _nav = this.GetComponent<NavMeshAgent>();


    //目標地点
    GetPoint();
    if (CanMoving == true) {
      _listNum = _nextPoint.Count();
      //destination　で　目標地点を設定する
      _nav.SetDestination(_nextPoint[_pointNum].position);
    }
    //else { Debug.Log("解体されている"); }
  }

  void Update() {
    if (CanMoving == true) {
      //Debug.Log("目標地点に関して");
      //目標地点についてかどうか
      if ((this.transform.position.x <= _nextPoint[_pointNum].position.x + 0.5 && this.transform.position.x >= _nextPoint[_pointNum].position.x - 0.5)
          && (this.transform.position.z <= _nextPoint[_pointNum].position.z + 0.5 && this.transform.position.z >= _nextPoint[_pointNum].position.z - 0.5)) {
        NextPoint();
      }
    } else {
      // 佐渡島追加 -----------------------------------------------------------------------------------------------------
      // 移動を止める

      // y座標は合わないので、平面上のxz座標が合っているかで確認
      if (_nav.destination.x != transform.position.x || _nav.destination.z != transform.position.z) {
        //_movindSound.Stop();
        _nav.SetDestination(transform.position);
      }
      // ----------------------------------------------------------------------------------------------------------------s
    }
  }
  private void OnEnable() {
    // 初期化が行われていなかったら、以下は実行しない
    if (_nav == null) { return; }

    if (!CanMoving) {
      // このオブジェクトが有効化されたら、再度動き出す
      CanMoving = true;
      _nav.SetDestination(_nextPoint[_pointNum].position);
    }
  }

  //目標地点をリストに格納する
  //_targetobjectの子要素のTransformを格納する
  void GetPoint() {
    if (_targetobject.childCount == 0) { return; }
    foreach (Transform child in _targetobject) {
      //リストに格納する
      _nextPoint.Add(child.transform);
      //Debug.Log(_nextPoint);
    }
  }

  //次の目標地点
  void NextPoint() {
    //リストの要素数がこれ以上ない場合　=>　添え字の値を０にする
    if (_pointNum + 1 == _listNum) {
      _pointNum = 0;
    } else {
      //次の目標地点を設定する
      _pointNum++;
    }

    _nav.SetDestination(_nextPoint[_pointNum].position);
  }
}
