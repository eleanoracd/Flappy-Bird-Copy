using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncraseScore : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsInLayerMask(other.gameObject, playerLayer))
        {
            ScoreManager.instance.UpdateScore();
        }
    }

    private bool IsInLayerMask(GameObject obj, LayerMask layerMask)
    {
        return (layerMask.value & (1 << obj.layer)) != 0;
    }
}
