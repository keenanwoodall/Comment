using UnityEditor;
using UnityEngine;

namespace Comments.Editor
{
    public class CommentTooltipPopup : EditorWindow
    {
        private static GUIContent _Content;
        private static CommentTooltipPopup _Instance;

        private static bool _RevealIsPending;
        private static Rect _RevealRect;
        private static double _DelayRemaining;
        private static double _LastUpdateTime;
        
        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            EditorApplication.update += EditorUpdate;
            _LastUpdateTime = EditorApplication.timeSinceStartup;
        }
        
        private static void EditorUpdate()
        {
            var currentTime = EditorApplication.timeSinceStartup;
            if (_RevealIsPending)
            {
                var deltaTime = currentTime - _LastUpdateTime;
                _DelayRemaining -= deltaTime;

                if (_DelayRemaining < 0f)
                {
                    _Instance = GetWindowWithRect<CommentTooltipPopup>(_RevealRect);
                    _RevealIsPending = false;
                }
                else
                {
                    // is this necessary to ensure update is invoked consistently in the editor?
                    EditorApplication.QueuePlayerLoopUpdate();
                }
            }
            
            _LastUpdateTime = currentTime;
        }
        
        public static void ShowFor(Rect hoverRect, GUIContent content, float delay = 0.5f)
        {
            _Content = content;
            _DelayRemaining = delay;
            _RevealIsPending = true;

            float padding = 10f;
            int maxWidth = 300;
            int heightOffset = 10;
            
            var absoluteScreenPos = GUIUtility.GUIToScreenPoint(new Vector2(hoverRect.center.x, hoverRect.yMax));
            var idealSize = EditorStyles.wordWrappedLabel.CalcSize(content);
            var actualWidth = Mathf.Min(idealSize.x, maxWidth);
            var actualHeight = EditorStyles.wordWrappedLabel.CalcHeight(content, actualWidth);
            var contentSize = new Vector2(actualWidth + padding, actualHeight + padding / 2f);

            absoluteScreenPos.x -= contentSize.x / 2f;
            absoluteScreenPos.y += heightOffset;

            _RevealRect = new Rect(absoluteScreenPos, contentSize);
        }

        public static void Hide()
        {
            if (_Instance)
                _Instance.Close();
            _Instance = null;
            _RevealIsPending = false;
        }
        
        private void OnEnable()
        {
            ShowPopup();
        }

        private void OnGUI()
        {
            var screenRect = new Rect(0, 0, Screen.width, Screen.height);
            var bgGrayscale = 55f / 255f;
            GUI.color = new Color(bgGrayscale, bgGrayscale, bgGrayscale, 1f);
            GUI.DrawTexture(screenRect, EditorGUIUtility.whiteTexture, ScaleMode.StretchToFill);

            var topRect = new Rect(0, 0, Screen.width, 1);
            var bottomRect = new Rect(0, Screen.height - 1, Screen.width, 1);
            var leftRect = new Rect(0, 0, 1, Screen.height);
            var rightRect = new Rect(Screen.width - 1, 0, 1, Screen.height);

            // Who needs styles!?
            GUI.color = new Color(0.1f, 0.1f, 0.1f, 1f);
            GUI.DrawTexture(topRect, EditorGUIUtility.whiteTexture, ScaleMode.StretchToFill);
            GUI.DrawTexture(bottomRect, EditorGUIUtility.whiteTexture, ScaleMode.StretchToFill);
            GUI.DrawTexture(leftRect, EditorGUIUtility.whiteTexture, ScaleMode.StretchToFill);
            GUI.DrawTexture(rightRect, EditorGUIUtility.whiteTexture, ScaleMode.StretchToFill);

            GUI.color = Color.white;
            EditorGUILayout.LabelField(_Content, EditorStyles.wordWrappedLabel);
        }
    }
}