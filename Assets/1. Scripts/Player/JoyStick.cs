using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{
    //stick의 위치
    public RectTransform stick, backGround;
    PlayerCrt playerCtr;
    bool isDrag;
    float limit;
    // 1. 스틱 드래그 + 제한(움직임이 큰원 안에서 극한되고, 마우스를 놓았을 때 중앙에 위치하게)
    // 2. 드래그한 만큼 캐릭터 이동
    private void Start()
    {
        playerCtr = GetComponent<PlayerCrt>();
        limit = backGround.rect.width * 0.5f;
    }
    private void Update()
    {
        // 드래그 하는 동안
        if (isDrag)
        {
            Vector2 vec = Input.mousePosition - backGround.position;
            // ClampMagnitude(,) => 어떤 값을 얼마만큼 제한해줄지
            stick.localPosition = Vector2.ClampMagnitude(vec, limit);

            Vector3 dir = (stick.position - backGround.position).normalized;
            transform.position += dir * playerCtr.speed * Time.deltaTime;

            // 조이스틱 클릭 떼어냈을 때(드래그 끝나면)
            if (Input.GetMouseButtonUp(0))
            {
                stick.localPosition = new Vector3(0, 0, 0);
                isDrag = false;
            }
        }
    }
    // 스틱을 누르면 호출
    public void ClickStick()
    {
        isDrag = true;
    }

}
