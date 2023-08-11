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
    // ������ư�� ������ ȣ��
    public void ClickSetting()
    {
        gameObject.SetActive(true);
        playerCtrl_script.isCantMove = true;
    }

    // �������� ���ư��� Btn
    public void ClickBack()
    {
        gameObject.SetActive(false);
        playerCtrl_script.isCantMove = false;
    }

    //���� �����ϱ� Btn
    public void ClickQuit()
    {
        missionView.SetActive(false);
        mainView.SetActive(true);

        //ĳ���� ���� ���
        playerCtrl_script.DestroyPlayer();
    }

    // ��ġ�̵� Btn
    public void ClickTouch()
    {
        isJoyStick = false;
        touchBtn.color = blue;
        joystickBtn.color = Color.white;
    }
    // ���̽�ƽ Btn
    public void ClickJoyStick() 
    {
        isJoyStick = true;
        joystickBtn.color = blue;
        touchBtn.color = Color.white;

    }
}
