using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class Mission3 : MonoBehaviour
{
    public Text InputText, KeyCode;
    public Animator shaker;

    Animator mAnim;
    PlayerCrt playerCrtl_script;


    void Start()
    {
        mAnim = GetComponentInChildren<Animator>();
    }

    //미션 시작
    public void MissionStart()
    {
        mAnim.SetBool("isUp", true);
        // 미션은 처음부터 있지만, 캐릭터는 중간에 호출되서 생기기 때문에 MissionStart에 넣음
        playerCrtl_script = FindObjectOfType<PlayerCrt>();

        //초기화
        InputText.text = string.Empty;
        KeyCode.text = string.Empty;

        //키코드 랜덤 숫자
        for(int i = 0; i<5; i++)
        {
            KeyCode.text += Random.Range(0, 10);
        }
    }

    //취소 버튼 누르면 호출
    public void ClickCancle()
    {
        mAnim.SetBool("isUp", false);
        playerCrtl_script.MissionEnd();
    }
    //숫자 버튼 누르면 호출
    public void ClickNumber()
    {
        if (InputText.text.Length <= 4)
        {
            InputText.text += EventSystem.current.currentSelectedGameObject.name;
        }
    }
    //삭제 버튼 누르면 호출
    public void ClickDelete()
    {
        if(InputText.text != string.Empty)
        {
            InputText.text = InputText.text.Substring(0, InputText.text.Length - 1);
        }
    }

    //체크 버튼 누르면 호출
    public void ClickCheck()
    {
        if (InputText.text == KeyCode.text)
        {
            MissionSucces();
        }
        else
        {
            shaker.enabled = true;
        }
    }
    //미션 성공하면 호출
    public void MissionSucces()
    {
        ClickCancle();
    }

}
