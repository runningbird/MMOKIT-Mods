using MultiplayerARPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.MMO.Scripts.Utilities
{
    public class UtilitiesWindow : EditorWindow
    {
        string myString = "MMO Kit Utilities";
        bool groupEnabled;
        
        Vector2 scrollPos;

        List<GameObject> harvestablePrefabs = new List<GameObject>();
        List<GameObject> enemyMobsPrefabs = new List<GameObject>();
        List<GameObject> npcMobsPrefabs = new List<GameObject>();

        int mainToolbarInt = 0;
        int spawnerToolbarInt = 0;

        

        [MenuItem("Window/MMOKIT-Utilities")]
        static void ShowWindow()
        {
            GetWindow<UtilitiesWindow>(false, "MMOKIT-UTILITIES", true);
        }

        void OnGUI()
        {
            string[] toolbarStrings = { "Spawners", "NPCS", "Other" };
            mainToolbarInt = GUILayout.Toolbar(mainToolbarInt, toolbarStrings);
            switch (mainToolbarInt)
            {
                case 0:
                    {
                        Spawners();
                        break;
                    }
                case 1:
                    {
                        ShowAllNPC();
                        break;
                    }
                case 3:
                    {
                        break;
                    }
            }

        }

        void Spawners()
        {
            string[] toolbarStrings = { "Harvestables", "Monsters" };

            spawnerToolbarInt = GUILayout.Toolbar(spawnerToolbarInt, toolbarStrings);

            switch (spawnerToolbarInt)
            {
                case 0:
                    {
                        ShowAllHarvestables();
                        break;
                    }
                case 1:
                    {
                        ShowAllMonsters();
                        break;
                    }
            }
        }

        void FindAllHarvestableItems()
        {
            List<string> harvestableItemsFolders = FindSpawnerFolders("Harvestables");
            //load all prefabs into list


            string[] assetGuids = AssetDatabase.FindAssets("t:Object", harvestableItemsFolders.ToArray());



            foreach (string guid in assetGuids)
            {
                //Debug.Log(AssetDatabase.GUIDToAssetPath(guid));
                string myObjectPath = AssetDatabase.GUIDToAssetPath(guid);
                Object[] myObjs = AssetDatabase.LoadAllAssetsAtPath(myObjectPath);

                //Debug.Log("printing myObs now...");
                foreach (Object thisObject in myObjs)
                {
                    //Debug.Log(thisObject.name);
                    //Debug.Log(thisObject.GetType().Name); 
                    string myType = thisObject.GetType().Name;
                    if (myType == "HarvestableEntity")
                    {
                        Debug.Log("HarvestableEntity found in ...  " + thisObject.name + " at " + myObjectPath);
                        harvestablePrefabs.Add((GameObject)myObjs.Where(p=> p.GetType().Name == "GameObject").FirstOrDefault());
                    }
                }
            }
        }
        void ShowAllHarvestables()
        {
            harvestablePrefabs.Clear();
            FindAllHarvestableItems();
            if (harvestablePrefabs.Count > 0)
            {
                EditorGUILayout.BeginHorizontal();
                scrollPos =
                    EditorGUILayout.BeginScrollView(scrollPos);

                foreach (GameObject prefab in harvestablePrefabs)
                {

                    if (GUILayout.Button(prefab.name)){
                        GameObject gameObject = new GameObject("HarvestableSpawnArea" + "-" + prefab.name, typeof(HarvestableSpawnArea));
                        gameObject.GetComponent<HarvestableSpawnArea>().prefab = prefab.GetComponent<HarvestableEntity>(); ;
                    }
                }
                EditorGUILayout.EndScrollView();
                EditorGUILayout.EndHorizontal();
            }
            else
            {
                GUILayout.Label("No Harvestable Prefabs found");
                GUILayout.Label("Make sure your Harvestable prefabs are in a Harvestables folder in your project");
            }

        }

        void FindAllMonsterItems()
        {
            List<string> enemyMobsFolders = FindSpawnerFolders("CharacterEntities");
            //load all prefabs into list


            string[] assetGuids = AssetDatabase.FindAssets("t:Object", enemyMobsFolders.ToArray());



            foreach (string guid in assetGuids)
            {
                //Debug.Log(AssetDatabase.GUIDToAssetPath(guid));
                string myObjectPath = AssetDatabase.GUIDToAssetPath(guid);
                Object[] myObjs = AssetDatabase.LoadAllAssetsAtPath(myObjectPath);

                //Debug.Log("printing myObs now...");
                foreach (Object thisObject in myObjs)
                {
                    //Debug.Log(thisObject.name);
                    //Debug.Log(thisObject.GetType().Name); 
                    string myType = thisObject.GetType().Name;
                    if (myType == "MonsterCharacterEntity")
                    {
                        Debug.Log("enemyMobsFolders found in ...  " + thisObject.name + " at " + myObjectPath);
                        enemyMobsPrefabs.Add((GameObject)myObjs.Where(p => p.GetType().Name == "GameObject").FirstOrDefault());
                    }
                }
            }
        }
        void ShowAllMonsters()
        {
            enemyMobsPrefabs.Clear ();

            FindAllMonsterItems();
            if (enemyMobsPrefabs.Count > 0)
            {
                EditorGUILayout.BeginHorizontal();
                scrollPos =
                    EditorGUILayout.BeginScrollView(scrollPos);

                foreach (GameObject prefab in enemyMobsPrefabs)
                {

                    if (GUILayout.Button(prefab.name))
                    {
                        GameObject gameObject = new GameObject("MonsterSpawnArea" + "-" + prefab.name, typeof(MonsterSpawnArea));
                        gameObject.GetComponent<MonsterSpawnArea>().prefab = prefab.GetComponent<MonsterCharacterEntity>(); ;
                    }
                }
                EditorGUILayout.EndScrollView();
                EditorGUILayout.EndHorizontal();
            }
            else
            {
                GUILayout.Label("No Enemy Mob Prefabs found");
                GUILayout.Label("Make sure your enemy mobs prefabs are in a CharacterEntities folder in your project");
            }
        }

        static List<string> FindSpawnerFolders(string spawnerFolder)
        {
            List<string> spawnerFolders = new List<string>();
            //This method prints out the entire folder list of a project into the console
            var folders = AssetDatabase.GetSubFolders("Assets");
            foreach (var folder in folders)
            {
                Recursive(folder, spawnerFolder, spawnerFolders);
            }
            return spawnerFolders;
        }

        static void Recursive(string folder, string spawnerFolder, List<string> spawnerFolders)
        {
           
            var folders = AssetDatabase.GetSubFolders(folder);
            foreach (var fld in folders)
            {
                Recursive(fld, spawnerFolder, spawnerFolders);
            }

            if(folder.Contains(spawnerFolder))
            {
                spawnerFolders.Add(folder);
                Debug.Log(spawnerFolder + " " + folder);
            }
        }

        void FindAllNPC()
        {
            List<string> npcMobsFolders = FindSpawnerFolders("Npcs");
            //load all prefabs into list

            string[] assetGuids = AssetDatabase.FindAssets("t:Object", npcMobsFolders.ToArray());

            foreach (string guid in assetGuids)
            {
                //Debug.Log(AssetDatabase.GUIDToAssetPath(guid));
                string myObjectPath = AssetDatabase.GUIDToAssetPath(guid);
                Object[] myObjs = AssetDatabase.LoadAllAssetsAtPath(myObjectPath);

                //Debug.Log("printing myObs now...");
                foreach (Object thisObject in myObjs)
                {
                    //Debug.Log(thisObject.name);
                    //Debug.Log(thisObject.GetType().Name); 
                    string myType = thisObject.GetType().Name;
                    if (myType == "NpcEntity")
                    {
                        Debug.Log("npcMobsFolders found in ...  " + thisObject.name + " at " + myObjectPath);
                        npcMobsPrefabs.Add((GameObject)myObjs.Where(p => p.GetType().Name == "GameObject").FirstOrDefault());
                    }
                }
            }
        }

        void ShowAllNPC()
        {
            npcMobsPrefabs.Clear();
            FindAllNPC();
            if (npcMobsPrefabs.Count > 0)
            {
                EditorGUILayout.BeginHorizontal();
                scrollPos =
                    EditorGUILayout.BeginScrollView(scrollPos);

                foreach (GameObject prefab in npcMobsPrefabs)
                {

                    if (GUILayout.Button(prefab.name))
                    {
                        Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
                    }
                }
                EditorGUILayout.EndScrollView();
                EditorGUILayout.EndHorizontal();
            }
            else
            {
                GUILayout.Label("No NPC Prefabs found");
                GUILayout.Label("Make sure your NPC prefabs are in a CharacterEntities folder in your project");
            }
        }
    }
}
