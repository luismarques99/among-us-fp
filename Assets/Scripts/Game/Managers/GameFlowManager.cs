using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Managers
{
    public class GameFlowManager : MonoBehaviour
    {
        [Header("Parameters")] [Tooltip("Duration of the fade-to-black at the end of the game")]
        public float endSceneLoadDelay = 3f;

        [Tooltip("The canvas group of the fade-to-black screen")]
        public CanvasGroup endGameFadeCanvasGroup;

        [Header("Win")] [Tooltip("This string has to be the name of the scene you want to load when winning")]
        public string winSceneName = "WinScene";

        [Tooltip("Duration of delay before the fade-to-black, if winning")]
        public float delayBeforeFadeToBlack = 4f;

        [Tooltip("Win game message")] public string winGameMessage;

        [Tooltip("Duration of delay before the win message")]
        public float delayBeforeWinMessage = 2f;

        [Tooltip("Sound played on win")] public AudioClip victorySound;

        [Header("Lose")] [Tooltip("This string has to be the name of the scene you want to load when losing")]
        public string loseSceneName = "LoseScene";

        public bool GameIsEnding { get; private set; }

        private float _timeLoadEndGameScene;
        private string _sceneToLoad;

        public void Start()
        {
            // AudioUtility.SetMasterVolume(1);
        }

        public void Awake()
        {
            // EventManager.AddListener<AllObjectivesCompletedEvent>(OnAllObjectivesCompleted);
            // EventManager.AddListener<PlayerDeathEvent>(OnPlayerDeath);
        }

        public void Update()
        {
            if (!GameIsEnding) return;

            var timeRatio = 1 - (_timeLoadEndGameScene - Time.time) / endSceneLoadDelay;
            endGameFadeCanvasGroup.alpha = timeRatio;

            // AudioUtility.SetMasterVolume(1 - timeRatio);

            // See if it's time to load the end scene (after the delay)
            if (Time.time < _timeLoadEndGameScene) return;

            SceneManager.LoadScene(_sceneToLoad);
            GameIsEnding = false;
        }

        // public void OnAllObjectivesCompleted(AllObjectivesCompletedEvent evt) => EndGame(true);
        // public void OnPlayerDeath(PlayerDeathEvent evt) => EndGame(false);

        public void EndGame(bool win)
        {
            // unlocks the cursor before leaving the scene, to be able to click buttons
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Remember that we need to load the appropriate end scene after a delay
            GameIsEnding = true;
            endGameFadeCanvasGroup.gameObject.SetActive(true);
            if (win)
            {
                _sceneToLoad = winSceneName;
                _timeLoadEndGameScene = Time.time + endSceneLoadDelay + delayBeforeFadeToBlack;

                // play a sound on win
                var audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = victorySound;
                audioSource.playOnAwake = false;
                // audioSource.outputAudioMixerGroup = AudioUtility.GetAudioGroup(AudioUtility.AudioGroups.HUDVictory);
                audioSource.PlayScheduled(AudioSettings.dspTime + delayBeforeWinMessage);

                // create a game message
                //var message = Instantiate(WinGameMessagePrefab).GetComponent<DisplayMessage>();
                //if (message)
                //{
                //    message.delayBeforeShowing = delayBeforeWinMessage;
                //    message.GetComponent<Transform>().SetAsLastSibling();
                //}

                // DisplayMessageEvent displayMessage = Events.DisplayMessageEvent;
                // displayMessage.Message = WinGameMessage;
                // displayMessage.DelayBeforeDisplay = DelayBeforeWinMessage;
                // EventManager.Broadcast(displayMessage);
            }
            else
            {
                _sceneToLoad = loseSceneName;
                _timeLoadEndGameScene = Time.time + endSceneLoadDelay;
            }
        }

        public void OnDestroy()
        {
            // EventManager.RemoveListener<AllObjectivesCompletedEvent>(OnAllObjectivesCompleted);
            // EventManager.RemoveListener<PlayerDeathEvent>(OnPlayerDeath);
        }
    }
}