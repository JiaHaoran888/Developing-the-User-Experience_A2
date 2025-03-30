using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("相机引用")]
    [SerializeField] private GameObject menuCamera;
    [SerializeField] private GameObject gameCamera;

    [Header("UI面板页面")]
    [SerializeField] private PageBase menuPage;
    [SerializeField] private PageBase gamePage;

    [Header("玩家")]
    [SerializeField] private Transform hero;

    private Vector3 _originPosition;

    private void Start()
    {
        _originPosition = hero.position; 
    }

    public void GameStart()
    {
        menuCamera.SetActive(false);
        gameCamera.SetActive(true);

        menuPage.Close();
        gamePage.Open();
    }

    public void ReturnMenu()
    {
        menuCamera.SetActive(true);
        gameCamera.SetActive(false);

        menuPage.Open();
        gamePage.Close();
    }

    public void RotateHero(float value)
    {
        hero.rotation *= Quaternion.Euler(new Vector3(0, value,0));
    }

    public void MoveHero(float value)
    {
        hero.position += new Vector3(0,0,value);
    }

    public void ScaleHero(float value)
    {
        hero.localScale += new Vector3(value, value, value);
    }

    public void ResetHero()
    {
        hero.position = _originPosition;
        hero.localScale = Vector3.one;
        hero.rotation = Quaternion.Euler(new Vector3(0,90,0));
    }
}
