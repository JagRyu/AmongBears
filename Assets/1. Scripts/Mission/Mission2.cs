using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class Mission2 : MonoBehaviour
{
    public Transform trash, handle;
    public GameObject bottom;
    public Animator shaker;

    Animator mAnim;
    PlayerCrt playerCrtl_script;
    RectTransform rectHandle;

    bool isDrag;
    bool isPlay;
    Vector2 originPos;

    void Start()
    {
        mAnim = GetComponentInChildren<Animator>();
        rectHandle = handle.GetComponent<RectTransform>();
        originPos = rectHandle.anchoredPosition;
    }
    private void Update()
    {
        if (isPlay)
        {
            // 드래그
            if (isDrag)
            {
                //핸들의 위치를 마우스의 위치로 옮겨줌
                handle.position = Input.mousePosition;
                //제한
                rectHandle.anchoredPosition = new Vector2(originPos.x, Mathf.Clamp(rectHandle.anchoredPosition.y, -135, -48));
                shaker.enabled = true;

                //드래그 끝
                if (Input.GetMouseButtonUp(0))
                {
                    rectHandle.anchoredPosition = originPos;
                    isDrag = false;
                    shaker.enabled = false;
                }

            }
            if (rectHandle.anchoredPosition.y <= -130)
            {
                bottom.SetActive(false);
            }
            else
            {
                bottom.SetActive(true);
            }

            //쓰레기삭제
            for (int i = 0; i < trash.childCount; i++)
            {
                if (trash.GetChild(i).GetComponent<RectTransform>().anchoredPosition.y <= -400)
                {
                    Destroy(trash.GetChild(i).gameObject);
                }
            }
            //성공여부 체크
            if (trash.childCount == 0)
            {
                MissionSucces();
                isPlay = false;
                rectHandle.anchoredPosition = originPos;
                isDrag = false;
                shaker.enabled = false;
            }
        }
    }

    //미션 시작
    public void MissionStart()
    {
        mAnim.SetBool("isUp", true);
        // 미션은 처음부터 있지만, 캐릭터는 중간에 호출되서 생기기 때문에 MissionStart에 넣음
        playerCrtl_script = FindObjectOfType<PlayerCrt>();

        //초기화
        for (int i = 0; i < trash.childCount; i++)
        {
            Destroy(trash.GetChild(i).gameObject);
        }


        //쓰레기 스폰
        for (int i = 0; i < 6; i++)
        {
            //사과
            GameObject trash4 = Instantiate(Resources.Load("Trash/Trash4"), trash) as GameObject;
            trash4.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-180, 180), Random.Range(-180, 180));
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
        isPlay = true;
    }

    //취소 버튼 누르면 호출
    public void ClickCancle()
    {
        mAnim.SetBool("isUp", false);
        playerCrtl_script.MissionEnd();
    }

    //손잡이 누르면 호출
    public void ClickHandle()
    {
        isDrag = true;
    }

    //미션 성공하면 호출
    public void MissionSucces()
    {
        ClickCancle();
    }
}
