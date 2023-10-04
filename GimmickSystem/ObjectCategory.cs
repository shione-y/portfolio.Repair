using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectCategory : MonoBehaviour {
  //ゲームマネジャー
  [NonSerialized]
  private GameObject GameManager;

  //オブジェクト管理スクリプト
  [NonSerialized]
  private GameObject GimmickCondition;
  [NonSerialized]
  public GimmickConditions GC;

  //オブジェクトの分類名
  [SerializeField]
  public enum Category {
    //持てるもの
    [Tooltip("持てるもの")]
    Take,
    //使える
    [Tooltip("使えるもの")]
    Using,
    //修理解体可能
    [Tooltip("修理解体可能なもの")]
    Overhaul
  }

  //解体修理の処理を分担するため、とりあえず、復活
  //Overhaulオブジェクトの状態
  [SerializeField]
  public enum State {
    //test null
    Null,
    //修理可能
    [Tooltip("修理可能")]
    Repair,
    //解体可能
    [Tooltip("解体可能")]
    Demolish
  }


  [Tooltip("分類名")]
  public Category category;

  [Tooltip("解体修理　状態")]
  public State overhaulState;

  void Awake() {
    GameManager = GameObject.Find("GameManager");

    GimmickCondition = GameObject.Find("GimmickCondition");
    GC = GimmickCondition.GetComponent<GimmickConditions>();
  }


  // -------------------------------------------------------------------------
  // 佐渡島の変更点

  // 行動可能かどうかの判定 -----------------------
  //　持つ
  public bool GetCanHave() {
    return this.category == Category.Take;
  }

  //　使う
  public bool GetCanUseParts() {
    return this.category == Category.Using;
  }

  //　解体・修理
  public bool GetCanOverhaul() {
    return this.category == Category.Overhaul;
  }
  // -----------------------------------------------

  // 以下、仮想メソッド ----------------------------------------

  // 解体・修理の処理 ------------------------------
  public virtual bool GetRightRepairPats(Transform mono) { return false; }

  // 解体
  public virtual void Dismatle() { }
  public virtual bool GetCanDismatle() {
    return this.overhaulState == State.Demolish || this.category == Category.Using;
  }
  // 修理
  public virtual void Repair() { }
  public virtual bool GetCanRepair() {
    return this.overhaulState == State.Repair;
  }

  // -----------------------------------------------

  // 部品を使う+使えるかどうかの判定 ---------------
  public virtual bool UseParts() { return false; }

  // -------------------------------------------------------------------------


}
