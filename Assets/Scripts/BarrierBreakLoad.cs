using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierBreakLoad : MonoBehaviour
{
    [SerializeField] private GameObject barrier;

    private void Start()
    {
        if(PlayerData.BreakedBarrier)
        {
            Destroy(barrier);
        }
    }
}
