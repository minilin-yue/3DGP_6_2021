using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM_level : MonoBehaviour
{
    public static GM_level Gm; 

    public enum Chapter
    {
        unStart,
        level,
        finish
    }
    public Text mission;
    public Text txt_point1;
    public Text txt_point2;
    public Text txt_point3;
    public Text txt_point4;
    public Text txt_num1;
    public Text txt_num2;
    public Text txt_num3;
    public Text txt_num4;

    public Chapter chapter;
    public Caption caption;
    public GameObject portal_0;
    public bool debugMode;
    [Header("任務過關積分")]
    public int min_point = 300;
    [Header("玩家目前積分")]
    public int p_point = 0;
    [Header("場景裡食物量(請填0，會自動加總)")]
    public int sfood1 = 0;
    public int sfood2 = 0;
    public int sfood3 = 0;
    public int sfood4 = 0;
    [Header("玩家食物量")]
    public int pfood1 = 0;
    public int pfood2 = 0;
    public int pfood3 = 0;
    public int pfood4 = 0;
    [Header("單個食物積分")]
    public int point1 = 0;
    public int point2 = 0;
    public int point3 = 0;
    public int point4 = 0;
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
    private Voice voice;

    // Init
    void Awake()
    {
        Gm = this;

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
        voice = gameObject.GetComponent<Voice>();
    }

    // Update is called once per frame
    void Update()
    {
        p_point = pfood1 * point1 + pfood2 * point2 + pfood3 * point3 + pfood4 * point4;

        txt_point1.text = "♨" + point1.ToString();
        txt_point2.text = "♨" + point2.ToString();
        txt_point3.text = "♨" + point3.ToString();
        txt_point4.text = "♨" + point4.ToString();

        if (pfood1 < 100) txt_num1.text = pfood1.ToString();
        else txt_num1.text = "99+";

        if (pfood2 < 100) txt_num2.text = pfood2.ToString();
        else txt_num2.text = "99+";

        if (pfood3 < 100) txt_num3.text = pfood3.ToString();
        else txt_num3.text = "99+";

        if (pfood4 < 100) txt_num4.text = pfood4.ToString();
        else txt_num4.text = "99+";

        if (p_point < 10000) mission.text = "通關條件：♨" + min_point.ToString() + "\n目前積分：♨" + p_point.ToString();
        else mission.text = "通關條件：♨" + min_point.ToString() + "\n目前積分：♨9999+";

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
                isPlaying = true;
                caption.Play(1);
                voice.Play(1);
                //Invoke("Narrator0", 8);

            }
            if (p_point >= min_point)
            {
                isPlaying = false;
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
        voice.Play(0);
        story = false;
    }

    public int GetFoodCount(int index)
    {
        switch (index)
        {
            case 0:
                return pfood1;
            case 1:
                return pfood2;
            case 2:
                return pfood3;
            case 3:
                return pfood4;
            default:
                break;
        }
        return 0;
    }

    public void ReduceFoodCount(int index)
    {
        switch (index)
        {
            case 0:
                pfood1--;
                break;
            case 1:
                pfood2--;
                break;
            case 2:
                pfood3--;
                break;
            case 3:
                pfood4--;
                break;
            default:
                break;
        }
    }

}
