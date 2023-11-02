using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageSorter : MonoBehaviour
{
    [SerializeField] private Package firstNode;
    private bool isSorting = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) SortPackages();
    }

    private List<float> GetSortedWeights(Package package)
    {
        List<float> weights = new List<float>(); 
        GetAllWeights(package, weights);
        weights.Sort();

        return weights;
    }

    private void GetAllWeights(Package package, List<float> list)
    {
        if (package == null) return;

        GetAllWeights(package.left, list);

        list.Add(package.weight);
        package.weight = 0;

        GetAllWeights(package.right, list);
    }

    private void SortPackages()
    {
        if (isSorting) return;

        int currentPackage = 0;
        List<float> sortedWeights = GetSortedWeights(firstNode);

        //For better visualization in unity i used coroutine.
        //Packages are not sorted immediately, so we can see the process

        isSorting = true;
        StartCoroutine(SortPackages(firstNode));

        IEnumerator SortPackages(Package package)
        {
            if (package == null) yield break;

            yield return StartCoroutine(SortPackages(package.left));

            package.weight = sortedWeights[currentPackage];
            currentPackage++;


            package.PunchTextScale();
            yield return new WaitForSeconds(0.5f);
            if (currentPackage == sortedWeights.Count - 1) isSorting = false;

            yield return StartCoroutine(SortPackages(package.right));
        }
    }
}