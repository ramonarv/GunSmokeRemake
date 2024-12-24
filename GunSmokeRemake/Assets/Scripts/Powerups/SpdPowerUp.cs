using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpdPowerup : MonoBehaviour
{
    public GameObject[] speedBlocks;
    public Sprite speedBlockSprite;
    public Sprite defaultBlockSprite;

    private int maxPowerups = 3;

    // Start is called before the first frame update
    void Start()
    {
        ResetDamageBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDamageUI(PlayerStatus.instance.playerSpeed - 5);
    }

    public void UpdateDamageUI(int currentPowerupCount)
    {
        currentPowerupCount = Mathf.Clamp(currentPowerupCount, 0, maxPowerups);

        for (int i = 0; i < speedBlocks.Length; i++)
        {
            if (i < currentPowerupCount)
            {
                speedBlocks[i].GetComponent<Image>().sprite = speedBlockSprite;
            }
            else
            {
                speedBlocks[i].GetComponent<Image>().sprite = defaultBlockSprite;
            }
        }

    }

    private void ResetDamageBlocks()
    {
        foreach (var block in speedBlocks)
        {
            block.GetComponent<Image>().sprite = defaultBlockSprite;
        }
    }
}
