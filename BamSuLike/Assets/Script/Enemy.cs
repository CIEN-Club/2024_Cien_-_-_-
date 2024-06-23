using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator animator;
    public RuntimeAnimatorController[] animCon;
    private SpriteRenderer spriteRenderer;

    bool isLive = true;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private float health;

    [SerializeField]
    private Rigidbody2D target;

    Vector2 direction;

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
        isLive = true;
        health = maxHealth;
    }

    public void Init(SpawnData data)
    {
        animator.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Bullet"))
        {
            return;
        }

        health -= collision.GetComponent<Bullet>().GetDamage();

        if(health > 0)
        {
            // Live, Hit action
        }
        else
        {
            // Die
            Dead();
        }
    }

    void Dead()
    {
        this.gameObject.SetActive(false);
    }

    public float getHpRatio()
    {
        return Mathf.Max(0, health / maxHealth);
    }
}
