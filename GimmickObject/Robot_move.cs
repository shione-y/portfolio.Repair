using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

//�p�j���{�b�g�̓���
//https://gist.github.com/tsubaki/301d163cab865ad8fa17
//https://qiita.com/guru_taka/items/b59aa55643c77cc5aa6e

//���{�b�g�̓A�j���[�V�������g���Ă���킯�ł͂Ȃ��̂ŁA�X�N���v�g���ŃT�E���h�̒��߂��s��
public class Robot_move : MonoBehaviour {
  GameObject gimmickCondition;
  GimmickConditions GC;

  //�ړ����s�����ǂ���
  [Tooltip("�p�j���{�̈ړ���������")]
  public bool CanMoving;

  //�ڕW�n�_
  private Transform _targetobject;
  //��L��targetobject�̎q�v�f�����X�g�Ɋi�[����
  public List<Transform> _nextPoint = new List<Transform>();
  //�ڕW�n�_�̐�
  private int _listNum = 0;
  //�ڕW�n�_�̓Y����
  private int _pointNum = 0;
  private NavMeshAgent _nav;

  void Start() {
    //GimmickCondition�̎擾
    gimmickCondition = GameObject.Find("GimmickCondition");
    GC = gimmickCondition.GetComponent<GimmickConditions>();

    //�^�[�Q�b�g�I�u�W�F�N�g���܂Ƃ߂��Ă���I�u�W�F�N�g�̒T���Ǝ擾
    _targetobject = GameObject.Find("robot_targetPoints").transform;
    _nav = this.GetComponent<NavMeshAgent>();


    //�ڕW�n�_
    GetPoint();
    if (CanMoving == true) {
      _listNum = _nextPoint.Count();
      //destination�@�Ł@�ڕW�n�_��ݒ肷��
      _nav.SetDestination(_nextPoint[_pointNum].position);
    }
    //else { Debug.Log("��̂���Ă���"); }
  }

  void Update() {
    if (CanMoving == true) {
      //Debug.Log("�ڕW�n�_�Ɋւ���");
      //�ڕW�n�_�ɂ��Ă��ǂ���
      if ((this.transform.position.x <= _nextPoint[_pointNum].position.x + 0.5 && this.transform.position.x >= _nextPoint[_pointNum].position.x - 0.5)
          && (this.transform.position.z <= _nextPoint[_pointNum].position.z + 0.5 && this.transform.position.z >= _nextPoint[_pointNum].position.z - 0.5)) {
        NextPoint();
      }
    } else {
      // ���n���ǉ� -----------------------------------------------------------------------------------------------------
      // �ړ����~�߂�

      // y���W�͍���Ȃ��̂ŁA���ʏ��xz���W�������Ă��邩�Ŋm�F
      if (_nav.destination.x != transform.position.x || _nav.destination.z != transform.position.z) {
        //_movindSound.Stop();
        _nav.SetDestination(transform.position);
      }
      // ----------------------------------------------------------------------------------------------------------------s
    }
  }
  private void OnEnable() {
    // ���������s���Ă��Ȃ�������A�ȉ��͎��s���Ȃ�
    if (_nav == null) { return; }

    if (!CanMoving) {
      // ���̃I�u�W�F�N�g���L�������ꂽ��A�ēx�����o��
      CanMoving = true;
      _nav.SetDestination(_nextPoint[_pointNum].position);
    }
  }

  //�ڕW�n�_�����X�g�Ɋi�[����
  //_targetobject�̎q�v�f��Transform���i�[����
  void GetPoint() {
    if (_targetobject.childCount == 0) { return; }
    foreach (Transform child in _targetobject) {
      //���X�g�Ɋi�[����
      _nextPoint.Add(child.transform);
      //Debug.Log(_nextPoint);
    }
  }

  //���̖ڕW�n�_
  void NextPoint() {
    //���X�g�̗v�f��������ȏ�Ȃ��ꍇ�@=>�@�Y�����̒l���O�ɂ���
    if (_pointNum + 1 == _listNum) {
      _pointNum = 0;
    } else {
      //���̖ڕW�n�_��ݒ肷��
      _pointNum++;
    }

    _nav.SetDestination(_nextPoint[_pointNum].position);
  }
}
