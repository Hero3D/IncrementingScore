using UnityEngine;

public class IncrementingScore : MonoBehaviour
{
    public float score; /*{ get; private set; }*/

    [SerializeField] private float scoreAmount = 10.0f; // Amount to give per score
    [SerializeField] private float scoreResetTime = 0.5f; // controlls how quickly the score accumulates -- Lower = Faster
    [SerializeField] private float scoreReductionRate = 1.0f;  // amount to reduce the scoreRestTime ^ after each increment. Higher = faster; 

    private float _scoreTimer;
    private float _defaultResetTime;

    private void Start()
    {
        _defaultResetTime = scoreResetTime;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _scoreTimer += Time.deltaTime;
            if (_scoreTimer < scoreResetTime) return;

            AddScore(scoreAmount);
            _scoreTimer = 0.0f;
            scoreResetTime -= scoreReductionRate * Time.deltaTime;
            return;
        }

        if (_defaultResetTime != scoreResetTime)
        {
            scoreResetTime = _defaultResetTime;
        }
    }

    private void AddScore(float amount)
    {
        score += amount;
    }
}
