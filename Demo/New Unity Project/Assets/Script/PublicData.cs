using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicRoleData
{
    public string ID;
    public float  Level;
    public string picture;
    public float speed;
    public float  Bullet;
}

public class PublicCharacterData : PublicRoleData
{
    public static PublicCharacterData GetCharacterData(CharacterData data)
    {
        PublicCharacterData characterData = new PublicCharacterData();
        characterData.ID = data.id;
        characterData.Level = data.Value(data.level);
        characterData.picture = data.pictrue;
        characterData.speed = data.Value(data.MoveSpeed);
        characterData.Bullet = data.Value(data.buttle);
        return characterData;
    }
}

public class PublicMonsterData : PublicRoleData
{
    public static PublicMonsterData GetMonsterData(MonsterData data)
    {
        PublicMonsterData monsterData =new PublicMonsterData();
        monsterData.ID = data.id;
        monsterData.Level = data.Value(data.level);
        monsterData.picture = data.pictrue;
        monsterData.speed = data.Value(data.MoveSpeed);
        monsterData.Bullet = data.Value(data.buttle);
        return monsterData;
    }
}
public class PublicData : MonoBehaviour
{

}
