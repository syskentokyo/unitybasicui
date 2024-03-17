using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutoHideOnStart : MonoBehaviour
{

    public UnityEvent _targetEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        _targetEvent?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
