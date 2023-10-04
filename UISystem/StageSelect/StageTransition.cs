using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Loading;

public class StageTransition : UpaSceneManager
{
    //次のステージ
    [Tooltip("次のステージ")]
    public string nextStage;
    
    //次のステージSceneに遷移
    public void NextStage()
    {
        LoadScene(nextStage);
    }
}
