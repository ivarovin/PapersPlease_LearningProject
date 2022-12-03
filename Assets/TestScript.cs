using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Newspaper", LoadSceneMode.Additive);
        SceneManager.LoadScene("WalkingSkeleton", LoadSceneMode.Additive);
    }
}
