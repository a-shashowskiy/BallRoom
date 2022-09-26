using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "GameData", order = 0)]

public class SO_GameInitData : ScriptableObject
{
    public int ballToSpawn;
    public int forseToUse;
    public List<Color> colorListToUse;
}
