using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    public Vector2 MaxPosition { get; private set; }
    public Vector2 MinPosition { get; private set; }
    // Start is called before the first frame update
    [SerializeField]
    private GameObject EnemyNailPrefab = null;
    [SerializeField]
    private GameObject EnemyMeteorPrefab = null;
    [SerializeField]
    private Text Highscore = null;
    [SerializeField]
    private Text textscore = null;
    [SerializeField]
    private Text textlife = null;
    [SerializeField]
    private Text textStation = null;
    public PoolManager pool { get; private set; }
    private int score = 0;
    private int highscore = 0;
    private int life = 3;
    private int Stationlife = 5;

    private void Awake()
    {
        pool = FindObjectOfType<PoolManager>();
    }
    private void Start()
    {
        MaxPosition = new Vector2(10f, 3.5f);
        MinPosition = new Vector2(-10f, -4f);
        
        highscore = PlayerPrefs.GetInt("highscore", 0);
        UpdateUI();
        StartCoroutine(SpawnEnemyNail());
        StartCoroutine(SpawnEnemyMeteor());

    }

    // Update is called once per frame
    public void dead()
    {
        life--;
        if(life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        UpdateUI();
    }
    public void Stationdead()
    {

    }
    public void addscore(int addscore)
    {
        score += addscore;
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
        UpdateUI();
    }
    private IEnumerator SpawnEnemyMeteor()
    {
        float positionY = 0f;
        float delay = 0f;
        while (true)
        {
            delay = Random.Range(1f, 3f);
            positionY = Random.Range(MinPosition.y, MaxPosition.y);
            Instantiate(EnemyMeteorPrefab, new Vector2(10f, positionY), Quaternion.identity);          
            yield return new WaitForSeconds(delay);

        }
    }
    private IEnumerator SpawnEnemyNail()
    {
        float positionY = 0f;
        float delay = 0f;
        while(true)
        {
            delay = Random.Range(1f, 3f);
            positionY = Random.Range(MinPosition.y, MaxPosition.y);
            for(int i = 0; i < 3; i++)
            {
                Instantiate(EnemyNailPrefab, new Vector2(10f, positionY), Quaternion.identity);
                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(delay);
                   
        }
    }
    private void UpdateUI()
    {
        textscore.text = string.Format("SCORE {0}", score);
        Highscore.text = string.Format("HIGH SCORE {0}", highscore);
        textlife.text = string.Format("LIFE {0}", life);
        textStation.text = string.Format("STATION LIFE {0}", Stationlife);
        
    }
}
