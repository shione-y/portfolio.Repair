using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Take : ObjectCategory {

  void Start() {
    //enum�^�ϐ��̏�������
    category = Category.Take;
    //�C����̏�Ԃ̒l���O�iNull�j�ɂ���
    //overhaulState = 0;

  }

  void Update() {

  }

  //�v���C���[����̓���
  //�@����
  //public bool PickUpParts()
  //{
  //    //���g��Parts�I�u�W�F�N�g���ǂ���
  //    if (this.category == Category.Take)
  //    {
  //        //�������̓v���C���[���ōs��
  //        Debug.Log("����");
  //        return true;
  //    }
  //    else return false;
  //}

}
