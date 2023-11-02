using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Magazine represents stack data structure

public class Magazine : MonoBehaviour
{
    //orderOfAddingBullets is just for adding bulets in certain order.
    //We set values of this list in unity
    [SerializeField] private List<Bullet> orderOfAddingBullets;
    [SerializeField] private List<Bullet> bullets = new List<Bullet>();

    //Adding elements in stack is incapsulated in Add() method, so
    //we add bullets in order wich we have set in unity inspector
    private void Start()
    {
        foreach (Bullet bullet in orderOfAddingBullets) Add(bullet);
    }
    public bool IsEmpty() => bullets.All(b => b == null);

    public Bullet Pop()
    {
        Bullet bullet = bullets.First();
        bullets.Remove(bullet);
        return bullet;
    }

    public void Add(Bullet bullet) => bullets.Insert(0, bullet);
}