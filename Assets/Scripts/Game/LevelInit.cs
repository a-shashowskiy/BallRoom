using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInit : MonoBehaviour
{
    [SerializeField] private SO_GameInitData gameInitData;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private BallPusher cameraBallPusher;
    [SerializeField] private int roomSize = 2;
    // Start is called before the first frame update
    void Start()
    {
        //Init puch force data
        cameraBallPusher = FindObjectOfType<BallPusher>();
        cameraBallPusher.forseToPush = gameInitData.forseToUse;

        //SPAWN Ball
        for(int i = 0; i < gameInitData.ballToSpawn; i++)
        {
            Vector2 pos = Random.insideUnitCircle * roomSize;
            Ball b =  Instantiate(ballPrefab, new Vector3(pos.x, 0.3f, pos.y), Quaternion.identity).GetComponent<Ball>();
            b.Init(gameInitData);
        }
    }


}
