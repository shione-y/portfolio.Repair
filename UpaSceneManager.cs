using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Unity�����̂��̂Ǝ��ʂ��邽�߂ɁuUpa�v���ŏ��ɕt�������ǁA���ɐ[���Ӗ��͖����ł�
public class UpaSceneManager : MonoBehaviour
{
    // ComingSoon�e�L�X�g�\���p
    public GameObject ComingSoonObj;
    CanvasGroup _panelAlpha;
    float _alphaNum = 0;

    bool _isShow = false;
    float _showTime = 0f;

    //�@���[�f�B���O--------------------------------------

    //���[�f�B���O�p�l��
    [SerializeField] private GameObject _loadingUI;
    //���[�f�B���O�p�l����̃X���C�_�[
    [SerializeField] private Slider _slider;

    //���[�h�����n�߂ā@�u�Œች�b�҂��v
    private float _currentTime;
    //���[�h�����n�߂ā@�u���b���������v�i�o�ߎ��ԁj
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

        // ������
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
            // �\������
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
            // ��\���ɂ���
            _alphaNum -= 3f * Time.deltaTime;
            _panelAlpha.alpha = _alphaNum;
        }
    }

    // �{�^���ɕt����p
    public void LoadScene(string sceneName)
    {
        StartCoroutine(Loading(sceneName));
    }

    public IEnumerator Loading(string sceneName)
    {
        //�o�ߎ��Ԃ����Z�b�g����
        _currentTime = 0f;
        //���[�f�B���O�p�l����\��
        _loadingUI.SetActive(true);

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        //�ǂݍ��݊������ɋ����I�ɃV�[���J�ڂ��Ȃ��悤�ɂ��� => progress��0.9�܂ł����s���Ȃ��Ȃ�
        async.allowSceneActivation = false;

        //�P�b�҂�
        //yield return new WaitForSeconds(1);
        while(_currentTime <= 1f)
        {
            _currentTime += _stopTime;
            Debug.Log("�b���@�F�@" +  _currentTime);
            //���Ƀ��[�h���I����Ă�����
            if (async.progress < 0.9f)
            {
                Debug.Log("���[�h");
                _slider.value = 1;
                async.allowSceneActivation = true;
                break;
            }
        }
        _currentTime = 0f;
        // else����H�H
        //�X���C�_�[��p���ĂR�b�ȏネ�[�h��ʂ�\������
        while (async.progress < 0.9f || _currentTime < _durationTime)
        {
            yield return new WaitForSeconds(_stopTime);
            _currentTime += _stopTime;
            if (_currentTime > _durationTime)
            {
                _currentTime = _durationTime;
            }

            //���[�h�̐i�������@�Ɓ@�Œ�҂����Ԃɑ΂����o�ߎ��Ԃ̊������r
            //���[�h�̐i���������x��Ă���ꍇ�i���[�h���Œ�҂����Ԉȏォ�����Ă���ꍇ�j
            if (async.progress / 0.9f < _currentTime / _durationTime)
            {
                _slider.value = async.progress;
            }
            //�o�ߎ��Ԃ̊������x��Ă���ꍇ�i���[�h�����łɏI�����Ă���ꍇ�j
            else
            {
                _slider.value = _currentTime / _durationTime;
            }
        }
        //yield return new WaitForSeconds(1);
        async.allowSceneActivation = true;
        _loadingUI.SetActive(false);

    }



    //�Q�[���v���C�I��
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }


    // ComingSoon��\������t���O���I��
    public void ShowComingSoon()
    {
        _isShow = true;
    }
}
