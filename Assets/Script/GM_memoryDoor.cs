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

    private SaveData.memoryState ms;
    private ChangeScene cngPortal;
    private ChangeScene cngPortal1;
    private ChangeScene cngPortal2;
    private ChangeScene cngPortal3;
    private ChangeScene cngPortal4;
    private bool isSet = false;
    private bool isPlaying = false;
    private bool story = false;
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
        if (!isSet && chapter == Chapter.unStart)
        {
            cngPortal = cngPortal1;
            cngPortal.sceneName = "level1";
            isSet = true;
            chapter = Chapter.level_1;
        }

        if (!isSet && chapter == Chapter.level_1)
        {
            cngPortal = cngPortal2;
            cngPortal.sceneName = "level2";
            isSet = true;
            chapter = Chapter.level_2;
        }
        if (!isSet && chapter == Chapter.level_2)
        {
            cngPortal = cngPortal3;
            cngPortal.sceneName = "level3";
            isSet = true;
            chapter = Chapter.level_3;
        }
        if (!isSet && chapter == Chapter.level_3)
        {
            cngPortal = cngPortal4;
            cngPortal.sceneName = "level4";
            isSet = true;
            chapter = Chapter.level_4;
        }
        if (!isSet && chapter == Chapter.level_4)
        {
            isSet = true;
            chapter = Chapter.finish;
        }
        if (!isSet && chapter == Chapter.finish)
        {
            isSet = true;
            chapter = Chapter.unStart;
        }

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
        SaveData.Save<SaveData.memoryState>(ms, "memoryState.dat");
    }

}
