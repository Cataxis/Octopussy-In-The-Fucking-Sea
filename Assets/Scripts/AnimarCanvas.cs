using UnityEngine;
using DG.Tweening;

public class AnimarCanvas : MonoBehaviour
{
    public Transform tituloImage;
    public Transform botonPlayImage;
    public Transform textoCreditos1;
    public Transform textoCreditos2;

    private void Start()
    {
        // Inicia la animación en el método Start
        AnimarCanvasElements();
    }

    private void AnimarCanvasElements()
    {
        // Establecer la posición inicial de los elementos
        tituloImage.localScale = Vector3.zero;
        botonPlayImage.localScale = Vector3.zero;
        textoCreditos1.localScale = Vector3.zero;
        textoCreditos2.localScale = Vector3.zero;

        // Animación de entrada usando DOTween para el título
        tituloImage.DOScale(Vector3.one, 1f).SetEase(Ease.OutElastic);

        // Animación de entrada usando DOTween para los créditos
        textoCreditos1.DOScale(Vector3.one, 0.8f).SetEase(Ease.OutBack).SetDelay(0.3f);
        textoCreditos2.DOScale(Vector3.one, 0.8f).SetEase(Ease.OutBack).SetDelay(0.3f);

        // Animación para resaltar el botón de play
        botonPlayImage.DOScale(Vector3.one * 1.1f, 0.5f).SetEase(Ease.OutExpo).SetDelay(1f).OnComplete(AnimarBoton);
    }

    private void AnimarBoton()
    {
        // Escala y desescala el botón de play de manera repetida para resaltarlo
        botonPlayImage.DOScale(Vector3.one * 1.2f, 0.5f).SetEase(Ease.OutExpo).SetLoops(-1, LoopType.Yoyo);
    }
}
