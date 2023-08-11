using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MissionView;
    public GameObject Player;

    // 게임 종료 버튼 누르면 호출
    public void ClickQuit()
    {
        print("게임종료 버튼 누름");
        //유니티 에디터
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        //안드로이드
#else
Application.Quit();
#endif

    }


    //미션 버튼 누르면 호출
    public void ClickMission()
    {
        gameObject.SetActive(false);
        MissionView.SetActive(true);

        GameObject player = Instantiate(Player, new Vector3(0,-2,0),Quaternion.identity);
        player.GetComponent<PlayerCrt>().mainView = gameObject;
        player.GetComponent<PlayerCrt>().missionView = MissionView;

    }


}
