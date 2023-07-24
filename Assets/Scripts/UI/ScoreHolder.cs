using TMPro;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreField;

    private int _score = 0;

    public int Score => _score;

    public void UpdateScore()
    {
        _score++;

        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreField.text = _score.ToString();
    }
}
