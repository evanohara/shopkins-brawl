using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInjector : MonoBehaviour
{
    public void InjectAssignments()
    {
        Game.instance.GetComponent<MatchCharacterAssigner>().GiveAssignment(1, MatchCharacterAssigner.ShopkinCharacters.AppleBlossom);
        Game.instance.GetComponent<MatchCharacterAssigner>().GiveAssignment(2, MatchCharacterAssigner.ShopkinCharacters.KookyCookie);
        Game.instance.GetComponent<MatchCharacterAssigner>().GiveAssignment(3, MatchCharacterAssigner.ShopkinCharacters.KookyCookie);
        Game.instance.GetComponent<MatchCharacterAssigner>().GiveAssignment(4, MatchCharacterAssigner.ShopkinCharacters.KookyCookie);
    }
}
