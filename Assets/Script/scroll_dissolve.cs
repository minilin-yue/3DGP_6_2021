using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll_dissolve : MonoBehaviour
{
    //public GameObject magicscroll;
    //public GameObject cylinder;
    //public GameObject korona;
    //public GameObject bottom;
    //public GameObject top;
    //public GameObject uchwyt;
    //public GameObject plane01;
    //public GameObject uv;
    public Material m_cylinder;
    public Material m_korona;
    public Material m_bottom;
    public Material m_top;
    public Material m_uchwyt;
    //private Material plane01;
    public Material m_uv;
    public GameObject cube;
    private int frame = 0;
    private float edge_alpha = 1.0f;
    private bool flag = false;

    static public bool finish = false;
    private bool destroy = false;


    // Start is called before the first frame update
    void Start()
    {
        m_cylinder.SetFloat("Vector1_DABB2478", edge_alpha);
        m_korona.SetFloat("Vector1_DABB2478", edge_alpha);
        m_bottom.SetFloat("Vector1_DABB2478", edge_alpha);
        m_top.SetFloat("Vector1_DABB2478", edge_alpha);
        m_uchwyt.SetFloat("Vector1_DABB2478", edge_alpha);
        m_uv.SetFloat("Vector1_DABB2478", edge_alpha);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (finish)
        {
            flag = true;
            Debug.Log("finish is true.");
        }
        if (flag == true)
        {
            m_cylinder.SetFloat("Vector1_DABB2478", edge_alpha);
            m_korona.SetFloat("Vector1_DABB2478", edge_alpha);
            m_bottom.SetFloat("Vector1_DABB2478", edge_alpha);
            m_top.SetFloat("Vector1_DABB2478", edge_alpha);
            m_uchwyt.SetFloat("Vector1_DABB2478", edge_alpha);
            m_uv.SetFloat("Vector1_DABB2478", edge_alpha);
            edge_alpha = edge_alpha - 0.01f;
            if(!destroy && edge_alpha < 0.35f)
            {
                Destroy(cube);
                destroy = true;
            }
            if(edge_alpha <= 0.0f)
            {
                gameObject.SetActive(false);
                flag = false;
            }
        }
    }
}
