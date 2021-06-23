using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private int score = 50;
    [SerializeField]
    protected float speed = 10f;
    
    private GameManager gameManager = null;
    private Collider2D col = null;
    private Animator animator = null;
   
    private bool isdead;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isdead) return;
        Move();
        
        if (transform.position.x < gameManager.MinPosition.x)
            Destroy(gameObject);
        if (transform.position.y < gameManager.MinPosition.y)
            Destroy(gameObject);
        if (transform.position.y > gameManager.MaxPosition.y)
            Destroy(gameObject);
    }
    protected virtual void Move()
    {
       transform.Translate(Vector2.left * speed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isdead) return;
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            isdead = true;
            StartCoroutine(Dead());
        }
    }
    private IEnumerator Dead()
    {
        gameManager.addscore(score);
        col.enabled = false;
        animator.Play("Enemy");
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
