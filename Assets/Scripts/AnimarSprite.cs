using UnityEngine;
using DG.Tweening;

public class AnimarSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color colorNormal;
    public Color colorRojo;
    public float duration = 5.0f;

    private void Start()
    {
        // Inicia la animación en el método Start
        AnimarSpriteRenderer();
    }

    private void AnimarSpriteRenderer()
    {
        // Configura el color inicial del SpriteRenderer
        spriteRenderer.color = colorNormal;

        // Animación para cambiar el color del SpriteRenderer a rojo y viceversa
        Sequence sequence = DOTween.Sequence();
        sequence.Append(spriteRenderer.DOColor(colorRojo, duration).SetEase(Ease.OutQuad));
        sequence.Append(spriteRenderer.DOColor(colorNormal, duration).SetEase(Ease.OutQuad));
        sequence.SetLoops(-1);
    }
}
