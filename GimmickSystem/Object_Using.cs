using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectCategory;

public class Object_Using : ObjectCategory {


  void Start() {
    //enum型変数の書き換え
    category = Category.Using;

  }

  void Update() {

  }

  //　使う
  public override bool UseParts() {
    if (this.category == Category.Using) {
      //Debug.Log("なんか！使った！");
      GC.Using(this.gameObject);
      return true;
    } else return false;
  }

  public override void Dismatle() {
    // 解体のスクリプトが付いているオブジェクトの場合、強制敵に解体する
    // Ussingが付いているオブジェクトが解体出来なくて困った際の応急処置
    Object_Demolish _d;
    if (TryGetComponent<Object_Demolish>(out _d)) { _d.Dismatle(); }
  }
}
