using DG.Tweening;
using UnityEngine;

//This class represent an element of a queue

public class Child : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake() => spriteRenderer = GetComponent<SpriteRenderer>();

    public void Born()
    {
        SetRandomGender();
        FadeOutToRight();
    }

    private void SetRandomGender()
    {
        int random = Random.Range(0, 2);
        spriteRenderer.color = (random == 0) ? Color.blue : Color.magenta;
    }

    private void FadeOutToRight()
    {
        transform.DOBlendableMoveBy(new Vector3(10, 0, 0), 3);
        spriteRenderer.material.DOFade(0, 3);
    }
}