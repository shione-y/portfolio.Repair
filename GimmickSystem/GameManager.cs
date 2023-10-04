using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

  //���U���g�p�l��
  [SerializeField] private GameObject resultPanel;



  void Start() {
    Time.timeScale = 1;
  }

  void Update() {

  }

  //�X�e�[�W�̃��Z�b�g
  public void GameReset() {
    //�V�[����ǂݍ��݂Ȃ���
    //���݂̃V�[�������擾
    Scene nowScene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(nowScene.name);
  }

  //�N���A����

  public void Clear() {
    Debug.Log("--------------- G A M E  C L E A R ---------------");
    // SE
    // Animation
    //�|�[�Y
    Time.timeScale = 0;

    //SE
    //���U���g�̕\��
    resultPanel.SetActive(true);


  }


}
