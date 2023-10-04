using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Loading;

public class resultButton : MonoBehaviour
{

    //次のステージSceneに遷移
    public void NestStage()
    {
        //Debug.Log(" 次のステージ画面に移動 ");
        //ステージリストを用意し、そこから次のステージを割り出す　→　遷移
        SceneManager.LoadScene("test_2");

    }
    //ステージ選択画面に遷移
    public void StageSelect()
    {
        //Debug.Log(" ステージ選択画面に移動 ");
        SceneManager.LoadScene("StageSelect");
    }
}
