using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MissionView;
    public GameObject Player;

    // ���� ���� ��ư ������ ȣ��
    public void ClickQuit()
    {
        print("�������� ��ư ����");
        //����Ƽ ������
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        //�ȵ���̵�
#else
Application.Quit();
#endif

    }


    //�̼� ��ư ������ ȣ��
    public void ClickMission()
    {
        gameObject.SetActive(false);
        MissionView.SetActive(true);

        GameObject player = Instantiate(Player, new Vector3(0,-2,0),Quaternion.identity);
        player.GetComponent<PlayerCrt>().mainView = gameObject;
        player.GetComponent<PlayerCrt>().missionView = MissionView;

    }


}
