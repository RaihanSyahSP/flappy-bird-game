using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private AudioSource dieSoundEffect;
    private int score;

    // ketika game baru mulai maka pause game nya
    private void Awake()
    {
        Application.targetFrameRate = 60;
        dieSoundEffect = GetComponent<AudioSource>();
        Pause();
    }

    public void Play()
    {
        dieSoundEffect = GetComponent<AudioSource>();
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for(int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        //freezeing game nya
        Time.timeScale = 0f;
        player.enabled = false; 
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        dieSoundEffect.Play();
        playButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
