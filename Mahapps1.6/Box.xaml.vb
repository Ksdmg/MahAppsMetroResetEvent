Imports System.Threading
Imports System.Windows.Threading

Partial Public Class Box

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Overloads Shared Sub Show()


        Using ready As New ManualResetEvent(False)
            Dim BoxThread = New Thread(Sub()
                                           Dim Box = New Box


                                           Dim ClosedHandler As New EventHandler(Sub()
                                                                                     RemoveHandler Box.Closed, ClosedHandler
                                                                                     Box.Dispatcher.InvokeShutdown()
                                                                                 End Sub)
                                           AddHandler Box.Closed, ClosedHandler

                                           Box.ShowDialog()
                                           ready.Set()
                                       End Sub)
            BoxThread.Name = "WpfBox"
            BoxThread.SetApartmentState(ApartmentState.STA)
            BoxThread.IsBackground = True
            BoxThread.Start()

            ready.WaitOne()

        End Using

        Trace.WriteLine("This is only executed after window is closed!!")

    End Sub


End Class
