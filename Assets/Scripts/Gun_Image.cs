using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class Gun_Image : MonoBehaviour
{
    public GameObject Gun_Bar_Image;
    private Material GunBarMat_Image;

    [Header("Passive Ids")]
    public int Rarity_ID;
    public int Passive_ID;

    [Header("Body Glow Animate")]
    public float time = 0;
    private bool IncreaseLock;



    // Start is called before the first frame update
    void Start()
    {
       // GunBarMat_Image = Gun_Bar_Image.GetComponent<Image>().material;

        //GunBarMat_Image.SetColor("_GlowColor", Gun_Bar_Image.GetComponent<Image>().color);
    }

    // Update is called once per frame
    void Update()
    {
        //Set_Effects();
    }

    private void FixedUpdate()
    {
        //Body_Bar_AnimateGlow();
    }

    public void Set_Effects()
    {
        if (Rarity_ID == 2)
        {
            GunBarMat_Image.EnableKeyword("GLOW_ON");
        }

        if (Rarity_ID != 2)
        {
            GunBarMat_Image.DisableKeyword("GLOW_ON");
        }


    }

    public void Body_Bar_AnimateGlow()
    {
        int GlowAmount;
        int Min_Glow_Amount = 10;
        int Max_Glow_Amount = 40;


        if (time == 0)
        {
            IncreaseLock = false;
        }

        if (time == 4)
        {
            IncreaseLock = true;
        }

        if (IncreaseLock == false)
        {
            time += Time.fixedDeltaTime;
        }

        if (IncreaseLock == true)
        {
            time -= Time.fixedDeltaTime;
        }

        time = Mathf.Clamp(time, 0, 4);
        GlowAmount = (int)Mathf.SmoothStep(Min_Glow_Amount, Max_Glow_Amount, time);
        GunBarMat_Image.SetInt("_Glow", GlowAmount);
    }
}
