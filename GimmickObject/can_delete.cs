using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can_delete : MonoBehaviour {
  void OnCollisionEnter(Collision collision) {
    // 当たったら全部消す
    Destroy(collision.gameObject);
  }
}