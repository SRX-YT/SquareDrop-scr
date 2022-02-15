using UnityEngine;
using UnityEngine.UI;

public class PrototypeCodes : MonoBehaviour
{
    private Text versionText;
    [SerializeField] float versionNumber;
    [SerializeField] string versionBuild;

    private void Start()
    {
        versionText = GetComponent<Text>();
        versionText.text = versionBuild + " v" + versionNumber + " || " + Random.Range(0000, 9999);
    }
}
