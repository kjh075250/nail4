using UnityEngine;

public class HammerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    private GameManager gameManager = null;
    // Start is called before the first frame update
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (transform.position.x > gameManager.MaxPosition.x)
            Destroy(gameObject);
        if (transform.position.y > gameManager.MaxPosition.y)
            Destroy(gameObject);
        if (transform.position.y < gameManager.MinPosition.y)
            Destroy(gameObject);
        if (Input.GetMouseButton(0))
            Destroy(gameObject);
    }
}
