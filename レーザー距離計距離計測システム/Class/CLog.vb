'*******************************************************************************
' @(h)  CLog.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  システムログ、オペレーションログの登録。
'*******************************************************************************
Imports System.Text
Imports System.Windows.Forms
'Imports Oracle.DataAccess.Client
Public Class CLog

    ''コンストラクタ---------------------------------------------------------------------------
#Region "コンストラクタ"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：コンストラクタ
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：ログ種別の保存
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Sub New()
    End Sub

    ''内部関数(Function)-----------------------------------------------------------------------
#Region "mStrログ内容"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：mStrログ内容
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：ログ内容の編集。
    ' 備　考　：エラーメッセージ、始まり地点と最終地点、に編集する。
    '---------------------------------------------------------------------------
#End Region
    Private Function mStrログ内容(ByVal ex As Exception) As String
        Dim strBuff() As String
        Dim str最終 As String = ""
        Dim str最初 As String = ""
        Dim strログ内容 As String = ""
        Dim i As Integer
        Dim j As Integer

        ''スタックとレースを配列へ保存
        strBuff = Split(ex.StackTrace, vbCrLf)

        ''最終エラー地点の保存
        For i = LBound(strBuff) To UBound(strBuff)
            ''改行をはずす
            strBuff(i) = strBuff(i).Replace(vbCrLf, "")
            ''登録できない文字の変換
            strBuff(i) = strBuff(i).Replace("&", "")

            ''空はふくまない
            If strBuff(i) Is Nothing Then

            ElseIf strBuff(i).Trim = "" Then

                ''プロジェクトの名前空間のスタックトレースのみ
            ElseIf InStr(strBuff(i), Application.ProductName & ".") = 0 Then

            Else
                str最終 = strBuff(i).Trim
                Exit For
            End If
        Next

        ''最初のエラー地点の保存
        For j = UBound(strBuff) To i Step -1
            ''改行をはずす
            strBuff(j) = strBuff(j).Replace(vbCrLf, "")
            ''登録できない文字の変換
            strBuff(j) = strBuff(j).Replace("&", "")

            ''空はふくまない
            If strBuff(j) Is Nothing Then

            ElseIf strBuff(j).Trim = "" Then

                ''プロジェクトの名前空間のスタックトレースのみ
            ElseIf InStr(strBuff(j), Application.ProductName & ".") = 0 Then

            Else
                If j <> i Then
                    str最初 = strBuff(j).Trim
                End If
                Exit For
            End If
        Next

        ''ログ内容編集
        If str最初 <> "" Then
            'Chr(10)で改行
            strログ内容 = ex.Message.Replace(Chr(10), "").Trim & Chr(10) & str最終 & Chr(10) & str最初
        Else
            strログ内容 = ex.Message.Replace(Chr(10), "") & Chr(10) & str最終
        End If

        ''改行変換
        strログ内容 = strログ内容.Replace(vbCrLf, "")

        ''シングル変換
        strログ内容 = strログ内容.Replace("'", "''")

        Return strログ内容
    End Function

    ''外部関数(Sub)----------------------------------------------------------------------------
