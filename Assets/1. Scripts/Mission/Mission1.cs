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

    //�̼� ����
    public void MissionStart()
    {
        mAnim.SetBool("isUp", true);
        // �̼��� ó������ ������, ĳ���ʹ� �߰��� ȣ��Ǽ� ����� ������ MissionStart�� ����
        playerCrtl_script = FindObjectOfType<PlayerCrt>();


        //�ʱ�ȭ
        for(int i = 0; i < imgs.Length; i++)
        {
            imgs[i].color = Color.white;
        }
        //��������
        for(int i = 0; i<4; i++) 
        {
            int rand = Random.Range(0, 7); //0~6
            imgs[rand].color = red;
        }
    }
    //��� ��ư ������ ȣ��
    public void ClickCancle()
    {
        mAnim.SetBool("isUp", false);
        playerCrtl_script.MissionEnd();
    }
    //������ ��ư ������ ȣ��
    public void ClickButton()
    {
        Image img = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();
        if(img.color == Color.white)
        {
            //�Ͼ���̸� ����������
            img.color = red;
        }
        else
        {
            //�������̸� �Ͼ������
            img.color = Color.white;
        }

        //�������� üũ
        int count = 0;
        for(int i = 0;i < imgs.Length;i++)
        {
            if (imgs[i].color == Color.white) { count++; }
        }
        if(count == imgs.Length)
        {
            //����
            Invoke("MissionSucces", 0.2f);
        }
    }

    //�̼� �����ϸ� ȣ��
    public void MissionSucces()
    {
        ClickCancle();
    }

}
