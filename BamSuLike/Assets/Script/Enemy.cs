using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Rigidbody2D target;

    Vector2 direction;
    bool isLive;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        isLive = true;
    }

    private void OnEnable()
    {
        target = GameManager.Instance.player.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!isLive) { return; }

        direction = target.position - rigid.position;
        Vector2 nextVec = direction.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if(direction.x != 0)
        {
            spriteRenderer.flipX = direction.x < 0;
        }
    }
}
