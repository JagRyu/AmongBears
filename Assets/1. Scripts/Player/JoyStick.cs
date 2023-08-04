using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{
    //stick�� ��ġ
    public RectTransform stick, backGround;
    PlayerCrt playerCtr;
    bool isDrag;
    float limit;
    // 1. ��ƽ �巡�� + ����(�������� ū�� �ȿ��� ���ѵǰ�, ���콺�� ������ �� �߾ӿ� ��ġ�ϰ�)
    // 2. �巡���� ��ŭ ĳ���� �̵�
    private void Start()
    {
        playerCtr = GetComponent<PlayerCrt>();
        limit = backGround.rect.width * 0.5f;
    }
    private void Update()
    {
        // �巡�� �ϴ� ����
        if (isDrag)
        {
            Vector2 vec = Input.mousePosition - backGround.position;
            // ClampMagnitude(,) => � ���� �󸶸�ŭ ����������
            stick.localPosition = Vector2.ClampMagnitude(vec, limit);

            Vector3 dir = (stick.position - backGround.position).normalized;
            transform.position += dir * playerCtr.speed * Time.deltaTime;

            // ���̽�ƽ Ŭ�� ������� ��(�巡�� ������)
            if (Input.GetMouseButtonUp(0))
            {
                stick.localPosition = new Vector3(0, 0, 0);
                isDrag = false;
            }
        }
    }
    // ��ƽ�� ������ ȣ��
    public void ClickStick()
    {
        isDrag = true;
    }

}
