using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text finalScoreText;
    [SerializeField] TMP_Text bestScoreText;

    float score;
    float finalScore;
    float bestScore;

    bool isAnimating;

    private void Start()
    {
        bestScore = PlayerPrefs.GetFloat("BestScore", 0f);
        bestScoreText.text = "Best: " + ((int)bestScore).ToString();
    }

    private void Update()
    {
        if (GameManager.Instance.IsPlayerAlive)
        {
            score += 1 * Time.deltaTime;
            scoreText.text = ((int)score).ToString();
        }
        else
        {
            if (score > finalScore && !isAnimating)
            {
                StartCoroutine(AnimateScore(finalScore, score));
                finalScore = score; // Solo actualizar el valor del finalScore al comienzo de la animación
            }
        }
    }

    IEnumerator AnimateScore(float startValue, float endValue)
    {
        isAnimating = true;
        float currentValue = startValue;
        float duration = 1f; // Duración de la animación en segundos

        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            currentValue = Mathf.Lerp(startValue, endValue, timer / duration);
            finalScoreText.text = "Score: " + ((int)currentValue).ToString();
            yield return null;
        }

        finalScoreText.text = "Score: " + ((int)endValue).ToString();
        // No actualizamos el bestScoreText aquí para que mantenga su valor original

        if (endValue > bestScore)
        {
            bestScore = endValue;
            PlayerPrefs.SetFloat("BestScore", bestScore);
            bestScoreText.text = "Best: " + ((int)bestScore).ToString(); // Solo actualizamos el bestScoreText cuando el bestScore cambia
        }

        isAnimating = false;
    }
}
