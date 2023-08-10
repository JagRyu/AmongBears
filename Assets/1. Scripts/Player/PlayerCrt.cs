using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerCrt : MonoBehaviour
{
    public GameObject joyStick;
    public float speed;

    public Settings settings;
    Animator anim;

    public bool isCantMove;
    private void Start()
    {
        anim = GetComponent<Animator>();
        Camera.main.transform.parent = transform;
        Camera.main.transform.localPosition = new Vector3(0, 0, -10f);

    }
    private void Update()
    {
        if (isCantMove)
        {
            joyStick.SetActive(false);
        }
        else
        {
            Move();
        }
    }

    //캐릭터 움직임 관리
    void Move()
    {
        if (settings.isJoyStick)
        {
            joyStick.SetActive(true);
        }
        else
        {
            joyStick.SetActive(false);

            //클릭했는지 판단
            if (Input.GetMouseButton(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    Vector3 dir = (Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f)).normalized;

                    transform.position += dir * speed * Time.deltaTime;
                    anim.SetBool("isWalk", true);

                    if (dir.x < 0)
                    {
                        //왼쪽
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else
                    {
                        //오른쪽
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                }
            }
            //클릭하지 않는다면
            else
            {
                anim.SetBool("isWalk", false);
            }
        }
    }
}
