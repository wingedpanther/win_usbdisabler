Imports Microsoft.Win32
'Created by Vivek(vivekspathil@gmail.com)
'Date : 12-02-2017
'USB Port disabler - To secure system files from unauthorized copy to usb drives
Public Class UsbFunctions
    Dim regKey As RegistryKey
    'All USB ports will be get disabled excpetd already connected USB decices.(
    Public Function ToggleUSBPort(ByVal IsDisable)
        Dim regKey As RegistryKey
        regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\USBSTOR", True)
        With regKey
            If IsDisable Then
                'True = Disable it
                regKey.SetValue("Start", 4) ' 4(To disable the ports)
            Else
                'False = Enable it
                regKey.SetValue("Start", 3) ' 3(To enable the ports)
            End If
        End With
        Return True
    End Function
    Public Function USBPortStatus()
        Dim objVal As Object
        regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\USBSTOR")
        objVal = regKey.GetValue("Start")
        If objVal = "3" Then 'Opened 
            Return True
        Else 'Closed
            Return False
        End If
    End Function
End Class
