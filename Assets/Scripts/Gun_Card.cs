using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class Gun_Card : MonoBehaviour
{
    public int Rarity_ID;
    public int Passive_ID;

    public GameObject Card_Bg;
    private Material Card_Bg_Mat;

    public GameObject Card_Glow;
    private Material Card_Glow_Mat;

    public float time;
    public float ShineSpeed = 5.5f;

    // Start is called before the first frame update
    void Start()
    {
        Card_Bg_Mat = Card_Bg.GetComponent<Image>().material;
        Card_Glow_Mat = Card_Glow.GetComponent<Image>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //Set_Effects();
    }

    private void FixedUpdate()
    {
        //Card_BG_AnimateShine();
    }

    public void Set_Effects()
    {
        if (Rarity_ID == 2)
        {
            Card_Glow_Mat.EnableKeyword("OUTBASE_ON");
            
            
        }

        if (Rarity_ID != 2)
        {
            Card_Glow_Mat.DisableKeyword("OUTBASE_ON");
            
            
        }

        if (Rarity_ID > 0)
        {
            Card_Bg_Mat.EnableKeyword("SHINE_ON");
        }

        if (Rarity_ID == 0)
        {
            Card_Bg_Mat.DisableKeyword("SHINE_ON");
        }


    }

    public void Card_BG_AnimateShine()
    {
        float ShineLocation;
        float Min_ShineLocation = 0;
        float Max_ShineLocation = 1.1f;


        if (time < ShineSpeed)
        {
            time += 0.03f;
        }

        if (time >= ShineSpeed)
        {
            time = 0;
        }

        ShineLocation = Mathf.SmoothStep(Min_ShineLocation, Max_ShineLocation, time);

        Card_Bg_Mat.SetFloat("_ShineLocation", ShineLocation);
    }
}
