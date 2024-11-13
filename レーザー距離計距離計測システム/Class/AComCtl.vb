Imports System.IO.Ports
Imports MSCommLib
Imports MSCommLib.CommEventConstants
Imports MSCommLib.OnCommConstants

Public MustInherit Class AComCtl

    'シリアル通信クラス
    '2024/10 田岡　MsCommからSerialPortに変更
    Friend WithEvents mMSComm As SerialPort
    'Friend WithEvents mMSComm As MSComm
    '------------------------------------------

    Private mHst_Parity As New Collections.Hashtable
    Private mHst_StopBits As New Collections.Hashtable

    Private intCOMErrCode As Integer = 0

    ''' <summary>
    ''' コンストラクタ(ポート番号,ボーレート,パリティビット,データビット,ストップビット)
    ''' </summary>
    ''' <param name="PortNumber">ポート番号</param>
    ''' <param name="baudRate">ボーレート</param>
    ''' <param name="parity">パリティビット</param>
    ''' <param name="dataBits">データビット</param>
    ''' <param name="stopBits">ストップビット</param>
    ''' <remarks></remarks>
    '2024/10 田岡　PortNumberのデータ型、値を変更
    Public Sub New(Optional ByVal PortNumber As String = "COM1", Optional ByVal baudRate As Integer = 9600,
        Optional ByVal parity As Parity = Parity.None, Optional ByVal dataBits As Integer = 8,
        Optional ByVal stopBits As StopBits = StopBits.One)
        'Public Sub New(Optional ByVal PortNumber As Short = 1, Optional ByVal baudRate As Integer = 9600, _
        'Optional ByVal parity As Parity = Parity.None, Optional ByVal dataBits As Integer = 8, _
        'Optional ByVal stopBits As StopBits = StopBits.One)
        '---------------------------------------------------------------------------------------------------------------
        'パリティビット対応テーブル
        mHst_Parity.Add(System.IO.Ports.Parity.Even, "E")
        mHst_Parity.Add(System.IO.Ports.Parity.Mark, "M")
        mHst_Parity.Add(System.IO.Ports.Parity.None, "N")
        mHst_Parity.Add(System.IO.Ports.Parity.Odd, "O")
        mHst_Parity.Add(System.IO.Ports.Parity.Space, "S")

        'パリティビット対応テーブル
        mHst_StopBits.Add(StopBits.One, "1")
        mHst_StopBits.Add(StopBits.OnePointFive, "1.5")
        mHst_StopBits.Add(StopBits.Two, "2")

        'シリアル通信用クラス作成
        '使用シリアルポート番号を指定
        '接続設定
        '2024/10 田岡　プロパティをSerialPort用に変更
        Me.mMSComm = New SerialPort With {
            .PortName = "COM1",
            .BaudRate = baudRate,
            .Parity = parity,
            .DataBits = dataBits,
            .StopBits = stopBits
        }
        'シリアル通信用クラス作成
        'Me.mMSComm = New MSComm
        '使用シリアルポート番号を指定
        'Me.mMSComm.CommPort = PortNumber
        '接続設定
        'Me.mMSComm.Settings = CStr(baudRate) & "," & CStr(Me.mHst_Parity(parity)) _
        '& "," & CStr(dataBits) & CStr(Me.mHst_StopBits(stopBits))
        '----------------------------------------------------------------
    End Sub

    ''' <summary>
    ''' COMポートをオープンします
    ''' </summary>
    ''' <returns>
    ''' TRUE:オープン成功
    ''' FALSE:オープン失敗
    ''' </returns>
    ''' <remarks></remarks>
    Public Function PortOpen() As Boolean
        Try
            '2024/10 田岡　プロパティをSerialPort用に変更
            If Not Me.mMSComm.IsOpen Then
                'If Not Me.mMSComm.PortOpen Then
                '-----------------------------------------
                '新しいシリアルポート接続を開く
                '2024/10 田岡　OpenをSerialPort用に変更
                Me.mMSComm.Open()
                'Me.mMSComm.PortOpen = True
                '---------------------------------------
                Return True
            End If

            Return False
        Catch ex As Runtime.InteropServices.COMException
            Me.intCOMErrCode = ex.ErrorCode
            'COMERR.GetErrorComment(ex.ErrorCode)
        End Try
    End Function

    ''' <summary>
    ''' COMポートを再オープンします
    ''' </summary>
    ''' <returns>
    ''' TRUE:再オープン成功
    ''' FALSE:再オープン失敗
    ''' </returns>
    ''' <remarks></remarks>
    Public Function PortReOpen() As Boolean

        Try
            'シリアルポートを閉じる
            '2024/10 田岡　CloseをSerialPort用に変更
            Me.mMSComm.Close()
            ' Me.mMSComm.PortOpen = False
            '----------------------------------------

            '新しいシリアルポート接続を開く
            '2024/10 田岡　OpenをSerialPort用に変更
            Me.mMSComm.Open()
            'Me.mMSComm.PortOpen = True
            '---------------------------------------
            Return True
        Catch ex As Runtime.InteropServices.COMException
            Me.intCOMErrCode = ex.ErrorCode
            COMERR.GetErrorComment(ex.ErrorCode)
            Try
                '新しいシリアルポート接続を開く
                '2024/10 田岡　OpenをSerialPort用に変更
                Me.mMSComm.Open()
                'Me.mMSComm.PortOpen = True
                '----------------------------------------

                Return True
            Catch ex2 As Runtime.InteropServices.COMException
                Me.intCOMErrCode = ex2.ErrorCode
                'COMERR.GetErrorComment(ex2.ErrorCode)
            End Try
        End Try
    End Function

    ''' <summary>
    ''' COMポートをクローズします
    ''' </summary>
    ''' <returns>
    ''' TRUE:クローズ成功
    ''' FALSE:クローズ失敗
    ''' </returns>
    ''' <remarks></remarks>
    Public Function PortClose() As Boolean
        Try
            '2024/10 田岡　プロパティをSerialPort用に変更
            If Me.mMSComm.IsOpen Then
                'If Me.mMSComm.PortOpen Then
                '-----------------------------------------

                'シリアルポートを閉じる
                '2024/10 田岡　CloseをSerialPort用に変更
                Me.mMSComm.Close()
                'Me.mMSComm.PortOpen = False
                '-----------------------------------------

                Return True
            End If
        Catch ex As Runtime.InteropServices.COMException
            Me.intCOMErrCode = ex.ErrorCode
            'COMERR.GetErrorComment(ex.ErrorCode)
        End Try
    End Function

    ''' <summary>
    ''' 中断信号を受信
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub BreakErrorListener()
    End Sub

    ''' <summary>
    ''' CTSタイムアウト
    ''' </summary>
    ''' <remarks>１文字を送信しようとしたがCTSラインがオフの状態でシステムで指定された時間が経過したため発生</remarks>
    Public Overridable Sub CTSTimeOutErrorListener()
    End Sub

    ''' <summary>
    ''' DSRタイムアウト
    ''' </summary>
    ''' <remarks>１文字を送信しようとしたが、DSRラインがオフの状態でシステムで指定された時間が経過したため発生</remarks>
    Public Overridable Sub DSRTimeOutErrorListener()
    End Sub

    ''' <summary>
    ''' CDタイムアウト
    ''' </summary>
    ''' <remarks>１文字を送信しようとしたが、CDラインがオフの状態で、システムで指定された時間が経過したため発生</remarks>
    Public Overridable Sub CDTimeOutErrorListener()
    End Sub

    ''' <summary>
    ''' フレームエラー
    ''' </summary>
    ''' <remarks>ハードウェアによってフレームエラーを検出したため発生</remarks>
    Public Overridable Sub FrameErrorErrorListener()
    End Sub

    ''' <summary>
    ''' ポートオーバーラン
    ''' </summary>
    ''' <remarks>ハードウェアから１文字が読み取られる前に、次の文字が受信</remarks>
    Public Overridable Sub PortOverRunErrorListener()
    End Sub

    ''' <summary>
    ''' 受信バッファオーバーフロー
    ''' </summary>
    ''' <remarks>受信バッファに空き領域がない場合発生</remarks>
    Public Overridable Sub RxOverErrorListener()

    End Sub

    ''' <summary>
    ''' パリティエラー
    ''' </summary>
    ''' <remarks>ハードウェアによってパリティエラーを検出した場合発生</remarks>
    Public Overridable Sub RxParityErrorListener()
    End Sub

    ''' <summary>
    ''' 送信バッファ
    ''' </summary>
    ''' <remarks>１文字をキューに入れようとしたが、送信バッファがいっぱいになったため発生</remarks>
    Public Overridable Sub TxFullErrorListener()
    End Sub

    ''' <summary>
    ''' デバイスコントロールブロックエラー
    ''' </summary>
    ''' <remarks>ポートのデバイスコントロールブロック(DCB)で予期しないエラーが発生</remarks>
    Public Overridable Sub DCBErrorListener()
    End Sub

    ''' <summary>
    ''' 送信イベントリスナ
    ''' </summary>
    ''' <remarks>送信バッファ内の文字数が、SThresholdプロパティで指定された値よりも少なくなった場合に発生</remarks>
    Public Overridable Sub SendEventListener()
    End Sub

    ''' <summary>
    ''' 受信イベントリスナ
    ''' </summary>
    ''' <remarks>
    ''' RThresholdプロパティで指定された文字数を受信時に発生。このイベントは、Inputプロパティを
    ''' 使って受信バッファからデータを削除するまで、絶えず発生する
    ''' </remarks>
    Public Overridable Sub ReceiveEventListener()
    End Sub

    ''' <summary>
    ''' CTSイベントリスナ
    ''' </summary>
    ''' <remarks>CTSラインの状態が変化時に発生</remarks>
    Public Overridable Sub CTSEventListener()
    End Sub

    ''' <summary>
    ''' DSRイベントリスナ
    ''' </summary>
    ''' <remarks>DSRラインの状態が変化時に発生。このイベントは、DSRが１から０に変化したときにだけ発生する。</remarks>
    Public Overridable Sub DSREventListener()
    End Sub

    ''' <summary>
    ''' CDイベントリスナ
    ''' </summary>
    ''' <remarks>CDラインの状態が変化時に発生</remarks>
    Public Overridable Sub CDEventListener()
    End Sub

    ''' <summary>
    ''' リング検出イベントリスナ
    ''' </summary>
    ''' <remarks>
    ''' リングが検出された時に発生します。UART（汎用非同期送受信装置）によっては、このイベントが
    ''' サポートされない場合があります。
    ''' </remarks>
    Public Overridable Sub RingEventListener()
    End Sub

    ''' <summary>
    ''' EOF文字受信イベントリスナ
    ''' </summary>
    ''' <remarks>EOF(End Of File)文字(ASCII文字26)を受信時に発生します。</remarks>
    Public Overridable Sub EOFEventListener()
    End Sub

    ''' <summary>
    ''' COM通信エラー／通信イベント生リスナ
    ''' </summary>
    ''' <remarks></remarks>
    '2024/10 田岡
    Public Overridable Sub mMSComm_OnComm(sender As Object, e As SerialDataReceivedEventArgs) Handles mMSComm.DataReceived
        Select Case e.EventType
            Case SerialData.Chars
                '文字が受信され、入力バッファーに格納
                Me.EOFEventListener()
            Case SerialData.Eof
                'EOF文字を受信
                Me.EOFEventListener()
        End Select
    End Sub
    Public Overridable Sub mMSComm_OnComm(sender As Object, e As SerialErrorReceivedEventArgs) Handles mMSComm.ErrorReceived
        Select Case e.EventType
            Case SerialError.Frame
                'フレームエラー
                Me.FrameErrorErrorListener()
            Case SerialError.Overrun
                'ポートオーバーラン
                Me.PortOverRunErrorListener()
            Case SerialError.RXOver
                '受信バッファオーバーフロー
                Me.RxOverErrorListener()
            Case SerialError.RXParity
                'パリティエラー
                Me.RxParityErrorListener()
            Case SerialError.TXFull
                '送信バッファ
                Me.TxFullErrorListener()
        End Select
    End Sub

    Public Overridable Sub mMSComm_OnComm(sender As Object, e As SerialPinChangedEventArgs) Handles mMSComm.PinChanged
        Select Case e.EventType
            Case SerialPinChange.Break
                '中断信号を受信
                Me.BreakErrorListener()
            Case SerialPinChange.CtsChanged
                'CTSラインの状態が変化
                Me.CTSEventListener()
            Case SerialPinChange.DsrChanged
                'DSRラインの状態が変化
                Me.DSREventListener()
            Case SerialPinChange.CDChanged
                'CDラインの状態が変化
                Me.CDEventListener()
            Case SerialPinChange.Ring
                'リングが検出
                Me.RingEventListener()
        End Select
    End Sub

    Public Overridable Sub mMSComm_OnComm(sender As Object, e As SerialPort) Handles mMSComm.Disposed
        Select Case e.EventType
            Case comEventCTSTO
                'CTSタイムアウト
                Me.CTSTimeOutErrorListener()
            Case comEventDSRTO
                'DSRタイムアウト
                Me.DSRTimeOutErrorListener()
            Case comEventCDTO
                'CDタイムアウト
                Me.CDTimeOutErrorListener()
            Case comEventDCB
                'デバイスコントロールブロックエラー
                Me.DCBErrorListener()
            Case comEvSend
                '送信イベントリスナ
                Me.SendEventListener()
        End Select
    End Sub

    'Public Overridable Sub mMSComm_OnComm() Handles mMSComm.OnComm
    '    Select Case Me.mMSComm.CommEvent
    '        Case comEventBreak
    '            '中断信号を受信
    '            Me.BreakErrorListener()
    '        Case comEventCTSTO
    '            'CTSタイムアウト
    '            Me.CTSTimeOutErrorListener()
    '        Case comEventDSRTO
    '            'DSRタイムアウト
    '            Me.DSRTimeOutErrorListener()
    '        Case comEventCDTO
    '            'CDタイムアウト
    '            Me.CDTimeOutErrorListener()
    '        Case comEventFrame
    '            'フレームエラー
    '            Me.FrameErrorErrorListener()
    '        Case comEventOverrun
    '            'ポートオーバーラン
    '            Me.PortOverRunErrorListener()
    '        Case comEventRxOver
    '            '受信バッファオーバーフロー
    '            Me.RxOverErrorListener()
    '        Case comEventRxParity
    '            'パリティエラー
    '            Me.RxParityErrorListener()
    '        Case comEventTxFull
    '            '送信バッファ
    '            Me.TxFullErrorListener()
    '        Case comEventDCB
    '            'デバイスコントロールブロックエラー
    '            Me.DCBErrorListener()
    '        Case comEvSend
    '            '送信イベントリスナ
    '            Me.SendEventListener()
    '        Case comEvReceive
    '            '受信イベントリスナ
    '            Me.ReceiveEventListener()
    '        Case comEvCTS
    '            'CTSラインの状態が変化
    '            Me.CTSEventListener()
    '        Case comEvDSR
    '            'DSRラインの状態が変化
    '            Me.DSREventListener()
    '        Case comEvCD
    '            'CDラインの状態が変化
    '            Me.CDEventListener()
    '        Case comEvRing
    '            'リングが検出
    '            Me.RingEventListener()
    '        Case comEvEOF
    '            'EOF文字を受信
    '            Me.EOFEventListener()
    '    End Select
    'End Sub
    '------------------------------------------------------------------------------------
    Private Class COMERR
        Public Shared Function GetErrorComment(ByVal ErrorCode As Integer) As String
            Dim strRet As String = ""

            Select Case ErrorCode
                Case -2146820283
                    ''「COMが既にオープンされている可能性あり」----------------------------------------
                    '{"HRESULT からの例外: 0x800A1F45"}
                    '    Data: {System.Collections.ListDictionaryInternal}
                    '    ErrorCode: -2146820283
                    '    HelpLink: Nothing
                    '    InnerException: Nothing
                    '    Message: "HRESULT からの例外: 0x800A1F45"
                    '    Source: "Interop.MSCommLib"
                    '    StackTrace: "   場所 MSCommLib.MSCommClass.set_PortOpen(Boolean pfPortOpen)
                    '    TargetSite: {System.Reflection.RuntimeMethodInfo}

                    strRet = "COMが既にオープンされている可能性あり、オープンできません。"
                Case -2146820286
                    ''「接続先機器の電源が切れている可能性があります」-------------------------------------------
                    '{"HRESULT からの例外: 0x800A1F42"}
                    '    Data: {System.Collections.ListDictionaryInternal}
                    '    ErrorCode: -2146820286
                    '    HelpLink: Nothing
                    '    InnerException: Nothing
                    '    Message: "HRESULT からの例外: 0x800A1F42"
                    '    Source: "Interop.MSCommLib"
                    '    StackTrace: "   場所 MSCommLib.MSCommClass.set_PortOpen(Boolean pfPortOpen)
                    '    TargetSite: {System.Reflection.RuntimeMethodInfo}

                    strRet = "接続先機器の電源が切れている可能性があり、オープンできません。"
                Case -2146820276
                    '接続先が切れていてクローズできない()
                    '>? ex
                    '{"HRESULT からの例外: 0x800A1F4C"}
                    '    Data: {System.Collections.ListDictionaryInternal}
                    '    ErrorCode: -2146820276
                    '    HelpLink: Nothing
                    '    InnerException: Nothing
                    '    Message: "HRESULT からの例外: 0x800A1F4C"
                    '    Source: "Interop.MSCommLib"
                    '    StackTrace: "   場所 MSCommLib.MSCommClass.set_PortOpen(Boolean pfPortOpen)
                    '   場所 母材コイル管理システム.AComCtl.PortReOpen() 場所 D:\My Documents\Workspace\Order\藤田金属\母材管理システム\ブリーフケース\Apl\母材コイル管理システム\母材コイル管理システム\Class\AComCtl.vb:行 85"
                    '    TargetSite: {System.Reflection.RuntimeMethodInfo}
                    strRet = "接続先機器の電源が切れている可能性があり、クローズできません。"
            End Select

            Return strRet
        End Function
    End Class
End Class
