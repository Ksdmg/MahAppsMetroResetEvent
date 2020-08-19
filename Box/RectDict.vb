Imports ControlzEx.Theming

Partial Public NotInheritable Class RectDict
    Private Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Shared ReadOnly Property Instance As ResourceDictionary
        Get
            If _Instance Is Nothing Then
                _Instance = New RectDict
                Dim Theme = ThemeManager.Current.GetTheme("Dark.Blue")
                ThemeManager.Current.ChangeTheme(Nothing, _Instance, Theme)
            End If
            Return _Instance
        End Get
    End Property
    Private Shared _Instance As ResourceDictionary

End Class