#Region "エラー発生じのエラー表示とログ登録"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubErr
    ' 戻り値　：
    ' 引　数　：exception
    ' 機能説明：エラー発生じのエラー表示とログ登録
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubErr(ByVal ex As Exception, ByVal Method_Name As String)
        Dim strMsg As String

        strMsg = ex.ToString
        ''ログ登録
        Call Me.gSubシステムログ登録(Method_Name & " " & Me.mStrログ内容(ex), True)

        Call MessageBox.Show(strMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Sub

    ''ログ登録------------------------------------------------------------------------------------------
    'Public Sub gSub操作ログ登録(ByVal strログ内容 As String, ByVal blnTrans As Boolean)
    '    Try
    '        If MFile.gStrParameterStr("操作ログ", "1") = MConst.STRFLGOFF Then
    '            Exit Sub
    '        End If

    '        Dim claSQL As New CSql
    '        With claSQL
    '            .gSubClearSQL()
    '            .pSQLTYPE = CSql.SQL_TYPE.SQL_INSERT
    '            .pStrTable = "DC操作ログ管理"
    '            .gSubColumnValue("ログID", "SQ操作ログ登録順.NEXTVAL", False)
    '            .gSubColumnValue("発生端末", MMain.gstrID, True)
    '            .gSubColumnValue("ログ内容", strログ内容, True)
    '            If MMain.gstr加工NO.Trim <> "" Then
    '                .gSubColumnValue("加工NO", MMain.gstr加工NO, True)
    '            End If
    '            If MMain.gstr子番.Trim <> "" Then
    '                .gSubColumnValue("子番", MMain.gstr子番, True)
    '            End If
    '            If MMain.gstrセットNO.Trim <> "" Then
    '                .gSubColumnValue("セットNO", MMain.gstrセットNO, True)
    '            End If
    '            If MMain.gstrカットNO.Trim <> "" Then
    '                .gSubColumnValue("カットNO", MMain.gstrカットNO, True)
    '            End If
    '            .gSubColumnValue("ログ種別", "0", True) 'アプリ=0 PKG=1 
    '            Call MMain.gclaODP.gBlnExeCute(Me.GetType().Name & ".vb:" & System.Reflection.MethodBase.GetCurrentMethod.Name,.gStrSQL, blnTrans)
    '        End With
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Public Sub gSubシステムログ登録(ByVal strログ内容 As String, ByVal blnTrans As Boolean)
        Try
            If MFile.gStrParameterStr("システムログ", "1") = MConst.STRFLGOFF Then
                Exit Sub
            End If

            Dim claSQL As New CSql
            With claSQL
                .gSubClearSQL()
                .pSQLTYPE = CSql.SQL_TYPE.SQL_INSERT
                .pStrTable = "DCシステムログ管理"
                .gSubColumnValue("ログID", "SQシステムログ登録順.NEXTVAL", False)
                .gSubColumnValue("発生端末", MMain.gstrID, True)

                ''改行あれば変換
                strログ内容 = strログ内容.Replace(vbCrLf, Chr(10))

                ''シングルあれば変換
                strログ内容 = strログ内容.Replace("'", "''")

                ''最大ログ内容を超えるとき
                If System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(strログ内容) > 3800 Then
                    .gSubColumnValue("ログ内容", "SUBSTRB('" & strログ内容 & "',1,3800)", False, 0, False)
                Else
                    .gSubColumnValue("ログ内容", strログ内容, True)
                End If

                If MMain.gstr加工NO.Trim <> "" Then
                    .gSubColumnValue("加工NO", MMain.gstr加工NO, True)
                End If
                If MMain.gstr子番.Trim <> "" Then
                    .gSubColumnValue("子番", MMain.gstr子番, True)
                End If
                If MMain.gstrセットNO.Trim <> "" Then
                    .gSubColumnValue("セットNO", MMain.gstrセットNO, True)
                End If
                If MMain.gstrカットNO.Trim <> "" Then
                    .gSubColumnValue("カットNO", MMain.gstrカットNO, True)
                End If
                .gSubColumnValue("ログ種別", "0", True) 'アプリ=0 PKG=1 
                Call MMain.gclaODP.gBlnExeCute(Me.GetType().Name & ".vb:" & System.Reflection.MethodBase.GetCurrentMethod.Name, .gStrSQL, blnTrans)
            End With
        Catch ex As Exception
            Try
                Dim claSQL As New CSql
                With claSQL
                    .gSubClearSQL()
                    .pSQLTYPE = CSql.SQL_TYPE.SQL_INSERT
                    .pStrTable = "DCシステムログ管理"
                    .gSubColumnValue("ログID", "SQシステムログ登録順.NEXTVAL", False)
                    .gSubColumnValue("発生端末", MMain.gstrID, True)

                    .gSubColumnValue("ログ内容", "err", True)

                    If MMain.gstr加工NO.Trim <> "" Then
                        .gSubColumnValue("加工NO", MMain.gstr加工NO, True)
                    End If
                    If MMain.gstr子番.Trim <> "" Then
                        .gSubColumnValue("子番", MMain.gstr子番, True)
                    End If
                    If MMain.gstrセットNO.Trim <> "" Then
                        .gSubColumnValue("セットNO", MMain.gstrセットNO, True)
                    End If
                    If MMain.gstrカットNO.Trim <> "" Then
                        .gSubColumnValue("カットNO", MMain.gstrカットNO, True)
                    End If
                    .gSubColumnValue("ログ種別", "0", True) 'アプリ=0 PKG=1 
                    Call MMain.gclaODP.gBlnExeCute(Me.GetType().Name & ".vb:" & System.Reflection.MethodBase.GetCurrentMethod.Name, .gStrSQL, blnTrans)
                End With

            Catch ex2 As Exception

            End Try
        End Try
    End Sub

End Class
