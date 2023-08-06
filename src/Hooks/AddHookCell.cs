using UniverseLib.UI;
using UniverseLib.UI.Models;
using UniverseLib.UI.Widgets.ScrollView;

namespace UnityExplorer.Hooks
{
    public class AddHookCell : ICell
    {
        public bool Enabled => UIRoot.activeSelf;

        public RectTransform Rect { get; set; }
        public GameObject UIRoot { get; set; }

        public float DefaultHeight => 30;

        public Text MethodNameLabel;
		public ButtonRef HookPrefixButton;
		public ButtonRef HookPostfixButton;

		public int CurrentDisplayedIndex;

		private void OnPrefixHookClicked()
		{
			HookCreator.AddPrefixHookClicked(CurrentDisplayedIndex);
		}
		private void OnPostfixHookClicked()
		{
			HookCreator.AddPostfixHookClicked(CurrentDisplayedIndex);
		}

		public void Enable()
        {
            this.UIRoot.SetActive(true);
        }

        public void Disable()
        {
            this.UIRoot.SetActive(false);
        }

        public GameObject CreateContent(GameObject parent)
        {
            UIRoot = UIFactory.CreateUIObject(this.GetType().Name, parent, new Vector2(100, 30));
            Rect = UIRoot.GetComponent<RectTransform>();
            UIFactory.SetLayoutGroup<HorizontalLayoutGroup>(UIRoot, false, false, true, true, 5, childAlignment: TextAnchor.UpperLeft);
            UIFactory.SetLayoutElement(UIRoot, minWidth: 100, flexibleWidth: 9999, minHeight: 30, flexibleHeight: 600);
            UIRoot.AddComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;

			HookPrefixButton = UIFactory.CreateButton(UIRoot, "HookPrefixButton", "Prefix", new Color(0.2f, 0.25f, 0.2f));
			UIFactory.SetLayoutElement(HookPrefixButton.Component.gameObject, minHeight: 25, minWidth: 100);
			HookPrefixButton.OnClick += OnPrefixHookClicked;

			HookPostfixButton = UIFactory.CreateButton(UIRoot, "HookPostfixButton", "Postfix", new Color(0.4f, 0.4f, 0.4f));
			UIFactory.SetLayoutElement(HookPostfixButton.Component.gameObject, minHeight: 25, minWidth: 100);
			HookPostfixButton.OnClick += OnPostfixHookClicked;

			MethodNameLabel = UIFactory.CreateLabel(UIRoot, "MethodName", "NOT SET", TextAnchor.MiddleLeft);
            UIFactory.SetLayoutElement(MethodNameLabel.gameObject, minHeight: 25, flexibleWidth: 9999);

            return UIRoot;
        }
    }
}
