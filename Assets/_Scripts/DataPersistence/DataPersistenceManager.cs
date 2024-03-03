using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets._Scripts.Models;
using Assets._Scripts.DataPersistence.Data;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler fileDataHandler;
    public static DataPersistenceManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Found more than one Data Persistence Manager in the scene.");
        }
        Instance = this;
    }

    private void Start()
    {
        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {
        this.gameData = fileDataHandler.Load();
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }
        GlobalControl.Instance.inventoryData.items.Clear();
        InventoryManager.Instance.RefreshInventory();
        foreach (var itemData in gameData.inventoryData.items)
        {
            Item item = GlobalControl.Instance.dataList.GetItemById(itemData.itemId);
            if(item != null)
            {
                GameObject go = item.m_object;
                GameObjectData gameObjectData = Instantiate(go.GetComponent<GameObjectData>());
                GameObject globalObject = GameObject.Find("GlobalObject");
                gameObjectData.transform.SetParent(globalObject.transform);
                gameObjectData.transform.localPosition = new Vector3(0f, 100f, 0f);
                gameObjectData.amount = itemData.amount;
                GlobalControl.Instance.inventoryData.items.Add(gameObjectData);
            }
        }
        InventoryManager.Instance.RefreshInventory();
        GlobalControl.Instance.resourceData.resources.Clear();
        foreach (var r in gameData.resourceData.resources)
        {
            GlobalControl.Instance.resourceData.resources.Add(new Resource(r.name, r.quantity));
        }

        foreach (var plant in GlobalControl.Instance.plantData.plants)
        {
            Destroy(plant.gameObject);
        }
        GlobalControl.Instance.plantData.plants.Clear();
        foreach (var itemData in gameData.plantData)
        {
            Item item = GlobalControl.Instance.dataList.GetItemById(itemData.plantId);
            if (item != null)
            {
                GameObject go = item.m_object;
                GameObjectData gameObjectData = go.GetComponent<GameObjectData>();
                GameObject itemPrefab = Instantiate(gameObjectData.itemPrefab); 
                if (itemPrefab != null)
                {
                    PlantGrowing plantGrowing = itemPrefab.GetComponent<PlantGrowing>();
                    DateTime presentTime = DateTime.Now;
                    plantGrowing.doubleChange = itemData.doubleChange;
                    plantGrowing.endTimeToGrow = DateTime.Parse(itemData.endTimeToGrow);
                    plantGrowing.growTime = itemData.growTime;
                    plantGrowing.harvestAmount = 2;
                    plantGrowing.maxStage = itemData.maxStage;
                    plantGrowing.startTimeToGrow = DateTime.Parse(itemData.endTimeToGrow);
                    plantGrowing.textInteraction = itemData.textInteraction;
                    plantGrowing.totalGrowTime = itemData.totalGrowTime;
                    plantGrowing.transform.position = new Vector3(itemData.position[0], itemData.position[1], itemData.position[2]);
/*                    if (plantGrowing.endTimeToGrow <= presentTime)
                    {
                        plantGrowing.animator.SetFloat("Stage", plantGrowing.maxStage);
                    }
                    else
                    {
                        TimeSpan timePassed = presentTime - plantGrowing.startTimeToGrow;
                        plantGrowing.animator.SetFloat("Stage", ((float)timePassed.TotalSeconds / plantGrowing.growTime) + 1);
                    }*/
                    DontDestroyOnLoad(itemPrefab);
                    GlobalControl.Instance.plantData.plants.Add(itemPrefab);
                }

            }
        }
    }
    public void SaveGame()
    {
        gameData = new GameData();
        foreach (var item in GlobalControl.Instance.inventoryData.items)
        {
            GameObjectDataDTO objectData = new GameObjectDataDTO();
            objectData.amount = item.amount;
            objectData.itemId = item.item.ID;
            gameData.inventoryData.items.Add(objectData);
        }
        foreach (Resource r in GlobalControl.Instance.resourceData.resources)
        {
            gameData.resourceData.resources.Add(new ResourceDTO
            {
                name = r.Name,
                quantity = r.Quantity
            });
        }
        foreach (GameObject r in GlobalControl.Instance.plantData.plants)
        {
            PlantGrowing plantGrowing = r.GetComponent<PlantGrowing>();
            gameData.plantData.Add(new PlantDTO
            {
                doubleChange = plantGrowing.doubleChange,
                endTimeToGrow = plantGrowing.endTimeToGrow.ToString(),
                growTime = plantGrowing.growTime,
                harvestAmount = plantGrowing.harvestAmount,
                maxStage = plantGrowing.maxStage,
                plantId = plantGrowing.seedPrefab.item.ID,
                startTimeToGrow = plantGrowing.startTimeToGrow.ToString(),
                textInteraction = plantGrowing.textInteraction,
                totalGrowTime = plantGrowing.totalGrowTime,
                position = new float[] { plantGrowing.position.x, plantGrowing.position.y, plantGrowing.position.z }
            });
        }

        fileDataHandler.Save(gameData);
    }


}
