using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private int _score = 0;
    private Text _scoreText;

    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }

    public void UpdateScoreText()
    {
        if (_scoreText)
        {
            _scoreText.text = "Score: " + _score.ToString();
        }
    }

    void Start()
    {
        _scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }
}
