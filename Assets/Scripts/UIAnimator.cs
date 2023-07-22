using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimator : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI gameOverText;
    public Image buttonImage;
    public Image panel; // Cambiamos el tipo de referencia a Image

    // Esta funci�n se llama cuando se activa el panel
    private void OnEnable()
    {

        // Iniciar las animaciones de los textos en loop (bouncy)
        AnimateBouncyText(scoreText);
        AnimateBouncyText(bestScoreText);

        // Animar el texto "Game Over" con un rebote
        AnimateBouncyText(gameOverText);

        // Animar el bot�n con un rebote
        AnimateBouncyButton();
    }


    // Funci�n para animar el rebote del bot�n
    private void AnimateBouncyButton()
    {
        // Puedes ajustar la magnitud y el tiempo de la animaci�n seg�n tus preferencias
        buttonImage.transform.DOScale(1.2f, 0.5f).SetEase(Ease.OutBounce).SetLoops(-1, LoopType.Yoyo);
    }

    // Funci�n para animar el rebote del texto
    private void AnimateBouncyText(TextMeshProUGUI text)
    {
        // Puedes ajustar la magnitud y el tiempo de la animaci�n seg�n tus preferencias
        text.transform.DOScale(1.1f, 0.5f).SetEase(Ease.OutBounce).SetLoops(-1, LoopType.Yoyo);
    }
}
