using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeManager : MonoBehaviour
{
    public GameObject pickupPrefab; // Prefab của trái cam
    public int numberOfPickups = 8; // Số lượng trái cam muốn sinh ra
    public Vector3[] spawnPoints; // Mảng chứa các vị trí cố định
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = new Vector3[numberOfPickups];
        spawnPoints[0] = new Vector3(-2.73f, 6.57f, 0);
        spawnPoints[1] = new Vector3(-1.35f, 7.64f, 0);
        spawnPoints[2] = new Vector3(-5.56f, 7.45f, 0);
        spawnPoints[3] = new Vector3(-4.51f, 6.19f, 0);
        spawnPoints[4] = new Vector3(11.34f, -4.36f, 0);
        spawnPoints[5] = new Vector3(11.61f, -5.73f, 0);
        spawnPoints[6] = new Vector3(12.87f, -6.62f, 0);
        spawnPoints[7] = new Vector3(14.21f, -5.77f, 0);

        SpawnPickupObjects();
    }

    // Hàm sinh ra nhiều trái cam
    void SpawnPickupObjects()
    {
        for (int i = 0; i < numberOfPickups; i++)
        {
            // Lấy vị trí cố định từ mảng
            Vector3 spawnPoint = spawnPoints[i % spawnPoints.Length];

            // Clone trái cam tại vị trí cố định
            GameObject newPickup = Instantiate(pickupPrefab, spawnPoint, Quaternion.identity);

            // Đặt parent cho trái cam mới nếu cần
            newPickup.transform.parent = transform;
        }
    }
}
