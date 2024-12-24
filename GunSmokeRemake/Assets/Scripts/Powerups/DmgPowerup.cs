using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class DmgPowerup : MonoBehaviour
{
    public GameObject[] damageBlocks;
    public Sprite damageBlockSprite;
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
        UpdateDamageUI(PlayerStatus.instance.playerDamage - 1);
    }

    public void UpdateDamageUI(int currentPowerupCount)
    {
        currentPowerupCount = Mathf.Clamp(currentPowerupCount, 0, maxPowerups);

        for (int i = 0; i < damageBlocks.Length; i++)
        {
            if (i < currentPowerupCount)
            {
                damageBlocks[i].GetComponent<Image>().sprite = damageBlockSprite;
            }
            else
            {
                damageBlocks[i].GetComponent<Image>().sprite = defaultBlockSprite;
            }
        }
        
    }

    private void ResetDamageBlocks()
    {
        foreach (var block in damageBlocks)
        {
            block.GetComponent<Image>().sprite = defaultBlockSprite;
        }
    }
}
