Public Class CDio

    ''プロパティー変数
    Private mstrデバイス名 As String
    Private msrtデバイスID As Short
    Private msbErrString As System.Text.StringBuilder
    Private mintErrNum As Integer
    Private intOld数量 As Integer


    ''' <summary>
    ''' デバイス名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pデバイス名() As String
        Get
            Return mstrデバイス名
        End Get
        Set(ByVal Value As String)
            mstrデバイス名 = Value
        End Set
    End Property
    ''' <summary>
    ''' デバイス名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pデバイスID() As Short
        Get
            Return msrtデバイスID
        End Get
        Set(ByVal Value As Short)
            msrtデバイスID = Value
        End Set
    End Property

    ''エラープロパティ
    ''' <summary>
    ''' エラー発生時のエラー番号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property pErrNum() As Integer
        Get
            Return mintErrNum
        End Get
    End Property
    ''' <summary>
    ''' エラー発生時のエラー内容
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property pErrString() As String
        Get
            Return msbErrString.ToString
        End Get
    End Property

    ''' <summary>
    ''' コンストラクタ(デバイスID,デバイス名)
    ''' </summary>
    ''' <param name="strDeiceID">デバイスID</param>
    ''' <param name="strDeviceName">デバイス名</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal strDeiceID As Short, ByVal strDeviceName As String)

        Me.msrtデバイスID = strDeiceID
        Me.mstrデバイス名 = strDeviceName

    End Sub

    ''外部関数(Function)-------------------------------------------------------------------------

    ''' <summary>
    ''' gBlnDIOオープン
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function gBlnDIOオープン() As Boolean
        Try
            Dim iRet As Integer
            Dim blnRet As Boolean = False
            Dim bye状態 As Byte
            Dim byeステータス As Byte

            'デバイスのステータスを取得
            iRet = DioGetRemoteStatus(msrtデバイスID, bye状態, byeステータス)
            If iRet <> DIO_ERR_SUCCESS Or byeステータス <> DIO_ERR_SUCCESS Then
                '一旦終了
                DioExit(msrtデバイスID)
            End If

            'デバイスオープン処理
            iRet = DioInit(mstrデバイス名, msrtデバイスID)
            If iRet = DIO_ERR_SUCCESS Then
                blnRet = True
            Else
                'エラー時処理
                Me.mintErrNum = iRet
                Call DioGetErrorString(iRet, Me.msbErrString)
            End If

            Return blnRet

        Catch ex As Exception
            Return False
        End Try

    End Function

    ''' <summary>
    ''' DIOクローズ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function gBlnDIOクローズ() As Boolean
        Try
            Dim iRet As Integer
            Dim blnRet As Boolean = False

            'デバイスクローズ処理
            iRet = DioExit(msrtデバイスID)
            If iRet = 0 Then
                blnRet = True
            Else
                'エラー時処理
                Me.mintErrNum = iRet
                Call DioGetErrorString(iRet, Me.msbErrString)
            End If

            Return blnRet

        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' ビット入力
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function gBlnビット入力(ByVal Id As Short, ByVal BitNo As Short, ByRef Data As Byte) As Boolean
        Try
            Dim iRet As Integer
            Dim blnRet As Boolean = False

            iRet = DioInpBit(Id, BitNo, Data)

            If iRet = 0 Then
                blnRet = True
            Else
                'エラー時処理
                Me.mintErrNum = iRet
                Call DioGetErrorString(iRet, Me.msbErrString)
            End If

            Return blnRet

        Catch ex As Exception
            Return False
        End Try

    End Function

    ''' <summary>
    ''' バイト入力(20130130Morimoto追加）
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function gBlnバイト入力(ByVal Id As Short, ByVal PortNo As Short, ByRef Data As Byte) As Boolean
        Try
            Dim iRet As Integer
            Dim blnRet As Boolean = False

            iRet = DioInpByte(Id, PortNo, Data)

            If iRet = 0 Then
                blnRet = True
            Else
                'エラー時処理
                Me.mintErrNum = iRet
                Call DioGetErrorString(iRet, Me.msbErrString)
            End If

            Return blnRet

        Catch ex As Exception
            Return False
        End Try

    End Function

    ''' <summary>
    ''' 7セグ出力(2桁対応)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function gBln7セグ出力(ByVal int数量 As Integer) As Boolean


        '呼び出し数量が同じ場合EXIT
        If int数量 = intOld数量 Then
            Return True
        End If
        intOld数量 = int数量

        Dim bytData_1 As Byte
        Dim bytData_10 As Byte

        '数値をByte型に変換する。
        '1の位
        Select Case int数量 Mod 10
            Case 0
                bytData_1 = &H3F
            Case 1
                bytData_1 = &H6
            Case 2
                bytData_1 = &H5B
            Case 3
                bytData_1 = &H4F
            Case 4
                bytData_1 = &H66
            Case 5
                bytData_1 = &H6D
            Case 6
                bytData_1 = &H7D
            Case 7
                bytData_1 = &H7
            Case 8
                bytData_1 = &H7F
            Case 9
                bytData_1 = &H6F
        End Select
        '1の位出力
        Dim i As Integer

        For i = 0 To 6
            Call gBlnDIO出力_ビット(i, (bytData_1 And (2 ^ i)) \ (2 ^ i))
        Next i

        '10の位
        Select Case (int数量 \ 10) Mod 10
            Case 0
                bytData_10 = &H3F
            Case 1
                bytData_10 = &H6
            Case 2
                bytData_10 = &H5B
            Case 3
                bytData_10 = &H4F
            Case 4
                bytData_10 = &H66
            Case 5
                bytData_10 = &H6D
            Case 6
                bytData_10 = &H7D
            Case 7
                bytData_10 = &H7
            Case 8
                bytData_10 = &H7F
            Case 9
                bytData_10 = &H6F
        End Select
        '1の位出力
        For i = 0 To 6
            Call gBlnDIO出力_ビット(i + 8, (bytData_10 And (2 ^ i)) \ (2 ^ i))
        Next i

    End Function

    ''' <summary>
    ''' 7セグ出力(2桁対応)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function gBln7セグ出力_クリア() As Boolean

        '1の位出力
        Dim i As Integer

        For i = 0 To 15
            Call gBlnDIO出力_ビット(i, 0)
        Next i

    End Function

    ''' <summary>
    ''' 1バイト出力処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function gBlnDIO出力_バイト(ByVal bytData As Byte) As Boolean
        Try
            Dim iRet As Integer
            Dim blnRet As Boolean = False

            '1バイト出力処理
            iRet = DioOutByte(msrtデバイスID, 0, bytData)
            If iRet = 0 Then
                blnRet = True
            Else
                'エラー時処理
                Me.mintErrNum = iRet
                Call DioGetErrorString(iRet, Me.msbErrString)
            End If

            Return blnRet

        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 1ビット出力処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function gBlnDIO出力_ビット(ByVal bytビットNo As Byte, ByVal bytData As Byte) As Boolean
        Try
            Dim iRet As Integer
            Dim blnRet As Boolean = False

            '1ビット出力処理
            iRet = DioOutBit(msrtデバイスID, bytビットNo, bytData)
            If iRet = 0 Then
                blnRet = True
            Else
                'エラー時処理
                Me.mintErrNum = iRet
                Call DioGetErrorString(iRet, Me.msbErrString)
            End If

            Return blnRet

        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
