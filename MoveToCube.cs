using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCube : MonoBehaviour
{
    public Transform Cube;
    // Start is called before the first frame update
    void Start()
    {
        Cube = GetComponent<Transform>();
    }
}