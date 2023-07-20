using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hud : MonoBehaviour
{
    [SerializeField] Slider speed;
    [SerializeField] Button pause;
    [SerializeField] Button play;

    references refers;
  
    void Start()
    {
        speed.onValueChanged.AddListener(changespeed);
        refers = FindObjectOfType<references>();
    }

    
    void changespeed(float value)
    {
        data.var = value;
    }

   public void Pausegame()
    {
        refers.Rotsetter_zero();
        pause.gameObject.SetActive(false);
        play.gameObject.SetActive(true);
    }
    public void Playgame()
    {
        refers.Rotsetter();
        play.gameObject.SetActive(false);
        pause.gameObject.SetActive(true);
    }
}
