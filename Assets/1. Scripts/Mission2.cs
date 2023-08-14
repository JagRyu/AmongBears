using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class Mission2 : MonoBehaviour
{
    public Transform trash;

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
        for(int i = 0; i < trash.childCount; i++)
        {
            Destroy(trash.GetChild(i).gameObject);
        }


        //������ ����
        for(int i = 0; i<6; i++)
        {
            //���
            GameObject trash4 = Instantiate(Resources.Load("Trash/Trash4"), trash) as GameObject;
            trash4.GetComponent<RectTransform>().anchoredPosition = new Vector2 (Random.Range(-180,180), Random.Range(-180, 180));
            trash4.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, Random.Range(0, 180));
            //ĵ
            GameObject trash5 = Instantiate(Resources.Load("Trash/Trash5"), trash) as GameObject;
            trash5.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-180, 180), Random.Range(-180, 180));
            trash5.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, Random.Range(0, 180));
        }
        for (int i = 0; i < 3; i++)
        {
            //��
            GameObject trash1 = Instantiate(Resources.Load("Trash/Trash1"), trash) as GameObject;
            trash1.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-180, 180), Random.Range(-180, 180));
            trash1.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, Random.Range(0, 180));
            //����
            GameObject trash2 = Instantiate(Resources.Load("Trash/Trash2"), trash) as GameObject;
            trash2.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-180, 180), Random.Range(-180, 180));
            trash2.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, Random.Range(0, 180));
            //���
            GameObject trash3 = Instantiate(Resources.Load("Trash/Trash3"), trash) as GameObject;
            trash3.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-180, 180), Random.Range(-180, 180));
            trash3.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, Random.Range(0, 180));
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
