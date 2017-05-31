using Xamarin.Forms;

namespace Operator.Models
{
    public abstract class ListItem : ObservableObject
    {
        protected Color SelectedColor = Color.Blue;
        protected Color UnSelectedColor = Color.Transparent;

        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }

            set { SetField(ref isSelected, value); }
        }

        private Color backgroundColor;
        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set { SetField(ref backgroundColor, value); }
        }

        public bool FlipSelection()
        {
            return IsSelected ? SetSelection(false) : SetSelection(true);
        }

        public bool SetSelection(bool Target)
        {
            IsSelected = Target;
            BackgroundColor = IsSelected ? SelectedColor : UnSelectedColor;
            return IsSelected;
        }
    }
}
