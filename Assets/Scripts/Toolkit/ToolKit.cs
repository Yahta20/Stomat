using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace KHNMU.Toolkit
{


    static class ToolKit
    {
        //[Obsolete]
        public static GameObject[] CreateChildArray(GameObject go)
        {
            var resArray = new List<GameObject>();
            if (go.transform.childCount > 0)
            {
                for (int i = 0; i < go.transform.childCount; i++)
                {
                    resArray.AddRange(
                        CreateChildList(go.transform.GetChild(i).gameObject)
                        );
                }
            }
            return resArray.ToArray();
        }
        public static List<GameObject> CreateChildList(GameObject go)
        {
            var resArray = new List<GameObject>();
            
            if (go.transform.childCount > 0)
            {
                for (int i = 0; i < go.transform.childCount; i++)
                {
                    resArray.Add(go.transform.GetChild(i).gameObject);
                    if (go.transform.GetChild(i).childCount>0)
                    {
                    resArray.AddRange(
                        CreateChildList(go.transform.GetChild(i).gameObject)
                        );

                    }
                }
            }
            /*
            else { resArray.Add(go); }
             */

            return resArray;
        }

        [MenuItem("ScriptableObject/Create ScriptableObject")]
        static void CreateSccriptableObject(ScriptableObject so, string path,string nam)
        {
            Type sot = so.GetType();
            var asset = ScriptableObject.CreateInstance(sot.ToString());//sot>()//<sot>();
                                                        //Assets\Scripts\Scriptable obj\ScriptableObj\Places
            string name = AssetDatabase.GenerateUniqueAssetPath($"{path}/{nam}.asset");
            AssetDatabase.CreateAsset(asset, name);
            AssetDatabase.SaveAssets();

            //EditorUtility.FocusProjectWindow();
            //
            //Selection.activeObject = asset;


        }


    }
            

}
