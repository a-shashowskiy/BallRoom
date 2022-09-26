using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Settings : MonoBehaviour
{
    [SerializeField] private SO_Colors colorDic;
    [SerializeField] private SO_GameInitData gameInitData;
    [SerializeField] private GameObject colorTogglePrefab;
    [SerializeField] private Transform spwanColor;
    [SerializeField] private Slider _ballCount;
    [SerializeField] private Slider _forsePush;
    [SerializeField] private TMPro.TextMeshProUGUI _balCountText;
    [SerializeField] private TMPro.TextMeshProUGUI _forseText;

    List<UnityEngine.UI.Toggle> toggles = new List<UnityEngine.UI.Toggle>();
    private void Start()
    {
        for(int i=0; i<=colorDic.colors.Count-1; i++)
        {
          GameObject t =  Instantiate(colorTogglePrefab, spwanColor);
            t.GetComponent<UI_CollorToUse>().Init(colorDic.colors[i], i);
            toggles.Add(t.GetComponent<UnityEngine.UI.Toggle>());
        }

        _ballCount.onValueChanged.AddListener(ChangeBallCount);
        _forsePush.onValueChanged.AddListener(ChangeForceVal);
        _balCountText.text = _ballCount.value.ToString();
        _forseText.text = _forsePush.value.ToString();
    }

    void ChangeBallCount(float valua)
    {
        _balCountText.text = valua.ToString();
    }

    void ChangeForceVal(float valua)
    {
        _forseText.text = valua.ToString(); 
    }

    public void SetValuaToPlay()
    {
        gameInitData.ballToSpawn = (int)_ballCount.value;
        gameInitData.forseToUse = (int)_forsePush.value;
        gameInitData.colorListToUse.Clear();
        for (int i=0; i <= toggles.Count-1;i++)
        {
            if (toggles[i].isOn)
            {
                gameInitData.colorListToUse.Add(colorDic.colors[i]);
            }
        } 
    }
}
