using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private Text textHighScore = null;
    private void Start()
    {
        textHighScore.text = string.Format("HIGHSCORE {0}", PlayerPrefs.GetInt("highscore", 0));
    }

    // Update is called once per frame
    public void OnClickStart()
    {
        SceneManager.LoadScene("Main");
    }
}
