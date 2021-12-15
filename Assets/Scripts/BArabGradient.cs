using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BArabGradient : MonoBehaviour
{
    [SerializeField] private Transform pointer;
    public float speed;

    private void Update()
    {
        transform.Translate(pointer.position);
    }
}
