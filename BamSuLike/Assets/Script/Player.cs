using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Input System 기능을 사용하기 위해 반드시 추가해야 합니다

public class Player : MonoBehaviour
{
    [SerializeField]
    private Vector2 inputVec; // 키입력을 저장할 벡터

    [SerializeField]
    private float speed; // 이동 속도

    private Rigidbody2D rigid; // Rigidbody Component 접근 경로
    private SpriteRenderer spRenderer; // SpriteRenderer Component 접근 경로
    private Animator animator; // Animator Component 접근 경로

    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>(); // 현재 오브젝트의 Rigidbody Component와 연결합니다
        spRenderer = this.GetComponent<SpriteRenderer>(); // 현재 오브젝트의 SpriteRenderer Component와 연결합니다.
        animator = this.GetComponent<Animator>(); // 현재 오브젝트의 Animator Component와 연결합니다.
    }

    private void FixedUpdate()
    {
        // 키입력을 inputVec에 저장합니다
        //inputVec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // inputVec으로 이동 벡터를 계산합니다
        Vector2 nextVec = inputVec.normalized * speed * Time.deltaTime;

        // 이동 벡터만큼 이동시킵니다
        // MovePosition은 전달 받은 좌표로 이동한다는 의미이기 때문에, 현재 위치(this.rigid.position)에 이동 벡터(nextVec)를 더한 값을 전달합니다
        rigid.MovePosition(this.rigid.position + nextVec);
    }

    private void LateUpdate()
    {
        // Speed라는 이름의 Float형 Parameter 값을 inputVec의 길이 값으로 변경합니다.
        animator.SetFloat("Speed", inputVec.magnitude);  

        if (inputVec.x != 0) // 좌우 키 입력이 존재할 때, 다음을 실행합니다.
        {
            spRenderer.flipX = inputVec.x < 0; // 왼쪽 방향으로 이동한다면, 좌우 반전을 시켜 왼쪽을 바라보게 설정합니다.
        }
    }

    void OnMove(InputValue value)
    {
        // inputVec에 Move로 인식한 값을 저장합니다
        inputVec = value.Get<Vector2>();
    }

    public Vector2 GetInputVec()
    {
        return inputVec.normalized;
    }
}
