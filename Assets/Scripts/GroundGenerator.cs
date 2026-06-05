using System.Collections.Generic;
using UnityEngine;
public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private int startingSections = 5;

    private Queue<GameObject> sections = new();
    private float sectionWidth;

    private void Start()
    {
        sectionWidth = groundPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        for (int i = 0; i < startingSections; i++)
        {
            SpawnSection(i * sectionWidth);
        }
    }

    private void SpawnSection(float xPos)
    {
        GameObject section = Instantiate(groundPrefab, new Vector3(xPos, -3.2f, 0), Quaternion.identity); 
        sections.Enqueue(section);
    }

    private void Update()
    {
        if (sections.Count == 0)
            return;

        GameObject first = sections.Peek();

        if (first.transform.position.x < -sectionWidth)
        {
            sections.Dequeue();

            GameObject last = null;

            foreach (GameObject section in sections)
            {
                last = section;
            }

            first.transform.position = new Vector3(last.transform.position.x + sectionWidth, first.transform.position.y, first.transform.position.z);
            sections.Enqueue(first);
        }
    }
}