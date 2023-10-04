using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//吹き出しの表示非表示
public class StageSelectTrigger : MonoBehaviour {
  //　対応する吹き出し
  [SerializeField]
  private GameObject _speechBubble;


  // Start is called before the first frame update
  void Start() {
  }

  // Update is called once per frame
  void Update() {

  }

  private void OnTriggerEnter(Collider other) {
    _speechBubble.SetActive(true);
  }

  private void OnTriggerExit(Collider other) {
    _speechBubble.SetActive(false);
  }
}
