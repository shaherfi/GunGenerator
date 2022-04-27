using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using System.IO;

public class GunGenerator : MonoBehaviour
{
    public int Permutation_Number;
    public TextMeshProUGUI Gun_Name;

    public Gun_Object Gun_Object_Script;
    public Gun_Image Gun_Image_Script;
    public Gun_Card Gun_Card_Script;

    public GameObject Game_Image;
    public Camera ScreenShotCam;


    [Header("Gun Part Sprites")]
    public Sprite[] Nozzle;
    public Sprite[] Neck;
    public Sprite[] Handle;
    public Sprite[] AmmoPack;
    public Sprite[] Scope;
    public Sprite[] Body;
    public Sprite[] Body_Accesories_1;
    public Sprite[] Butt;

    [Header("Gun Part Details Sprites")]
    public Sprite[] Nozzle_Details;
    public Sprite[] Neck_Details;
    public Sprite[] Handle_Details;
    public Sprite[] AmmoPack_Details;
    public Sprite[] Scope_Details;
    public Sprite[] Body_Details;
    public Sprite[] Butt_Details;

    [Header("Gun Part Colours")]
    public Color32[] Primary_Colour;
    public Color32[] Secondary_Colour;

    [Header("Gun Part Object")]
    public Image Nozzle_Part;
    public Image Neck_Part;
    public Image Handle_Part;
    public Image AmmoPack_Part;
    public Image Scope_Part;
    public Image Body_Part;
    public Image Body_Accesories_1_Part;
    public Image Butt_Part;

    [Header("Gun Part Details Object")]
    public Image Nozzle_Part_Detail;
    public Image Neck_Part_Detail;
    public Image Handle_Part_Detail;
    public Image AmmoPack_Part_Detail;
    public Image Scope_Part_Detail;
    public Image Body_Part_Detail;
    public Image Butt_Part_Detail;

    [Header("Gun Part ID")]
    public int Nozzle_ID;
    public int Neck_ID;
    public int Handle_ID;
    public int AmmoPack_ID;
    public int Scope_ID;
    public int Body_ID;
    public int Butt_ID;

    [Header("Gun Part Colour_ID")]
    public int Primary_Colour_ID;
    public int Secondary_Colour_ID;
    

    [Header("Gun Stats and Passives")]
    public int Rarity_ID;
    public int Passive_ID;

    
    public string[] Rarities;
    public Color32[] Passive_Colour;
    public string[] Passives_1;
    public int[] Passives_2_Percentage;
    public string[] Passive_3;
    public TextMeshProUGUI Rarity_UI_Text;
    public TextMeshProUGUI Passive_UI_Text;
    public int[] Damage;
    public TextMeshProUGUI Damage_UI_Text;



    [Header("PrefabSaving")]
    private string localPath_GunImage;
    private string localPath_Card;
    private string localPath_Object;
    public bool Save_Success;
    public GameObject Equipment_Card;
    public GameObject Gun_Image;
    public GameObject Gun_Object;


    [Header("Gun Part Object Object")]
    public GameObject Nozzle_Part_Object;
    public GameObject Neck_Part_Object;
    public GameObject Handle_Part_Object;
    public GameObject AmmoPack_Part_Object;
    public GameObject Scope_Part_Object;
    public GameObject Body_Part_Object;
    public GameObject Body_Accesories_1_Part_Object;
    public GameObject Butt_Part_Object;

    [Header("Gun Part Details Object Object")]
    public GameObject Nozzle_Part_Detail_Object;
    public GameObject Neck_Part_Detail_Object;
    public GameObject Handle_Part_Detail_Object;
    public GameObject AmmoPack_Part_Detail_Object;
    public GameObject Scope_Part_Detail_Object;
    public GameObject Body_Part_Detail_Object;
    public GameObject Butt_Part_Detail_Object;

    // Start is called before the first frame update
    void Start()
    {
        Randomise();
        Randomise_Passives();
        Permutation_Number = PlayerPrefs.GetInt("Permutation_Number", 0);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGunImage();
        Update_Gun_Passives();
        Gun_Name.text = "B.a.s.i.C" + " " + Permutation_Number.ToString();
        UpdateGunSprite();
    }

