using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Loading;

public class StageTransition : UpaSceneManager
{
    //���̃X�e�[�W
    [Tooltip("���̃X�e�[�W")]
    public string nextStage;
    
    //���̃X�e�[�WScene�ɑJ��
    public void NextStage()
    {
        LoadScene(nextStage);
    }
}
