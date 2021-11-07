using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caption : MonoBehaviour
{
    // 管理字幕內容與撥放
    public Text caption;
    public Text player;
    public GameObject sysinfo;
    public CaptionList[] list;
    public bool isPlaying;
    private int preSentence = 0;
    private int playingIdx = -1;
    private int curSentence = 0;
    private Text systext;

    void Start()
    {
        sysinfo.SetActive(false);
        isPlaying = false;
        systext = sysinfo.GetComponent<Text>();
        StartCoroutine("main");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Stop();
        }
    }
    public void Play(int idx)
    {
        Stop();
        playingIdx = idx;
        preSentence = -1;
        curSentence = 0;
        isPlaying = true;
        //print(idx+" "+curSentence);
    }
    public void Stop()
    {
        StopCoroutine("cngText");
        playingIdx = -1;
        preSentence = curSentence = 0;
        isPlaying = false;
        caption.text = "";
        player.text = "";
        systext.text = "";
        sysinfo.SetActive(false);
        //print("stop");
    }
    IEnumerator main()
    {
        while (true)
        {
            //print(preSentence + " " + curSentence + " " + playingIdx);
            if (playingIdx != -1 && preSentence != curSentence)
            {
                //print(preSentence+" "+curSentence+" "+playingIdx);
                StartCoroutine("cngText", list[playingIdx].sentence[curSentence]);
                preSentence = curSentence;
            }
            yield return null;
        }
        yield return null;

    }
    IEnumerator cngText(CaptionList.caption cur)
    {
        if (cur.type == CaptionList.strtype.caption)
        {
            //print(cur.str+"caption start");
            caption.text = cur.str;
            yield return new WaitForSecondsRealtime(cur.sec);
            caption.text = "";
        }
        else if (cur.type == CaptionList.strtype.player)
        {
            player.text = cur.str;
            yield return new WaitForSecondsRealtime(cur.sec);
            player.text = "";
        }
        else if (cur.type == CaptionList.strtype.sysinfo)
        {
            //print(cur.str + "sys start");
            sysinfo.SetActive(true);
            //sysinfo.transform.GetChild(0).GetComponent<ParticleSystem>().;
            yield return new WaitForSecondsRealtime(0.7f);
            systext.text = cur.str;
            yield return new WaitForSecondsRealtime(cur.sec-0.7f);
            sysinfo.SetActive(false);
            systext.text = "";
            //print(cur.str+"sys end");
        }
        curSentence += 1;
        //print(cur.str+"set + 1 "+curSentence);
        if (playingIdx != -1 && curSentence >= list[playingIdx].sentence.Count)
        {
            playingIdx = -1;
            curSentence = preSentence = 0;
            isPlaying = false;
        }
    }

}