    public void Randomise()
    {
        //Randomise 

        Nozzle_ID = Random.Range(0, 10);
        Neck_ID = Random.Range(0, 10);
        Handle_ID = Random.Range(0, 10);
        AmmoPack_ID = Random.Range(0, 10);
        Scope_ID = Random.Range(0, 10);
        Body_ID = Random.Range(0, 10);
        Butt_ID = Random.Range(0, 10);

        //Randomise_Colour

        Primary_Colour_ID = Random.Range(0, Primary_Colour.Length);
        Secondary_Colour_ID = Random.Range(0, Secondary_Colour.Length);

        

    }

    public void Randomise_Passives()
    {
        //Randomise_Gun_Passives
        Rarity_ID = Random.Range(0, 3);
        Passive_ID = Random.Range(0, Passives_1.Length);

        if(Gun_Object_Script != null)
        {
            Gun_Object_Script.Rarity_ID = Rarity_ID;
            Gun_Object_Script.Passive_ID = Passive_ID;
        }

        if (Gun_Image_Script != null)
        {
            Gun_Image_Script.Rarity_ID = Rarity_ID;
            Gun_Image_Script.Passive_ID = Passive_ID;
        }

        if (Gun_Card_Script != null)
        {
            Gun_Card_Script.Rarity_ID = Rarity_ID;
            Gun_Card_Script.Passive_ID = Passive_ID;
        }

    }

    public void UpdateGunImage()
    {
        Nozzle_Part.sprite = Nozzle[Nozzle_ID];
        Neck_Part.sprite = Neck[Neck_ID];
        Handle_Part.sprite = Handle[Handle_ID];
        AmmoPack_Part.sprite = AmmoPack[AmmoPack_ID];
        Scope_Part.sprite = Scope[Scope_ID];
        Body_Part.sprite = Body[Body_ID];
        Body_Accesories_1_Part.sprite = Body_Accesories_1[Body_ID];
        Butt_Part.sprite = Butt[Butt_ID];

        Nozzle_Part_Detail.sprite = Nozzle_Details[Nozzle_ID];
        Neck_Part_Detail.sprite = Neck_Details[Neck_ID];
        Handle_Part_Detail.sprite = Handle_Details[Handle_ID];
        AmmoPack_Part_Detail.sprite = AmmoPack_Details[AmmoPack_ID];
        Scope_Part_Detail.sprite = Scope_Details[Scope_ID];
        Body_Part_Detail.sprite = Body_Details[Body_ID];
        Butt_Part_Detail.sprite = Butt_Details[Butt_ID];

        Nozzle_Part.color = Primary_Colour[Primary_Colour_ID];
        Neck_Part.color = Primary_Colour[Primary_Colour_ID];
        Handle_Part.color = Primary_Colour[Primary_Colour_ID];
        AmmoPack_Part.color = Secondary_Colour[Secondary_Colour_ID];
        Scope_Part.color = Secondary_Colour[Secondary_Colour_ID];
        Body_Part.color = Primary_Colour[Primary_Colour_ID];
        Body_Accesories_1_Part.color = Secondary_Colour[Secondary_Colour_ID];
        Butt_Part.color = Primary_Colour[Primary_Colour_ID];
        
    }

