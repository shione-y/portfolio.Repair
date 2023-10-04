using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane_move : MonoBehaviour {
  private GimmickConditions GC;
  //クレーンと対応するレバー
  public GameObject handle;

  //クレーン内部の可動部分（group4）
  public Transform _movingPart;
  //可動部分のローカルポジション 位置の書き換えに使用する
  private Vector3 _localposition;
  //目標地点
  public Transform targetPoint;
  private float _speed = 1.0f;
  //se 
  bool play_se = false;
  AudioSource se;

  //レバーの添え字
  int num;

  void Start() {
    GC = GameObject.Find("GimmickCondition").GetComponent<GimmickConditions>();
    se = this.GetComponent<AudioSource>();
    _localposition = _movingPart.localPosition;

    //レバーの添え字を取得
    //レバーは解体修理する際にオブジェクトが変わるため
    num = GC.GetOwnPoint(handle);
  }

  void Update() {
    //対応するレバーが使用中か かつ　可動部分が目標地点に到着していないか
    if (GC.GetConditionUsing(num) && _movingPart.localPosition.y >= targetPoint.localPosition.y) {
      if (!play_se) {
        se.Play();
        play_se = true;
      }
      //クレーンの可動部分を移動させる
      float step = _speed * Time.deltaTime;
      _localposition.y -= step;
      _movingPart.localPosition = _localposition;
      //_movingPart.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);
    } else {
      se.Stop();
      play_se = false;
    }
  }
}
