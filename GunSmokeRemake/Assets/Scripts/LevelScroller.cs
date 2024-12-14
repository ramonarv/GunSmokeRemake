using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelScroller : MonoBehaviour
{
    private Vector2 lastTile;
    public Transform[] tiles;
    public int scrollSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // getting transform of the LAST tile in the list
        lastTile = new Vector2(tiles[tiles.Length - 1].position.x, tiles[tiles.Length -1].position.y);
        Debug.Log(lastTile);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].transform.Translate(Vector3.down * Time.deltaTime * scrollSpeed); 
            if (tiles[i].transform.position.y < -9)
            {
                tiles[i].transform.position = lastTile;
                Debug.Log(tiles[i].transform.position);
            }
        }
    }
}
