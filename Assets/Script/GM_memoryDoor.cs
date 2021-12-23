using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_memoryDoor : MonoBehaviour
{
    public enum Chapter
    {
        unStart,
        level_1,
        level_2,
        level_3,
        level_4,
        finish
    }
    public Chapter chapter;
    //public Caption caption;
    public GameObject portal_1;
    public GameObject portal_2;
    public GameObject portal_3;
    public GameObject portal_4;
    public bool debugMode;
    public int windowWidth = 400;
    public int windowHight = 150;

    private SaveData.memoryState ms;
    private ChangeScene cngPortal1;
    private ChangeScene cngPortal2;
    private ChangeScene cngPortal3;
    private ChangeScene cngPortal4;
    private bool isSet = false;
    private bool isPlaying = false;
    private bool story = false;
    Rect windowRect;
    int windowSwitch = 0;
    float alpha = 0;
    bool Quit = false;
    void GUIAlphaColor_0_To_1()
    {
        if (alpha < 1)
        {
            alpha += Time.deltaTime;
            GUI.color = new Color(1, 1, 1, alpha);
        }
    }

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
        if (!debugMode)
        {
            ms = SaveData.Load<SaveData.memoryState>("memoryState.dat");
            if (ms == null) chapter = Chapter.unStart;
            else chapter = ms.chapter;
            Debug.Log(chapter);
        }

        cngPortal1 = portal_1.transform.GetChild(3).GetComponent<ChangeScene>();
        cngPortal2 = portal_2.transform.GetChild(3).GetComponent<ChangeScene>();
        cngPortal3 = portal_3.transform.GetChild(3).GetComponent<ChangeScene>();
        cngPortal4 = portal_4.transform.GetChild(3).GetComponent<ChangeScene>();
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
            cngPortal1.sceneName = "level1";
            isSet = true;
            chapter = Chapter.level_1;
        }

        if (!isSet && chapter == Chapter.level_1)
        {
            cngPortal2.sceneName = "level2";
            isSet = true;
            chapter = Chapter.level_2;
        }
        if (!isSet && chapter == Chapter.level_2)
        {
            cngPortal3.sceneName = "level3";
            isSet = true;
            chapter = Chapter.level_3;
        }
        if (!isSet && chapter == Chapter.level_3)
        {
            cngPortal4.sceneName = "level4";
            isSet = true;
            chapter = Chapter.level_4;
        }
        if (!isSet && chapter == Chapter.level_4)
        {
            isSet = true;
            chapter = Chapter.finish;
        }
        /*if (!isSet && chapter == Chapter.finish)
        {
            isSet = true;
            chapter = Chapter.unStart;
        }*/

        if (chapter == Chapter.level_1)
        {

            portal_1.SetActive(true);

        }
        if (chapter == Chapter.level_2)
        {

            portal_2.SetActive(true);

        }
        if (chapter == Chapter.level_3)
        {

            portal_3.SetActive(true);
            
        }
        if (chapter == Chapter.level_4)
        {

            portal_4.SetActive(true);
            
        }
        if (chapter == Chapter.finish)
        {
            portal_1.SetActive(true);
            portal_2.SetActive(true);
            portal_3.SetActive(true);
            portal_4.SetActive(true);
        }

    }
    private void OnDestroy()
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
        GUI.Label(new Rect(100, 50, 300, 30), "Are you sure you want to quit game ?");
        GUI.Label(new Rect(100, 70, 300, 50), "Please press y/n.");
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Application.Quit();
            Quit = true;
            Debug.Log("Bye.");
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            windowSwitch = 0;
        }

        GUI.DragWindow();
    }


}
