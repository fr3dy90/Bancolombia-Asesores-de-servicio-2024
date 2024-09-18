using System;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance;
    public ColorLibrary colorLibrary; 
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
