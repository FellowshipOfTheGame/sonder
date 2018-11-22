using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private GameObject start;
    private GameObject end;
    private int beatsShownInAdvance;
    private int beatOfThisNote = -1;
    private float songPosInBeats;

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

    public int BeatOfThisNote
    {
        private get { return beatOfThisNote; }
        set { beatOfThisNote = value; }
    }

    void Start()
    {
        // Procurar start end no jogo
    }

    void Update()
    {
        if (BeatOfThisNote != -1)
        {
            transform.position = Vector2.Lerp(
                    start.transform.position,
                    end.transform.position,
                    (BeatsShownInAdvance - (BeatOfThisNote - SongPosInBeats)) / BeatsShownInAdvance
                );
        }
    }
}
