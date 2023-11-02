using UnityEngine;

public class Glock : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Magazine magazine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) Shoot();
    }

    private void Shoot()
    {
        if (magazine.IsEmpty()) return;

        Bullet bullet = magazine.Pop();
        animator.SetTrigger("Shoot");
        bullet.FlyOut();
    }
}