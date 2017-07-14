using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    public string myName = "Hyona";
    public Sprite[] mySprite;
    public float X_Rotation; //float는 뜬다는 말 즉, 부동 소수점이라는 뜻
    public float Y_Rotation;
    public float Z_Rotation = 0.1f;
    public float Y_MoveSpeed = 20;
    public float X_MoveSpeed = 20;
    public int Count = 0; //interger 라는 약자로 정수 라는 뜻
    private bool IsRotate = true;
    private bool RotateDirection = false; // bool 은 참과 거짓만을 담는 유형 회전방향 값은 처음에 거짓을 주고 시작
    private int spriteNum = 0;
    public bool CanMove = true;
    public bool AutoAnimation = false;
    public float WaitTime = 0.5f;
    private float AnimCounter = 0;
    // Use this for initialization
    void Start()
    {

        this.transform.name = myName;
    }

    // Update is called once per frame
    void Update()
    {
        Count += 1; //Count = Count + 1; 혹은  Count++;

        //Debug.Log("frame count = " + Count); // frame count = 라는 문자열 뒤에 Count 변수 값을 붙여주고 그걸 로그 기록으로 뿌려준다.

        if (mySprite.Length > 0)
        {
            if (AutoAnimation)
            {
                AnimCounter += Time.deltaTime;

                if (AnimCounter > WaitTime)
                {
                    AnimCounter = 0;
                    spriteNum++; // 그림 번호를 하나 증가
                    if (spriteNum >= mySprite.Length) // 더 그림이 없으면 첫번째 그림으로
                        spriteNum = 0;

                    GetComponent<SpriteRenderer>().sprite = mySprite[spriteNum]; // 그림을 실지로 바꿔준다.
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    spriteNum++;
                    if (spriteNum >= mySprite.Length)
                        spriteNum = 0;

                    GetComponent<SpriteRenderer>().sprite = mySprite[spriteNum];
                }
            }
        }

        if (CanMove)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // 만약 스페이스 바가 눌리는 순간이라면
            {
                RotateDirection = !RotateDirection; // 회전 방향 값의 참과 거짓을 뒤집는다.
                                                    //Debug.Log("스페이스바가 눌렸습니다. RotateDirection 값은 " + RotateDirection + "입니다");
            }

            if (Input.GetKeyDown(KeyCode.Return))
                IsRotate = !IsRotate;

            if (IsRotate)
            {
                if (RotateDirection == true) // = 를 2개 놔둔건(==) 같은지 비교하는 것. != 는 같지 않으면이라는 뜻.
                {
                    transform.localEulerAngles += new Vector3(X_Rotation, Y_Rotation, Z_Rotation) * Time.deltaTime;
                }
                else
                {
                    transform.localEulerAngles -= new Vector3(X_Rotation, Y_Rotation, Z_Rotation) * Time.deltaTime;
                }
            }

            Vector3 nowPos = transform.localPosition;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                nowPos -= new Vector3(X_MoveSpeed, 0, 0) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                nowPos -= new Vector3(-X_MoveSpeed, 0, 0) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                nowPos += new Vector3(0, Y_MoveSpeed, 0) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                nowPos += new Vector3(0, -Y_MoveSpeed, 0) * Time.deltaTime;
            }

            if (nowPos.x > 8)
                nowPos.x = 8;

            if (nowPos.x < -8)
                nowPos.x = -8;

            if (nowPos.y > 5)
                nowPos.y = 5;

            if (nowPos.y < -5)
                nowPos.y = -5;

            transform.localPosition = nowPos;
        }

        

    }
}