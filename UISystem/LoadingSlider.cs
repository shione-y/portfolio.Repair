using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//���[�f�B���O���
//�@���@���[�f�B���O���Ԃ��Z���Ă��Œ�R�b�Ԃ̓��[�f�B���O��ʂ�\������悤�ɂ���

public class LoadingSlider : MonoBehaviour
{
    //���[�f�B���O�p�l��
    [SerializeField] private GameObject _loadingUI;
    //���[�f�B���O�p�l����̃X���C�_�[
    [SerializeField] private Slider _slider;

    //���[�h�����n�߂ā@�u�Œች�b�҂��v
    private float _currentTime;
    //���[�h�����n�߂ā@�u���b���������v�i�o�ߎ��ԁj
    private float _durationTime = 3f;
    //
    private float _stopTime = 0.01f;

    public void LoadNextScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("MainScene");

        //�ǂݍ��݊������ɋ����I�ɃV�[���J�ڂ��Ȃ��悤�ɂ���
        async.allowSceneActivation = false;
        //���[�f�B���O�p�l����\��
        _loadingUI.SetActive(true);
        //�o�ߎ��Ԃ����Z�b�g����
        _currentTime = 0f;
        StartCoroutine(LoadScene(async));
    }

    IEnumerator LoadScene(AsyncOperation async)
    {
        while (!async.isDone || _currentTime < _durationTime)
        {
            yield return new WaitForSeconds(_stopTime);
            _currentTime += _stopTime;
            
            //���[�h�̐i�������@�Ɓ@�Œ�҂����Ԃɑ΂����o�ߎ��Ԃ̊������r
            //���[�h�̐i���������x��Ă���ꍇ�i���[�h���Œ�҂����Ԉȏォ�����Ă���ꍇ�j
            if(async.progress / 0.9f < _currentTime / _durationTime)
            {
                _slider.value = async.progress;
            }
            //�o�ߎ��Ԃ̊������x��Ă���ꍇ�i���[�h�����łɏI�����Ă���ꍇ�j
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
