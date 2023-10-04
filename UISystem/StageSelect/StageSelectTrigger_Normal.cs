using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����o���̕\����\��
public class StageSelectTrigger_Normal : MonoBehaviour
{
    //�@�Ή����鐁���o��
    [SerializeField]
    private GameObject _speechBubble;
    private StageTransition _transition;
    //�X�e�[�W��
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
        //�V�[���J�ڗp�@�{�^���̑J�ڐ�X�e�[�W����ύX����
        _transition.nextStage = _stageName;
    }

    private void OnTriggerExit(Collider other)
    {
        _speechBubble.SetActive(false);
    }
}
