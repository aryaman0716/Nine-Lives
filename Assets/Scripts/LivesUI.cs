using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LivesUI : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;

    private List<GameObject> hearts = new List<GameObject>();

    public void InitializeLives(int maxLives)
    {
        foreach (GameObject heart in hearts)
        {
            Destroy(heart);
        }

        hearts.Clear();

        for (int i = 0; i < maxLives; i++)
        {
            GameObject newHeart = Instantiate(heartPrefab, transform);
            hearts.Add(newHeart);
        }
    }
    public void AddHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab, transform);
        hearts.Add(newHeart);
    }
    public void RemoveHeart()
    {
        if (hearts.Count == 0)
            return;

        GameObject lastHeart = hearts[hearts.Count - 1];
        hearts.RemoveAt(hearts.Count - 1);
        Destroy(lastHeart);
    }
}