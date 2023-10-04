using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Take : ObjectCategory {

  void Start() {
    //enum型変数の書き換え
    category = Category.Take;
    //修理解体状態の値を０（Null）にする
    //overhaulState = 0;

  }

  void Update() {

  }

  //プレイヤーからの入力
  //　持つ
  //public bool PickUpParts()
  //{
  //    //自身がPartsオブジェクトかどうか
  //    if (this.category == Category.Take)
  //    {
  //        //持つ処理はプレイヤー側で行う
  //        Debug.Log("持つ");
  //        return true;
  //    }
  //    else return false;
  //}

}
