using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour {
    GameObject home1;
    bool isGameover = false;
    void Start()
    {
        home1 = gameObject.transform.Find("Home1").gameObject;

    }

    void GetMonsterData(string ID, GameObject Object)
    {
        var Data = StaticData.Instance.monsterDictionary[ID];
        var monsterData = PublicMonsterData.GetMonsterData(Data);
        var temp = Resources.Load<GameObject>("Monster");
        var monster = Instantiate(temp, Object.transform);
        monster.GetComponent<AiMonster>().data = monsterData;
    }

    void GetCharacterData(string ID, GameObject Object)
    {
        var Data = StaticData.Instance.characterDictionary[ID];
        var characterData = PublicCharacterData.GetCharacterData(Data);
        var temp = Resources.Load<GameObject>("Monster");
        var monster = Instantiate(temp, Object.transform);
        monster.GetComponent<Character>().data = characterData;
    }

    void Init()
    {
        
    }
	void Update ()
    {
		
	}
}
