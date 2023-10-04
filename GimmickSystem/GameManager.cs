using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

  //リザルトパネル
  [SerializeField] private GameObject resultPanel;



  void Start() {
    Time.timeScale = 1;
  }

  void Update() {

  }

  //ステージのリセット
  public void GameReset() {
    //シーンを読み込みなおす
    //現在のシーン名を取得
    Scene nowScene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(nowScene.name);
  }

  //クリア処理

  public void Clear() {
    Debug.Log("--------------- G A M E  C L E A R ---------------");
    // SE
    // Animation
    //ポーズ
    Time.timeScale = 0;

    //SE
    //リザルトの表示
    resultPanel.SetActive(true);


  }


}
