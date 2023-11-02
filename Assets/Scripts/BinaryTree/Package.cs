using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Package : MonoBehaviour
{
    [SerializeField] private TMP_Text weightText;
    [SerializeField] private float weightValue;

    public float weight 
    {
        get => weightValue;
        set 
        {
            //We can avoid changing text in Update() using property
            weightValue = value;
            weightText.text = $"{weightValue} kg";
        }
    }

    public Package left;
    public Package right;

    //Draws relations of packages for beter visualization
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        if (left != null) Gizmos.DrawLine(left.transform.position, transform.position);
        if (right != null) Gizmos.DrawLine(right.transform.position, transform.position);
    }

    public void PunchTextScale() => weightText.rectTransform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 0.5f);
}