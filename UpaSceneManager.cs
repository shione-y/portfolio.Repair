using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Unity公式のものと識別するために「Upa」を最初に付けたけど、特に深い意味は無いです
public class UpaSceneManager : MonoBehaviour
{
    // ComingSoonテキスト表示用
    public GameObject ComingSoonObj;
    CanvasGroup _panelAlpha;
    float _alphaNum = 0;

    bool _isShow = false;
    float _showTime = 0f;

    //　ローディング--------------------------------------

    //ローディングパネル
    [SerializeField] private GameObject _loadingUI;
    //ローディングパネル上のスライダー
    [SerializeField] private Slider _slider;

    //ロードをし始めて　「最低何秒待つか」
    private float _currentTime;
    //ロードをし始めて　「何秒たったか」（経過時間）
    private float _durationTime = 2f;
    //
    private float _stopTime = 0.01f;

    //----------------------------------------------------
    private void Start()
    {

        if (ComingSoonObj != null)
        {
            _panelAlpha = ComingSoonObj.GetComponent<CanvasGroup>();
            _panelAlpha.alpha = 0;
        }

        // 初期化
        _alphaNum = 0;
        _isShow = false;
        _showTime = 0f;

        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (ComingSoonObj == null) { return; }

        if (_isShow)
        {
            // 表示する
            if (_panelAlpha.alpha != 1)
            {
                Debug.Log("Show");
                _alphaNum += 4f * Time.deltaTime;
                _panelAlpha.alpha = _alphaNum;
            }

            _showTime += Time.deltaTime;
            if (_showTime > 2f)
            {
                _isShow = false;
                _showTime = 0f;
            }
        }
        else if (_panelAlpha.alpha > 0)
        {
            Debug.Log("Hide");
            // 非表示にする
            _alphaNum -= 3f * Time.deltaTime;
            _panelAlpha.alpha = _alphaNum;
        }
    }

    // ボタンに付ける用
    public void LoadScene(string sceneName)
    {
        StartCoroutine(Loading(sceneName));
    }

    public IEnumerator Loading(string sceneName)
    {
        //経過時間をリセットする
        _currentTime = 0f;
        //ローディングパネルを表示
        _loadingUI.SetActive(true);

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        //読み込み完了時に強制的にシーン遷移しないようにする => progressが0.9までしか行かなくなる
        async.allowSceneActivation = false;

        //１秒待つ
        //yield return new WaitForSeconds(1);
        while(_currentTime <= 1f)
        {
            _currentTime += _stopTime;
            Debug.Log("秒数　：　" +  _currentTime);
            //既にロードが終わっていたら
            if (async.progress < 0.9f)
            {
                Debug.Log("ロード");
                _slider.value = 1;
                async.allowSceneActivation = true;
                break;
            }
        }
        _currentTime = 0f;
        // elseいる？？
        //スライダーを用いて３秒以上ロード画面を表示する
        while (async.progress < 0.9f || _currentTime < _durationTime)
        {
            yield return new WaitForSeconds(_stopTime);
            _currentTime += _stopTime;
            if (_currentTime > _durationTime)
            {
                _currentTime = _durationTime;
            }

            //ロードの進捗割合　と　最低待ち時間に対した経過時間の割合を比較
            //ロードの進捗割合が遅れている場合（ロードが最低待ち時間以上かかっている場合）
            if (async.progress / 0.9f < _currentTime / _durationTime)
            {
                _slider.value = async.progress;
            }
            //経過時間の割合が遅れている場合（ロードがすでに終了している場合）
            else
            {
                _slider.value = _currentTime / _durationTime;
            }
        }
        //yield return new WaitForSeconds(1);
        async.allowSceneActivation = true;
        _loadingUI.SetActive(false);

    }



    //ゲームプレイ終了
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }


    // ComingSoonを表示するフラグをオン
    public void ShowComingSoon()
    {
        _isShow = true;
    }
}
