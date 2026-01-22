using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.SourceGenerators;
using Travels.Models;

namespace Travels.Desktop.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private HttpClient _client = new();

    [Reactive] private Guid? _id;
    [Reactive] private string? _name;
    [Reactive] private string? _description;
    [Reactive] private string? _country;
    [Reactive] private bool _isDeleted;

    public ObservableCollection<Point> Points { get; } = [];
    [Reactive] private Point? _selectedPoint;

    public MainWindowViewModel()
    {
        this.WhenAnyValue(x => x.SelectedPoint)
            .Subscribe(point =>
            {
                Id = point?.Id;
                Name = point?.Name;
                Description = point?.Description;
                Country = point?.Country;
                IsDeleted = point?.IsDeleted ?? false;
            });
    }

    [ReactiveCommand]
    private async Task Load()
    {
        var url = "http://localhost:5177/api/v1/points";
        var points = _client.GetFromJsonAsAsyncEnumerable<Point>(url);

        Points.Clear();
        await foreach (var point in points)
        {
            Points.Add(point);
        }
    }
}
