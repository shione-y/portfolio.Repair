using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectCategory;

public class Object_Using : ObjectCategory {


  void Start() {
    //enum�^�ϐ��̏�������
    category = Category.Using;

  }

  void Update() {

  }

  //�@�g��
  public override bool UseParts() {
    if (this.category == Category.Using) {
      //Debug.Log("�Ȃ񂩁I�g�����I");
      GC.Using(this.gameObject);
      return true;
    } else return false;
  }

  public override void Dismatle() {
    // ��̂̃X�N���v�g���t���Ă���I�u�W�F�N�g�̏ꍇ�A�����G�ɉ�̂���
    // Ussing���t���Ă���I�u�W�F�N�g����̏o���Ȃ��č������ۂ̉��}���u
    Object_Demolish _d;
    if (TryGetComponent<Object_Demolish>(out _d)) { _d.Dismatle(); }
  }
}
