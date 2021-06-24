using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeteorMove : EnemyMove
{
    private int score = 100;
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
        animator.Play("MeteorBroken");
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}

