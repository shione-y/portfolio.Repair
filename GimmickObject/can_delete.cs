using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can_delete : MonoBehaviour {
  void OnCollisionEnter(Collision collision) {
    // ����������S������
    Destroy(collision.gameObject);
  }
}