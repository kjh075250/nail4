using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeteorMove : EnemyMove
{

    //    private int score = 100;
    //    [SerializeField]
    //    private int speed = 30;
    //    private int hp = 3;
    //    private GameManager gameManager = null;
    //    private Collider2D col = null;
    //    private Animator animator = null;
    //    private SpriteRenderer spriteRenderer = null;

    //    private bool isdead;
    //    private bool isdamaged;
    //    private void Start()
    //    {
    //        gameManager = FindObjectOfType<GameManager>();
    //        col = GetComponent<Collider2D>();
    //        animator = GetComponent<Animator>();
    //        spriteRenderer = GetComponent<SpriteRenderer>();
    //    }

    //    private void Update()
    //    {
    //        if (isdamaged) return;
    //        if (isdead) return;
    //        transform.Translate(Vector2.left * speed * Time.deltaTime);
    //        if (transform.position.x < gameManager.MinPosition.x)
    //            Destroy(gameObject);
    //        if (transform.position.y < gameManager.MinPosition.y)
    //            Destroy(gameObject);
    //        if (transform.position.y > gameManager.MaxPosition.y)
    //            Destroy(gameObject);
    //    }
    //    private void OnTriggerEnter2D(Collider2D collision)
    //    {
    //        if (isdead) return;
    //        if (collision.CompareTag("Bullet"))
    //        {
    //            Destroy(collision.gameObject);
    //            if( hp > 1)
    //            {
    //                if (isdamaged) return;
    //                isdamaged = true;
    //                StartCoroutine(Damaged());
    //                return;
    //            }
    //            isdead = true;
    //            StartCoroutine(Dead());
    //        }
    //    }
    //    private IEnumerator Damaged()
    //    {
    //        hp--;
    //        yield return new WaitForSeconds(0.1f);
    //        isdamaged = false;
    //    }
    //    private IEnumerator Dead()
    //    {
    //        gameManager.addscore(score);
    //        col.enabled = false;
    //        animator.Play("MeteorBroken");
    //        yield return new WaitForSeconds(0.4f);
    //        Destroy(gameObject);
    //    }
    //}
}
