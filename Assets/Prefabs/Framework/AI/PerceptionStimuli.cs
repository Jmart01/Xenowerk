using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionStimuli : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PerceptionSystem>().RegisterStimuli(this);
    }

    private void OnDestroy()
    {
        PerceptionSystem system= FindObjectOfType<PerceptionSystem>();
        if (system != null)
        {
            system.UnRegisterStimuli(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
