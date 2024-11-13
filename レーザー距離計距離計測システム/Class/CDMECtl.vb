Imports System.IO.Ports
Imports MSCommLib
Imports MSCommLib.CommEventConstants
Imports MSCommLib.OnCommConstants

Public Class CDMECtl : Inherits AComCtl

    '読み取り値
    Public ReadData As String = "0"
    '出力反転数値
    Public mIntInvNumber As Integer = 0
    'オフセット値
    Public mIntOffSet As Integer = 0

    'タイムアウト回数
    Public mIntTimeOut As Integer = 0

    ''' <summary>
    ''' コンストラクタ(ポート番号,ボーレート,パリティビット,データビット,ストップビット)
    ''' </summary>
    ''' <param name="PortNumber">ポート番号</param>
    ''' <param name="baudRate">ボーレート</param>
    ''' <param name="parity">パリティビット</param>
    ''' <param name="dataBits">データビット</param>
    ''' <param name="stopBits">ストップビット</param>
    ''' <remarks></remarks>
    Public Sub New(Optional ByVal PortNumber As Short = 1, Optional ByVal baudRate As Integer = 9600, _
        Optional ByVal parity As Parity = Parity.None, Optional ByVal dataBits As Integer = 8, _
        Optional ByVal stopBits As StopBits = StopBits.One)

        MyBase.New(PortNumber, baudRate, parity, dataBits, stopBits)

        Me.mMSComm.Handshaking = HandshakeConstants.comNone

        Me.mMSComm.RTSEnable = False

        'データ受信時にOnCommイベントを発生させる閾値のバイト数を指定
        Me.mMSComm.RThreshold = 1

        'データ送信時にOnCommイベントを発生させる閾値のバイト数を指定
        Me.mMSComm.SThreshold = 1

        'シリアル通信中に、DTR(Data Terminal Ready）シグナルを有効にする
        Me.mMSComm.DTREnable = True

    End Sub

    ''' <summary>
    ''' 距離計測コマンド発行
    ''' </summary>
    ''' <remarks>距離を単発測定します。</remarks>
    Public Sub Command_DISTANCE()
        Try
            If Not Me.mMSComm.PortOpen Then
                '新しいシリアルポート接続を開く
                Me.mMSComm.PortOpen = True
            End If

            'タイムアウトカウントが５回以上なら
            If Me.mIntTimeOut > 5 Then
                'ポート再接続
                Me.PortReOpen()
                'タイムアウトカウントをクリア
                Me.mIntTimeOut = 0
            Else
                'タイムアウトカウントをカウント
                Me.mIntTimeOut += 1
            End If

            'コマンドシーケンス送信
            Me.mMSComm.Output = ControlChar.STX & "TSM" & ControlChar.EOT & vbCrLf

        Catch ex As InvalidOperationException
            Common.gMsg_警告("指定したポートが開いていません" & vbCrLf & ex.ToString)
        Catch ex As Exception
            Common.gMsg_警告(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' トラッキング
    ''' </summary>
    ''' <remarks>距離を連続測定します。</remarks>
    Public Sub Command_TRACKING()
        Try
            'コマンドシーケンス送信
            Me.mMSComm.Output = ControlChar.STX & "ICM0" & ControlChar.EOT & vbCrLf

        Catch ex As InvalidOperationException
            Common.gMsg_警告("指定したポートが開いていません" & vbCrLf & ex.ToString)
        Catch ex As Exception
            Common.gMsg_警告(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 温度測定
    ''' </summary>
    ''' <remarks>周辺温度を測定します。</remarks>
    Public Sub Command_TEMPERATURE()
        Dim strRead As String = ""
        Dim strRet As String = ""
        Dim intRet As Integer = -1
        Try
            'コマンドシーケンス送信
            Me.mMSComm.Output = ControlChar.STX & "GTE" & ControlChar.EOT & vbCrLf

        Catch ex As InvalidOperationException
            Common.gMsg_警告("指定したポートが開いていません" & vbCrLf & ex.ToString)
        Catch ex As Exception
            Common.gMsg_警告(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' レーザーオン
    ''' </summary>
    ''' <remarks>レーザー光線照射をオンにします。</remarks>
    Public Sub Command_LASER_ON()
        Try
            'コマンドシーケンス送信
            Me.mMSComm.Output = ControlChar.STX & "ISB0" & ControlChar.EOT & vbCrLf

        Catch ex As InvalidOperationException
            Common.gMsg_警告("指定したポートが開いていません" & vbCrLf & ex.ToString)
        Catch ex As Exception
            Common.gMsg_警告(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' レーザーオフ
    ''' </summary>
    ''' <remarks>レーザー光線照射をオフにします。</remarks>
    Public Sub Command_LASER_OFF()
        Try
            'コマンドシーケンス送信
            Me.mMSComm.Output = ControlChar.STX & "ISB1" & ControlChar.EOT & vbCrLf

        Catch ex As InvalidOperationException
            Common.gMsg_警告("指定したポートが開いていません" & vbCrLf & ex.ToString)
        Catch ex As Exception
            Common.gMsg_警告(ex.ToString)
        End Try
    End Sub

    ''Error-------------------------------------------------------------------------
    Public Overrides Sub BreakErrorListener()
        '再度オープン
        PortReOpen()
    End Sub

    Public Overrides Sub CTSTimeOutErrorListener()
        '再度オープン
        PortReOpen()
    End Sub

    Public Overrides Sub DSRTimeOutErrorListener()
        '再度オープン
        PortReOpen()
    End Sub

    Public Overrides Sub CDTimeOutErrorListener()
        '再度オープン
        PortReOpen()
    End Sub

    ''Event-------------------------------------------------------------------------
    Public Overrides Sub ReceiveEventListener()
        Dim strRead As String = "0"
        Dim intRead As Integer = 0

        'データ受信
        '+DDDDDD(CRLF)
        'DDDDDD：測定距離（1/10mm)

        ''COMデータ受信（リトライ５回）
        For i As Integer = 0 To 4
            strRead = CStr(Me.mMSComm.Input)
            If Not strRead Is Nothing Then
                Exit For
            End If
            System.Threading.Thread.Sleep(50)
        Next

        '★inoueテスト用

        '受信データ無ければコメントを表示させ終了
        If strRead Is Nothing Then
            Me.ReadData = "NODATA"
            Exit Sub
        End If

        '文字「＋」,「-」までループし、文字「＋」,「-」から7文字取得
        'For i As Integer = 0 To strRead.ToCharArray.Length - 1
        '    If strRead.ToCharArray(i, 1) = "+" Or strRead.ToCharArray(i, 1) = "-" Then

        '        intRead = CInt(strRead.Substring(i, 7))
        '        Exit For
        '    End If
        'Next
        For i As Integer = strRead.ToCharArray.Length - 1 To 0 Step -1
            If strRead.ToCharArray(i, 1) = "+" Or strRead.ToCharArray(i, 1) = "-" Then
                intRead = CInt(strRead.Substring(i, 7))
                Exit For
            End If
        Next

        '測定値反転
        intRead = intRead

        'オフセット設定
        intRead = intRead + mIntOffSet

        '符号反転
        If intRead < 0 Then
            '-の場合、+に変換
            intRead = intRead * -1
        End If


        '最大値(999999)上限設定
        If intRead > 999999 Then
            Me.ReadData = "999999"
        ElseIf intRead < 0 Then
            Me.ReadData = "0"
        Else
            Me.ReadData = CStr(intRead)
        End If

        'タイムアウトカウントをクリア
        Me.mIntTimeOut = 0

    End Sub
End Class
