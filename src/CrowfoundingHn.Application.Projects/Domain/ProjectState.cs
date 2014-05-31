namespace CrowfoundingHn.Projects.Domain
{
    public class ProjectState
    {
        

        public ProjectState(string state)
        {
            State = state;
        }

        public string State { get; private set; }

        static ProjectState _editing = new ProjectState("Editing");
        public static ProjectState Editing
        {
            get
            {
                return _editing;
            }
            set
            {
                _editing = value;
            }
        }
    }
}