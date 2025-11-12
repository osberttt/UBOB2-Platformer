using UnityEngine; // namespace

public class Script1 : MonoBehaviour // class block
{
    public GameObject enemyPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() // function block
    {
        // loop
        var number = 0;
        while (number < 5)
        {
            var position = new Vector2(Random.Range(0,5), Random.Range(0,5));
            Instantiate(enemyPrefab, position, Quaternion.identity, transform);
            number++;
        }

        Debug.Log("done");
    }

    // Update is called once per frame
    void Update() // function block
    {
        
    }
}
