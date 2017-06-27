Imports System.IO.Ports
Imports System.Threading

Class MainWindow
    Dim serialPort As SerialPort
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        'Starting a thread to found device
        Dim threadSearchCOM As New Thread(AddressOf searchDevices)
        threadSearchCOM.IsBackground = True
        threadSearchCOM.Start()


    End Sub
    Private Sub searchDevices()
        Dim serialSearch As New SerialSearch
        'Define the callback for PortFounded
        AddHandler serialSearch.PortFounded, AddressOf portFounded

        'Call findPort with context Device, will send to serialDevice a '$' and will wait a response who match with context
        serialSearch.findPort("Device")
    End Sub

    Public Sub portFounded(ByVal serialPort As SerialPort)
        Me.serialPort = serialPort
        Me.connectVerif.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, Sub() connectVerif.Text = "PORT FOUNDED: " + serialPort.PortName)
    End Sub

End Class