    public void UpdateGunSprite()
    {
        Nozzle_Part_Object.GetComponent<SpriteRenderer>().sprite = Nozzle[Nozzle_ID];
        Neck_Part_Object.GetComponent<SpriteRenderer>().sprite = Neck[Neck_ID];
        Handle_Part_Object.GetComponent<SpriteRenderer>().sprite = Handle[Handle_ID];
        AmmoPack_Part_Object.GetComponent<SpriteRenderer>().sprite = AmmoPack[AmmoPack_ID];
        Scope_Part_Object.GetComponent<SpriteRenderer>().sprite = Scope[Scope_ID];
        Body_Part_Object.GetComponent<SpriteRenderer>().sprite = Body[Body_ID];
        Body_Accesories_1_Part_Object.GetComponent<SpriteRenderer>().sprite = Body_Accesories_1[Body_ID];
        Butt_Part_Object.GetComponent<SpriteRenderer>().sprite = Butt[Butt_ID];

        Nozzle_Part_Detail_Object.GetComponent<SpriteRenderer>().sprite = Nozzle_Details[Nozzle_ID];
        Neck_Part_Detail_Object.GetComponent<SpriteRenderer>().sprite = Neck_Details[Neck_ID];
        Handle_Part_Detail_Object.GetComponent<SpriteRenderer>().sprite = Handle_Details[Handle_ID];
        AmmoPack_Part_Detail_Object.GetComponent<SpriteRenderer>().sprite = AmmoPack_Details[AmmoPack_ID];
        Scope_Part_Detail_Object.GetComponent<SpriteRenderer>().sprite = Scope_Details[Scope_ID];
        Body_Part_Detail_Object.GetComponent<SpriteRenderer>().sprite = Body_Details[Body_ID];
        Butt_Part_Detail_Object.GetComponent<SpriteRenderer>().sprite = Butt_Details[Butt_ID];

        Nozzle_Part_Object.GetComponent<SpriteRenderer>().color = Primary_Colour[Primary_Colour_ID];
        Neck_Part_Object.GetComponent<SpriteRenderer>().color = Primary_Colour[Primary_Colour_ID];
        Handle_Part_Object.GetComponent<SpriteRenderer>().color = Primary_Colour[Primary_Colour_ID];
        AmmoPack_Part_Object.GetComponent<SpriteRenderer>().color = Secondary_Colour[Secondary_Colour_ID];
        Scope_Part_Object.GetComponent<SpriteRenderer>().color = Secondary_Colour[Secondary_Colour_ID];
        Body_Part_Object.GetComponent<SpriteRenderer>().color = Primary_Colour[Primary_Colour_ID];
        Body_Accesories_1_Part_Object.GetComponent<SpriteRenderer>().color = Secondary_Colour[Secondary_Colour_ID];
        Butt_Part_Object.GetComponent<SpriteRenderer>().color = Primary_Colour[Primary_Colour_ID];

        //effects
    }

    public void Update_Gun_Passives()
    {
        Rarity_UI_Text.text = Rarities[Rarity_ID];
        Rarity_UI_Text.color = Passive_Colour[Rarity_ID];
        Passive_UI_Text.text = Passives_1[Passive_ID] + " " + Passives_2_Percentage[Rarity_ID]  + "%" + " " + Passive_3[Passive_ID];
        Passive_UI_Text.color = Passive_Colour[Rarity_ID];
        Damage_UI_Text.text = Damage[Rarity_ID].ToString();
    }

    //public void SavePermutation()
    //{
        
    //    PlayerPrefs.SetInt("Permutation_Number", Permutation_Number);
    //    localPath_GunImage = "Assets/Prefabs/Gun_Image/" + "B.a.s.i.C" + "_" + Permutation_Number.ToString() +"_Image" + ".prefab";
    //    localPath_Card = "Assets/Prefabs/Card/" + "B.a.s.i.C" + "_" + Permutation_Number.ToString() + "_Card" + ".prefab";
    //    localPath_Object = "Assets/Prefabs/Object/" + "B.a.s.i.C" + "_" + Permutation_Number.ToString() + "_Object" + ".prefab";

    //    PrefabUtility.SaveAsPrefabAsset(Equipment_Card, localPath_Card, out Save_Success);
    //    PrefabUtility.SaveAsPrefabAsset(Gun_Image, localPath_GunImage, out Save_Success);
    //    PrefabUtility.SaveAsPrefabAsset(Gun_Object, localPath_Object, out Save_Success);

    //    if (Save_Success == true)
    //    {
    //        Debug.Log("Permutation Saved");
    //    }

    //    if (Save_Success == false)
    //    {
    //        Debug.Log("Save Failed");
    //    }

    //    Permutation_Number += 1;
    //}
    public void TakePNG()
    {

        // Create a texture the size of the screen, RGB24 format
        RenderTexture activeRenderTexture = RenderTexture.active;
        RenderTexture.active = ScreenShotCam.targetTexture;

        ScreenShotCam.Render();

        Texture2D tex = new Texture2D(ScreenShotCam.targetTexture.width, ScreenShotCam.targetTexture.height, TextureFormat.RGBA32, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, ScreenShotCam.targetTexture.width, ScreenShotCam.targetTexture.height), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToPNG();
        Object.Destroy(tex);

        // For testing purposes, also write to a file in the project folder
        File.WriteAllBytes("Assets/Prefabs/Gun_PNG/" + "B.a.s.i.C" + "_" + Permutation_Number.ToString() + "_PNG" + ".png", bytes);
    }
}
