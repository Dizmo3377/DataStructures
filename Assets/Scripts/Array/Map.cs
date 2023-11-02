using UnityEngine;

public class Map : MonoBehaviour
{
    [HideInInspector] public Cell[,] cells {  get; private set; }

    [field:Header("Options")] [field:Space(10)]
    [field:SerializeField] public int height { get; private set; }
    [field:SerializeField] public int width { get; private set; }

    [Range(0,100),SerializeField] private int bombSpawnChance;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) Generate();
    }

    private bool MustSpawnBomb() => Random.Range(0, 101) < bombSpawnChance ? true : false; 

    private void Generate()
    {
        cells = new Cell[height,width];

        //Iterate through 2D array and generate each cell randomly
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                cells[i, j] = new Cell(MustSpawnBomb());
            }
        }
    }
}