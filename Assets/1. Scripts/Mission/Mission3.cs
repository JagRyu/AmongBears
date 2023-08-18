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

    //�̼� ����
    public void MissionStart()
    {
        mAnim.SetBool("isUp", true);
        // �̼��� ó������ ������, ĳ���ʹ� �߰��� ȣ��Ǽ� ����� ������ MissionStart�� ����
        playerCrtl_script = FindObjectOfType<PlayerCrt>();

        //�ʱ�ȭ
        InputText.text = string.Empty;
        KeyCode.text = string.Empty;

        //Ű�ڵ� ���� ����
        for(int i = 0; i<5; i++)
        {
            KeyCode.text += Random.Range(0, 10);
        }
    }

    //��� ��ư ������ ȣ��
    public void ClickCancle()
    {
        mAnim.SetBool("isUp", false);
        playerCrtl_script.MissionEnd();
    }
    //���� ��ư ������ ȣ��
    public void ClickNumber()
    {
        if (InputText.text.Length <= 4)
        {
            InputText.text += EventSystem.current.currentSelectedGameObject.name;
        }
    }
    //���� ��ư ������ ȣ��
    public void ClickDelete()
    {
        if(InputText.text != string.Empty)
        {
            InputText.text = InputText.text.Substring(0, InputText.text.Length - 1);
        }
    }

    //üũ ��ư ������ ȣ��
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
    //�̼� �����ϸ� ȣ��
    public void MissionSucces()
    {
        ClickCancle();
    }

}
