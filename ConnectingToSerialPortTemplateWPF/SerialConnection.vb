Imports System.IO.Ports
Imports System.Windows.Threading

Public Class SerialConnection
    Public Function createDefaultSerialPort(ByVal portName As String)
        Dim port As New SerialPort
        port.PortName = portName
        port.BaudRate = 115200
        port.DataBits = 8
        port.Parity = Parity.None
        port.StopBits = StopBits.One
        port.Handshake = Handshake.None
        port.Encoding = System.Text.Encoding.Default
        port.ReadTimeout = 200
        port.WriteTimeout = 50
        Return port
    End Function

End Class
