using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Fighter
{
    public override IEnumerator Attack(Fighter other)
    {
        this.Done = false;

        other.Damaged(this.Damage);

        this.Done = true;
        yield return null;
    }

    public override IEnumerator Spell(Fighter other, int spellselected)
    {
        throw new System.NotImplementedException();
    }
}
