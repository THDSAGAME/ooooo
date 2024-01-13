using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
public class Tank
{
    public int Damage { get; set; }
    public int Blood { get; set; }
    public int TypeGun { get; set; }
    public int Price { get; set; }
    
}
public class ObjectManager : MonoBehaviour
{
    [SerializeField] public CinemachineVirtualCamera virtualCamera;
    [SerializeField] public int idPlayer;
    [SerializeField] public int idTank, idLV, idItem, cost, tankOrItem; // 0: tank      ||     1: item
    [SerializeField] public LoadingData loadingData;
    [SerializeField] public TMP_Text gold, textBuy, idLevel, textNotBuy;
    [SerializeField] public GameObject login, play, shop, equip, setting, loading, start, mainPlay, level, bag, uiBuy, uiNotBuy;
    [SerializeField] public Player player;
    [SerializeField] public GameObject[] levels, tank;
    [SerializeField] public ItemButtonUse[] buttonsUseItem;
    [SerializeField] public GameObject _level, _player;
    [SerializeField] public GameObject soundOn, soundOff, musicOn, musicOff;
    [SerializeField] public GameObject[] item;
    [SerializeField] public bool isTime;
    public Tank[] tanks;
    private void Start()
    {
        tanks = new Tank[5];

        for (int i = 0; i < tanks.Length - 1; i++)
        {
            tanks[i] = new Tank
            {
                Damage = 30 + 10*i,
                Blood = 100,
                TypeGun = 1,
                Price = 1000 + 500*i
            };
        }
        tanks[4] = new Tank
        {
            Damage = 100,
            Blood = 100,
            TypeGun = 2,
            Price = 5000
        };
    }
}
