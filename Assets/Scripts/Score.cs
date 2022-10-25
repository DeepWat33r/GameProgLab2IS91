using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int numberItems;
    [SerializeField] private string CoinTag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(CoinTag))
        {
            CollectItem(other.gameObject);
            Debug.Log("Items collected: " + numberItems);
        }
    }

    private void CollectItem(GameObject itemGameObject)
    {
        itemGameObject.SetActive(false);
        numberItems++;
    }
}
