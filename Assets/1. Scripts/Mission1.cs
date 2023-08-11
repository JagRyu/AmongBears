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

    //�̼� ����
    public void MissionStart()
    {
        mAnim.SetBool("isUp", true);
        // �̼��� ó������ ������, ĳ���ʹ� �߰��� ȣ��Ǽ� ����� ������ MissionStart�� ����
        playerCrtl_script = FindObjectOfType<PlayerCrt>();
    }
    //��� ��ư ������ ȣ��
    public void ClickCancle()
    {
        mAnim.SetBool("isUp", false);
        playerCrtl_script.MissionEnd();
    }

}
