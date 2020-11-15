//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CharacterBattle : MonoBehaviour
//{
//    private Character_Base characterBase;

//    // Start is called before the first frame update
//    private void Awake()
//    {
//        characterBase = GetComponent<Character_Base>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        characterBase.PlayAnimMove(new Vector3(1, 0));
//    }

//    public void Setup(bool isPlayerTeam)
//    {
//        if (isPlayerTeam)
//        {
//            characterBase.SetAnimsSwordTwoHandedBack();
//            characterBase.GetMaterial().mainTexture = BattleHandler.GetInstance().playerSpriteSheet;
//        }
//        else
//        {
//            characterBase.SetAnimsSwordShield();
//            characterBase.GetMaterial().mainTexture = BattleHandler.GetInstance().enemySpriteSheet;
//        }
//    }

//    public Vector3 GetPosition()
//    {
//        return transform.position;
//    }

//    public void Attack(CharacterBattle targetCharacterBattle, Action onAttackComplete)
//    {
//        Vector3 attackDir = (targetCharacterBattle.GetPosition() - GetPosition()).normalized;
//        characterBase.PlayAnimAttack(attackDir, null, () => {
//            characterBase.PlayAnimIdle(attackDir);
//            onAttackComplete();
//        });
//    }
//}
