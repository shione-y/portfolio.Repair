using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//　※　アニメーションイベントを行うオブジェクトには初期状態でオーディオソースをつけない
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
