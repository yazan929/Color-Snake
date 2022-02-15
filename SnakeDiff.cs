using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class SnakeDiff : MonoBehaviour
{

    ToggleGroup group;
    void Start()
    {
        group = GetComponent<ToggleGroup>();
    }

    public void Submit()
    {
        Toggle theActiveToggle = group.ActiveToggles().FirstOrDefault();
        Debug.Log("test");
    }



    void Update()
    {

    }
}
