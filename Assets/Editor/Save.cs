using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class Save : MonoBehaviour
{
    private string localPath_GunImage;
    private string localPath_Card;
    private string localPath_Object;
    public bool Save_Success;
    public GameObject Equipment_Card;
    public GameObject Gun_Image;
    public GameObject Gun_Object;

    public GunGenerator GunGenerator_Script;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePermutation()
    {

        PlayerPrefs.SetInt("Permutation_Number", GunGenerator_Script.Permutation_Number);
        localPath_GunImage = "Assets/Prefabs/Gun_Image/" + "B.a.s.i.C" + "_" + GunGenerator_Script.Permutation_Number.ToString() + "_Image" + ".prefab";
        localPath_Card = "Assets/Prefabs/Card/" + "B.a.s.i.C" + "_" + GunGenerator_Script.Permutation_Number.ToString() + "_Card" + ".prefab";
        localPath_Object = "Assets/Prefabs/Object/" + "B.a.s.i.C" + "_" + GunGenerator_Script.Permutation_Number.ToString() + "_Object" + ".prefab";

        PrefabUtility.SaveAsPrefabAsset(Equipment_Card, localPath_Card, out Save_Success);
        PrefabUtility.SaveAsPrefabAsset(Gun_Image, localPath_GunImage, out Save_Success);
        PrefabUtility.SaveAsPrefabAsset(Gun_Object, localPath_Object, out Save_Success);

        if (Save_Success == true)
        {
            Debug.Log("Permutation Saved");
        }

        if (Save_Success == false)
        {
            Debug.Log("Save Failed");
        }

        GunGenerator_Script.Permutation_Number += 1;
    }
}
