using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_level : MonoBehaviour
{
    public enum Chapter
    {
        unStart,
        level,
        finish
    }
    public Chapter chapter;
    public Caption caption;
    public GameObject portal_0;
    public bool debugMode;
    [Header("任務要求食物量")]
    public int min_pfood = 300;
    public int max_sfood = 100;
    public int max_sfood1 = 100;
    public int max_sfood2 = 100;
    public int max_sfood3 = 100;
    public int max_sfood4 = 100;
    [Header("場景裡食物量")]
    public int sfood1 = 100;
    public int sfood2 = 100;
    public int sfood3 = 100;
    public int sfood4 = 100;
    [Header("玩家食物量")]
    public int pfood1 = 0;
    public int pfood2 = 0;
    public int pfood3 = 0;
    public int pfood4 = 0;
    [Header("GUI setting")]
    public int windowWidth = 800;
    public int windowHight = 300;
    public int fontsize = 30;


    private SaveData.memoryState ms;
    private ChangeScene cngPortal;

    private bool isSet = false;
    private bool isPlaying = false;
    private bool story = false;
    Rect windowRect;
    int windowSwitch = 0;
    float alpha = 0;
    bool Quit = false;


    // Init
    void Awake()
    {
        windowRect = new Rect(
            (Screen.width - windowWidth) / 2,
            (Screen.height - windowHight) / 2,
            windowWidth,
            windowHight);
    }

    // Start is called before the first frame update
    void Start()
    {
        /*if (!debugMode)
        {
            ms = SaveData.Load<SaveData.memoryState>("memoryState.dat");
            if (ms == null) chapter = Chapter.unStart;
            else chapter = ms.chapter;
            Debug.Log(chapter);
        }*/

        cngPortal = portal_0.transform.GetChild(3).GetComponent<ChangeScene>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            windowSwitch = 1;
            alpha = 0; // Init Window Alpha Color
        }
        if (!isSet && chapter == Chapter.unStart)
        {
            cngPortal.sceneName = "level0";
            isSet = true;
            chapter = Chapter.level;
        }

        if (!isSet && chapter == Chapter.level)
        {
            isSet = true;
            chapter = Chapter.finish;
        }


        if (chapter == Chapter.level)
        {
            if (!isPlaying)
            {
                story = true;
                
                //Invoke("Narrator0", 8);
               
            }
            if ((sfood1 + sfood2 + sfood3 + sfood4) <= max_sfood && (pfood1 + pfood2 + pfood3 + pfood4) >= min_pfood) 
            {
                isSet = false;
            }

        }
        
        if (chapter == Chapter.finish)
        {
            if (!isPlaying)
            {
                story = true;
                Narrator0();
                isPlaying = true;
            }
            else if (!story && !caption.isPlaying)
            {
                portal_0.SetActive(true);
            }
        }

    }
    /*private void OnDestroy()
    {
        SaveData.memoryState ms = new SaveData.memoryState();
        ms.chapter = chapter;
        if(Quit)
        {
            SaveData.Delete("memoryState.dat");
        }
        else
        {
            SaveData.Save<SaveData.memoryState>(ms, "memoryState.dat");
        }
    }
    */
        void GUIAlphaColor_0_To_1()
    {
        if (alpha < 1)
        {
            alpha += Time.deltaTime;
            GUI.color = new Color(1, 1, 1, alpha);
        }
    }
    void OnGUI()
    {

        if (windowSwitch == 1)
        {
            GUIAlphaColor_0_To_1();

            windowRect = GUI.Window(0, windowRect, QuitWindow, "Quit Window");
        }
    }

    void QuitWindow(int windowID)
    {
        GUIStyle fontStyle = new GUIStyle();
        fontStyle.fontSize = fontsize;
        fontStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(200, 100, 600, 60), "Are you sure you want to quit game ?", fontStyle);
        GUI.Label(new Rect(200, 160, 600, 120), "Please press y/n.", fontStyle);
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Application.Quit();
            Quit = true;
            Debug.Log("Bye.");
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            windowSwitch = 0;
            Quit = false;
        }

        GUI.DragWindow();
    }

    void Narrator0()
    {
        Debug.Log("Congratulations!!!");
        caption.Play(0);
        story = false;
    }
}
