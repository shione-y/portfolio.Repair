using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//吹き出しの表示非表示
public class StageSelectTrigger_Normal : MonoBehaviour
{
    //　対応する吹き出し
    [SerializeField]
    private GameObject _speechBubble;
    private StageTransition _transition;
    //ステージ名
    public string _stageName;
    


    // Start is called before the first frame update
    void Start()
    {
        _transition = _speechBubble.GetComponent<StageTransition>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        _speechBubble.SetActive(true);
        //シーン遷移用　ボタンの遷移先ステージ名を変更する
        _transition.nextStage = _stageName;
    }

    private void OnTriggerExit(Collider other)
    {
        _speechBubble.SetActive(false);
    }
}
