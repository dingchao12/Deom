using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour {
    GameObject home1;
    GameObject home2;
    GameObject home3;
    GameObject home4;
    GameObject home;
    Animator animator1;
    Animator animator2;
    Animator animator3;
    Animator animator4;
    bool isGameover = false;
    float time;
    void Awake()
    {
        home = gameObject.transform.Find("CharacterHome").gameObject;
        home1 = gameObject.transform.Find("MonsterHome/Home1").gameObject;
        home2 =gameObject .transform .Find("MonsterHome/Home2").gameObject;
        home3 = gameObject.transform.Find("MonsterHome/Home3").gameObject;
        home4 = gameObject.transform.Find("MonsterHome/Home4").gameObject;
        animator1 = home1.GetComponent<Animator>();
        animator2 = home2.GetComponent<Animator>();
        animator3 = home3.GetComponent<Animator>();
        animator4 = home4.GetComponent<Animator>();
        Init();
        CreatProp();
        CreatProp();
        CreatProp();
    }

    void CreatMonster(string ID, GameObject Object)
    {
        var Data = StaticData.Instance.monsterDictionary[ID];
        var monsterData = PublicMonsterData.GetMonsterData(Data);
        var temp = Resources.Load<GameObject>("Monster");
        var monster = Instantiate(temp, Object.transform);
        monster.name = temp.name;
        monster.AddComponent<AiMonster>().data = monsterData;
    }

    void CreatCharacter()
    {
        var Data = StaticData.Instance.characterDictionary["1"];
        var characterData = PublicCharacterData.GetCharacterData(Data);
        var temp = Resources.Load<GameObject>("Character");
        var character = Instantiate(temp, home.transform);
        character.AddComponent<Character>().data = characterData;
    }

    void CreatProp()
    {
        var Data = StaticData.Instance.propdictionary["3"];
        var temp = Resources.Load<GameObject>("Prop");
        var prop = Instantiate(temp, gameObject.transform);
        prop.transform.position = prop.transform.position + new Vector3(Random.Range(-480, 200), Random.Range(-350, 350));
        prop.AddComponent<Prop>().data = Data;
    }
    
    void Init()
    {
        animator1.Play("Start", 0);
        animator2.Play("Start", 0);
        animator3.Play("Start", 0);
        animator4.Play("Start", 0);
        StartCoroutine(OnDelay(2.3f, () =>
         {
             CreatMonster("1", home1);
             CreatMonster("2", home2);
             CreatMonster("3", home3);
             CreatMonster("4", home4);
             
         }));

        CreatCharacter();
    }

    IEnumerator OnDelay(float time, UnityEngine.Events.UnityAction rFunc)
    {
        yield return new WaitForSeconds(time);
        rFunc();
        yield return null;
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time > 2)
        {
            //CreatProp();
        }
    }
}
