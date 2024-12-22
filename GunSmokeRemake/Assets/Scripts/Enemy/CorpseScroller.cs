using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseScroller : MonoBehaviour
{
    private float scrollSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        if (PlayerStatus.instance.isPlayerDead)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.down * Time.deltaTime * scrollSpeed);
    }
}
