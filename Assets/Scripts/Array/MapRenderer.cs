using System.Collections.Generic;
using UnityEngine;

//For better show case of arrays as data structures i decided to 
//split visualization of map and map data

public class MapRenderer : MonoBehaviour
{
    [SerializeField] private Map map;
    [SerializeField] private List<SpriteRenderer> renderers;

    [SerializeField] private Sprite empty;
    [SerializeField] private Sprite bomb;

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W)) UpdateSprites();
    }

    public void UpdateSprites()
    {
        for (int i = 0; i < map.height; i++)
        {
            for (int j = 0; j < map.width; j++)
            {
                renderers[j + i * map.width].sprite = map.cells[i,j].hasBomb ? bomb : empty;
            }
        }
    }
}