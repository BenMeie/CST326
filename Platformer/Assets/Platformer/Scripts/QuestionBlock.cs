using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    private Material questionMaterial;

    public float rate = 1;
    // Start is called before the first frame update
    void Start()
    {
        questionMaterial = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        questionMaterial.mainTextureOffset = new Vector2(0, Mathf.Floor(rate * Time.realtimeSinceStartup)/5.0f);
    }
}
