using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�v���C��ʂ̑���UI�̕\���E��\���X�N���v�g


// 7/4 �t�F�[�h�C���A�E�g�̓��肪�C���������@�x���@
public class InstructionsDisplay : MonoBehaviour {
  //��������̃p�l��
  public GameObject instructions;
  private CanvasGroup _panelAlpha;
  private float _alphaNum = 0;

  //�L�[���͂��s���Ă��邩�ǂ��� false �L�[���͂Ȃ��@true�@�L�[���͂���
  private float _notInputTime = 0.00f;

  bool _isFadeOut = false;

  void Start() {
    _panelAlpha = instructions.GetComponent<CanvasGroup>();
    _panelAlpha.alpha = 0;
  }

  void Update() {
    if (!Input.anyKey && Input.GetAxis("Horizontal") == 0f) {
      //�L�[���͂��Ȃ��Ԍo�ߕb���𐔂���
      _notInputTime += Time.deltaTime;
      //�o�ߕb����5�b�ȏ�ɂȂ�����A�p�l����\��
      if (_notInputTime >= 5.0f) {
        _alphaNum += Time.deltaTime;
        _panelAlpha.alpha = _alphaNum;
      }
    } else {
      //���͂��������玞�Ԍo�߂����Z�b�g����
      _notInputTime = 0;
      _isFadeOut = true;
    }

    if (_isFadeOut && _panelAlpha.alpha > 0) {
      //������@�p�l�����\���ɂ���
      _alphaNum -= 1.3f * Time.deltaTime;
      _panelAlpha.alpha = _alphaNum;

    } else if (_panelAlpha.alpha == 0) {
      _isFadeOut = false;
    }
  }
}
