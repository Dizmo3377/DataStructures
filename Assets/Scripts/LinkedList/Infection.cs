using UnityEngine;

//This script iterates through the linked list

public class Infection : MonoBehaviour
{
    [SerializeField] private Patient firstPatient;
    [SerializeField] private Transform pointer;
    [SerializeField] private Vector2 pointerOffset;

    private Patient currentPatient;

    private void Awake() => currentPatient = firstPatient;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) SetInfectionAndMove(true);
        if (Input.GetKeyDown(KeyCode.S)) SetInfectionAndMove(false);

        SetPointerTo(currentPatient.transform.position);
    }

    private void SetPointerTo(Vector2 target) => pointer.position = pointerOffset + target;

    private void SetInfectionAndMove(bool state)
    {
        currentPatient.SetInfaction(state);
        currentPatient = currentPatient.next;
    }
}