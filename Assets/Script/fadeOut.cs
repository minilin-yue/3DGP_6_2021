using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOut : MonoBehaviour
{
    public Material[] mat;
    private float fadeValue = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < mat.Length; i++)
        {
            mat[i].SetFloat("alpha", 1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fade()
    {
        for (int i = 0; i < mat.Length; i++)
        {
            mat[i].SetFloat("alpha", fadeValue);
        }
    }
}
