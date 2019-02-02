using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattle : Fighter
{
    [SerializeField] private GameObject note;
    private int beatsShownInAdvance = 5;
    private bool spellgoing = false;
    private float songPosInBeats;
    private float songPosition;
    private int nextIndex = 0;
    private float dsptimesong;
    private float secPerBeat;
    private float bpm = 60f;
    private float[] notes;
    private GameObject Canvas;

    public override IEnumerator Attack(Fighter other)
    {
        this.Done = false;

        other.Damaged(this.Damage);

        this.Done = true;
        yield return null;
    }

    public override IEnumerator Spell(Fighter other)
    {
        this.Done = false;

        if (spellid == 0)
        {
            notes = new float[] { 5f, 6f, 7f };
            nextIndex = 0;

            secPerBeat = 60f / bpm;

            dsptimesong = (float)AudioSettings.dspTime;

            GetComponent<AudioSource>().Play();

            spellgoing = true;
            GameObject.Find("/Canvas/Combat UI/Minigame UI").SetActive(true);
            while (spellgoing) yield return null;

            GameObject.Find("/Canvas/Combat UI/Minigame UI").SetActive(false);
            other.Damaged(this.Spelldamage);
        }
        else if (spellid == 1)
        {
            other.Healed(this.Spelldamage);
        }

        this.Done = true;
        yield return null;
    }

    void Start() 
    {
        Canvas = GameObject.Find("/Canvas");
    }

    void Update()
    {
        if (spellgoing)
        {
            songPosition = (float)(AudioSettings.dspTime - dsptimesong);
            songPosInBeats = songPosition / secPerBeat;
            if (nextIndex < notes.Length && notes[nextIndex] < songPosInBeats + beatsShownInAdvance)
            {
                GameObject TempNote = Instantiate(note);
                TempNote.transform.SetParent(Canvas.transform, false);

                Note notescript = TempNote.GetComponent<Note>();
                notescript.BeatsShownInAdvance = beatsShownInAdvance;
                notescript.SongPosInBeats = songPosInBeats;
                notescript.SecPerBeat = secPerBeat;
                notescript.Dsptimesong = dsptimesong;
                notescript.BeatOfThisNote = notes[nextIndex];

                nextIndex++;
            }
        }
    }
}
