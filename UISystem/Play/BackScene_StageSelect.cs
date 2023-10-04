using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BackScene_StageSelect : MonoBehaviour
{
    private StageTransition _stageTransition;
    // Start is called before the first frame update
    void Start()
    {
      _stageTransition = GetComponent<StageTransition>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            _stageTransition.NextStage();
        }
    }

}
