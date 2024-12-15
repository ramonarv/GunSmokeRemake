using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelScroller : MonoBehaviour
{
    public Sprite sprite;
    public Transform[] tiles;
    public float scrollSpeed;
    public float tileHeight;
    public float pixelsPerUnit;


    // Start is called before the first frame update
    private void Start()
    {
        tileHeight = sprite.bounds.size.y;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        for (int i = 0; i < tiles.Length; i++)
        {

            if (tiles[i].transform.position.y < -tileHeight)
            {
                float highestY = GetHighestTileY();
                tiles[i].transform.position = new Vector2(
                    tiles[i].transform.position.x,
                    highestY + tileHeight);
            }

            tiles[i].transform.Translate(Vector2.down * Time.deltaTime * scrollSpeed);
        }
    }

    float GetHighestTileY()
    {
        float highestY = tiles[0].transform.position.y;
        for (int i = 1; i < tiles.Length; i++)
        {
            if (tiles[i].transform.position.y > highestY)
            {
                highestY = tiles[i].transform.position.y;
            }
        }
        return highestY;
    }

}
