using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIAnimator : MonoBehaviour
{
    public TextMeshProUGUI title;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        title.color = new Color((float)(Math.Sin(Time.frameCount * 0.01) + 0.5), (float)(Math.Sin(Time.frameCount * 0.01 - 1) + 0.5), (float)(Math.Sin(Time.frameCount * 0.01 + 2) + 0.5));
        title.transform.localScale = new Vector3((float)(Math.Sin(Time.frameCount * 0.01) * 0.1 + 1.1),(float)(Math.Sin(Time.frameCount * 0.01) * 0.1 + 1.1),1);
        title.transform.rotation = new Quaternion((float)(Math.Sin(Time.frameCount * 0.01) * 0.1),
            (float)(Math.Sin(Time.frameCount * 0.01) * 0.1), 0, 1);
        title.characterSpacing = (float)(Math.Sin(Time.frameCount * 0.01) * 2 + 1.1);
    }
}
