using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace MyGameNamespace
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;
        //public GameObject gameOverScreenPrefab;
        private float remainingTime = 120f;
        private bool timerRunning;

        private Color defaultTextColor;

        void Start()
        {
            StartTimer();
            defaultTextColor = timerText.color;
        }

        void Update()
        {
            if (timerRunning)
            {
                remainingTime -= Time.deltaTime;
                if (remainingTime <= 0)
                {
                    remainingTime = 0;
                    GameOver();
                }
                UpdateTimerDisplay();
            }
        }

        public void StartTimer() => timerRunning = true;

        public void StopTimer() => timerRunning = false;

        public void ResetTimer()
        {
            remainingTime = 120f;
            timerRunning = false;
            timerText.color = defaultTextColor;
            UpdateTimerDisplay();
            // if (timerText != null)
            // {
                
            // }
            //else Debug.LogError("TimerText is not assigned in the GameTimer script!");
        }

        private void OnDestroy() => StopTimer();

        private void GameOver()
        {
            if (remainingTime == 0)
            {
                SceneManager.LoadScene("Game Over"); 
                StopTimer();
            }
            //     Instantiate(gameOverScreenPrefab, Vector3.zero, Quaternion.identity);
            // else Debug.LogError("GameOverScreenPrefab reference is null! Game over screen prefab could not be instantiated.");
            // StopTimer();
        }

        private void UpdateTimerDisplay()
        {
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (remainingTime <= 0 && timerText != null)
                timerText.color = Color.red;
        }
    }
}

