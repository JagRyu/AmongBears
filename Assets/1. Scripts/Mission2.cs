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

    //미션 시작
    public void MissionStart()
    {
        mAnim.SetBool("isUp", true);
        // 미션은 처음부터 있지만, 캐릭터는 중간에 호출되서 생기기 때문에 MissionStart에 넣음
        playerCrtl_script = FindObjectOfType<PlayerCrt>();

        //초기화
        for(int i = 0; i < trash.childCount; i++)
        {
            Destroy(trash.GetChild(i).gameObject);
        }


        //쓰레기 스폰
        for(int i = 0; i<6; i++)
        {
            //사과
            GameObject trash4 = Instantiate(Resources.Load("Trash/Trash4"), trash) as GameObject;
            trash4.GetComponent<RectTransform>().anchoredPosition = new Vector2 (Random.Range(-180,180), Random.Range(-180, 180));
            trash4.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, Random.Range(0, 180));
            //캔
            GameObject trash5 = Instantiate(Resources.Load("Trash/Trash5"), trash) as GameObject;
            trash5.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-180, 180), Random.Range(-180, 180));
            trash5.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, Random.Range(0, 180));
        }
        for (int i = 0; i < 3; i++)
        {
            //병
            GameObject trash1 = Instantiate(Resources.Load("Trash/Trash1"), trash) as GameObject;
            trash1.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-180, 180), Random.Range(-180, 180));
            trash1.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, Random.Range(0, 180));
            //생선
            GameObject trash2 = Instantiate(Resources.Load("Trash/Trash2"), trash) as GameObject;
            trash2.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-180, 180), Random.Range(-180, 180));
            trash2.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, Random.Range(0, 180));
            //비닐
            GameObject trash3 = Instantiate(Resources.Load("Trash/Trash3"), trash) as GameObject;
            trash3.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-180, 180), Random.Range(-180, 180));
            trash3.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, Random.Range(0, 180));
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
