using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Input System ����� ����ϱ� ���� �ݵ�� �߰��ؾ� �մϴ�

public class Player : MonoBehaviour
{
    [SerializeField]
    private Vector2 inputVec; // Ű�Է��� ������ ����

    [SerializeField]
    private float speed; // �̵� �ӵ�

    private Rigidbody2D rigid; // Rigidbody Component ���� ���
    private SpriteRenderer spRenderer; // SpriteRenderer Component ���� ���
    private Animator animator; // Animator Component ���� ���

    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>(); // ���� ������Ʈ�� Rigidbody Component�� �����մϴ�
        spRenderer = this.GetComponent<SpriteRenderer>(); // ���� ������Ʈ�� SpriteRenderer Component�� �����մϴ�.
        animator = this.GetComponent<Animator>(); // ���� ������Ʈ�� Animator Component�� �����մϴ�.
    }

    private void FixedUpdate()
    {
        // Ű�Է��� inputVec�� �����մϴ�
        //inputVec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // inputVec���� �̵� ���͸� ����մϴ�
        Vector2 nextVec = inputVec.normalized * speed * Time.deltaTime;

        // �̵� ���͸�ŭ �̵���ŵ�ϴ�
        // MovePosition�� ���� ���� ��ǥ�� �̵��Ѵٴ� �ǹ��̱� ������, ���� ��ġ(this.rigid.position)�� �̵� ����(nextVec)�� ���� ���� �����մϴ�
        rigid.MovePosition(this.rigid.position + nextVec);
    }

    private void LateUpdate()
    {
        // Speed��� �̸��� Float�� Parameter ���� inputVec�� ���� ������ �����մϴ�.
        animator.SetFloat("Speed", inputVec.magnitude);  

        if (inputVec.x != 0) // �¿� Ű �Է��� ������ ��, ������ �����մϴ�.
        {
            spRenderer.flipX = inputVec.x < 0; // ���� �������� �̵��Ѵٸ�, �¿� ������ ���� ������ �ٶ󺸰� �����մϴ�.
        }
    }

    void OnMove(InputValue value)
    {
        // inputVec�� Move�� �ν��� ���� �����մϴ�
        inputVec = value.Get<Vector2>();
    }

    public Vector2 GetInputVec()
    {
        return inputVec.normalized;
    }
}
