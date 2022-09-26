using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_Game : MonoBehaviour
{
    public static UnityAction wallHited;
    public static UnityAction ballHited;
    private float _ballHitCounter = 0;
    private int _wallHitCounter = 0;
    [SerializeField] private Button buttonExit;
    [SerializeField] private TMPro.TextMeshProUGUI wallHit;
    [SerializeField] private TMPro.TextMeshProUGUI ballHit;

    // Start is called before the first frame update
    void Start()
    {
        _ballHitCounter = 0;
        _wallHitCounter = 0;
        buttonExit.onClick.AddListener(ExitToMenu);
        wallHited += WallHited;
        ballHited += BallHited;
    }
     
    void WallHited()
    {
        _wallHitCounter++;
        wallHit.text = "Wall Hit: " + _wallHitCounter;
    }
    void BallHited()
    {
        // TODO
        // костыль я знаю но быстро в голову не пришло как верно будет решить выбраной реализации мной отправку от обоих шаров
        // одновременно, скорее должна быть отдельно система приема сообщений о столкновении что будет проврять если пришло от 
        // двух обьектов и они оба одинаковы в двух сообщениях то плюсовать 1.
        _ballHitCounter += 0.5f; 
        ballHit.text = "Ball Hit: " + _ballHitCounter;
    }

    void ExitToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
