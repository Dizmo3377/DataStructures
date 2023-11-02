using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    public void FlyOut()
    {
        transform.DOBlendableMoveBy(new Vector3(-3,0,0),1);
        GetComponent<SpriteRenderer>().material.DOFade(0,1);
    }
}