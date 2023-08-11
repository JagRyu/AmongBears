using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission1 : MonoBehaviour
{
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
    }
    //취소 버튼 누르면 호출
    public void ClickCancle()
    {
        mAnim.SetBool("isUp", false);
        playerCrtl_script.MissionEnd();
    }

}
