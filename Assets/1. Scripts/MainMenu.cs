using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
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
}
