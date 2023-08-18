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

    //�̼� ����
    public void MissionStart()
    {
        mAnim.SetBool("isUp", true);
        // �̼��� ó������ ������, ĳ���ʹ� �߰��� ȣ��Ǽ� ����� ������ MissionStart�� ����
        playerCrtl_script = FindObjectOfType<PlayerCrt>();

        //�ʱ�ȭ
        for(int i = 0; i<numbers.childCount; i++)
        {
            numbers.GetChild(i).GetComponent<Image>().color = Color.white;
            numbers.GetChild(i).GetComponent<Button>().enabled = true;
        }

        //���� ���� ��ġ
        for (int i = 0; i<10; i++)
        {
            int rand = Random.Range(0, 10);

            Sprite temp = numbers.GetChild(i).GetComponent<Image>().sprite;
            numbers.GetChild(i).GetComponent<Image>().sprite = numbers.GetChild(rand).GetComponent<Image>().sprite;
            numbers.GetChild(rand).GetComponent<Image>().sprite = temp;
        }
        count = 1;
    }

    //���� ��ư ������ ȣ��
    public void ClickNumber()
    {
        if(count.ToString() == EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name)
        {
            //��ư �� ����
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = blue;

            //��ư ��Ȱ��ȭ
            EventSystem.current.currentSelectedGameObject.GetComponent<Button>().enabled = false;
            count++;

            //�������� üũ
            if(count == 11)
            {
                Invoke("MissionSucces", 0.2f);
            }
        }
    }

    //��� ��ư ������ ȣ��
    public void ClickCancle()
    {
        mAnim.SetBool("isUp", false);
        playerCrtl_script.MissionEnd();
    }
   
    //�̼� �����ϸ� ȣ��
    public void MissionSucces()
    {
        ClickCancle();
    }

}
