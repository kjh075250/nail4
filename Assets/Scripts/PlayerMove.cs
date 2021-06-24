using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;
    private GameManager gameManager = null;
    private Vector2 targetPosition = Vector2.zero;
    private Animator animator = null;
    private GameObject Hammer = null;
    private SpriteRenderer spriteRenderer = null;
    [SerializeField]
    private GameObject HammerPrefab = null;
    private bool isdamaged = false;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    private IEnumerator Fire()
    {        
        animator.Play("Player");       
        yield return new WaitForSeconds(0.5f);
        animator.Play("Nailer2");


    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            animator.Play("NailerMove");
            targetPosition.x = Mathf.Clamp(targetPosition.x, gameManager.MinPosition.x, gameManager.MaxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, gameManager.MinPosition.y, gameManager.MaxPosition.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            if (Hammer == null)
            {
                StartCoroutine(Fire());
                Hammer = Instantiate(HammerPrefab, this.transform);
                Hammer.transform.SetParent(null);
            }

        }
            
                
    }
    private void SpawnOrInstantiate()
    {
        if (HammerPrefab == null) return;

        GameObject bullet;
        if (gameManager.pool.transform.childCount > 0)
        {
            bullet = gameManager.pool.transform.GetChild(0).gameObject;
            bullet.transform.SetParent(transform, false);
            bullet.transform.position = transform.position;
            bullet.SetActive(true);
            bullet.transform.SetParent(null);
        }
        else
        {
            bullet = Instantiate(HammerPrefab, transform);
            bullet.transform.SetParent(null);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isdamaged) return;
        isdamaged = true;
        StartCoroutine(Dead());
    }
    private IEnumerator Dead()
    {
        gameManager.dead();
        for(int i = 0; i < 5; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        isdamaged = false;
    }
}
