using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//This class represent queue data structure

public class Children : MonoBehaviour
{
    [SerializeField] private float offsetBetweenElements;
    [SerializeField] private List<Child> children;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) MoveQueue();
    }

    public void Enqueue(Child child) => children.Add(child);

    public Child Dequeue()
    {
        Child child = children.First();
        children.Remove(child);
        return child;
    }

    private void MoveQueue()
    {
        Child child = Dequeue();
        if (child == null) return;

        child.Born();

        foreach (var childTransform in children) 
            childTransform.transform.DOMoveX(childTransform.transform.position.x + offsetBetweenElements, 0.5f);
    }
}