using Avalonia;
using Avalonia.Controls;

namespace Travels.Desktop.Components;

public partial class InputComponent : UserControl
{
    public static readonly AvaloniaProperty<object> LabelProperty =
        AvaloniaProperty.Register<InputComponent, object>(nameof(Label));

    public object Label
    {
        get => GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public static readonly AvaloniaProperty<string> ValueProperty =
        AvaloniaProperty.Register<InputComponent, string>(nameof(Value));

    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public InputComponent()
    {
        InitializeComponent();
    }
}

