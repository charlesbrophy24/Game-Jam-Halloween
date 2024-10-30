using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public int itemsCollected = 0;
    [SerializeField]
    private TMP_Text textCount;

    public void collectItem() 
    {
        itemsCollected++;
        textCount.text = $"{itemsCollected}";
    }
}
