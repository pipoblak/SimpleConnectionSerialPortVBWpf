Imports System.IO.Ports

Public Class SerialSearch
    Dim context As String
    Public Event PortFounded As Action(Of SerialPort)
    Dim serialConnection As New SerialConnection
    'Try to find a port who responds with inserted context
    Public Sub findPort(ByVal context As String)
        Me.context = context
        'Search in Connecteds COM 
        For Each sp As String In My.Computer.Ports.SerialPortNames
            'Creating default configs of a Port
            Dim port As SerialPort = serialConnection.createDefaultSerialPort(sp)
            'Adding handler to Recived Messages From Device
            AddHandler port.DataReceived, New System.IO.Ports.SerialDataReceivedEventHandler(AddressOf RecieveSearch)
            'Try to open port
            Try
                port.Open()
                'Send the command "WHO" for the serial device 
                port.WriteLine("$")

            Catch ex As Exception
                port.Dispose()
            End Try
        Next

    End Sub
    Private Sub RecieveSearch(sender As Object, e As System.IO.Ports.SerialDataReceivedEventArgs)
        Dim serialSender As SerialPort = sender

        Dim response As String = serialSender.ReadExisting()
        If (response.Contains(context)) Then
            RaiseEvent PortFounded(serialSender)
        Else
            serialSender.Close()

        End If

    End Sub

End Class
