using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Loading;

public class resultButton : MonoBehaviour
{

    //���̃X�e�[�WScene�ɑJ��
    public void NestStage()
    {
        //Debug.Log(" ���̃X�e�[�W��ʂɈړ� ");
        //�X�e�[�W���X�g��p�ӂ��A�������玟�̃X�e�[�W������o���@���@�J��
        SceneManager.LoadScene("test_2");

    }
    //�X�e�[�W�I����ʂɑJ��
    public void StageSelect()
    {
        //Debug.Log(" �X�e�[�W�I����ʂɈړ� ");
        SceneManager.LoadScene("StageSelect");
    }
}
