using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�@���@�A�j���[�V�����C�x���g���s���I�u�W�F�N�g�ɂ͏�����ԂŃI�[�f�B�I�\�[�X�����Ȃ�
public class GimmickAnimationEvents : MonoBehaviour
{
    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void Door_se()
    {
        this.GetComponent<AudioSource>().Play();
    }

    void Fens_falldown_se()
    {
        this.GetComponent<AudioSource>().Play();
    }

    void handle_se()
    {
        this.GetComponent <AudioSource>().Play();
    }

}
