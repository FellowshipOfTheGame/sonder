using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    [SerializeField] private float spelldamage = 25f;
    [SerializeField] private float damage = 25f;
    [SerializeField] private float hp = 50f;
    [SerializeField] private int spelltarget;
    [SerializeField] protected int spellid;
    private bool done = true;

    public abstract IEnumerator Attack(Fighter other);
    public abstract IEnumerator Spell(Fighter other);

    public bool Done
    {
        get { return done; }
        protected set { done = value; }
    }

    public float Damage
    {
        get { return damage; }
        protected set { damage = value; }
    }

    public float Spelldamage
    {
        get { return spelldamage; }
        protected set { spelldamage = value; }
    }

    public int Spelltarget
    {
        get { return spelltarget; }
        private set { spelltarget = value; }
    }

    public float Hp
    {
        get { return hp; }
        private set { hp = value; }
    }

    public void Damaged(float hit)
    {
        Hp -= hit;
        if (Hp <= 0)
        {
            // Animate and die
            Destroy(this.gameObject);
        }
    }

    public void Healed(float heal)
    {
        Hp += heal;
    }
}
