using UnityEngine;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] mapPrefabs; // 다양한 맵 프리팹 배열
    public GameObject transparentWallPrefab; // 투명 벽 프리팹
    public Transform playerTransform; // 플레이어의 위치
    public float spawnDistance = 95f; // 새로운 맵을 생성할 거리 기준
    public float segmentLength = 100f; // 각 맵 세그먼트의 길이
    public int maxMapSegments = 2; // 최대 유지할 맵 세그먼트 수

    private Queue<GameObject> mapSegments = new Queue<GameObject>(); // 생성된 맵 세그먼트를 추적할 큐
    private float nextSpawnZ = 95f; // 다음 맵 생성 위치 Z 좌표
    private bool initialSegmentSpawned = false; // 초기 맵 세그먼트가 생성되었는지 여부

    void Update()
    {
        // 플레이어가 특정 거리 이상 이동하면 새로운 맵 세그먼트를 생성
        if (!initialSegmentSpawned && playerTransform.position.z >= 80f)
        {
            initialSegmentSpawned = true;
            SpawnMapSegment();
        }

        if (initialSegmentSpawned && playerTransform.position.z > nextSpawnZ - spawnDistance)
        {
            SpawnMapSegment();

            // 맵 세그먼트가 최대 수를 초과하면 가장 오래된 세그먼트를 삭제
            if (mapSegments.Count > maxMapSegments)
            {
                GameObject oldSegment = mapSegments.Dequeue();
                Destroy(oldSegment);
            }
        }
    }

    void SpawnMapSegment()
    {
        // 다양한 맵 프리팹 중 하나를 랜덤으로 선택하여 Instantiate
        GameObject mapSegment = Instantiate(mapPrefabs[Random.Range(0, mapPrefabs.Length)], new Vector3(0, 0, nextSpawnZ), Quaternion.identity);

        // 맵 세그먼트를 큐에 추가
        mapSegments.Enqueue(mapSegment);

        // 투명 벽을 배치
        PlaceTransparentWalls(nextSpawnZ);

        // 다음 맵 세그먼트의 위치를 업데이트
        nextSpawnZ += segmentLength;
    }

    void PlaceTransparentWalls(float zPosition)
    {
        // 도로 양쪽에 투명 벽을 배치
        Instantiate(transparentWallPrefab, new Vector3(-0.7f, 0, zPosition), Quaternion.identity);
        Instantiate(transparentWallPrefab, new Vector3(0.7f, 0, zPosition), Quaternion.identity);
    }
}
