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
        characterData.ID = data.ID;
        characterData.Level = data.Value(data.Level);
        characterData.picture = data.Picture;
        characterData.speed = data.Value(data.moveSpeed);
        characterData.Bullet = data.Value(data.Bullet);
        return characterData;
    }
}

public class PublicMonsterData : PublicRoleData
{
    public static PublicMonsterData GetMonsterData(MonsterData data)
    {
        PublicMonsterData monsterData =new PublicMonsterData();
        monsterData.ID = data.ID;
        monsterData.Level = data.Value(data.Level);
        monsterData.picture = data.Picture;
        monsterData.speed = data.Value(data.moveSpeed);
        monsterData.Bullet = data.Value(data.Bullet);
        return monsterData;
    }
}
public class PublicData : MonoBehaviour
{

}
