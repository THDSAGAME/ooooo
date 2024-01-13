using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private ObjectManager objectManager;
    public void getShop()
    {
        objectManager.shop.SetActive(!objectManager.shop.activeSelf);
    }
    public void getEquip()
    {
        objectManager.equip.SetActive(!objectManager.equip.activeSelf);
    }
    public void getSetting()
    {
        objectManager.setting.SetActive(!objectManager.setting.activeSelf);
    }
    public void getBag()
    {
        objectManager.bag.SetActive(!objectManager.bag.activeSelf);
    }
    public void backStart()
    {
        objectManager.level.SetActive(false);
        objectManager.start.SetActive(true);
    }
    public void play()
    {
        objectManager.level.SetActive(true);
        objectManager.start.SetActive(false);
    }
    public void getSound()
    {
        objectManager.loadingData.players[objectManager.idPlayer].Sound = !objectManager.loadingData.players[objectManager.idPlayer].Sound;
        if (objectManager.loadingData.players[objectManager.idPlayer].Sound)
        {
            objectManager.soundOff.SetActive(false);
            objectManager.soundOn.SetActive(true);
        }
        else
        {
            objectManager.soundOn.SetActive(false);
            objectManager.soundOff.SetActive(true);
        }
        objectManager.loadingData.SavePlayersToFile();
    }
    public void getMusic()
    {
        objectManager.loadingData.players[objectManager.idPlayer].Music = !objectManager.loadingData.players[objectManager.idPlayer].Music;
        if (objectManager.loadingData.players[objectManager.idPlayer].Music)
        {
            objectManager.musicOff.SetActive(false);
            objectManager.musicOn.SetActive(true);
        }
        else
        {
            objectManager.musicOn.SetActive(false);
            objectManager.musicOff.SetActive(true);
        }
        objectManager.loadingData.SavePlayersToFile();
    }
    public void getCloseUiBuy()
    {
        objectManager.uiBuy.SetActive(false);
    }
    public void getCloseUiNotBuy()
    {
        objectManager.uiNotBuy.SetActive(false);
    }
    public void getBuy()
    {
        if (objectManager.tankOrItem == 1)
        {
            objectManager.loadingData.players[objectManager.idPlayer].Gold -= objectManager.cost;
            objectManager.gold.text = objectManager.loadingData.players[objectManager.idPlayer].Gold.ToString();
            objectManager.loadingData.players[objectManager.idPlayer].Items[objectManager.idItem] += 1;
            objectManager.buttonsUseItem[objectManager.idItem].updateCount();
            objectManager.loadingData.SavePlayersToFile();
            objectManager.uiBuy.SetActive(false);
        }
        else
        {
            objectManager.loadingData.players[objectManager.idPlayer].Gold -= objectManager.cost;
            objectManager.gold.text = objectManager.loadingData.players[objectManager.idPlayer].Gold.ToString();

            objectManager.loadingData.players[objectManager.idPlayer].Equipments[objectManager.idItem] = 1;

            objectManager.equip.GetComponent<Equipment>().mode = 1;
            objectManager.equip.GetComponent<Equipment>().text.text = "Select";
            objectManager.equip.GetComponent<Equipment>().bt.color = new Color(5f / 255f, 1f, 0f, 1f);


            objectManager.loadingData.SavePlayersToFile();
            objectManager.uiBuy.SetActive(false);
        }

    }



}
