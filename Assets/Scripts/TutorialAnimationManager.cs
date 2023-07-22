using UnityEngine;
using DG.Tweening;

public class TutorialAnimationManager : MonoBehaviour
{
    public Transform image1; // Referencia a la primera imagen (izquierda)
    public Transform image2; // Referencia a la segunda imagen (derecha)

    public float moveDistance = 100f; // Distancia a la que se mueven las imágenes
    public float duration = 1.5f; // Duración de la animación

    void Start()
    {
        // Iniciar las animaciones al iniciar el juego
        StartTutorialAnimationLeft();
    }

    void StartTutorialAnimationLeft()
    {
        // Animación para la primera imagen (image1)
        Sequence seqImage1 = DOTween.Sequence();
        seqImage1.Append(image1.DOMoveX(image1.position.x - moveDistance, duration)); // Mover la imagen a la izquierda
        seqImage1.Append(image1.DOScale(Vector3.one * 1.5f, 0.5f)); // Expandir la imagen
        seqImage1.Append(image1.DOScale(Vector3.one, 0.5f)); // Contraer la imagen
        seqImage1.OnComplete(() => Destroy(image1.gameObject)); // Destruir la imagen una vez completada la animación

        Invoke("StartTutorialAnimationRight", 1f);
    }

    void StartTutorialAnimationRight()
    {
        image2.gameObject.SetActive(true);
        Sequence seqImage2 = DOTween.Sequence();
        seqImage2.AppendInterval(duration); // Esperar a que termine la animación de la imagen 1
        seqImage2.Append(image2.DOMoveX(image2.position.x + moveDistance, duration)); // Mover la imagen a la derecha
        seqImage2.Append(image2.DOScale(Vector3.one * 1.5f, 0.5f)); // Expandir la imagen
        seqImage2.Append(image2.DOScale(Vector3.one, 0.5f)); // Contraer la imagen
        seqImage2.OnComplete(() => Destroy(image2.gameObject)); // Destruir la imagen una vez completada la animación
    }
}
