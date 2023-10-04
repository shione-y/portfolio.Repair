using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectCategory : MonoBehaviour {
  //�Q�[���}�l�W���[
  [NonSerialized]
  private GameObject GameManager;

  //�I�u�W�F�N�g�Ǘ��X�N���v�g
  [NonSerialized]
  private GameObject GimmickCondition;
  [NonSerialized]
  public GimmickConditions GC;

  //�I�u�W�F�N�g�̕��ޖ�
  [SerializeField]
  public enum Category {
    //���Ă����
    [Tooltip("���Ă����")]
    Take,
    //�g����
    [Tooltip("�g�������")]
    Using,
    //�C����̉\
    [Tooltip("�C����̉\�Ȃ���")]
    Overhaul
  }

  //��̏C���̏����𕪒S���邽�߁A�Ƃ肠�����A����
  //Overhaul�I�u�W�F�N�g�̏��
  [SerializeField]
  public enum State {
    //test null
    Null,
    //�C���\
    [Tooltip("�C���\")]
    Repair,
    //��̉\
    [Tooltip("��̉\")]
    Demolish
  }


  [Tooltip("���ޖ�")]
  public Category category;

  [Tooltip("��̏C���@���")]
  public State overhaulState;

  void Awake() {
    GameManager = GameObject.Find("GameManager");

    GimmickCondition = GameObject.Find("GimmickCondition");
    GC = GimmickCondition.GetComponent<GimmickConditions>();
  }


  // -------------------------------------------------------------------------
  // ���n���̕ύX�_

  // �s���\���ǂ����̔��� -----------------------
  //�@����
  public bool GetCanHave() {
    return this.category == Category.Take;
  }

  //�@�g��
  public bool GetCanUseParts() {
    return this.category == Category.Using;
  }

  //�@��́E�C��
  public bool GetCanOverhaul() {
    return this.category == Category.Overhaul;
  }
  // -----------------------------------------------

  // �ȉ��A���z���\�b�h ----------------------------------------

  // ��́E�C���̏��� ------------------------------
  public virtual bool GetRightRepairPats(Transform mono) { return false; }

  // ���
  public virtual void Dismatle() { }
  public virtual bool GetCanDismatle() {
    return this.overhaulState == State.Demolish || this.category == Category.Using;
  }
  // �C��
  public virtual void Repair() { }
  public virtual bool GetCanRepair() {
    return this.overhaulState == State.Repair;
  }

  // -----------------------------------------------

  // ���i���g��+�g���邩�ǂ����̔��� ---------------
  public virtual bool UseParts() { return false; }

  // -------------------------------------------------------------------------


}
