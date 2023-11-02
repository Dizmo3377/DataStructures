using UnityEngine;

//This class represents a node of a linked list

public class Patient : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    //Link to the next element in linked list
    public Patient next;

    private void Awake() => spriteRenderer = GetComponent<SpriteRenderer>();

    public void SetInfaction(bool state) => spriteRenderer.color = state ? Color.red : Color.white;
}