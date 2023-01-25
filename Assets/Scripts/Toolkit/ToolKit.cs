using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;

namespace KHNMU.Toolkit
{


    static class ToolKit
    {
        //[Obsolete]


#if UNITY_EDITOR
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

        public static List<UIBehaviour> CreateComponentList(GameObject go) {
            var resArray = new List<UIBehaviour>();

            if (go.transform.childCount > 0)
            {
                for (int i = 0; i < go.transform.childCount; i++)
                {
                    if (go.transform.GetChild(i).GetComponents<UIBehaviour>().Length>0)
                    {
                        resArray.AddRange(go.transform.GetChild(i).GetComponents<UIBehaviour>());
                    }

                    if (go.transform.GetChild(i).childCount > 0)
                    {
                        resArray.AddRange(
                            CreateComponentList(go.transform.GetChild(i).gameObject)
                            );
                    }
                }
            }
            return resArray;
        }
        //[MenuItem("ScriptableObject/Create ScriptableObject")]
        public static string CreateSccriptableObject(ScriptableObject so, string path,string nam)
        {
            Type sot = so.GetType();
            var asset = ScriptableObject.CreateInstance(sot.ToString());//sot>()//<sot>();
                                                        //Assets\Scripts\Scriptable obj\ScriptableObj\Places
            string name = AssetDatabase.GenerateUniqueAssetPath($"{path}/{nam}.asset");
            AssetDatabase.CreateAsset(asset, name);

            AssetDatabase.SaveAssets();
            return name;
            //EditorUtility.FocusProjectWindow();
            //
            //Selection.activeObject = asset;
        }

        public static ComfortablePlace CiRSccriptableObject(ScriptableObject so, string path, string nam)
        {
            Type sot = so.GetType();
            var asset = ScriptableObject.CreateInstance(sot.ToString());//sot>()//<sot>();
                                                                        //Assets\Scripts\Scriptable obj\ScriptableObj\Places
            System.IO.Directory.CreateDirectory(path);
            string name = AssetDatabase.GenerateUniqueAssetPath($"{path}/{nam}.asset");
            AssetDatabase.CreateAsset(asset, name);

            AssetDatabase.SaveAssets();
            return (ComfortablePlace)asset;
            //EditorUtility.FocusProjectWindow();
            //
            //Selection.activeObject = asset;


        }
#endif
        public static UnityEngine.Object FindExact (UnityEngine.Object comp, UnityEngine.Object[] comparr)//where T :UnityEngine.Object
        {
            for (int i = 0; i < comparr.Length; i++)
            {
                if (comp==comparr[i])
                {
                    return comparr[i];
                }
            }
            return null;
        }

        public static int FindExactInt(UnityEngine.Object comp, UnityEngine.Object[] comparr)//where T :UnityEngine.Object
        {
            for (int i = 0; i < comparr.Length; i++)
            {
                if (comp == comparr[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public static void ExitApp()
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif

        }

        public static void EraseChildObject(Transform parent) {
            for (int i = 0; i < parent.childCount; i++)
            {
                
                UnityEngine.MonoBehaviour.Destroy(
                parent.GetChild(i).gameObject);  
            }
            
        }

        public static void Ordering(Transform parent)
        {
            var xs = new int[] { 10, 20, 30, 40 };
            ref int found = ref FindFirst(xs, s => s == 30);
            found = 0;
            Debug.Log(string.Join(" ", xs));  // output: 10 20 0 40
            Debug.Log(string.Join(" ", xs));  // output: 10 20 0 40

            ref int FindFirst(int[] numbers, Func<int, bool> predicate)
            {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (predicate(numbers[i]))
                {
                    return ref numbers[i];
                }
            }
            throw new InvalidOperationException("No element satisfies the given condition.");
            }

        }
     
        

    }
            

}
