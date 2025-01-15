using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    // [SerializeField] private int TotalCherries = 5;
    [SerializeField] private TextMeshProUGUI cherriesText;

    void Start()
    {
        cherries = PlayerPrefs.GetInt("Foods", cherries);
        UpdateCherries();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            AudioManager.Instance.PlaySound(AudioType.itemCollect);
            Destroy(collision.gameObject);
            cherries++;
            PlayerPrefs.SetInt("Foods", cherries);
            UpdateCherries();
        }
    }

    private void UpdateCherries()
    {
        cherriesText.text = $"{cherries}";
    }
}
