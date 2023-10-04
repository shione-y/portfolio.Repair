using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����o���̕\����\��
public class StageSelectTrigger : MonoBehaviour {
  //�@�Ή����鐁���o��
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
