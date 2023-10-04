using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//プレイ画面の操作UIの表示・非表示スクリプト


// 7/4 フェードインアウトの入りが気持ち悪い　遅い　
public class InstructionsDisplay : MonoBehaviour {
  //操作説明のパネル
  public GameObject instructions;
  private CanvasGroup _panelAlpha;
  private float _alphaNum = 0;

  //キー入力が行われているかどうか false キー入力なし　true　キー入力あり
  private float _notInputTime = 0.00f;

  bool _isFadeOut = false;

  void Start() {
    _panelAlpha = instructions.GetComponent<CanvasGroup>();
    _panelAlpha.alpha = 0;
  }

  void Update() {
    if (!Input.anyKey && Input.GetAxis("Horizontal") == 0f) {
      //キー入力がない間経過秒数を数える
      _notInputTime += Time.deltaTime;
      //経過秒数が5秒以上になったら、パネルを表示
      if (_notInputTime >= 5.0f) {
        _alphaNum += Time.deltaTime;
        _panelAlpha.alpha = _alphaNum;
      }
    } else {
      //入力があったら時間経過をリセットする
      _notInputTime = 0;
      _isFadeOut = true;
    }

    if (_isFadeOut && _panelAlpha.alpha > 0) {
      //操作方法パネルを非表示にする
      _alphaNum -= 1.3f * Time.deltaTime;
      _panelAlpha.alpha = _alphaNum;

    } else if (_panelAlpha.alpha == 0) {
      _isFadeOut = false;
    }
  }
}
