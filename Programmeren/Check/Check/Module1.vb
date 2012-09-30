Module Module1
    Sub close()
        Console.ReadLine()
        End
    End Sub
    Sub Main()
        Dim th As New Threading.Thread(AddressOf close)
        th.Start()
        While 1
            Console.WriteLine("[" & Format(Now, "dd/MM/yyyy HH:mm:ss:ms") & "] " & "INFO: " & "Initializing check...")
            Console.WriteLine("[" & Format(Now, "dd/MM/yyyy HH:mm:ss:ms") & "] " & "INFO: " & "Pinging PC-TRAP-BOVEN...")
            Try
                If My.Computer.Network.Ping("PC-TRAP-BOVEN") = True Then
                    '' Ping gelukt
                    Console.WriteLine("[" & Format(Now, "dd/MM/yyyy HH:mm:ss:ms") & "] " & "STATUS: " & "Pong received!")
                Else
                    Console.WriteLine("[" & Format(Now, "dd/MM/yyyy HH:mm:ss:ms") & "] " & "STATUS: " & "No connection!")
                End If
            Catch ex As Exception
                Console.WriteLine("[" & Format(Now, "dd/MM/yyyy HH:mm:ss:ms") & "] " & "STATUS: " & "No connection!")
            End Try

            Console.WriteLine("[" & Format(Now, "dd/MM/yyyy HH:mm:ss:ms") & "] " & "INFO: " & "Pinging PC-TRAP-BENEDEN...")
            Try
                If My.Computer.Network.Ping("PC-TRAP-BENEDEN") = True Then
                    '' Ping gelukt
                    Console.WriteLine("[" & Format(Now, "dd/MM/yyyy HH:mm:ss:ms") & "] " & "STATUS: " & "Pong received!")
                Else
                    Console.WriteLine("[" & Format(Now, "dd/MM/yyyy HH:mm:ss:ms") & "] " & "STATUS: " & "No connection!")
                End If
            Catch ex As Exception
                Console.WriteLine("[" & Format(Now, "dd/MM/yyyy HH:mm:ss:ms") & "] " & "STATUS: " & "No connection!")
            End Try

            Console.WriteLine("[" & Format(Now, "dd/MM/yyyy HH:mm:ss:ms") & "] " & "INFO: " & "Testing internet connection...")
            Try
                If IsConnectionAvailable() = True Then
                    '' Ping gelukt
                    Console.WriteLine("[" & Format(Now, "dd/MM/yyyy HH:mm:ss:ms") & "] " & "STATUS: " & "Internet connection OK!")
                Else
                    Console.WriteLine("[" & Format(Now, "dd/MM/yyyy HH:mm:ss:ms") & "] " & "STATUS: " & "No internet connection!")
                End If
            Catch ex As Exception
                Console.WriteLine("[" & Format(Now, "dd/MM/yyyy HH:mm:ss:ms") & "] " & "STATUS: " & "No internet connection!")
            End Try
            Console.WriteLine("[" & Format(Now, "dd/MM/yyyy HH:mm:ss:ms") & "] " & "PAUSE: " & "Sleeping 60 seconds...")
            Threading.Thread.Sleep(60000)
        End While
    End Sub
    Public Function IsConnectionAvailable() As Boolean
        ' Returns True if connection is available 
        ' Replace www.google.com with a site that 
        ' is guaranteed to be online - perhaps your 
        ' corporate site, or microsoft.com 
        Dim objUrl As New System.Uri("http://www.google.com/")
        ' Setup WebRequest 
        Dim objWebReq As System.Net.WebRequest
        objWebReq = System.Net.WebRequest.Create(objUrl)
        Dim objResp As System.Net.WebResponse
        Try
            ' Attempt to get response and return True 
            objResp = objWebReq.GetResponse
            objResp.Close()
            objWebReq = Nothing
            Return True
        Catch ex As Exception
            ' Error, exit and return False 
            objWebReq = Nothing
            Return False
        End Try
    End Function
End Module
