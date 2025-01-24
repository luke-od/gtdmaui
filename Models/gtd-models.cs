using System.ComponentModel;
using System.Collections.ObjectModel;

namespace GTDApp.Models
{
    public class Item : INotifyPropertyChanged
    {
        private string _title = string.Empty;
        private string _notes = string.Empty;
        private DateTime? _dueDate;
        private ProcessingState _state;
        private string _context = string.Empty;
        private string _project = string.Empty;
        
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        
        public string Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged(nameof(Notes));
            }
        }
        
        public DateTime? DueDate
        {
            get => _dueDate;
            set
            {
                _dueDate = value;
                OnPropertyChanged(nameof(DueDate));
            }
        }
        
        public ProcessingState State
        {
            get => _state;
            set
            {
                _state = value;
                OnPropertyChanged(nameof(State));
            }
        }
        
        public string Context
        {
            get => _context;
            set
            {
                _context = value;
                OnPropertyChanged(nameof(Context));
            }
        }
        
        public string Project
        {
            get => _project;
            set
            {
                _project = value;
                OnPropertyChanged(nameof(Project));
            }
        }

public event PropertyChangedEventHandler? PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum ProcessingState
    {
        Inbox,
        NextAction,
        WaitingFor,
        Someday,
        Reference,
        Done
    }

    public class Project
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ObservableCollection<Item> Items { get; set; } = new();
        public DateTime? Deadline { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class Context
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string Description { get; set; } = string.Empty; // Initialize with a default value
    }
}
