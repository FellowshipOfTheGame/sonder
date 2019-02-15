using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SelectAction : MonoBehaviour
{
    [SerializeField] private GameObject[] all_actions;
    [SerializeField] private GameObject[] spell_actions;
    [SerializeField] private List<PlayerBattle> team;
    [SerializeField] private GameObject enemy;
    private List<Fighter> fighters = new List<Fighter>();
    private List<Enemy> enemies = new List<Enemy>();
    private GameObject spelloptions;
    private int spellselected = 0;
    private int action = 0;
    private int target = 0;
    private int phase = 0;
    private int turn = 0;
    private int who = 0;

    private void Shuffle(List<Fighter> array)
    {
        int n = array.Count;
        while (n > 1)
        {
            n--;
            int i = Random.Range(0, n + 1);
            Fighter temp = array[i];
            array[i] = array[n];
            array[n] = temp;
        }
    }

    private int Next(int now)
    {
        return (now + 1) % fighters.Count;
    }

    private int Previous(int now)
    {
        if (now == 0)
        {
            return fighters.Count - 1;
        }
        else
        {
            return now - 1;

        }
    }

    void Start()
    {
        int r = Random.Range(0, 2);

        foreach (PlayerBattle player in team)
        {
            fighters.Add(player);
        }

        spelloptions = GameObject.Find("/Canvas/Combat UI/Spell Options");
        GameObject Canvas = GameObject.Find("/Canvas");
        GameObject TempEnemy;

        if (r == 0)
        {
            TempEnemy = Instantiate(enemy);
            TempEnemy.transform.position = new Vector3(-350, 150, 0);
            TempEnemy.transform.SetParent(Canvas.transform, false);
            fighters.Add(TempEnemy.GetComponent<Enemy>());
            enemies.Add(TempEnemy.GetComponent<Enemy>());

            TempEnemy = Instantiate(enemy);
            TempEnemy.transform.position = new Vector3(-400, -50, 0);
            TempEnemy.transform.SetParent(Canvas.transform, false);
            fighters.Add(TempEnemy.GetComponent<Enemy>());
            enemies.Add(TempEnemy.GetComponent<Enemy>());
        }
        else if (r == 1)
        {
            TempEnemy = Instantiate(enemy);
            TempEnemy.transform.position = new Vector3(-330, 250, 0);
            TempEnemy.transform.SetParent(Canvas.transform, false);
            fighters.Add(TempEnemy.GetComponent<Enemy>());
            enemies.Add(TempEnemy.GetComponent<Enemy>());

            TempEnemy = Instantiate(enemy);
            TempEnemy.transform.position = new Vector3(-430, 70, 0);
            TempEnemy.transform.SetParent(Canvas.transform, false);
            fighters.Add(TempEnemy.GetComponent<Enemy>());
            enemies.Add(TempEnemy.GetComponent<Enemy>());

            TempEnemy = Instantiate(enemy);
            TempEnemy.transform.position = new Vector3(-300, -100, 0);
            TempEnemy.transform.SetParent(Canvas.transform, false);
            fighters.Add(TempEnemy.GetComponent<Enemy>());
            enemies.Add(TempEnemy.GetComponent<Enemy>());
        }

        Shuffle(fighters);
    }

    void Update()
    {
        for (int i = fighters.Count - 1; i >= 0; i--)
        {
            if (fighters[i] == null)
            {
                fighters.RemoveAt(i);
                if (turn == i)
                {
                    turn = Next(turn);
                }
            }
        }

        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
            }
        }

        for (int i = team.Count - 1; i >= 0; i--)
        {
            if (team[i] == null)
            {
                team.RemoveAt(i);
            }
        }

        if (enemies.Count == 0)
        {
            Debug.Log("Win");
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else if (team.Count == 0)
        {
            Debug.Log("Lose");
            UnityEditor.EditorApplication.isPlaying = false;
        }

        if (turn >= fighters.Count) turn = Next(turn);
                
        else
        {
            if (phase == 0)
            {
                if (fighters[Previous(turn)].Done)
                {
                    if (fighters[turn] is Enemy)
                    {
                        int n = team.Count;
                        int rand = Random.Range(0, n);

                        StartCoroutine(fighters[turn].Attack(team[rand]));
                        turn = Next(turn);
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.DownArrow))
                        {
                            if (action < all_actions.Length - 1)
                            {
                                action++;
                            }
                        }
                        else if (Input.GetKeyDown(KeyCode.UpArrow))
                        {
                            if (action > 0)
                            {
                                action--;
                            }
                        }
                        else if (Input.GetKeyDown(KeyCode.Space))
                        {
                            if (action == 0)
                            {
                                target = 0;
                                who = 0;
                                phase = 1;
                            }
                            else if (action == 1)
                            {
                                spelloptions.SetActive(true);
                                phase = 2;
                            }
                            else if (action == 2)
                            {
                                UnityEditor.EditorApplication.isPlaying = false;
                            }
                        }
                    }
                }

                for (int i = 0; i < all_actions.Length; i++)
                {
                    Image img = all_actions[i].GetComponent<Image>();
                    if (i != action || fighters[Previous(turn)].Done == false || fighters[turn] is Enemy)
                    {
                        img.color = Color.white;
                    }
                    else
                    {
                        img.color = Color.gray;
                    }
                }

                for (int i = 0; i < spell_actions.Length; i++)
                {
                    Image img = spell_actions[i].GetComponent<Image>();
                    if (i != spellselected)
                    {
                        img.color = Color.white;
                    }
                    else
                    {
                        img.color = Color.gray;
                    }
                }

                for (int i = 0; i < fighters.Count; i++)
                {
                    if (i == turn && fighters[turn] is PlayerBattle)
                    {
                        fighters[i].GetComponent<Image>().color = Color.red;
                    }
                    else
                    {
                        fighters[i].GetComponent<Image>().color = Color.white;
                    }
                }
            }
            else if (phase == 1)
            {
                for (int i = 0; i < all_actions.Length; i++)
                {
                    Image img = all_actions[i].GetComponent<Image>();
                    img.color = Color.white;
                }

                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (who == 0)
                    {
                        if (target < enemies.Count - 1)
                        {
                            target++;
                        }
                    }
                    else
                    {
                        if (target < team.Count() - 1)
                        {
                            target++;
                        }
                    }

                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (target > 0)
                    {
                        target--;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (who == 0)
                    {
                        if (action == 0)
                        {
                            StartCoroutine(fighters[turn].Attack(enemies[target]));
                        }
                        else if (action == 1)
                        {
                            StartCoroutine(fighters[turn].Spell(enemies[target], spellselected));
                        }
                    }
                    else
                    {
                        if (action == 0)
                        {
                            StartCoroutine(fighters[turn].Attack(team[target]));
                        }
                        else if (action == 1)
                        {
                            StartCoroutine(fighters[turn].Spell(team[target], spellselected));
                        }
                    }

                    turn = Next(turn);
                    phase = 0;
                }

                if (who == 0)
                {
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        Image img = enemies[i].gameObject.GetComponent<Image>();
                        if (i != target)
                        {
                            img.color = Color.white;
                        }
                        else
                        {
                            img.color = Color.red;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < team.Count; i++)
                    {
                        Image img = team[i].gameObject.GetComponent<Image>();
                        if (i != target)
                        {
                            img.color = Color.white;
                        }
                        else
                        {
                            img.color = Color.red;
                        }
                    }

                }

            }
            else if (phase == 2)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (spellselected < spell_actions.Length - 1)
                    {
                        spellselected++;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (spellselected > 0)
                    {
                        spellselected--;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (spellselected == 0)
                    {
                        target = 0;
                        who = 1;
                        phase = 1;
                    }
                    else if (spellselected == 1)
                    {
                        target = 0;
                        who = 1;
                        phase = 1;
                    }
                    else if (spellselected == 2)
                    {
                        target = 0;
                        who = 0;
                        phase = 1;
                    }
                    spelloptions.SetActive(false);
                }

                for (int i = 0; i < spell_actions.Length; i++)
                {
                    Image img = spell_actions[i].GetComponent<Image>();
                    if (i != spellselected)
                    {
                        img.color = Color.white;
                    }
                    else
                    {
                        img.color = Color.gray;
                    }
                }
            }
        }
    }
}
