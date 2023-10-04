using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane_move : MonoBehaviour {
  private GimmickConditions GC;
  //�N���[���ƑΉ����郌�o�[
  public GameObject handle;

  //�N���[�������̉������igroup4�j
  public Transform _movingPart;
  //�������̃��[�J���|�W�V���� �ʒu�̏��������Ɏg�p����
  private Vector3 _localposition;
  //�ڕW�n�_
  public Transform targetPoint;
  private float _speed = 1.0f;
  //se 
  bool play_se = false;
  AudioSource se;

  //���o�[�̓Y����
  int num;

  void Start() {
    GC = GameObject.Find("GimmickCondition").GetComponent<GimmickConditions>();
    se = this.GetComponent<AudioSource>();
    _localposition = _movingPart.localPosition;

    //���o�[�̓Y�������擾
    //���o�[�͉�̏C������ۂɃI�u�W�F�N�g���ς�邽��
    num = GC.GetOwnPoint(handle);
  }

  void Update() {
    //�Ή����郌�o�[���g�p���� ���@���������ڕW�n�_�ɓ������Ă��Ȃ���
    if (GC.GetConditionUsing(num) && _movingPart.localPosition.y >= targetPoint.localPosition.y) {
      if (!play_se) {
        se.Play();
        play_se = true;
      }
      //�N���[���̉��������ړ�������
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
