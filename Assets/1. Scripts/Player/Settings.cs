using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Settings : MonoBehaviour
{

    GameObject mainView, missionView;

    public bool isJoyStick;
    public Image touchBtn, joystickBtn;
    public Color blue;
    public PlayerCrt playerCtrl_script;


    private void Start()
    {
        mainView = playerCtrl_script.mainView;
        missionView = playerCtrl_script.missionView;
    }
    // 설정버튼을 누르면 호츨
    public void ClickSetting()
    {
        gameObject.SetActive(true);
        playerCtrl_script.isCantMove = true;
    }

    // 게임으로 돌아가기 Btn
    public void ClickBack()
    {
        gameObject.SetActive(false);
        playerCtrl_script.isCantMove = false;
    }

    //게임 종료하기 Btn
    public void ClickQuit()
    {
        missionView.SetActive(false);
        mainView.SetActive(true);

        //캐릭터 삭제 기능
        playerCtrl_script.DestroyPlayer();
    }

    // 터치이동 Btn
    public void ClickTouch()
    {
        isJoyStick = false;
        touchBtn.color = blue;
        joystickBtn.color = Color.white;
    }
    // 조이스틱 Btn
    public void ClickJoyStick() 
    {
        isJoyStick = true;
        joystickBtn.color = blue;
        touchBtn.color = Color.white;

    }
}
