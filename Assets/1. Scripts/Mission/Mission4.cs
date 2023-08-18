using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class Mission4 : MonoBehaviour
{
    public Transform numbers;
    public Color blue;
    Animator mAnim;
    PlayerCrt playerCrtl_script;

    int count;
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
        for(int i = 0; i<numbers.childCount; i++)
        {
            numbers.GetChild(i).GetComponent<Image>().color = Color.white;
            numbers.GetChild(i).GetComponent<Button>().enabled = true;
        }

        //숫자 랜덤 배치
        for (int i = 0; i<10; i++)
        {
            int rand = Random.Range(0, 10);

            Sprite temp = numbers.GetChild(i).GetComponent<Image>().sprite;
            numbers.GetChild(i).GetComponent<Image>().sprite = numbers.GetChild(rand).GetComponent<Image>().sprite;
            numbers.GetChild(rand).GetComponent<Image>().sprite = temp;
        }
        count = 1;
    }

    //숫자 버튼 누르면 호출
    public void ClickNumber()
    {
        if(count.ToString() == EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name)
        {
            //버튼 색 변경
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = blue;

            //버튼 비활성화
            EventSystem.current.currentSelectedGameObject.GetComponent<Button>().enabled = false;
            count++;

            //성공여부 체크
            if(count == 11)
            {
                Invoke("MissionSucces", 0.2f);
            }
        }
    }

    //취소 버튼 누르면 호출
    public void ClickCancle()
    {
        mAnim.SetBool("isUp", false);
        playerCrtl_script.MissionEnd();
    }
   
    //미션 성공하면 호출
    public void MissionSucces()
    {
        ClickCancle();
    }

}
