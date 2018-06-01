Imports System.Speech
Imports System.Speech.Recognition
Imports System.Speech.Synthesis
Imports System.IO
Imports System.Xml

Public Class Form1

    Public beingDrag As Boolean = False
    Public mousedownX As Integer
    Public mousedownY As Integer


    Dim WithEvents reg As New Recognition.SpeechRecognitionEngine

    'Private Sub setcolor(ByVal color As System.Drawing.Color)
    '    Dim synth As New Synthesis.SpeechSynthesizer

    '    Me.BackColor = color


    'End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Dim jarvis = CreateObject("sapi.spvoice")
        ' jarvis.speak("I'm jarvis personal asssistant for you,  with memory 4 GB  speed 2.2 giga-heartz quadcore i5 second generation intel processor is ready to take your commands sir")

        reg.SetInputToDefaultAudioDevice()



        Dim gram As New Recognition.SrgsGrammar.SrgsDocument
        Dim command As New Recognition.SrgsGrammar.SrgsRule("command")
        Dim commandlist As New Recognition.SrgsGrammar.SrgsOneOf(File.ReadAllLines(Environment.CurrentDirectory + "\\commands.txt"))

        'Dim commandlist As New Recognition.SrgsGrammar.SrgsOneOf("hello jarvis", "hi jarvis", "change the background color", "hey jarvis",
        '                  "red", "blue", "yellow", "aqua", "indigo", "green", "white",
        '                 "black", "purple", "pink", "orange", "violet", "open notepad", "open cmd",
        '                   "close cmd", "open twitter", "close yourself", "open google", "close notepad",
        '                  "what time is it?", "who are you", "describe yourself", "what is today's date", "open microsoft word",
        '                 "close microsoft word", "open powerpoint", "close powerpoint", "open excel", "close excel", "open vlc", "open video player",
        '                   "start vlc", "start video player", "play", "pause", "forward", "backward", "fast", "slomo", "volume up", "volume down",
        '                "close vlc", "whats the weather outside", "whats the temperature", "whats up", "i am fine", "jarvis are you there", "what is god", "where do you live",
        '                 "what is life", "who created you", "jarvis i want to do shopping", "flipkart", "amazon", "go incognito", "new tab", "close tab",
        '                  "open browser", "close browser", "I WANT TO SEARCH SOMETHING")
        command.Add(commandlist)


        gram.Rules.Add(command)
        gram.Root = command


        reg.LoadGrammar(New Recognition.Grammar(gram))
        reg.RecognizeAsync(RecognizeMode.Multiple)

    End Sub


    Private Sub reg_RecognizeCompleted(sender As Object, e As RecognizeCompletedEventArgs) Handles reg.RecognizeCompleted
        ' reg.RecognizeAsync()



    End Sub
    Public Function GetWeather(input As [String]) As [String]
        Dim query As [String] = [String].Format("https://query.yahooapis.com/v1/public/yql?q=select * from weather.forecast where woeid in (select woeid from geo.places(1) where text='siliguri, west bengal')&format=xml&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys")
        Dim wData As New XmlDocument()
        Dim temp As String
        Dim condition As String
        Dim tempe


        wData.Load(query)

        Dim manager As New XmlNamespaceManager(wData.NameTable)
        manager.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0")

        Dim channel As XmlNode = wData.SelectSingleNode("query").SelectSingleNode("results").SelectSingleNode("channel")
        Dim nodes As XmlNodeList = wData.SelectNodes("query/results/channel")
        Try
            temp = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", manager).Attributes("temp").Value
            condition = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", manager).Attributes("text").Value

            If input = "temp" Then
                tempe = (temp - 32) / 1.8
                tempe = System.Math.Round(tempe, 2)
                Return tempe
            End If

            If input = "cond" Then
                Return condition
            End If
        Catch
            Return "Error Receiving data"
        End Try
        Return "error"
    End Function





    Private Sub reg_SpeechRecognized(sender As Object, e As SpeechRecognizedEventArgs) Handles reg.SpeechRecognized
        Dim jarvis
        Dim num As Integer
        Dim r As String
        Dim search As Boolean = False
        '  Dim QEvent As String


        jarvis = CreateObject("sapi.spvoice")
        ' jarvis.Speak("I'm searching for-" + e.Result.Words[1].Text + ". Enjoy at it sir!");
        'Process.Start("http://google.com/search?q=" + e.Result.Words[1].Text);


        ' Select Case e.Result.Text
        'If e.Result.Text.Contains("jarvis") Then
        'Dim choice As String = e.Result.Text.Replace("jarvis", "")

        r = e.Result.Text

        '  Label1.Text = "You  : " + r
        'If r.Contains("search") Then

        '    Dim sl As Integer = Len(r)
        '    Dim ns As [String] = Mid(r, sl, 6)
        '    Label1.Text = "You  : " + ns
        '    MsgBox(ns)
        '    jarvis.speak("I'm searching " + ns)
        '    Process.Start("https://www.google.co.in/search?q=" + ns)
        'End If

        'If (search) Then
        '    Process.Start("https://www.google.co.in/search?q=" + r)
        '    search = False
        'End If


        'If search = False AndAlso r = "If want to search something" Then


        '    jarvis.speak("What do you want to search")
        '    search = True
        'End If


        'num = New Random().Next(1, 4)
        '        If num = 1 Then
        '            jarvis.speak("Alright, I am searching " + r + " in google")
        '        ElseIf num = 2 Then
        '            jarvis.speak("ok sir, I am searching " + r)
        '        ElseIf num = 3 Then
        '            jarvis.speak("Alright, I am searching ")
        '        End If

        '        r = String.Empty

        ' End If

        'End If
        '' talking with jarvis
        If r = "hello jarvis" Then
            num = New Random().Next(1, 5)
            If num = 1 Then
                jarvis.speak("hello sir, what i can do for you")
            ElseIf num = 2 Then
                jarvis.speak("Hello sir, how are you ")
            ElseIf num = 3 Then
                jarvis.speak("hello sir, how can i help you ")
            ElseIf num = 4
                jarvis.speak("hello sir , glad to see you")
            End If



        End If

        If r = "hi jarvis" Then
            jarvis.speak("Hi sir, how are you")
        End If

        If r = "i am fine" Then
            jarvis.speak("good to here that")
        End If
        If r = "whats up" Then
            jarvis.speak("Great! How are you doing?")

        End If

        If r = " jarvis are you there" Then
            jarvis.speak("always there for you ,sir")

        End If

        If r = "what is god" Then
            jarvis.speak("God, who created the universe in all of its magnitude and creative details, is able to be known, by us. He tells us about himself, but even goes beyond that.")

        End If

        If r = "where do you live" Then
            jarvis.speak("i live in" + SystemInformation.UserDomainName.ToString() + "sir")

        End If

        If r = "what is life" Then
            jarvis.speak("the condition that distinguishes animals and plants from inorganic matter, including the capacity for growth, reproduction, functional activity, and continual change preceding death.")

        End If

        If r = "who are you" OrElse r = "describe yourself" Then

            jarvis.speak("I'm jarvis personal asssistant for you,  with memory 4 GB  speed 2.2 giga-heartz quadcore i5 second generation intel processor,   made by genius, aashish")
        End If


        If r = "who created you" Then
            jarvis.speak("I'm created by aashish")
        End If

        '' weather report

        If r = "whats the weather outside" Then
            Try
                If My.Computer.Network.IsAvailable = True Then
                    jarvis.speak("the sky is" + GetWeather("cond") + ".")
                Else
                    jarvis.speak("No internet connection sir please connect to the internet")
                End If
            Catch ex As Exception

            End Try


        End If

        If r = "whats the temperature" Then
            Try
                If My.Computer.Network.IsAvailable = True Then
                    jarvis.speak("today's temperature is " + GetWeather("temp") + " degree celsius")
                Else
                    jarvis.speak("No internet connection sir please connect to the internet")
                End If
            Catch ex As Exception

            End Try

        End If

        'If r = "change the background color" Then
        '    jarvis.speak("Which color you want sir")
        'End If

        'If r = "red" Then
        '    jarvis.speak("Setting the background color  red")
        '    setcolor(Color.Red)
        'End If

        'If r = "blue" Then
        '    jarvis.speak("Setting the background color  blue")
        '    setcolor(Color.Blue)
        'End If

        'If r = "yellow" Then
        '    jarvis.speak("Setting the background color  yellow")
        '    setcolor(Color.Yellow)
        'End If
        'If r = "aqua" Then
        '    jarvis.speak("Setting the background color  aqua")
        '    setcolor(Color.Aqua)
        'End If
        'If r = "indigo" Then
        '    jarvis.speak("Setting the background color  indigo")
        '    setcolor(Color.Indigo)
        'End If
        'If r = "green" Then

        '    jarvis.speak("Setting the background color  Green")
        '    setcolor(Color.Green)
        'End If
        'If r = "purple" Then

        '    jarvis.speak("Setting the background color  purple")
        '    setcolor(Color.Purple)
        'End If
        'If r = "black" Then

        '    jarvis.speak("Setting the background color  black")
        '    setcolor(Color.Black)
        'End If
        'If r = "white" Then

        '    jarvis.speak("Setting the background color  white")
        '    setcolor(Color.White)
        'End If
        'If r = "orange" Then

        '    jarvis.speak("Setting the background color  Orange")
        '    setcolor(Color.Orange)
        'End If
        'If r = "pink" Then

        '    jarvis.speak("Setting the background color  pink")
        '    setcolor(Color.Pink)
        'End If
        'If r = "violet" Then

        '    jarvis.speak("Setting the background color  violet")
        '    setcolor(Color.Violet)
        'End If


        '' //Web commands
        'If r = "open browser" Then
        '    Dim url As String = “http://www.google.co.in\“
        '    jarvis.speak("opening browser sir")
        '    System.Diagnostics.Process.Start(url)
        'End If

        If r = "open google" OrElse r = "open browser" Then
            Try
                If My.Computer.Network.IsAvailable = True Then
                    Dim url As String = “http://www.google.co.in\“
                    jarvis.speak("opening google sir")
                    System.Diagnostics.Process.Start(url)
                Else
                    jarvis.speak("Seems to be like there is no internet connection, please connect the internet and try again")


                End If



            Catch ex As Exception

            End Try

        End If

        If r = "go incognito" Then
            SendKeys.Send("^+{n}")

        End If

        If r = "new tab" OrElse r = "tab" Then
            SendKeys.Send("^{t}")
        End If

        If r = "close tab" Then
            SendKeys.Send("^{w}")
        End If

        If r = "open twitter" Then
            Try
                If My.Computer.Network.IsAvailable = True Then
                    Dim url As String = “https://twitter.com/Ashish2050gupta“
                    jarvis.speak("opening TWITTER sir")
                    Process.Start(url)

                Else
                    jarvis.speak("Anable to open twitter as there is no internet connection sir")
                End If
            Catch ex As Exception
                '  jarvis.speak("Anable to open twitter as there is no internet connection sir")
            End Try

        End If

        If r = "jarvis i want to do shopping" Then
            Try
                If My.Computer.Network.IsAvailable = True Then
                    jarvis.speak("On which website you want to shop sir")


                Else
                    jarvis.speak("Anable to open twitter as there is no internet connection sir")
                End If
            Catch ex As Exception
            End Try

        End If
        If r = "flipkart" Then
            Dim url As String = "https://www.flipkart.com/"
            jarvis.speak("opening flipkart sir")
            Process.Start(url)
        End If

        If r = "amazon" Then
            Dim url As String = "https://www.amazon.in/"
            jarvis.speak("opening amazon sir")
            Process.Start(url)
        End If



        If r = "close browser" Then
            jarvis.speak("As per your command sir")

            Dim arrProcess() As Process = System.Diagnostics.Process.GetProcessesByName("UCBrowser")

            For Each p As Process In arrProcess
                p.Kill()

            Next

        End If

        If r = "open notepad" Then
            jarvis.speak("opening notepad sir")
            System.Diagnostics.Process.Start("notepad.exe")
        End If

        If r = "close notepad" Then
            Dim arrProcess() As Process = System.Diagnostics.Process.GetProcessesByName("notepad")

            For Each p As Process In arrProcess
                p.Kill()
            Next
        End If


        If r = "open cmd" Then
            jarvis.speak("opening CMD sir")
            ' System.Diagnostics.Process.Start("cmd.exe")
            Process.Start("cmd.exe")
        End If

        If r = "close cmd" Then
            Dim Process() As Process = System.Diagnostics.Process.GetProcessesByName("cmd")

            For Each p As Process In Process
                p.Kill()
            Next
        End If

        '' ***microsoft office commands

        If r = "open microsoft word" Then
            jarvis.speak("opening microsoft word sir")
            System.Diagnostics.Process.Start("WINWORD.exe")
            'Process.Start("WINWORD.exe")

        End If

        If r = "close microsoft word" Then

            jarvis.speak("closing microsoft word sir")
            Dim Process() As Process = System.Diagnostics.Process.GetProcessesByName("WINWORD")

            For Each p As Process In Process
                p.Kill()


            Next
        End If
        If r = "save file" Then
            SendKeys.Send("^{s}")
        End If

        If r = "open powerpoint" Then
            jarvis.speak("opening POWERPOINT sir")
            'System.Diagnostics.Process.Start("POWERPNT.exe")
            Process.Start("POWERPNT.exe")
        End If

        If r = "close powerpoint" Then

            jarvis.speak("closing POWERPOINT sir")
            Dim Process() As Process = System.Diagnostics.Process.GetProcessesByName("POWERPNT")

            For Each p As Process In Process
                p.Kill()

            Next
        End If

        If r = "open excel" Then
            jarvis.speak("opening EXCEL sir")
            'System.Diagnostics.Process.Start("POWERPNT.exe")
            Process.Start("EXCEL.exe")
        End If

        If r = "close excel" Then

            jarvis.speak("closing EXCEL sir")
            Dim Process() As Process = System.Diagnostics.Process.GetProcessesByName("EXCEL")

            For Each p As Process In Process
                p.Kill()

            Next
        End If



        If r = "close yourself" Then
            jarvis.speak(" BYE SIR  ,Have a nice day ahead !")
            Me.Close()
        End If

        '' time and date commands

        If r = "what time is it?" Then
            jarvis.speak(DateTime.Now.ToString("h:mm:tt"))
        End If

        If r = "what is today's date" Then
            jarvis.speak(DateTime.Now.ToString("dd/mm/yyyy"))
        End If



        '' // vlc/ media commands

        If r = "open vlc" Then
            jarvis.speak("opening vlc sir")
            Process.Start("C:\Program Files\VideoLAN\VLC\vlc.exe")
        End If

        If r = "open video player" Then
            jarvis.speak("opening media player sir")
            Process.Start("vlc.exe")
        End If

        If r = "play" Then
            SendKeys.Send(" ")
        End If

        If r = "pause" Then
            SendKeys.Send(" ")
        End If
        If r = "forward" Then
            SendKeys.Send("^{RIGHT}")
        End If

        If r = "backward" Then
            SendKeys.Send("^{LEFT}")
        End If

        If r = "fast" Then
            SendKeys.Send("+")
        End If

        If r = "slomo" Then
            SendKeys.Send("-")
        End If

        If r = "volume up" Then
            SendKeys.Send("^{UP}")
        End If

        If r = "volume down" Then
            SendKeys.Send("^{DOWN}")
        End If

        If r = "close vlc" Then
            Dim Process() As Process = System.Diagnostics.Process.GetProcessesByName("vlc")

            For Each p As Process In Process
                p.Kill()

            Next
        End If

        'End Select


    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            beingDrag = True
            mousedownX = e.X
            mousedownY = e.Y
        End If

    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove

        If beingDrag = True Then
            Dim tmp As Point = New Point()
            tmp.X = Me.Location.X + (e.X - mousedownX)
            tmp.Y = Me.Location.Y + (e.Y - mousedownY)
            Me.Location = tmp
            tmp = Nothing

        End If
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If e.Button = MouseButtons.Left Then
            beingDrag = False
        End If
    End Sub


End Class
