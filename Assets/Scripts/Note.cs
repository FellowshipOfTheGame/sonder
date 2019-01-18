using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject end;
    private int beatsShownInAdvance;
    private float beatOfThisNote = -1f;
    private float songPosInBeats;
    private float songPosition;
    private float dsptimesong;
    private float secPerBeat;

    public int BeatsShownInAdvance
    {
        private get { return beatsShownInAdvance; }
        set { beatsShownInAdvance = value; }
    }

    public float SongPosInBeats
    {
        private get { return songPosInBeats; }
        set { songPosInBeats = value; }
    }

    public float BeatOfThisNote
    {
        private get { return beatOfThisNote; }
        set { beatOfThisNote = value; }
    }

    public float SecPerBeat
    {
        private get { return secPerBeat; }
        set { secPerBeat = value; }
    }

    public float Dsptimesong
    {
        private get { return dsptimesong; }
        set { dsptimesong = value; }
    }

    void Start()
    {
        start = GameObject.Find("/Canvas/Combat UI/Minigame UI/Start");
        end = GameObject.Find("/Canvas/Combat UI/Minigame UI/End");
    }

    void Update()
    {
        if (BeatOfThisNote != -1)
        {
            songPosition = (float)(AudioSettings.dspTime - Dsptimesong);
            songPosInBeats = songPosition / SecPerBeat;

            transform.position = Vector2.Lerp(
                    start.transform.position,
                    end.transform.position,
                    (BeatsShownInAdvance - (BeatOfThisNote - SongPosInBeats)) / BeatsShownInAdvance
                );
        }
    }
}
