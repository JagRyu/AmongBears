using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class Mission1 : MonoBehaviour
{
    public Color red;
    public Image[] imgs; 
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
        for(int i = 0; i < imgs.Length; i++)
        {
            imgs[i].color = Color.white;
        }
        //랜덤으로
        for(int i = 0; i<4; i++) 
        {
            int rand = Random.Range(0, 7); //0~6
            imgs[rand].color = red;
        }
    }
    //취소 버튼 누르면 호출
    public void ClickCancle()
    {
        mAnim.SetBool("isUp", false);
        playerCrtl_script.MissionEnd();
    }
    //육각형 버튼 누르면 호출
    public void ClickButton()
    {
        Image img = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();
        if(img.color == Color.white)
        {
            //하얀색이면 빨간색으로
            img.color = red;
        }
        else
        {
            //빨간색이면 하얀색으로
            img.color = Color.white;
        }

        //성공여부 체크
        int count = 0;
        for(int i = 0;i < imgs.Length;i++)
        {
            if (imgs[i].color == Color.white) { count++; }
        }
        if(count == imgs.Length)
        {
            //성공
            Invoke("MissionSucces", 0.2f);
        }
    }

    //미션 성공하면 호출
    public void MissionSucces()
    {
        ClickCancle();
    }

}
