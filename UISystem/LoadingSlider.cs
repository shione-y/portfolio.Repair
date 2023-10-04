using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//ローディング画面
//　◆　ローディング時間が短くても最低３秒間はローディング画面を表示するようにする

public class LoadingSlider : MonoBehaviour
{
    //ローディングパネル
    [SerializeField] private GameObject _loadingUI;
    //ローディングパネル上のスライダー
    [SerializeField] private Slider _slider;

    //ロードをし始めて　「最低何秒待つか」
    private float _currentTime;
    //ロードをし始めて　「何秒たったか」（経過時間）
    private float _durationTime = 3f;
    //
    private float _stopTime = 0.01f;

    public void LoadNextScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("MainScene");

        //読み込み完了時に強制的にシーン遷移しないようにする
        async.allowSceneActivation = false;
        //ローディングパネルを表示
        _loadingUI.SetActive(true);
        //経過時間をリセットする
        _currentTime = 0f;
        StartCoroutine(LoadScene(async));
    }

    IEnumerator LoadScene(AsyncOperation async)
    {
        while (!async.isDone || _currentTime < _durationTime)
        {
            yield return new WaitForSeconds(_stopTime);
            _currentTime += _stopTime;
            
            //ロードの進捗割合　と　最低待ち時間に対した経過時間の割合を比較
            //ロードの進捗割合が遅れている場合（ロードが最低待ち時間以上かかっている場合）
            if(async.progress / 0.9f < _currentTime / _durationTime)
            {
                _slider.value = async.progress;
            }
            //経過時間の割合が遅れている場合（ロードがすでに終了している場合）
            else
            {
                _slider.value = _currentTime / _durationTime;
            }

            yield return new WaitForSeconds(1);
            async.allowSceneActivation = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
