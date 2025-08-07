using Pattern.Factory;
using UnityEngine;

public class GoblinFactory : MonsterFactory
{
    protected override Monster CreateMonster(string type)
    {
        switch (type)
        {
            case "Normal":
                return new GameObject("Goblin").AddComponent<Goblin>();
                break;
            case "Warrior":
                return new GameObject("Goblin").AddComponent<GoblinWarrior>();
                break;
            case "Archer":
                return new GameObject("Goblin").AddComponent<GoblinArcher>();
                break;
            default:
                Debug.Log($"Unknown Monster Type : {type}");
                break;
        }
        return null;
    }
}
